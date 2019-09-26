// ****************************************************************************
// <copyright file="StoreService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2014
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <project>Cimbalino.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.Threading.Tasks;
using Windows.System;

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IStoreService"/>.
    /// </summary>
    public class StoreService : IStoreService
    {
        /// <summary>
        /// Shows the Store application.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task ShowAsync()
        {
            var storeUrl = "ms-windows-store:";

            return Launcher.LaunchUriAsync(new Uri(storeUrl, UriKind.Absolute)).AsTask();
        }

        /// <summary>
        /// Shows the Store application.
        /// </summary>
        /// <param name="publisherName">The publisher display name.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task ShowPublisherAsync(string publisherName)
        {
            var storeUrl = "ms-windows-store:Publisher?name=" + Uri.EscapeDataString(publisherName);

            return Launcher.LaunchUriAsync(new Uri(storeUrl, UriKind.Absolute)).AsTask();
        }

        /// <summary>
        /// Shows the Store application, optionally filtering results by keyword, publisher, and content type.
        /// </summary>
        /// <param name="keywords">The keywords to search for.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task SearchAsync(string keywords)
        {
            var storeUrl = "ms-windows-store:Search?query=" + Uri.EscapeDataString(keywords);

            return Launcher.LaunchUriAsync(new Uri(storeUrl, UriKind.Absolute)).AsTask();
        }

        /// <summary>
        /// Shows the Store application.
        /// </summary>
        /// <param name="applicationId">The application id.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task ReviewAsync(string applicationId)
        {
            var storeUrl = "ms-windows-store:Review?PFN=" + Uri.EscapeDataString(applicationId);

            return Launcher.LaunchUriAsync(new Uri(storeUrl, UriKind.Absolute)).AsTask();
        }
    }
}