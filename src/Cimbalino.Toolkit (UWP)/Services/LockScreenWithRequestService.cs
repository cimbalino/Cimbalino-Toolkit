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

using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;

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
        public override async Task<LockScreenServiceRequestResult> RequestAccessAsync()
        {
            var status = await BackgroundExecutionManager.RequestAccessAsync();

            switch (status)
            {
#pragma warning disable 618
                case BackgroundAccessStatus.AllowedMayUseActiveRealTimeConnectivity:
                case BackgroundAccessStatus.AllowedWithAlwaysOnRealTimeConnectivity:
#pragma warning restore 618
                case BackgroundAccessStatus.AlwaysAllowed:
                case BackgroundAccessStatus.AllowedSubjectToSystemPolicy:
                    return LockScreenServiceRequestResult.Granted;

#pragma warning disable 618
                case BackgroundAccessStatus.Denied:
#pragma warning restore 618
                case BackgroundAccessStatus.DeniedByUser:
                case BackgroundAccessStatus.DeniedBySystemPolicy:
                case BackgroundAccessStatus.Unspecified:
                    return LockScreenServiceRequestResult.Denied;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}