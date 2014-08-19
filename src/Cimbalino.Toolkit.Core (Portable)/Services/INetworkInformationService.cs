// ****************************************************************************
// <copyright file="INetworkInformationService.cs" company="Pedro Lamas">
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

using System;

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of providing network information for a specific device.
    /// </summary>
    public interface INetworkInformationService
    {
        /// <summary>
        /// Occurs when the network status changes for a connection.
        /// </summary>
        event EventHandler NetworkStatusChanged;

        /// <summary>
        /// Gets a value indicating whether the network is available.
        /// </summary>
        /// <value>true if the network is available; otherwise, false.</value>
        bool IsNetworkAvailable { get; }
    }
}