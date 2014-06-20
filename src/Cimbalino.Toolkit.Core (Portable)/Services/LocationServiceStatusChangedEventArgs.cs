// ****************************************************************************
// <copyright file="LocationServiceStatusChangedEventArgs.cs" company="Pedro Lamas">
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
    /// Provides information for the <see cref="ILocationService.StatusChanged"/> event.
    /// </summary>
    public class LocationServiceStatusChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the updated status of the <see cref="ILocationService"/> object.
        /// </summary>
        /// <value>The updated status of the <see cref="ILocationService"/> object.</value>
        public LocationServiceStatus Status { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationServiceStatusChangedEventArgs"/> class.
        /// </summary>
        /// <param name="status">The updated status of the <see cref="ILocationService"/> object.</param>
        public LocationServiceStatusChangedEventArgs(LocationServiceStatus status)
        {
            Status = status;
        }
    }
}