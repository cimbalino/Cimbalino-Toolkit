// ****************************************************************************
// <copyright file="DeviceStatusWithKeyboardService.cs" company="Pedro Lamas">
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

using Microsoft.Phone.Info;

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IDeviceStatusService"/>.
    /// </summary>
    public class DeviceStatusWithKeyboardService : DeviceStatusService
    {
        /// <summary>
        /// Gets a value indicating whether the user has deployed the physical hardware keyboard of the device.
        /// </summary>
        /// <value>true if the keyboard is deployed; otherwise, false.</value>
        public override bool IsKeyboardDeployed
        {
            get
            {
                return DeviceStatus.IsKeyboardDeployed;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the device contains a physical hardware keyboard.
        /// </summary>
        /// <value>true if the device contains a physical hardware keyboard; otherwise, false.</value>
        public override bool IsKeyboardPresent
        {
            get
            {
                return DeviceStatus.IsKeyboardPresent;
            }
        }
    }
}