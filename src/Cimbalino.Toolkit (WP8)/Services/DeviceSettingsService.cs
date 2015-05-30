// ****************************************************************************
// <copyright file="DeviceSettingsService.cs" company="Pedro Lamas">
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

#if WINDOWS_PHONE || WINDOWS_PHONE_APP
using System;
using System.Threading.Tasks;
using Windows.System;
#else
using System;
using System.Threading.Tasks;
using Cimbalino.Toolkit.Helpers;

#endif

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IDeviceSettingsService"/>.
    /// </summary>
    public class DeviceSettingsService : IDeviceSettingsService
    {
        /// <summary>
        /// Shows the Airplane Mode settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task ShowAirplaneModeSettingsAsync()
        {
            return LaunchUrlAsync("ms-settings-airplanemode:");
        }

        /// <summary>
        /// Shows the Bluetooth settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task ShowBluetoothSettingsAsync()
        {
            return LaunchUrlAsync("ms-settings-bluetooth:");
        }

        /// <summary>
        /// Shows the Photos+Camera settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task ShowCameraSettingsAsync()
        {
            return LaunchUrlAsync("ms-settings-camera:");
        }

        /// <summary>
        /// Shows the Cellular settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task ShowCellularSettingsAsync()
        {
            return LaunchUrlAsync("ms-settings-cellular:");
        }

        /// <summary>
        /// Shows the Email and Accounts settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task ShowEmailAndAccountsSettingsAsync()
        {
            return LaunchUrlAsync("ms-settings-emailandaccounts:");
        }

        /// <summary>
        /// Shows the Location settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task ShowLocationSettingsAsync()
        {
            return LaunchUrlAsync("ms-settings-location:");
        }

        /// <summary>
        /// Shows the Lock Screen settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task ShowLockScreenSettingsAsync()
        {
            return LaunchUrlAsync("ms-settings-lock:");
        }

        /// <summary>
        /// Shows the Notifications+Actions settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task ShowNotificationSettingsAsync()
        {
            return LaunchUrlAsync("ms-settings-notifications:");
        }

        /// <summary>
        /// Shows the Power settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task ShowPowerSettingsAsync()
        {
            return LaunchUrlAsync("ms-settings-power:");
        }

        /// <summary>
        /// Shows the NFC settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task ShowProximitySettingsAsync()
        {
            return LaunchUrlAsync("ms-settings-proximity:");
        }

        /// <summary>
        /// Shows the Screen Rotation settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task ShowScreenRotationSettingsAsync()
        {
            return LaunchUrlAsync("ms-settings-screenrotation:");
        }

        /// <summary>
        /// Shows the Wi-Fi settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task ShowWiFiSettingsAsync()
        {
            return LaunchUrlAsync("ms-settings-wifi:");
        }

        /// <summary>
        /// Shows the Workplace settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task ShowWorkplaceSettingsAsync()
        {
            return LaunchUrlAsync("ms-settings-workplace:");
        }

#if WINDOWS_PHONE || WINDOWS_PHONE_APP
        private async Task LaunchUrlAsync(string url)
        {
            await Launcher.LaunchUriAsync(new Uri(url, UriKind.Absolute));
        }
#else
        private Task LaunchUrlAsync(string url)
        {
            return ExceptionHelper.ThrowNotSupported<Task>();
        }
#endif
    }
}