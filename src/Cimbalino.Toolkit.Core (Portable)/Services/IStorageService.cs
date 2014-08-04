// ****************************************************************************
// <copyright file="IStorageService.cs" company="Pedro Lamas">
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
    /// Represents a service capable of handling the application storage asynchronously.
    /// </summary>
    public interface IStorageService
    {
        /// <summary>
        /// Gets the local storage controller instance.
        /// </summary>
        /// <value>The local storage controller instance.</value>
        IStorageServiceHandler Local { get; }

        /// <summary>
        /// Gets the roaming storage controller instance.
        /// </summary>
        /// <value>The roaming storage controller instance.</value>
        IStorageServiceHandler Roaming { get; }

        /// <summary>
        /// Gets the temporary storage controller instance.
        /// </summary>
        /// <value>The temporary storage controller instance.</value>
        IStorageServiceHandler Temporary { get; }
    }
}