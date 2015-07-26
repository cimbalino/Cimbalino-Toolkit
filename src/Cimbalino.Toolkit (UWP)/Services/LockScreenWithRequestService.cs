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
#if WINDOWS_PHONE
using System;
using System.Threading.Tasks;
using Windows.Phone.System.UserProfile;
using Cimbalino.Toolkit.Core.Services;
#else
using Windows.ApplicationModel.Background;
using System;
using System.Threading.Tasks;
using Cimbalino.Toolkit.Core.Services;
using Cimbalino.Toolkit.Helpers;

#endif

namespace Cimbalino.Toolkit.Services
{
    public class LockScreenWithRequestService : LockScreenService
    {
        public override Task<LockScreenServiceRequestResult> RequestAccessAsync()
        {
#if WINDOWS_PHONE_APP
            return ExceptionHelper.ThrowNotSupported<Task<LockScreenServiceRequestResult>>();
#else
            return Request();
#endif
        }

#if WINDOWS_PHONE
        private static async Task<LockScreenServiceRequestResult> Request()
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
        private static async Task<LockScreenServiceRequestResult> Request()
        {
            var status = await BackgroundExecutionManager.RequestAccessAsync();
            switch (status)
            {
                case BackgroundAccessStatus.AllowedMayUseActiveRealTimeConnectivity:
                case BackgroundAccessStatus.AllowedWithAlwaysOnRealTimeConnectivity:
                    return LockScreenServiceRequestResult.Granted;
                default:
                    return LockScreenServiceRequestResult.Denied;
            }
        }
#endif
    }
}
