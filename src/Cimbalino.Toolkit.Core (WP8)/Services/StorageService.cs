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
using System;
using System.Reflection;
using System.Windows;
using Windows.Storage;
#elif WINDOWS_PHONE_APP
using System;
using System.Reflection;
using Windows.Storage;
#else
using System;
using Windows.Storage;
#endif

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IStorageService"/>.
    /// </summary>
    public class StorageService : IStorageService
    {
        private static readonly IStorageServiceHandler LocalStorageServiceHandlerStatic, RoamingStorageServiceHandlerStatic, TemporaryStorageServiceHandlerStatic;
#if WINDOWS_PHONE || WINDOWS_PHONE_APP
        private static readonly IStorageServiceHandler LocalCacheStorageServiceHandlerStatic;
#endif

        static StorageService()
        {
            var applicationData = ApplicationData.Current;

            LocalStorageServiceHandlerStatic = new StorageServiceHandler(applicationData.LocalFolder);

#if WINDOWS_PHONE
            if (Version.Parse(Deployment.Current.RuntimeVersion).Major >= 6)
            {
                RoamingStorageServiceHandlerStatic = new StorageServiceHandler(applicationData.RoamingFolder);
                TemporaryStorageServiceHandlerStatic = new StorageServiceHandler(applicationData.TemporaryFolder);

                var localCacheFolderPropertyInfo = applicationData.GetType().GetRuntimeProperty("LocalCacheFolder");

                if (localCacheFolderPropertyInfo != null)
                {
                    LocalCacheStorageServiceHandlerStatic = new StorageServiceHandler((StorageFolder)localCacheFolderPropertyInfo.GetValue(applicationData));
                }
            }
#else
            RoamingStorageServiceHandlerStatic = new StorageServiceHandler(applicationData.RoamingFolder);
            TemporaryStorageServiceHandlerStatic = new StorageServiceHandler(applicationData.TemporaryFolder);
#endif

#if WINDOWS_PHONE_APP
            var localCacheFolderPropertyInfo = applicationData.GetType().GetRuntimeProperty("LocalCacheFolder");

            if (localCacheFolderPropertyInfo != null)
            {
                LocalCacheStorageServiceHandlerStatic = new StorageServiceHandler((StorageFolder)localCacheFolderPropertyInfo.GetValue(applicationData));
            }
#endif
        }

        /// <summary>
        /// Gets the storage handler instance for the root folder in the local app data store.
        /// </summary>
        /// <value>The storage handler instance for the root folder in the local app data store.</value>
        public IStorageServiceHandler Local
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
        public IStorageServiceHandler Roaming
        {
            get
            {
#if WINDOWS_PHONE
                if (RoamingStorageServiceHandlerStatic == null)
                {
                    throw new NotSupportedException();
                }
#endif

                return RoamingStorageServiceHandlerStatic;
            }
        }

        /// <summary>
        /// Gets the storage handler instance for the root folder in the temporary app data store.
        /// </summary>
        /// <value>The storage handler instance for the root folder in the temporary app data store.</value>
        public IStorageServiceHandler Temporary
        {
            get
            {
#if WINDOWS_PHONE
                if (TemporaryStorageServiceHandlerStatic == null)
                {
                    throw new NotSupportedException();
                }
#endif

                return TemporaryStorageServiceHandlerStatic;
            }
        }

        /// <summary>
        /// Gets the storage handler instance for the root folder in the local app data store where you can save files that are not included in backup and restore.
        /// </summary>
        /// <value>The storage handler instance for the root folder in the local app data store where you can save files that are not included in backup and restore.</value>
        public IStorageServiceHandler LocalCache
        {
            get
            {
#if WINDOWS_PHONE || WINDOWS_PHONE_APP
                if (LocalCacheStorageServiceHandlerStatic == null)
                {
                    throw new NotSupportedException();
                }

                return LocalCacheStorageServiceHandlerStatic;
#else
                throw new NotSupportedException();
#endif
            }
        }
    }
}