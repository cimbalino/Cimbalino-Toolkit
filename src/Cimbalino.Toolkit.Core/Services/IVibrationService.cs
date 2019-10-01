// ****************************************************************************
// <copyright file="IVibrationService.cs" company="Pedro Lamas">
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

using System;

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of using device vibration capabilities.
    /// </summary>
    public interface IVibrationService
    {
        /// <summary>
        /// Vibrates the device for 200 milliseconds.
        /// </summary>
        void Vibrate();

        /// <summary>
        /// Vibrates the device for the specified duration (from 0 to 5000 milliseconds).
        /// </summary>
        /// <param name="duration">The duration (from 0 to 5000 milliseconds) for which the device vibrates.</param>
        void Vibrate(double duration);

        /// <summary>
        /// Vibrates the device for the specified duration (from 0 to 5000 milliseconds).
        /// </summary>
        /// <param name="duration">The duration (from 0 to 5000 milliseconds) for which the device vibrates.</param>
        void Vibrate(TimeSpan duration);

        /// <summary>
        /// Stops the vibration of the device.
        /// </summary>
        void Cancel();
    }
}