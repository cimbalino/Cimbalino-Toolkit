// ****************************************************************************
// <copyright file="IRuntimeInformationService.cs" company="Pedro Lamas">
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
    /// Represents a service capable of providing runtime information for a specific device.
    /// </summary>
    public interface IRuntimeInformationService
    {
        /// <summary>
        /// Gets the device runtime profile.
        /// </summary>
        /// <value>The device runtime profile.</value>
        RuntimeInformationServiceProfile Profile { get; }

        /// <summary>
        /// Gets the device runtime version.
        /// </summary>
        /// <value>The device runtime version.</value>
        Version Version { get; }
    }
}