// ****************************************************************************
// <copyright file="LockScreenService.uwp.cs" company="Pedro Lamas">
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
using Cimbalino.Toolkit.Helpers;
using Windows.System.UserProfile;

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="ILockScreenService"/>.
    /// </summary>
    public class LockScreenService : ILockScreenService
    {
        /// <summary>
        /// Sets the lock screen background image.
        /// </summary>
        /// <param name="uri">The file URI.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task SetLockScreenAsync(Uri uri)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sets the lock screen background image.
        /// </summary>
        /// <param name="stream">The file stream.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual async Task SetLockScreenAsync(Stream stream)
        {
            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.System.UserProfile.LockScreen"))
            {
                await LockScreen.SetImageStreamAsync(stream.AsRandomAccessStream());
            }
        }

        /// <summary>
        /// Gets the current lock screen background image URI.
        /// </summary>
        /// <returns>The file URI.</returns>
        public virtual Uri GetCurrentLockScreenUri()
        {
            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.System.UserProfile.LockScreen"))
            {
                return LockScreen.OriginalImageFile;
            }

            return null;
        }

        /// <summary>
        /// Sets the current app as the lock screen background image provider.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task<LockScreenServiceRequestResult> RequestAccessAsync()
        {
            return ExceptionHelper.ThrowNotSupported<Task<LockScreenServiceRequestResult>>("To use this method, add Cimbalino.Toolkit assembly to the project and use the LockScreenWithRequestService instead. This method can't be called from a Background Agent.");
        }
    }
}