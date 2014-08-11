// ****************************************************************************
// <copyright file="SettingsService.cs" company="Pedro Lamas">
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
using Windows.Storage;
#else
using System;
using Windows.Storage;
#endif

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="ISettingsService"/>.
    /// </summary>
    public class SettingsService : ISettingsService
    {
        private static readonly ISettingsServiceHandler LocalSettingsServiceHandlerStatic, RoamingSettingsServiceHandlerStatic;
#if WINDOWS_PHONE || WINDOWS_PHONE_APP
        private static readonly ISettingsServiceHandler LegacySettingsServiceHandlerStatic;
#endif

        static SettingsService()
        {
            var applicationData = ApplicationData.Current;

            LocalSettingsServiceHandlerStatic = new SettingsServiceHandler(applicationData.LocalSettings);

#if WINDOWS_PHONE
            if (Version.Parse(Deployment.Current.RuntimeVersion).Major >= 6)
            {
                RoamingSettingsServiceHandlerStatic = new SettingsServiceHandler(applicationData.RoamingSettings);
            }
#else
            RoamingSettingsServiceHandlerStatic = new SettingsServiceHandler(applicationData.RoamingSettings);
#endif

#if WINDOWS_PHONE || WINDOWS_PHONE_APP
            LegacySettingsServiceHandlerStatic = new LegacySettingsServiceHandler();
#endif
        }

        /// <summary>
        /// Gets the local settings handler instance for the app.
        /// </summary>
        /// <value>The local settings handler instance for the app.</value>
        public ISettingsServiceHandler Local
        {
            get
            {
                return LocalSettingsServiceHandlerStatic;
            }
        }

        /// <summary>
        /// Gets the roaming settings handler instance for the app.
        /// </summary>
        /// <value>The roaming settings handler instance for the app.</value>
        public ISettingsServiceHandler Roaming
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
        public ISettingsServiceHandler Legacy
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