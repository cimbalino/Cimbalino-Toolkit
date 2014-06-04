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
    public class DeviceSettingsService : IDeviceSettingsService
    {
        public async Task ShowAirplaneModeSettingsAsync()
        {
            await LaunchUrlAsync("ms-settings-airplanemode:");
        }

        public async Task ShowBluetoothSettingsAsync()
        {
            await LaunchUrlAsync("ms-settings-bluetooth:");
        }

        public async Task ShowCellularSettingsAsync()
        {
            await LaunchUrlAsync("ms-settings-cellular:");
        }

        public async Task ShowEmailAndAccountsSettingsAsync()
        {
            await LaunchUrlAsync("ms-settings-emailandaccounts:");
        }

        public async Task ShowLocationSettingsAsync()
        {
            await LaunchUrlAsync("ms-settings-location:");
        }

        public async Task ShowLockSettingsAsync()
        {
            await LaunchUrlAsync("ms-settings-lock:");
        }

        public async Task ShowPowerSettingsAsync()
        {
            await LaunchUrlAsync("ms-settings-power:");
        }

        public async Task ShowScreenRotationSettingsAsync()
        {
            await LaunchUrlAsync("ms-settings-screenrotation:");
        }

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