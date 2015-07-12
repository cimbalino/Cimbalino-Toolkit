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
    public interface IPersonalizationService
    {
        /// <summary>
        /// Gets a value indicating whether this instance is supported.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is supported; otherwise, <c>false</c>.
        /// </value>
        bool IsSupported { get; }

        /// <summary>
        /// Sets the lock screen image.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="fileIsInPackage">if set to <c>true</c> [file is in package].</param>
        /// <returns></returns>
        Task<bool> SetLockScreenImageAsync(string filePath, bool fileIsInPackage = false);

        /// <summary>
        /// Sets the wallpaper image.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="fileIsInPackage">if set to <c>true</c> [file is in package].</param>
        /// <returns></returns>
        Task<bool> SetWallpaperImageAsync(string filePath, bool fileIsInPackage = false);
    }
}
