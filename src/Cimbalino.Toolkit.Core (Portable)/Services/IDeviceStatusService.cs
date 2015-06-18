// ****************************************************************************
// <copyright file="IDeviceStatusService.cs" company="Pedro Lamas">
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
    /// Represents a service capable of obtaining information about the device on which it is running.
    /// </summary>
    public interface IDeviceStatusService
    {
        event EventHandler<BatteryStatusChangedEventArgs> BatteryStatusChanged;
         
        /// <summary>
        /// Gets the memory usage of the current application in bytes.
        /// </summary>
        /// <value>The memory usage of the current application in bytes.</value>
        long ApplicationCurrentMemoryUsage { get; }

        /// <summary>
        /// Gets the maximum amount of memory that your application process can allocate.
        /// </summary>
        /// <value>The maximum amount of memory that your application process can allocate.</value>
        long ApplicationMemoryUsageLimit { get; }

        /// <summary>
        /// Gets the peak memory usage of the current application in bytes.
        /// </summary>
        /// <value>The peak memory usage of the current application in bytes.</value>
        long ApplicationPeakMemoryUsage { get; }

        /// <summary>
        /// Gets the firmware version running on the device.
        /// </summary>
        /// <value>The firmware version running on the device.</value>
        string DeviceFirmwareVersion { get; }

        /// <summary>
        /// Gets the hardware version running on the device.
        /// </summary>
        /// <value>The hardware version running on the device.</value>
        string DeviceHardwareVersion { get; }

        /// <summary>
        /// Gets the device manufacturer name.
        /// </summary>
        /// <value>The device manufacturer name.</value>
        string DeviceManufacturer { get; }

        /// <summary>
        /// Gets the device name.
        /// </summary>
        /// <value>The device name.</value>
        string DeviceName { get; }

        /// <summary>
        /// Gets the physical RAM size of the device in bytes.
        /// </summary>
        /// <value>The physical RAM size of the device in bytes.</value>
        long DeviceTotalMemory { get; }

        /// <summary>
        /// Gets a value indicating whether the device is a low memory device (less than 256 MB of memory installed).
        /// </summary>
        /// <value>true if the device is a low memory device (less than 256 MB of memory installed); otherwise, false.</value>
        bool IsLowMemoryDevice { get; }

        /// <summary>
        /// Gets a value indicating whether the user has deployed the physical hardware keyboard of the device.
        /// </summary>
        /// <value>true if the keyboard is deployed; otherwise, false.</value>
        bool IsKeyboardDeployed { get; }

        /// <summary>
        /// Gets a value indicating whether the device contains a physical hardware keyboard.
        /// </summary>
        /// <value>true if the device contains a physical hardware keyboard; otherwise, false.</value>
        bool IsKeyboardPresent { get; }

        /// <summary>
        /// Gets the a value indicating whether the device is currently running on battery power or is plugged in to an external power supply.
        /// </summary>
        /// <value>true if the device is currently running on battery power or is plugged in to an external power supply; otherwise, false.</value>
        DeviceStatusServicePowerSource PowerSource { get; }

        /// <summary>
        /// Gets the a value indicating the percent of the battery remaining on the device
        /// </summary>
        /// <value>null if the platform can't report this, otherwise, the battery percentage</value>
        int? RemainingChargePercent { get; }
    }
}