// ****************************************************************************
// <copyright file="LauncherService.cs" company="Pedro Lamas">
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
using Windows.Storage;
using Windows.System;

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="ILauncherService"/>.
    /// </summary>
    public class LauncherService : ILauncherService
    {
        /// <summary>
        /// Starts the default app associated with the URI scheme name for the specified <see cref="Uri"/>.
        /// </summary>
        /// <param name="uri">The <see cref="Uri"/> to start.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public async virtual Task LaunchUriAsync(Uri uri)
        {
            await Launcher.LaunchUriAsync(uri);
        }

        /// <summary>
        /// Starts the default app associated with the URI scheme name for the specified <see cref="Uri"/>.
        /// </summary>
        /// <param name="url">The URI to start.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public async virtual Task LaunchUriAsync(string url)
        {
            await LaunchUriAsync(new Uri(url));
        }

        /// <summary>
        /// Starts the default app associated with the specified file.
        /// </summary>
        /// <param name="file">The file to start.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public async virtual Task LaunchFileAsync(string file)
        {
            var storageFile = await ApplicationData.Current.LocalFolder.GetFileAsync(file);

            await Launcher.LaunchFileAsync(storageFile);
        }
    }
}