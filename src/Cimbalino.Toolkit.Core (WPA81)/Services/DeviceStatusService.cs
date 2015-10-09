// ****************************************************************************
// <copyright file="DeviceStatusService.cs" company="Pedro Lamas">
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

#if WINDOWS_PHONE_APP
using System;
using Cimbalino.Toolkit.Helpers;
using Windows.Devices.Input;
using Windows.Phone.Devices.Power;
using Windows.Phone.System.Power;
using Windows.Security.ExchangeActiveSyncProvisioning;
using Windows.System;
#elif WINDOWS_APP
using System;
using Cimbalino.Toolkit.Helpers;
using Windows.Devices.Input;
using Windows.Security.ExchangeActiveSyncProvisioning;
#else
using System;
using Cimbalino.Toolkit.Helpers;
using Windows.Devices.Input;
using Windows.Devices.Power;
using Windows.Security.ExchangeActiveSyncProvisioning;
using Windows.System;
using Windows.System.Power;
#endif

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

#if WINDOWS_PHONE_APP
            Battery.GetDefault().RemainingChargePercentChanged += OnPowerChanged;
            PowerManager.PowerSavingModeChanged += OnPowerChanged;
#elif WINDOWS_UWP
            Battery.AggregateBattery.ReportUpdated += OnPowerChanged;
            PowerManager.EnergySaverStatusChanged += OnPowerChanged;
#endif
        }

#if WINDOWS_APP
        /// <summary>
        /// Occurs when the power status has changed
        /// </summary>
        public event EventHandler<PowerStatusChangedEventArgs> PowerStatusChanged
        {
            add
            {
                ExceptionHelper.ThrowNotSupported();
            }
            remove
            {
            }
        }
#else
        /// <summary>
        /// Occurs when the power status has changed
        /// </summary>
        public event EventHandler<PowerStatusChangedEventArgs> PowerStatusChanged;
#endif

        /// <summary>
        /// Gets the memory usage of the current application in bytes.
        /// </summary>
        /// <value>The memory usage of the current application in bytes.</value>
        public virtual long ApplicationCurrentMemoryUsage
        {
            get
            {
#if WINDOWS_PHONE_APP || WINDOWS_UWP
                if (!ApiHelper.SupportsMemoryManager)
                {
                    return -1;
                }

                return (long)MemoryManager.AppMemoryUsage;
#else
                return ExceptionHelper.ThrowNotSupported<long>();
#endif
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
#if WINDOWS_PHONE_APP || WINDOWS_UWP
                if (!ApiHelper.SupportsMemoryManager)
                {
                    return -1;
                }

                return (long)MemoryManager.AppMemoryUsageLimit;
#else
                return ExceptionHelper.ThrowNotSupported<long>();
#endif
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
#if WINDOWS_PHONE_APP || WINDOWS_UWP
                return _easClientDeviceInformation.SystemFirmwareVersion;
#else
                return ExceptionHelper.ThrowNotSupported<string>();
#endif
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
#if WINDOWS_PHONE_APP || WINDOWS_UWP
                return _easClientDeviceInformation.SystemHardwareVersion;
#else
                return ExceptionHelper.ThrowNotSupported<string>();
#endif
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
#if WINDOWS_PHONE_APP || WINDOWS_UWP
                return _easClientDeviceInformation.SystemManufacturer;
#else
                return string.Empty;
#endif
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
#if WINDOWS_PHONE_APP || WINDOWS_UWP
                return _easClientDeviceInformation.SystemProductName;
#else
                return string.Empty;
#endif
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
#if WINDOWS_UWP
                
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
#else
                return ExceptionHelper.ThrowNotSupported<DeviceStatusServicePowerSource>();
#endif
            }
        }

        /// <summary>
        /// Gets the a value indicating the percent of the battery remaining on the device
        /// </summary>
        /// <value>null if the platform can't report this, otherwise, the battery percentage</value>
        public virtual int? RemainingChargePercent
        {
            get
            {
#if WINDOWS_PHONE_APP
                return Battery.GetDefault().RemainingChargePercent;
#elif WINDOWS_UWP
                var report = Battery.AggregateBattery.GetReport();
                if (report.FullChargeCapacityInMilliwattHours.HasValue && report.RemainingCapacityInMilliwattHours.HasValue)
                {
                    return (report.RemainingCapacityInMilliwattHours.Value / report.FullChargeCapacityInMilliwattHours.Value) * 100;
                }

                return null;
#else
                return ExceptionHelper.ThrowNotSupported<int?>();
#endif
            }
        }

        /// <summary>
        /// Gets the value indicating if the device is in power saver mode.
        /// </summary>
        /// <value>
        /// Null if the platform can't report this, otherwise [true] if in power saver mode
        /// </value>
        public virtual bool? IsInPowerSaverMode
        {
            get
            {
#if WINDOWS_PHONE_APP
                return PowerManager.PowerSavingMode == PowerSavingMode.On;
#elif WINDOWS_UWP
                return PowerManager.EnergySaverStatus == EnergySaverStatus.On;
#else
                return null;
#endif
            }
        }

#if WINDOWS_PHONE_APP || WINDOWS_UWP
        private void OnPowerChanged(object sender, object o)
        {
            var eventHandler = PowerStatusChanged;
            var args = new PowerStatusChangedEventArgs(RemainingChargePercent, IsInPowerSaverMode);

            eventHandler?.Invoke(this, args);
        }
#endif
    }
}