// ****************************************************************************
// <copyright file="StorageServiceStorageType.cs" company="Pedro Lamas">
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
    /// Describes the storage type.
    /// </summary>
    public enum StorageServiceStorageType
    {
        /// <summary>
        /// Local storage.
        /// </summary>
        Local,

        /// <summary>
        /// Roaming storage.
        /// </summary>
        Roaming,

        /// <summary>
        /// Local cache storage.
        /// </summary>
        LocalCache,

        /// <summary>
        /// Temporary storage.
        /// </summary>
        Temporary,

        /// <summary>
        /// Package storage.
        /// </summary>
        Package
    }
}