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
        public async Task ShowAirplaneModeSettingsAsync()
        {
            await LaunchUrlAsync("ms-settings-airplanemode:");
        }

        /// <summary>
        /// Shows the Bluetooth settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public async Task ShowBluetoothSettingsAsync()
        {
            await LaunchUrlAsync("ms-settings-bluetooth:");
        }

        /// <summary>
        /// Shows the Cellular settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public async Task ShowCellularSettingsAsync()
        {
            await LaunchUrlAsync("ms-settings-cellular:");
        }

        /// <summary>
        /// Shows the Email and Accounts settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public async Task ShowEmailAndAccountsSettingsAsync()
        {
            await LaunchUrlAsync("ms-settings-emailandaccounts:");
        }

        /// <summary>
        /// Shows the Location settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public async Task ShowLocationSettingsAsync()
        {
            await LaunchUrlAsync("ms-settings-location:");
        }

        /// <summary>
        /// Shows the Lock Screen settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public async Task ShowLockScreenSettingsAsync()
        {
            await LaunchUrlAsync("ms-settings-lock:");
        }

        /// <summary>
        /// Shows the Power settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public async Task ShowPowerSettingsAsync()
        {
            await LaunchUrlAsync("ms-settings-power:");
        }

        /// <summary>
        /// Shows the Screen Rotation settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public async Task ShowScreenRotationSettingsAsync()
        {
            await LaunchUrlAsync("ms-settings-screenrotation:");
        }

        /// <summary>
        /// Shows the Wi-Fi settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public async Task ShowWiFiSettingsAsync()
        {
            await LaunchUrlAsync("ms-settings-wifi:");
        }

        private async Task LaunchUrlAsync(string url)
        {
#if WINDOWS_PHONE || WINDOWS_PHONE_APP
            await Launcher.LaunchUriAsync(new Uri(url, UriKind.Absolute));
#else
            throw new NotSupportedException();
#endif
        }
    }
}