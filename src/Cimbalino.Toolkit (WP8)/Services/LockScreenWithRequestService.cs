// ****************************************************************************
// <copyright file="LockScreenWithRequestService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2014
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <project>Cimbalino.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

#if WINDOWS_PHONE || WINDOWS_PHONE_81
using System;
using System.Threading.Tasks;
using Windows.Phone.System.UserProfile;
#elif WINDOWS_PHONE_APP
using System.Threading.Tasks;
using Cimbalino.Toolkit.Helpers;
#else
using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
#endif

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="ILockScreenService"/>.
    /// </summary>
    public class LockScreenWithRequestService : LockScreenService
    {
        /// <summary>
        /// Sets the current app as the lock screen background image provider.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
#if WINDOWS_PHONE_APP
        public override Task<LockScreenServiceRequestResult> RequestAccessAsync()
        {
            return ExceptionHelper.ThrowNotSupported<Task<LockScreenServiceRequestResult>>();
        }
#elif WINDOWS_PHONE || WINDOWS_PHONE_81
        public override async Task<LockScreenServiceRequestResult> RequestAccessAsync()
        {
            var result = await LockScreenManager.RequestAccessAsync();

            switch (result)
            {
                case LockScreenRequestResult.Denied:
                    return LockScreenServiceRequestResult.Denied;

                case LockScreenRequestResult.Granted:
                    return LockScreenServiceRequestResult.Granted;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
#else
        public override async Task<LockScreenServiceRequestResult> RequestAccessAsync()
        {
            var status = await BackgroundExecutionManager.RequestAccessAsync();

            switch (status)
            {
                case BackgroundAccessStatus.AllowedMayUseActiveRealTimeConnectivity:
                case BackgroundAccessStatus.AllowedWithAlwaysOnRealTimeConnectivity:
                    return LockScreenServiceRequestResult.Granted;

                case BackgroundAccessStatus.Denied:
                case BackgroundAccessStatus.Unspecified:
                    return LockScreenServiceRequestResult.Denied;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
#endif
    }
}