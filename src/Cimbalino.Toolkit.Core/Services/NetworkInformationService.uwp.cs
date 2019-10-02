// ****************************************************************************
// <copyright file="NetworkInformationService.uwp.cs" company="Pedro Lamas">
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
using Windows.Networking.Connectivity;

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="INetworkInformationService"/>.
    /// </summary>
    public class NetworkInformationService : INetworkInformationService
    {
        /// <summary>
        /// Occurs when the network status changes for a connection.
        /// </summary>
        public event EventHandler NetworkStatusChanged;

        /// <summary>
        /// Initializes a new instance of the <see cref="NetworkInformationService"/> class.
        /// </summary>
        public NetworkInformationService()
        {
            NetworkInformation.NetworkStatusChanged += (sender) =>
            {
                RaiseNetworkStatusChanged(null);
            };
        }

        /// <summary>
        /// Gets a value indicating whether the network is available.
        /// </summary>
        /// <value>true if the network is available; otherwise, false.</value>
        public virtual bool IsNetworkAvailable
        {
            get
            {
                return NetworkInformation.GetInternetConnectionProfile() != null;
            }
        }

        /// <summary>
        /// Raises the <see cref="NetworkStatusChanged"/> event with the provided event data.
        /// </summary>
        /// <param name="eventArgs">The event data.</param>
        protected virtual void RaiseNetworkStatusChanged(EventArgs eventArgs)
        {
            var eventHandler = NetworkStatusChanged;

            if (eventHandler != null)
            {
                eventHandler(this, eventArgs);
            }
        }
    }
}