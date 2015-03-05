﻿// ****************************************************************************
// <copyright file="ApplicationSettingsService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2014
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <project>Cimbalino.Toolkit.Core</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

#if WINDOWS_PHONE
using System;
using System.Windows;
using Windows.Storage;
#elif WINDOWS_PHONE_APP
using System;
using Windows.Storage;
#else
using System;
using Windows.Storage;
#endif

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IApplicationSettingsService"/>.
    /// </summary>
    public class ApplicationSettingsService : IApplicationSettingsService
    {
        private static bool SupportsLocalSettings = true;
        private static readonly IApplicationSettingsServiceHandler LocalSettingsServiceHandlerStatic, RoamingSettingsServiceHandlerStatic;
#if WINDOWS_PHONE || WINDOWS_PHONE_APP
        private const string AppManifestName = "AppxManifest.xml";
        private static readonly IApplicationSettingsServiceHandler LegacySettingsServiceHandlerStatic;
#endif

        static ApplicationSettingsService()
        {
#if WINDOWS_PHONE
            var appManifestResourceInfo = Application.GetResourceStream(new Uri(AppManifestName, UriKind.Relative));
            SupportsLocalSettings = appManifestResourceInfo != null;
#endif
            var applicationData = ApplicationData.Current;

            if (SupportsLocalSettings)
            {
                LocalSettingsServiceHandlerStatic = new ApplicationSettingsServiceHandler(applicationData.LocalSettings);
            }

#if WINDOWS_PHONE
            if (Version.Parse(Deployment.Current.RuntimeVersion).Major >= 6)
            {
                RoamingSettingsServiceHandlerStatic = new ApplicationSettingsServiceHandler(applicationData.RoamingSettings);
            }
#else
            RoamingSettingsServiceHandlerStatic = new ApplicationSettingsServiceHandler(applicationData.RoamingSettings);
#endif

#if WINDOWS_PHONE || WINDOWS_PHONE_APP
            LegacySettingsServiceHandlerStatic = new LegacyApplicationSettingsServiceHandler();
#endif
        }

        /// <summary>
        /// Gets the local settings handler instance for the app.
        /// </summary>
        /// <value>The local settings handler instance for the app.</value>
        public virtual IApplicationSettingsServiceHandler Local
        {
            get
            {
                if (!SupportsLocalSettings)
                {
                    throw new NotSupportedException();
                }

                return LocalSettingsServiceHandlerStatic;
            }
        }

        /// <summary>
        /// Gets the roaming settings handler instance for the app.
        /// </summary>
        /// <value>The roaming settings handler instance for the app.</value>
        public virtual IApplicationSettingsServiceHandler Roaming
        {
            get
            {
#if WINDOWS_PHONE
                if (RoamingSettingsServiceHandlerStatic == null)
                {
                    throw new NotSupportedException();
                }
#endif

                return RoamingSettingsServiceHandlerStatic;
            }
        }

        /// <summary>
        /// Gets the legacy settings handler instance for the app.
        /// </summary>
        /// <value>The legacy settings handler instance for the app.</value>
        public virtual IApplicationSettingsServiceHandler Legacy
        {
            get
            {
#if WINDOWS_PHONE || WINDOWS_PHONE_APP
                return LegacySettingsServiceHandlerStatic;
#else
                throw new NotSupportedException();
#endif
            }
        }
    }
}