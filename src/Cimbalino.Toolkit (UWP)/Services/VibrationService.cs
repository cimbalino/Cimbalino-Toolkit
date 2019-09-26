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

using System;
using Windows.Phone.Devices.Notification;

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
        public virtual void Vibrate()
        {
            Vibrate(200);
        }

        /// <summary>
        /// Vibrates the device for the specified duration (from 0 to 5000 milliseconds).
        /// </summary>
        /// <param name="duration">The duration (from 0 to 5000 milliseconds) for which the device vibrates.</param>
        public virtual void Vibrate(double duration)
        {
            Vibrate(TimeSpan.FromMilliseconds(duration));
        }

        /// <summary>
        /// Vibrates the device for the specified duration (from 0 to 5000 milliseconds).
        /// </summary>
        /// <param name="duration">The duration (from 0 to 5000 milliseconds) for which the device vibrates.</param>
        public virtual void Vibrate(TimeSpan duration)
        {
            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.Devices.Notification.VibrationDevice"))
            {
                VibrationDevice.GetDefault().Vibrate(duration);
            }
        }

        /// <summary>
        /// Stops the vibration of the device.
        /// </summary>
        public virtual void Cancel()
        {
            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.Devices.Notification.VibrationDevice"))
            {
                VibrationDevice.GetDefault().Cancel();
            }
        }
    }
}