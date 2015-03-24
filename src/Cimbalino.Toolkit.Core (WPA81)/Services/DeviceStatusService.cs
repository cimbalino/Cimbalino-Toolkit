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
using Cimbalino.Toolkit.Core.Helpers;
using System;
using Windows.Devices.Input;
using Windows.Security.ExchangeActiveSyncProvisioning;
using Windows.System;
#elif WINDOWS_APP
using System;
using Windows.Devices.Input;
using Windows.Security.ExchangeActiveSyncProvisioning;
#else
using Cimbalino.Toolkit.Core.Helpers;
using System;
using Windows.Devices.Input;
using Windows.Security.ExchangeActiveSyncProvisioning;
using Windows.System;
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
        }

        /// <summary>
        /// Gets the memory usage of the current application in bytes.
        /// </summary>
        /// <value>The memory usage of the current application in bytes.</value>
        public virtual long ApplicationCurrentMemoryUsage
        {
            get
            {
#if WINDOWS_PHONE_APP || WINDOWS_UAP
                if (!ApiHelper.SupportsMemoryManager)
                {
                    return -1;
                }

                return (long)MemoryManager.AppMemoryUsage;
#else
                throw new NotSupportedException();
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
#if WINDOWS_PHONE_APP || WINDOWS_UAP
                if (!ApiHelper.SupportsMemoryManager)
                {
                    return -1;
                }

                return (long)MemoryManager.AppMemoryUsageLimit;
#else
                throw new NotSupportedException();
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
                throw new NotSupportedException();
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
#if WINDOWS_PHONE_APP || WINDOWS_UAP
                return _easClientDeviceInformation.SystemFirmwareVersion;
#else
                throw new NotSupportedException();
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
#if WINDOWS_PHONE_APP || WINDOWS_UAP
                return _easClientDeviceInformation.SystemHardwareVersion;
#else
                throw new NotSupportedException();
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
#if WINDOWS_PHONE_APP || WINDOWS_UAP
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
#if WINDOWS_PHONE_APP || WINDOWS_UAP
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
                throw new NotSupportedException();
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
                throw new NotSupportedException();
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
                throw new NotSupportedException();
            }
        }
    }
}