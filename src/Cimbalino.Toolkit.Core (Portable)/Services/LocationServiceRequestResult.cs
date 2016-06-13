// ****************************************************************************
// <copyright file="LocationServiceRequestResult.cs" company="Pedro Lamas">
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
    /// Indicates if your app has permission to access location data.
    /// </summary>
    public enum LocationServiceRequestResult
    {
        /// <summary>
        /// Permission to access location was denied.
        /// </summary>
        Denied,

        /// <summary>
        /// Permission to access location was granted.
        /// </summary>
        Allowed
    }
}