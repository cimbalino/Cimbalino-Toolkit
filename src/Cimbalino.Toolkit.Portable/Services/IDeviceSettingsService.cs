// ****************************************************************************
// <copyright file="IDeviceSettingsService.cs" company="Pedro Lamas">
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

using System.Threading.Tasks;

namespace Cimbalino.Toolkit.Services
{
    public interface IDeviceSettingsService
    {
        Task ShowAirplaneModeSettingsAsync();
        
        Task ShowBluetoothSettingsAsync();

        Task ShowCellularSettingsAsync();

        Task ShowEmailAndAccountsSettingsAsync();

        Task ShowLocationSettingsAsync();
        
        Task ShowLockSettingsAsync();
        
        Task ShowPowerSettingsAsync();
        
        Task ShowScreenRotationSettingsAsync();

        Task ShowWiFiSettingsAsync();
    }
}