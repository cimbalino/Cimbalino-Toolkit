// ****************************************************************************
// <copyright file="LocationServiceStatus.cs" company="Pedro Lamas">
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

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Indicates the ability of the <see cref="ILocationService"/> to provide location data.
    /// </summary>
    public enum LocationServiceStatus
    {
        /// <summary>
        /// Location data is available.
        /// </summary>
        Ready = 0,
        
        /// <summary>
        /// The location provider is initializing. This is the status if a GPS is the source of location data and the GPS receiver does not yet have the required number of satellites in view to obtain an accurate position.
        /// </summary>
        Initializing = 1,
        
        /// <summary>
        /// No location data is available from any location provider.
        /// </summary>
        NoData = 2,

        /// <summary>
        /// The location provider is disabled. This status indicates that the user has not granted the application permission to access location.
        /// </summary>
        Disabled = 3,
        
        /// <summary>
        /// An operation to retrieve location has not yet been initialized.
        /// </summary>
        NotInitialized = 4,
        
        /// <summary>
        /// The Windows Sensor and Location Platform is not available on this version of Windows.
        /// </summary>
        NotAvailable = 5,
    }
}