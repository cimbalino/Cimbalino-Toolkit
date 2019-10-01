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
        /// Gets the storage handler instance for the root folder in the local app data store.
        /// </summary>
        /// <value>The storage handler instance for the root folder in the local app data store.</value>
        IStorageServiceHandler Local { get; }

        /// <summary>
        /// Gets the storage handler instance for the root folder in the roaming app data store.
        /// </summary>
        /// <value>The storage handler instance for the root folder in the roaming app data store.</value>
        IStorageServiceHandler Roaming { get; }

        /// <summary>
        /// Gets the storage handler instance for the root folder in the temporary app data store.
        /// </summary>
        /// <value>The storage handler instance for the root folder in the temporary app data store.</value>
        IStorageServiceHandler Temporary { get; }

        /// <summary>
        /// Gets the storage handler instance for the root folder in the local app data store where you can save files that are not included in backup and restore.
        /// </summary>
        /// <value>The storage handler instance for the root folder in the local app data store where you can save files that are not included in backup and restore.</value>
        IStorageServiceHandler LocalCache { get; }

        /// <summary>
        /// Gets the storage handler instance for the root folder in the package installation data store.
        /// </summary>
        /// <value>The storage handler instance for the root folder in the package installation data store.</value>
        IStorageServiceHandler Package { get; }
    }
}