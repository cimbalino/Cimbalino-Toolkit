// ****************************************************************************
// <copyright file="PersonalizationService.cs" company="Pedro Lamas">
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

using System;
using System.Threading.Tasks;
using Cimbalino.Toolkit.Services;
using Windows.Storage;
using Windows.System.UserProfile;

namespace Cimbalino.Toolkit.Core.Services
{
    /// <summary>
    /// Personalization service allows the changing of the user's Wallpaper and Lock screen images
    /// </summary>
    public class PersonalizationService : IPersonalizationService
    {
        /// <summary>
        /// Gets a value indicating whether this instance is supported.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is supported; otherwise, <c>false</c>.
        /// </value>
        public virtual bool IsSupported { get; } = UserProfilePersonalizationSettings.IsSupported();

        /// <summary>
        /// Sets the lock screen image.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="fileIsInPackage">if set to <c>true</c> [file is in package].</param>
        /// <returns></returns>
        public virtual async Task<bool> SetLockScreenImageAsync(string filePath, bool fileIsInPackage = false)
        {
            var file = await GetStorageFile(filePath, fileIsInPackage);

            var result = await UserProfilePersonalizationSettings.Current.TrySetLockScreenImageAsync(file);
            return result;
        }

        /// <summary>
        /// Sets the wallpaper image.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="fileIsInPackage">if set to <c>true</c> [file is in package].</param>
        /// <returns></returns>
        public virtual async Task<bool> SetWallpaperImageAsync(string filePath, bool fileIsInPackage = false)
        {
            var file = await GetStorageFile(filePath, fileIsInPackage);

            var result = await UserProfilePersonalizationSettings.Current.TrySetWallpaperImageAsync(file);
            return result;
        }

        private async Task<StorageFile> GetStorageFile(string filePath, bool fileIsInPackage = false)
        {
            var file = fileIsInPackage
                ? await StorageFile.GetFileFromApplicationUriAsync(new Uri(filePath))
                : await StorageFile.GetFileFromPathAsync(filePath);

            return file;
        }
    }
}
