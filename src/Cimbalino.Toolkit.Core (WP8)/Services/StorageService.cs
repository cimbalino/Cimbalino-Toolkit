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

#if WINDOWS_PHONE
using Cimbalino.Toolkit.Helpers;
using Windows.Storage;
#elif WINDOWS_PHONE_81 || WINDOWS_PHONE_APP
using System.Reflection;
using Cimbalino.Toolkit.Helpers;
using Windows.Storage;
#else
using Cimbalino.Toolkit.Helpers;
using Windows.Storage;
#endif

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IStorageService"/>.
    /// </summary>
    public class StorageService : IStorageService
    {
        internal static readonly IStorageServiceHandler LocalStorageServiceHandlerStatic, PackageStorageServiceHandlerStatic;

#if !WINDOWS_PHONE
        internal static readonly IStorageServiceHandler RoamingStorageServiceHandlerStatic, TemporaryStorageServiceHandlerStatic;
#endif

#if WINDOWS_PHONE_81 || WINDOWS_PHONE_APP
        internal static readonly IStorageServiceHandler LocalCacheStorageServiceHandlerStatic;
#endif

        static StorageService()
        {
            var applicationData = ApplicationData.Current;

            LocalStorageServiceHandlerStatic = new StorageServiceHandler(applicationData.LocalFolder, StorageServiceStorageType.Local);
            PackageStorageServiceHandlerStatic = new StorageServiceHandler(Windows.ApplicationModel.Package.Current.InstalledLocation, StorageServiceStorageType.Package);

#if !WINDOWS_PHONE
            RoamingStorageServiceHandlerStatic = new StorageServiceHandler(applicationData.RoamingFolder, StorageServiceStorageType.Roaming);
            TemporaryStorageServiceHandlerStatic = new StorageServiceHandler(applicationData.TemporaryFolder, StorageServiceStorageType.Temporary);
#endif

#if WINDOWS_PHONE_81 || WINDOWS_PHONE_APP
            var localCacheFolderPropertyInfo = applicationData.GetType().GetRuntimeProperty("LocalCacheFolder");

            if (localCacheFolderPropertyInfo != null)
            {
                LocalCacheStorageServiceHandlerStatic = new StorageServiceHandler((StorageFolder)localCacheFolderPropertyInfo.GetValue(applicationData), StorageServiceStorageType.LocalCache);
            }
#endif
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
#if WINDOWS_PHONE
                return ExceptionHelper.ThrowNotSupported<IStorageServiceHandler>();
#else
                return RoamingStorageServiceHandlerStatic;
#endif
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
#if WINDOWS_PHONE
                return ExceptionHelper.ThrowNotSupported<IStorageServiceHandler>();
#else
                return TemporaryStorageServiceHandlerStatic;
#endif
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
#if WINDOWS_PHONE_81 || WINDOWS_PHONE_APP
                if (LocalCacheStorageServiceHandlerStatic == null)
                {
                    return ExceptionHelper.ThrowNotSupported<IStorageServiceHandler>();
                }

                return LocalCacheStorageServiceHandlerStatic;
#else
                return ExceptionHelper.ThrowNotSupported<IStorageServiceHandler>();
#endif
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