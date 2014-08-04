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

using Windows.Storage;

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IStorageService"/>.
    /// </summary>
    public class StorageService : IStorageService
    {
        private static readonly IStorageServiceHandler LocalStorageServiceHandler, RoamingStorageServiceHandler, TemporaryStorageServiceHandler;

        static StorageService()
        {
            var applicationData = ApplicationData.Current;

            if (applicationData.LocalFolder != null)
            {
                LocalStorageServiceHandler = new StorageServiceHandler(applicationData.LocalFolder);
            }

            if (applicationData.RoamingFolder != null)
            {
                RoamingStorageServiceHandler = new StorageServiceHandler(applicationData.RoamingFolder);
            }

            if (applicationData.TemporaryFolder != null)
            {
                TemporaryStorageServiceHandler = new StorageServiceHandler(applicationData.TemporaryFolder);
            }
        }

        /// <summary>
        /// Gets the local storage controller instance.
        /// </summary>
        /// <value>The local storage controller instance.</value>
        public IStorageServiceHandler Local
        {
            get
            {
                return LocalStorageServiceHandler;
            }
        }

        /// <summary>
        /// Gets the roaming storage controller instance.
        /// </summary>
        /// <value>The roaming storage controller instance.</value>
        public IStorageServiceHandler Roaming
        {
            get
            {
                return RoamingStorageServiceHandler;
            }
        }

        /// <summary>
        /// Gets the temporary storage controller instance.
        /// </summary>
        /// <value>The temporary storage controller instance.</value>
        public IStorageServiceHandler Temporary
        {
            get
            {
                return TemporaryStorageServiceHandler;
            }
        }
    }
}