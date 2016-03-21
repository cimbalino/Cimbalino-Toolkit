// ****************************************************************************
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
using Cimbalino.Toolkit.Helpers;
#elif WINDOWS_PHONE_81 || WINDOWS_PHONE_APP
using Windows.Storage;
#elif WINDOWS_UWP
using Windows.Storage;
#else
using Cimbalino.Toolkit.Helpers;
using Windows.Storage;
#endif

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IApplicationSettingsService"/>.
    /// </summary>
    public class ApplicationSettingsService : IApplicationSettingsService
    {
#if !WINDOWS_PHONE
        private static readonly IApplicationSettingsServiceHandler LocalSettingsServiceHandlerStatic, RoamingSettingsServiceHandlerStatic;
#endif

#if !WINDOWS_APP
        private static readonly IApplicationSettingsServiceHandler LegacySettingsServiceHandlerStatic;
#endif

        static ApplicationSettingsService()
        {
#if !WINDOWS_PHONE
            var applicationData = ApplicationData.Current;

            LocalSettingsServiceHandlerStatic = new ApplicationSettingsServiceHandler(applicationData.LocalSettings);
            RoamingSettingsServiceHandlerStatic = new ApplicationSettingsServiceHandler(applicationData.RoamingSettings);
#endif

#if !WINDOWS_APP
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
#if WINDOWS_PHONE
                return ExceptionHelper.ThrowNotSupported<IApplicationSettingsServiceHandler>();
#else
                return LocalSettingsServiceHandlerStatic;
#endif
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
                return ExceptionHelper.ThrowNotSupported<IApplicationSettingsServiceHandler>();
#else
                return RoamingSettingsServiceHandlerStatic;
#endif
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
#if !WINDOWS_APP
                return LegacySettingsServiceHandlerStatic;
#else
                return ExceptionHelper.ThrowNotSupported<IApplicationSettingsServiceHandler>();
#endif
            }
        }
    }
}