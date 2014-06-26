// ****************************************************************************
// <copyright file="VibrationService.cs" company="Pedro Lamas">
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
using Microsoft.Devices;
#elif WINDOWS_PHONE_APP
using System;
using Windows.Phone.Devices.Notification;
#else
using System;
#endif

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IVibrationService"/>.
    /// </summary>
    public class VibrationService : IVibrationService
    {
        /// <summary>
        /// Vibrates the device for 200 milliseconds.
        /// </summary>
        public void Vibrate()
        {
            Vibrate(200);
        }

        /// <summary>
        /// Vibrates the device for the specified duration (from 0 to 5000 milliseconds).
        /// </summary>
        /// <param name="duration">The duration (from 0 to 5000 milliseconds) for which the device vibrates.</param>
        public void Vibrate(double duration)
        {
            Vibrate(TimeSpan.FromMilliseconds(duration));
        }

        /// <summary>
        /// Vibrates the device for the specified duration (from 0 to 5000 milliseconds).
        /// </summary>
        /// <param name="duration">The duration (from 0 to 5000 milliseconds) for which the device vibrates.</param>
        public void Vibrate(TimeSpan duration)
        {
#if WINDOWS_PHONE
            VibrateController.Default.Start(duration);
#elif WINDOWS_PHONE_APP
            VibrationDevice.GetDefault().Vibrate(duration);
#else
            throw new NotSupportedException();
#endif
        }

        /// <summary>
        /// Stops the vibration of the device.
        /// </summary>
        public void Cancel()
        {
#if WINDOWS_PHONE
            VibrateController.Default.Stop();
#elif WINDOWS_PHONE_APP
            VibrationDevice.GetDefault().Cancel();
#else
            throw new NotSupportedException();
#endif
        }
    }
}