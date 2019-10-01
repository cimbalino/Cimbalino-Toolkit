// ****************************************************************************
// <copyright file="LocationServicePositionChangedEventArgs.cs" company="Pedro Lamas">
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
    /// Provides data for <see cref="ILocationService.PositionChanged"/> events.
    /// </summary>
    public class LocationServicePositionChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the <see cref="LocationServicePosition"/> object containing the location and time stamp data for the <see cref="ILocationService.PositionChanged"/> event.
        /// </summary>
        /// <value>The <see cref="LocationServicePosition"/>.</value>
        public LocationServicePosition Position { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationServicePositionChangedEventArgs"/> class.
        /// </summary>
        /// <param name="position">A <see cref="LocationServicePosition"/> object containing the location and time stamp data for the event.</param>
        public LocationServicePositionChangedEventArgs(LocationServicePosition position)
        {
            Position = position;
        }
    }
}