// ****************************************************************************
// <copyright file="DeviceStatusService.uwp.cs" company="Pedro Lamas">
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
using Cimbalino.Toolkit.Helpers;
using Windows.Devices.Input;
using Windows.Devices.Power;
using Windows.Security.ExchangeActiveSyncProvisioning;
using Windows.System;
using Windows.System.Power;

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IDeviceStatusService"/>.
    /// </summary>
    public class DeviceStatusService : IDeviceStatusService
    {
        private readonly EasClientDeviceInformation _easClientDeviceInformation;
        private readonly KeyboardCapabilities _keyboardCapabilities;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceStatusService"/> class.
        /// </summary>
        public DeviceStatusService()
        {
            _easClientDeviceInformation = new EasClientDeviceInformation();
            _keyboardCapabilities = new KeyboardCapabilities();

            Battery.AggregateBattery.ReportUpdated += OnPowerChanged;
            PowerManager.EnergySaverStatusChanged += OnPowerChanged;
        }

        /// <summary>
        /// Occurs when the power status has changed
        /// </summary>
        public event EventHandler<PowerStatusChangedEventArgs> PowerStatusChanged;

        /// <summary>
        /// Gets the memory usage of the current application in bytes.
        /// </summary>
        /// <value>The memory usage of the current application in bytes.</value>
        public virtual long ApplicationCurrentMemoryUsage
        {
            get
            {
                return (long)MemoryManager.AppMemoryUsage;
            }
        }

        /// <summary>
        /// Gets the maximum amount of memory that your application process can allocate.
        /// </summary>
        /// <value>
        /// The maximum amount of memory that your application process can allocate.
        /// </value>
        public virtual long ApplicationMemoryUsageLimit
        {
            get
            {
                return (long)MemoryManager.AppMemoryUsageLimit;
            }
        }

        /// <summary>
        /// Gets the peak memory usage of the current application in bytes.
        /// </summary>
        /// <value>The peak memory usage of the current application in bytes.</value>
        public virtual long ApplicationPeakMemoryUsage
        {
            get
            {
                return ExceptionHelper.ThrowNotSupported<long>();
            }
        }

        /// <summary>
        /// Gets the firmware version running on the device.
        /// </summary>
        /// <value>The firmware version running on the device.</value>
        public virtual string DeviceFirmwareVersion
        {
            get
            {
                return _easClientDeviceInformation.SystemFirmwareVersion;
            }
        }

        /// <summary>
        /// Gets the hardware version running on the device.
        /// </summary>
        /// <value>The hardware version running on the device.</value>
        public virtual string DeviceHardwareVersion
        {
            get
            {
                return _easClientDeviceInformation.SystemHardwareVersion;
            }
        }

        /// <summary>
        /// Gets the device manufacturer name.
        /// </summary>
        /// <value>The device manufacturer name.</value>
        public virtual string DeviceManufacturer
        {
            get
            {
                return _easClientDeviceInformation.SystemManufacturer;
            }
        }

        /// <summary>
        /// Gets the device name.
        /// </summary>
        /// <value>The device name.</value>
        public virtual string DeviceName
        {
            get
            {
                return _easClientDeviceInformation.SystemProductName;
            }
        }

        /// <summary>
        /// Gets the physical RAM size of the device in bytes.
        /// </summary>
        /// <value>The physical RAM size of the device in bytes.</value>
        public virtual long DeviceTotalMemory
        {
            get
            {
                return ExceptionHelper.ThrowNotSupported<long>();
            }
        }

        /// <summary>
        /// Gets a value indicating whether the device is a low memory device (less than 256 MB of memory installed).
        /// </summary>
        /// <value>
        /// true if the device is a low memory device (less than 256 MB of memory installed); otherwise, false.
        /// </value>
        public virtual bool IsLowMemoryDevice
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the user has deployed the physical hardware keyboard of the device.
        /// </summary>
        /// <value>true if the keyboard is deployed; otherwise, false.</value>
        public virtual bool IsKeyboardDeployed
        {
            get
            {
                return ExceptionHelper.ThrowNotSupported<bool>();
            }
        }

        /// <summary>
        /// Gets a value indicating whether the device contains a physical hardware keyboard.
        /// </summary>
        /// <value>
        /// true if the device contains a physical hardware keyboard; otherwise, false.
        /// </value>
        public virtual bool IsKeyboardPresent
        {
            get
            {
                return _keyboardCapabilities.KeyboardPresent != 0;
            }
        }

        /// <summary>
        /// Gets the a value indicating whether the device is currently running on battery power or is plugged in to an external power supply.
        /// </summary>
        /// <value>
        /// true if the device is currently running on battery power or is plugged in to an external power supply; otherwise, false.
        /// </value>
        public virtual DeviceStatusServicePowerSource PowerSource
        {
            get
            {
                var status = PowerManager.BatteryStatus;
                switch (status)
                {
                    case BatteryStatus.Idle:
                    case BatteryStatus.Discharging:
                        return DeviceStatusServicePowerSource.Battery;
                    case BatteryStatus.Charging:
                        return DeviceStatusServicePowerSource.External;
                    default:
                        return ExceptionHelper.ThrowNotSupported<DeviceStatusServicePowerSource>();
                }
            }
        }

        /// <summary>
        /// Gets the a value indicating the percent of the battery remaining on the device.
        /// </summary>
        /// <value>null if the platform can't report this, otherwise, the battery percentage.</value>
        public virtual int? RemainingChargePercent
        {
            get
            {
                var report = Battery.AggregateBattery.GetReport();
                if (report.FullChargeCapacityInMilliwattHours.HasValue && report.RemainingCapacityInMilliwattHours.HasValue)
                {
                    return (report.RemainingCapacityInMilliwattHours.Value / report.FullChargeCapacityInMilliwattHours.Value) * 100;
                }

                return null;
            }
        }

        /// <summary>
        /// Gets the value indicating if the device is in power saver mode.
        /// </summary>
        /// <value>
        /// Null if the platform can't report this, otherwise [true] if in power saver mode.
        /// </value>
        public virtual bool? IsInPowerSaverMode
        {
            get
            {
                return PowerManager.EnergySaverStatus == EnergySaverStatus.On;
            }
        }

        private void OnPowerChanged(object sender, object o)
        {
            var eventHandler = PowerStatusChanged;
            var args = new PowerStatusChangedEventArgs(RemainingChargePercent, IsInPowerSaverMode);

            eventHandler?.Invoke(this, args);
        }
    }
}