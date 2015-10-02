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
        /// Shows the Storage Sense settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowStorageSenseSettingsAsync();

        /// <summary>
        /// Shows the Maps settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowMapsSettingsAsync();

        /// <summary>
        /// Shows the Data Sense settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowDataSenseSettingsAsync();

        /// <summary>
        /// Shows the Proxy settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowProxySettingsAsync();

        /// <summary>
        /// Shows the Region and Language settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowRegionAndLanguageSettingsAsync();

        /// <summary>
        /// Shows the Webcam settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowWebcamSettingsAsync();

        /// <summary>
        /// Shows the Microphone settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowMicrophoneSettingsAsync();

        /// <summary>
        /// Shows the Custom Devices settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowCustomDevicesSettingsAsync();

        /// <summary>
        /// Shows the Contact settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowContactsSettingsAsync();

        /// <summary>
        /// Shows the Calendar settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowCalendarSettingsAsync();

        /// <summary>
        /// Shows the Messaging settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowMessagingSettingsAsync();

        /// <summary>
        /// Shows the Display settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowDisplaySettingsAsync();

        /// <summary>
        /// Shows the Connected Devices settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowConnectedDevicesSettingsAsync();

        /// <summary>
        /// Shows the Mouse and Touchpad settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowMouseAndTouchpadSettingsAsync();

        /// <summary>
        /// Shows the Dial-Up settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowDialUpSettingsAsync();

        /// <summary>
        /// Shows the Ethernet settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowEthernetSettingsAsync();

        /// <summary>
        /// Shows the Mobile Hotspot settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowMobileHotspotSettingsAsync();

        /// <summary>
        /// Shows the Personalization settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowPersonalizationSettingsAsync();

        /// <summary>
        /// Shows the Date and Time settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowDateAndTimeSettingsAsync();

        /// <summary>
        /// Shows the Speech settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowSpeechSettingsAsync();

        /// <summary>
        /// Shows the Radios settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowRadiosSettingsAsync();

        /// <summary>
        /// Shows the Speech Privacy settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowSpeechPrivacySettingsAsync();

        /// <summary>
        /// Shows the Windows Update settings dialog.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowWindowsUpdateSettingsAsync();
    }
}