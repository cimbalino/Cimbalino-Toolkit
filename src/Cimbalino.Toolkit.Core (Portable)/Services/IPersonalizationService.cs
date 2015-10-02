// ****************************************************************************
// <copyright file="IPersonalizationService.cs" company="Pedro Lamas">
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

using System.Threading.Tasks;

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of changing of the user's wallpaper and lock screen images.
    /// </summary>
    public interface IPersonalizationService
    {
        /// <summary>
        /// Gets a value indicating whether this instance is supported.
        /// </summary>
        /// <value>true if this instance is supported; otherwise, false.</value>
        bool IsSupported { get; }

        /// <summary>
        /// Sets the lock screen image.
        /// </summary>
        /// <param name="fileUri">The file URI.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task<bool> SetLockScreenImageAsync(string fileUri);

        /// <summary>
        /// Sets the wallpaper image.
        /// </summary>
        /// <param name="fileUri">The file URI.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task<bool> SetWallpaperImageAsync(string fileUri);
    }
}