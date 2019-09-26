// ****************************************************************************
// <copyright file="StorageService.cs" company="Pedro Lamas">
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

using Cimbalino.Toolkit.Helpers;
using Windows.Storage;

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IStorageService"/>.
    /// </summary>
    public class StorageService : IStorageService
    {
        internal static readonly IStorageServiceHandler LocalStorageServiceHandlerStatic, PackageStorageServiceHandlerStatic;
        internal static readonly IStorageServiceHandler RoamingStorageServiceHandlerStatic, TemporaryStorageServiceHandlerStatic;

        static StorageService()
        {
            var applicationData = ApplicationData.Current;

            LocalStorageServiceHandlerStatic = new StorageServiceHandler(applicationData.LocalFolder, StorageServiceStorageType.Local);
            PackageStorageServiceHandlerStatic = new StorageServiceHandler(Windows.ApplicationModel.Package.Current.InstalledLocation, StorageServiceStorageType.Package);

            RoamingStorageServiceHandlerStatic = new StorageServiceHandler(applicationData.RoamingFolder, StorageServiceStorageType.Roaming);
            TemporaryStorageServiceHandlerStatic = new StorageServiceHandler(applicationData.TemporaryFolder, StorageServiceStorageType.Temporary);
        }

        /// <summary>
        /// Gets the storage handler instance for the root folder in the local app data store.
        /// </summary>
        /// <value>The storage handler instance for the root folder in the local app data store.</value>
        public virtual IStorageServiceHandler Local
        {
            get
            {
                return LocalStorageServiceHandlerStatic;
            }
        }

        /// <summary>
        /// Gets the storage handler instance for the root folder in the roaming app data store.
        /// </summary>
        /// <value>The storage handler instance for the root folder in the roaming app data store.</value>
        public virtual IStorageServiceHandler Roaming
        {
            get
            {
                return RoamingStorageServiceHandlerStatic;
            }
        }

        /// <summary>
        /// Gets the storage handler instance for the root folder in the temporary app data store.
        /// </summary>
        /// <value>The storage handler instance for the root folder in the temporary app data store.</value>
        public virtual IStorageServiceHandler Temporary
        {
            get
            {
                return TemporaryStorageServiceHandlerStatic;
            }
        }

        /// <summary>
        /// Gets the storage handler instance for the root folder in the local app data store where you can save files that are not included in backup and restore.
        /// </summary>
        /// <value>The storage handler instance for the root folder in the local app data store where you can save files that are not included in backup and restore.</value>
        public virtual IStorageServiceHandler LocalCache
        {
            get
            {
                return ExceptionHelper.ThrowNotSupported<IStorageServiceHandler>();
            }
        }

        /// <summary>
        /// Gets the storage handler instance for the root folder in the package installation data store.
        /// </summary>
        /// <value>The storage handler instance for the root folder in the package installation data store.</value>
        public virtual IStorageServiceHandler Package
        {
            get
            {
                return PackageStorageServiceHandlerStatic;
            }
        }
    }
}