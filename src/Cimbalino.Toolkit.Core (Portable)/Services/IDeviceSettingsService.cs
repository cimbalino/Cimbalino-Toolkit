// ****************************************************************************
// <copyright file="IDeviceSettingsService.cs" company="Pedro Lamas">
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

using System.Threading.Tasks;

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of launching a Settings dialog that allows the user to change the device's settings dialog.
    /// </summary>
    public interface IDeviceSettingsService
    {
        /// <summary>
        /// Shows the Airplane Mode settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowAirplaneModeSettingsAsync();

        /// <summary>
        /// Shows the Bluetooth settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowBluetoothSettingsAsync();

        /// <summary>
        /// Shows the Photos+Camera settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowCameraSettingsAsync();

        /// <summary>
        /// Shows the Cellular settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowCellularSettingsAsync();

        /// <summary>
        /// Shows the Email and Accounts settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowEmailAndAccountsSettingsAsync();

        /// <summary>
        /// Shows the Location settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowLocationSettingsAsync();

        /// <summary>
        /// Shows the Lock Screen settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowLockScreenSettingsAsync();

        /// <summary>
        /// Shows the Notifications+Actions settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowNotificationSettingsAsync();

        /// <summary>
        /// Shows the Power settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowPowerSettingsAsync();
        
        /// <summary>
        /// Shows the Screen Rotation settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowScreenRotationSettingsAsync();

        /// <summary>
        /// Shows the Wi-Fi settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowWiFiSettingsAsync();

        /// <summary>
        /// Shows the Workplace settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowWorkplaceSettingsAsync();

        /// <summary>
        /// Shows the storage sense settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowStorageSenseSettingsAsync();

        /// <summary>
        /// Shows the maps settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowMapsSettingsAsync();

        /// <summary>
        /// Shows the data sense settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowDataSenseSettingsAsync();

        /// <summary>
        /// Shows the proxy settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowProxySettingsAsync();

        /// <summary>
        /// Shows the region and language settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowRegionAndLanguageSettingsAsync();

        /// <summary>
        /// Shows the webcam settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowWebcamSettingsAsync();

        /// <summary>
        /// Shows the microphone settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowMicrophoneSettingsAsync();

        /// <summary>
        /// Shows the custom devices settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowCustomDevicesSettingsAsync();

        /// <summary>
        /// Shows the Contact settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowContactsSettingsAsync();

        /// <summary>
        /// Shows the calendar settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowCalendarSettingsAsync();

        /// <summary>
        /// Shows the messaging settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowMessagingSettingsAsync();

        /// <summary>
        /// Shows the display settings
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowDisplaySettingsAsync();

        /// <summary>
        /// Shows the connected devices
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowConnectedDevicesSettingsAsync();

        /// <summary>
        /// Shows the mouse and touchpad
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowMouseAndTouchpadSettingsAsync();

        /// <summary>
        /// Shows the dial up settings
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowDialUpSettingsAsync();

        /// <summary>
        /// Shows the ethernet settings
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowEthernetSettingsAsync();

        /// <summary>
        /// Shows the mobile hotspot settings
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowMobileHotspotSettingsAsync();

        /// <summary>
        /// Shows the personalization settings
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowPersonalizationSettingsAsync();

        /// <summary>
        /// Shows the date and time settings
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowDateAndTimeSettingsAsync();

        /// <summary>
        /// Shows the speech settings
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowSpeechSettingsAsync();

        /// <summary>
        /// Shows the radios settings
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowRadiosSettingsAsync();

        /// <summary>
        /// Shows the speech privacy settings
        /// </summary>
        /// <returns></returns>
        Task ShowSpeechPrivacySettingsAsync();

        /// <summary>
        /// Shows the windows update settings
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowWindowsUpdateSettingsAsync();
    }
}