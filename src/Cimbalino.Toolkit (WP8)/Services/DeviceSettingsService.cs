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

#if WINDOWS_PHONE || WINDOWS_PHONE_APP || WINDOWS_UAP
using System;
using System.Threading.Tasks;
using Windows.System;
using Cimbalino.Toolkit.Core.Helpers;
using Cimbalino.Toolkit.Helpers;

#else
using System;
using System.Threading.Tasks;
using Cimbalino.Toolkit.Core.Helpers;
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
#if WINDOWS_UAP
            return LaunchUrlAsync("ms-settings://network/airplanemode");
#else
            return LaunchUrlAsync("ms-settings-airplanemode:");
#endif
        }

        /// <summary>
        /// Shows the Bluetooth settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task ShowBluetoothSettingsAsync()
        {
#if WINDOWS_UAP
            return LaunchUrlAsync("ms-settings://bluetooth");
#else
            return LaunchUrlAsync("ms-settings-bluetooth:");
#endif
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
#if WINDOWS_UAP
            return LaunchUrlAsync("ms-settings://network/cellular");
#else
            return LaunchUrlAsync("ms-settings-cellular:");
#endif
        }

        /// <summary>
        /// Shows the Email and Accounts settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task ShowEmailAndAccountsSettingsAsync()
        {
#if WINDOWS_UAP
            return LaunchUrlAsync("ms-settings://emailandaccounts");
#else
            return LaunchUrlAsync("ms-settings-emailandaccounts:");
#endif
        }

        /// <summary>
        /// Shows the Location settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task ShowLocationSettingsAsync()
        {
#if WINDOWS_UAP
            return LaunchUrlAsync("ms-settings://privacy/location");
#else
            return LaunchUrlAsync("ms-settings-location:");
#endif
        }

        /// <summary>
        /// Shows the Lock Screen settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task ShowLockScreenSettingsAsync()
        {
#if WINDOWS_UAP
            return LaunchUrlAsync("ms-settings://lockscreen");
#else
            return LaunchUrlAsync("ms-settings-lock:");
#endif
        }

        /// <summary>
        /// Shows the Notifications+Actions settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task ShowNotificationSettingsAsync()
        {
#if WINDOWS_UAP
            return LaunchUrlAsync("ms-settings://notifications");
#else
            return LaunchUrlAsync("ms-settings-notifications:");
#endif
        }

        /// <summary>
        /// Shows the Power settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task ShowPowerSettingsAsync()
        {
#if WINDOWS_UAP
            return LaunchUrlAsync("ms-settings://batterysaver");
#else
            return LaunchUrlAsync("ms-settings-power:");
#endif
        }

        /// <summary>
        /// Shows the NFC settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task ShowProximitySettingsAsync()
        {
            if (ApiHelper.SupportsBackButton)
            {
#if WINDOWS_UAP
                return LaunchUrlAsync("ms-settings://proximity");
#else
                return LaunchUrlAsync("ms-settings-proximity:");
#endif
            }

            return ExceptionHelper.ThrowNotSupported<Task>();
        }

        /// <summary>
        /// Shows the Screen Rotation settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task ShowScreenRotationSettingsAsync()
        {
#if WINDOWS_UAP
            return LaunchUrlAsync("ms-settings://screenrotation");
#else
            return LaunchUrlAsync("ms-settings-screenrotation:");
#endif
        }

        /// <summary>
        /// Shows the Wi-Fi settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task ShowWiFiSettingsAsync()
        {
#if WINDOWS_UAP
            return LaunchUrlAsync("ms-settings://network/wifi");
#else
            return LaunchUrlAsync("ms-settings-wifi:");
#endif
        }

        /// <summary>
        /// Shows the Workplace settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task ShowWorkplaceSettingsAsync()
        {
#if WINDOWS_UAP
            return LaunchUrlAsync("ms-settings://workplace");
#else
            return LaunchUrlAsync("ms-settings-workplace:");
#endif
        }

        /// <summary>
        /// Shows the storage sense settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowStorageSenseSettingsAsync()
        {
#if WINDOWS_UAP
            return LaunchUrlAsync("ms-settings://storagesense");
#else
            return ExceptionHelper.ThrowNotSupported<Task>();
#endif
        }

        /// <summary>
        /// Shows the maps settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowMapsSettingsAsync()
        {
#if WINDOWS_UAP
            return LaunchUrlAsync("ms-settings://maps");
#else
            return ExceptionHelper.ThrowNotSupported<Task>();
#endif
        }

        /// <summary>
        /// Shows the data sense settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowDataSenseSettingsAsync()
        {
#if WINDOWS_UAP
            return LaunchUrlAsync("ms-settings://datasense");
#else
            return ExceptionHelper.ThrowNotSupported<Task>();
#endif
        }

        /// <summary>
        /// Shows the NFC transaction settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowNfcTransactionSettingsAsync()
        {
            if (ApiHelper.SupportsBackButton)
            {
#if WINDOWS_UAP
                return LaunchUrlAsync("ms-settings://nfctransactions");
#else
                return LaunchUrlAsync("ms-settings-nfctransactions:");
#endif
            }

            return ExceptionHelper.ThrowNotSupported<Task>();
        }

        /// <summary>
        /// Shows the proxy settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowProxySettingsAsync()
        {
            if (!ApiHelper.SupportsBackButton)
            {
#if WINDOWS_UAP
                return LaunchUrlAsync("ms-settings://proxy");
#else
                return ExceptionHelper.ThrowNotSupported<Task>();
#endif
            }

            return ExceptionHelper.ThrowNotSupported<Task>();
        }

        /// <summary>
        /// Shows the region and language settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowRegionAndLanguageSettingsAsync()
        {
#if WINDOWS_UAP
            return LaunchUrlAsync("ms-settings://regionlanguage");
#else
            return ExceptionHelper.ThrowNotSupported<Task>();
#endif
        }

        /// <summary>
        /// Shows the webcam settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowWebcamSettingsAsync()
        {
#if WINDOWS_UAP
            return LaunchUrlAsync("ms-settings://privacy/webcam");
#else
            return ExceptionHelper.ThrowNotSupported<Task>();
#endif
        }

        /// <summary>
        /// Shows the microphone settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowMicrophoneSettingsAsync()
        {
#if WINDOWS_UAP
            return LaunchUrlAsync("ms-settings://privacy/microphone");
#else
            return ExceptionHelper.ThrowNotSupported<Task>();
#endif
        }

        /// <summary>
        /// Shows the custom devices settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowCustomDevicesSettingsAsync()
        {
#if WINDOWS_UAP
            return LaunchUrlAsync("ms-settings://privacy/customdevices");
#else
            return ExceptionHelper.ThrowNotSupported<Task>();
#endif
        }

        /// <summary>
        /// Shows the contacts settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowContactsSettingsAsync()
        {
#if WINDOWS_UAP
            return LaunchUrlAsync("ms-settings://privacy/contacts");
#else
            return ExceptionHelper.ThrowNotSupported<Task>();
#endif
        }

        /// <summary>
        /// Shows the calendar settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowCalendarSettingsAsync()
        {
#if WINDOWS_UAP
            return LaunchUrlAsync("ms-settings://privacy/calendar");
#else
            return ExceptionHelper.ThrowNotSupported<Task>();
#endif
        }

        /// <summary>
        /// Shows the messaging settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowMessagingSettingsAsync()
        {
#if WINDOWS_UAP
            return LaunchUrlAsync("ms-settings://privacy/messaging");
#else
            return ExceptionHelper.ThrowNotSupported<Task>();
#endif
        }

#if WINDOWS_PHONE || WINDOWS_PHONE_APP || WINDOWS_UAP
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