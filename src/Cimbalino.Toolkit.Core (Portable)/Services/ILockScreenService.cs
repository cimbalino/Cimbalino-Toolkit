// ****************************************************************************
// <copyright file="ILockScreenService.cs" company="Pedro Lamas">
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
using System.IO;
using System.Threading.Tasks;

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of managing the lock screen.
    /// </summary>
    public interface ILockScreenService
    {
        /// <summary>
        /// Sets the lock screen background image.
        /// </summary>
        /// <param name="uri">The file URI.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task SetLockScreenAsync(Uri uri);

        /// <summary>
        /// Sets the lock screen background image.
        /// </summary>
        /// <param name="stream">The file stream.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task SetLockScreenAsync(Stream stream);

        /// <summary>
        /// Gets the current lock screen background image URI.
        /// </summary>
        /// <returns>The file URI.</returns>
        Uri GetCurrentLockScreenUri();

        /// <summary>
        /// Sets the current app as the lock screen background image provider.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task<LockScreenServiceRequestResult> RequestAccessAsync();
    }
}
