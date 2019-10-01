// ****************************************************************************
// <copyright file="DeviceStatusServicePowerSource.cs" company="Pedro Lamas">
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

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Indicates whether the device is currently running on battery power or is plugged in to an external power supply.
    /// </summary>
    public enum DeviceStatusServicePowerSource
    {
        /// <summary>
        /// The device is running on battery power.
        /// </summary>
        Battery,

        /// <summary>
        /// The device is plugged in to an external power source, such as being docked to a computer or connected to a power supply.
        /// </summary>
        External,
    }
}