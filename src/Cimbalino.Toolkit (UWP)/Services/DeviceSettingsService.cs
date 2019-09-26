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

using System;
using System.Threading.Tasks;
using Cimbalino.Toolkit.Helpers;
using Windows.System;
using Windows.System.Profile;

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
        public virtual Task ShowAirplaneModeSettingsAsync() => LaunchUrlAsync(IsMobile ? "ms-settings-airplanemode:" : "ms-settings:network-airplanemode");

        /// <summary>
        /// Shows the Bluetooth settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task ShowBluetoothSettingsAsync() => LaunchUrlAsync(IsMobile ? "ms-settings-bluetooth:" : "ms-settings:bluetooth");

        /// <summary>
        /// Shows the Photos+Camera settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task ShowCameraSettingsAsync() => LaunchUrlAsync("ms-settings-camera:");

        /// <summary>
        /// Shows the Cellular settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task ShowCellularSettingsAsync() => LaunchUrlAsync("ms-settings:network-cellular");

        /// <summary>
        /// Shows the Email and Accounts settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task ShowEmailAndAccountsSettingsAsync() => LaunchUrlAsync("ms-settings:emailandaccounts");

        /// <summary>
        /// Shows the Location settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task ShowLocationSettingsAsync() => LaunchUrlAsync("ms-settings://privacy/location");

        /// <summary>
        /// Shows the Lock Screen settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task ShowLockScreenSettingsAsync() => LaunchUrlAsync("ms-settings:lockscreen");

        /// <summary>
        /// Shows the Notifications+Actions settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task ShowNotificationSettingsAsync() => LaunchUrlAsync("ms-settings:notifications");

        /// <summary>
        /// Shows the Power settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task ShowPowerSettingsAsync() => LaunchUrlAsync("ms-settings:batterysaver");

        /// <summary>
        /// Shows the Screen Rotation settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task ShowScreenRotationSettingsAsync() => LaunchUrlAsync("ms-settings:screenrotation");

        /// <summary>
        /// Shows the Wi-Fi settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task ShowWiFiSettingsAsync() => LaunchUrlAsync(IsMobile ? "ms-settings-wifi:" : "ms-settings:network-wifi");

        /// <summary>
        /// Shows the Workplace settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task ShowWorkplaceSettingsAsync() => LaunchUrlAsync(IsMobile ? "ms-settings-workplace" : "ms-settings:workplace");

        /// <summary>
        /// Shows the Storage Sense settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowStorageSenseSettingsAsync() => LaunchUrlAsync("ms-settings:storagesense");

        /// <summary>
        /// Shows the Maps settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowMapsSettingsAsync() => LaunchUrlAsync("ms-settings:maps");

        /// <summary>
        /// Shows the Data Sense settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowDataSenseSettingsAsync() => LaunchUrlAsync("ms-settings:datausage");

        /// <summary>
        /// Shows the Proxy settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowProxySettingsAsync()
        {
            if (!IsMobile)
            {
                return LaunchUrlAsync("ms-settings:network-proxy");
            }

            return ExceptionHelper.ThrowNotSupported<Task>();
        }

        /// <summary>
        /// Shows the Region and Language settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowRegionAndLanguageSettingsAsync()
        {
            if (!IsMobile)
            {
                return LaunchUrlAsync("ms-settings:regionlanguage");
            }

            return ExceptionHelper.ThrowNotSupported<Task>();
        }

        /// <summary>
        /// Shows the Webcam settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowWebcamSettingsAsync() => LaunchUrlAsync("ms-settings:privacy-webcam");

        /// <summary>
        /// Shows the Microphone settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowMicrophoneSettingsAsync() => LaunchUrlAsync("ms-settings:privacy-microphone");

        /// <summary>
        /// Shows the Custom Devices settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowCustomDevicesSettingsAsync() => LaunchUrlAsync("ms-settings:privacy-customdevices");

        /// <summary>
        /// Shows the Contact settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowContactsSettingsAsync() => LaunchUrlAsync("ms-settings:privacy-contacts");

        /// <summary>
        /// Shows the Calendar settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowCalendarSettingsAsync() => LaunchUrlAsync("ms-settings:privacy-calendar");

        /// <summary>
        /// Shows the Messaging settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowMessagingSettingsAsync() => LaunchUrlAsync("ms-settings:privacy-messaging");

        /// <summary>
        /// Shows the Display settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowDisplaySettingsAsync() => LaunchUrlAsync("ms-settings:display");

        /// <summary>
        /// Shows the Connected Devices settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowConnectedDevicesSettingsAsync()
        {
            if (IsMobile)
            {
                return ExceptionHelper.ThrowNotSupported<Task>();
            }

            return LaunchUrlAsync("ms-settings:connecteddevices");
        }

        /// <summary>
        /// Shows the Mouse and Touchpad settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowMouseAndTouchpadSettingsAsync() => LaunchUrlAsync("ms-settings:mousetouchpad");

        /// <summary>
        /// Shows the Dial-Up settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowDialUpSettingsAsync()
        {
            if (IsMobile)
            {
                return ExceptionHelper.ThrowNotSupported<Task>();
            }

            return LaunchUrlAsync("ms-settings:network-dialup");
        }

        /// <summary>
        /// Shows the Ethernet settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowEthernetSettingsAsync()
        {
            if (IsMobile)
            {
                return ExceptionHelper.ThrowNotSupported<Task>();
            }

            return LaunchUrlAsync("ms-settings:network-ethernet");
        }

        /// <summary>
        /// Shows the Mobile Hotspot settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowMobileHotspotSettingsAsync() => LaunchUrlAsync(IsMobile ? "ms-settings-mobilehotspot:" : "ms-settings:network-mobilehotspot");

        /// <summary>
        /// Shows the Personalization settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowPersonalizationSettingsAsync() => LaunchUrlAsync("ms-settings:personalization");

        /// <summary>
        /// Shows the Date and Time settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowDateAndTimeSettingsAsync() => LaunchUrlAsync("ms-settings:dateandtime");

        /// <summary>
        /// Shows the Speech settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowSpeechSettingsAsync() => LaunchUrlAsync("ms-settings:speech");

        /// <summary>
        /// Shows the Radios settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowRadiosSettingsAsync() => LaunchUrlAsync("ms-settings:privacy-radios");

        /// <summary>
        /// Shows the Speech Privacy settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowSpeechPrivacySettingsAsync() => LaunchUrlAsync("ms-settings:privacy-speechtyping");

        /// <summary>
        /// Shows the Windows Update settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowWindowsUpdateSettingsAsync() => LaunchUrlAsync("ms-settings:windowsupdate");

        private Task LaunchUrlAsync(string url) => Launcher.LaunchUriAsync(new Uri(url, UriKind.Absolute)).AsTask();

        private static string _deviceFamily;

        private bool IsMobile
        {
            get
            {
                if (string.IsNullOrEmpty(_deviceFamily))
                {
                    _deviceFamily = AnalyticsInfo.VersionInfo.DeviceFamily;
                }

                return _deviceFamily == "Windows.Mobile";
            }
        }
    }
}