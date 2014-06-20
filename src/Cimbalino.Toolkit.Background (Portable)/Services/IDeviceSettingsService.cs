// ****************************************************************************
// <copyright file="IDeviceSettingsService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2014
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <project>Cimbalino.Toolkit.Background</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System.Threading.Tasks;

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of launching a Settings dialog that allows the user to change the device's settings.
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
    }
}