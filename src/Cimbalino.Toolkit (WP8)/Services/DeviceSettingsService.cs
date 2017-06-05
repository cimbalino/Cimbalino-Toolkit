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

#if WINDOWS_PHONE || WINDOWS_PHONE_81 || WINDOWS_PHONE_APP
using System;
using System.Threading.Tasks;
using Cimbalino.Toolkit.Helpers;
using Windows.System;
#elif WINDOWS_UWP
using System;
using System.Threading.Tasks;
using Cimbalino.Toolkit.Helpers;
using Windows.System;
using Windows.System.Profile;
#else
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
#if WINDOWS_UWP
            return LaunchUrlAsync(IsMobile ? "ms-settings-airplanemode:" : "ms-settings:network-airplanemode");
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
#if WINDOWS_UWP
            return LaunchUrlAsync(IsMobile ? "ms-settings-bluetooth:" : "ms-settings:bluetooth");
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
#if WINDOWS_UWP
            return LaunchUrlAsync("ms-settings:network-cellular");
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
#if WINDOWS_UWP
            return LaunchUrlAsync("ms-settings:emailandaccounts");
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
#if WINDOWS_UWP
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
#if WINDOWS_UWP
            return LaunchUrlAsync("ms-settings:lockscreen");
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
#if WINDOWS_UWP
            return LaunchUrlAsync("ms-settings:notifications");
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
#if WINDOWS_UWP
            return LaunchUrlAsync("ms-settings:batterysaver");
#else
            return LaunchUrlAsync("ms-settings-power:");
#endif
        }

        /// <summary>
        /// Shows the Screen Rotation settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task ShowScreenRotationSettingsAsync()
        {
#if WINDOWS_UWP
            return LaunchUrlAsync("ms-settings:screenrotation");
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
#if WINDOWS_UWP
            return LaunchUrlAsync(IsMobile ? "ms-settings-wifi:" : "ms-settings:network-wifi");
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
#if WINDOWS_UWP
            return LaunchUrlAsync(IsMobile ? "ms-settings-workplace" : "ms-settings:workplace");
#else
            return LaunchUrlAsync("ms-settings-workplace:");
#endif
        }

        /// <summary>
        /// Shows the Storage Sense settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowStorageSenseSettingsAsync()
        {
#if WINDOWS_UWP
            return LaunchUrlAsync("ms-settings:storagesense");
#else
            return ExceptionHelper.ThrowNotSupported<Task>();
#endif
        }

        /// <summary>
        /// Shows the Maps settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowMapsSettingsAsync()
        {
#if WINDOWS_UWP
            return LaunchUrlAsync("ms-settings:maps");
#else
            return ExceptionHelper.ThrowNotSupported<Task>();
#endif
        }

        /// <summary>
        /// Shows the Data Sense settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowDataSenseSettingsAsync()
        {
#if WINDOWS_UWP
            return LaunchUrlAsync("ms-settings:datausage");
#else
            return ExceptionHelper.ThrowNotSupported<Task>();
#endif
        }

        /// <summary>
        /// Shows the Proxy settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowProxySettingsAsync()
        {
#if WINDOWS_UWP
            if (!IsMobile)
            {
                return LaunchUrlAsync("ms-settings:network-proxy");
            }

            return ExceptionHelper.ThrowNotSupported<Task>();
#else
            return ExceptionHelper.ThrowNotSupported<Task>();
#endif
        }

        /// <summary>
        /// Shows the Region and Language settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowRegionAndLanguageSettingsAsync()
        {
#if WINDOWS_UWP
            if (!IsMobile)
            {
                return LaunchUrlAsync("ms-settings:regionlanguage");
            }

            return ExceptionHelper.ThrowNotSupported<Task>();
#else
            return ExceptionHelper.ThrowNotSupported<Task>();
#endif
        }

        /// <summary>
        /// Shows the Webcam settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowWebcamSettingsAsync()
        {
#if WINDOWS_UWP
            return LaunchUrlAsync("ms-settings:privacy-webcam");
#else
            return ExceptionHelper.ThrowNotSupported<Task>();
#endif
        }

        /// <summary>
        /// Shows the Microphone settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowMicrophoneSettingsAsync()
        {
#if WINDOWS_UWP
            return LaunchUrlAsync("ms-settings:privacy-microphone");
#else
            return ExceptionHelper.ThrowNotSupported<Task>();
#endif
        }

        /// <summary>
        /// Shows the Custom Devices settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowCustomDevicesSettingsAsync()
        {
#if WINDOWS_UWP
            return LaunchUrlAsync("ms-settings:privacy-customdevices");
#else
            return ExceptionHelper.ThrowNotSupported<Task>();
#endif
        }

        /// <summary>
        /// Shows the Contact settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowContactsSettingsAsync()
        {
#if WINDOWS_UWP
            return LaunchUrlAsync("ms-settings:privacy-contacts");
#else
            return ExceptionHelper.ThrowNotSupported<Task>();
#endif
        }

        /// <summary>
        /// Shows the Calendar settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowCalendarSettingsAsync()
        {
#if WINDOWS_UWP
            return LaunchUrlAsync("ms-settings:privacy-calendar");
#else
            return ExceptionHelper.ThrowNotSupported<Task>();
#endif
        }

        /// <summary>
        /// Shows the Messaging settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowMessagingSettingsAsync()
        {
#if WINDOWS_UWP
            return LaunchUrlAsync("ms-settings:privacy-messaging");
#else
            return ExceptionHelper.ThrowNotSupported<Task>();
#endif
        }

        /// <summary>
        /// Shows the Display settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowDisplaySettingsAsync()
        {
#if WINDOWS_UWP
            return LaunchUrlAsync("ms-settings:display");
#else
            return ExceptionHelper.ThrowNotSupported<Task>();
#endif
        }

        /// <summary>
        /// Shows the Connected Devices settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowConnectedDevicesSettingsAsync()
        {
#if WINDOWS_UWP
            if (IsMobile)
            {
                return ExceptionHelper.ThrowNotSupported<Task>();
            }

            return LaunchUrlAsync("ms-settings:connecteddevices");
#else
            return ExceptionHelper.ThrowNotSupported<Task>();
#endif
        }

        /// <summary>
        /// Shows the Mouse and Touchpad settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowMouseAndTouchpadSettingsAsync()
        {
#if WINDOWS_UWP
            return LaunchUrlAsync("ms-settings:mousetouchpad");
#else
            return ExceptionHelper.ThrowNotSupported<Task>();
#endif
        }

        /// <summary>
        /// Shows the Dial-Up settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowDialUpSettingsAsync()
        {
#if WINDOWS_UWP
            if (IsMobile)
            {
                return ExceptionHelper.ThrowNotSupported<Task>();
            }

            return LaunchUrlAsync("ms-settings:network-dialup");
#else
            return ExceptionHelper.ThrowNotSupported<Task>();
#endif
        }

        /// <summary>
        /// Shows the Ethernet settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowEthernetSettingsAsync()
        {
#if WINDOWS_UWP
            if (IsMobile)
            {
                return ExceptionHelper.ThrowNotSupported<Task>();
            }

            return LaunchUrlAsync("ms-settings:network-ethernet");
#else
            return ExceptionHelper.ThrowNotSupported<Task>();
#endif
        }

        /// <summary>
        /// Shows the Mobile Hotspot settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowMobileHotspotSettingsAsync()
        {
#if WINDOWS_UWP
            return LaunchUrlAsync(IsMobile ? "ms-settings-mobilehotspot:" : "ms-settings:network-mobilehotspot");
#else
            return ExceptionHelper.ThrowNotSupported<Task>();
#endif
        }

        /// <summary>
        /// Shows the Personalization settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowPersonalizationSettingsAsync()
        {
#if WINDOWS_UWP
            return LaunchUrlAsync("ms-settings:personalization");
#else
            return ExceptionHelper.ThrowNotSupported<Task>();
#endif
        }

        /// <summary>
        /// Shows the Date and Time settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowDateAndTimeSettingsAsync()
        {
#if WINDOWS_UWP
            return LaunchUrlAsync("ms-settings:dateandtime");
#else
            return ExceptionHelper.ThrowNotSupported<Task>();
#endif
        }

        /// <summary>
        /// Shows the Speech settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowSpeechSettingsAsync()
        {
#if WINDOWS_UWP
            return LaunchUrlAsync("ms-settings:speech");
#else
            return ExceptionHelper.ThrowNotSupported<Task>();
#endif
        }

        /// <summary>
        /// Shows the Radios settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowRadiosSettingsAsync()
        {
#if WINDOWS_UWP
            return LaunchUrlAsync("ms-settings:privacy-radios");
#else
            return ExceptionHelper.ThrowNotSupported<Task>();
#endif
        }

        /// <summary>
        /// Shows the Speech Privacy settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowSpeechPrivacySettingsAsync()
        {
#if WINDOWS_UWP
            return LaunchUrlAsync("ms-settings:privacy-speechtyping");
#else
            return ExceptionHelper.ThrowNotSupported<Task>();
#endif
        }

        /// <summary>
        /// Shows the Windows Update settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowWindowsUpdateSettingsAsync()
        {
#if WINDOWS_UWP
            return LaunchUrlAsync("ms-settings:windowsupdate");
#else
            return ExceptionHelper.ThrowNotSupported<Task>();
#endif
        }

        private Task LaunchUrlAsync(string url)
        {
#if WINDOWS_PHONE || WINDOWS_PHONE_81 || WINDOWS_PHONE_APP || WINDOWS_UWP
            return Launcher.LaunchUriAsync(new Uri(url, UriKind.Absolute)).AsTask();
#else
            return ExceptionHelper.ThrowNotSupported<Task>();
#endif
        }

#if WINDOWS_UWP
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
#endif

    }
}