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
        public virtual async Task ShowAsync()
        {
#if WINDOWS_PHONE || WINDOWS_PHONE_APP
            var storeUrl = "zune:navigate";
#else
            var storeUrl = "ms-windows-store:";
#endif

            await Launcher.LaunchUriAsync(new Uri(storeUrl, UriKind.Absolute));
        }

        /// <summary>
        /// Shows the Store application.
        /// </summary>
        /// <param name="publisherName">The publisher display name.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual async Task ShowPublisherAsync(string publisherName)
        {
#if WINDOWS_PHONE || WINDOWS_PHONE_APP
            var storeUrl = "zune:search?publisher=" + Uri.EscapeDataString(publisherName);
#else
            var storeUrl = "ms-windows-store:Publisher?name=" + Uri.EscapeDataString(publisherName);
#endif

            await Launcher.LaunchUriAsync(new Uri(storeUrl, UriKind.Absolute));
        }

        /// <summary>
        /// Shows the Store application, optionally filtering results by keyword, publisher, and content type.
        /// </summary>
        /// <param name="keywords">The keywords to search for.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual async Task SearchAsync(string keywords)
        {
#if WINDOWS_PHONE || WINDOWS_PHONE_APP
            var storeUrl = "zune:search?keyword=" + Uri.EscapeDataString(keywords);
#else
            var storeUrl = "ms-windows-store:Search?query=" + Uri.EscapeDataString(keywords);
#endif

            await Launcher.LaunchUriAsync(new Uri(storeUrl, UriKind.Absolute));
        }

        /// <summary>
        /// Shows the Store application.
        /// </summary>
        /// <param name="applicationId">The application id.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual async Task ReviewAsync(string applicationId)
        {
#if WINDOWS_PHONE || WINDOWS_PHONE_APP
            var storeUrl = "zune:reviewapp";

            if (!string.IsNullOrEmpty(applicationId))
            {
                storeUrl += "?appid=" + Uri.EscapeDataString(applicationId);
            }
#else
            var storeUrl = "ms-windows-store:Review?PFN=" + Uri.EscapeDataString(applicationId);
#endif

            await Launcher.LaunchUriAsync(new Uri(storeUrl, UriKind.Absolute));
        }
    }
}