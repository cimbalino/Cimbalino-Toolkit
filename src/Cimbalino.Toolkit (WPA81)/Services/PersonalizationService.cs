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

using System.Threading.Tasks;
using Cimbalino.Toolkit.Helpers;

namespace Cimbalino.Toolkit.Services
{
    public class PersonalizationService : IPersonalizationService
    {
        /// <summary>
        /// Gets a value indicating whether this instance is supported.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is supported; otherwise, <c>false</c>.
        /// </value>
        public virtual bool IsSupported { get; } = ExceptionHelper.ThrowNotSupported<bool>();

        /// <summary>
        /// Sets the lock screen image.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="fileIsInPackage">if set to <c>true</c> [file is in package].</param>
        /// <returns></returns>
        public virtual Task<bool> SetLockScreenImageAsync(string filePath, bool fileIsInPackage = false)
        {
            return ExceptionHelper.ThrowNotSupported<Task<bool>>();
        }

        /// <summary>
        /// Sets the wallpaper image.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="fileIsInPackage">if set to <c>true</c> [file is in package].</param>
        /// <returns></returns>
        public virtual Task<bool> SetWallpaperImageAsync(string filePath, bool fileIsInPackage = false)
        {
            return ExceptionHelper.ThrowNotSupported<Task<bool>>();
        }
    }
}
