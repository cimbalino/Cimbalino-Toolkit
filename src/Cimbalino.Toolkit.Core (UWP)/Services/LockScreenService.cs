// ****************************************************************************
// <copyright file="LockScreenService.cs" company="Pedro Lamas">
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

#if WINDOWS_PHONE
using System;
using System.IO;
using System.Threading.Tasks;
using Cimbalino.Toolkit.Helpers;
using Windows.Phone.System.UserProfile;
#elif WINDOWS_PHONE_APP
using System;
using System.IO;
using System.Threading.Tasks;
using Cimbalino.Toolkit.Helpers;
#else
using System;
using System.IO;
using System.Threading.Tasks;
using Cimbalino.Toolkit.Helpers;
using Windows.System.UserProfile;
#endif

namespace Cimbalino.Toolkit.Services
{
    public class LockScreenService : ILockScreenService
    {
#if WINDOWS_PHONE
        private const string LockScreenImageUrlNormal = "ms-appdata:///Local/shared/shellcontent/MBWallpaper.png";
        private const string LockScreenImageUrlAlternative = "ms-appdata:///Local/shared/shellcontent/MBWallpaper2.png";
        private const string LockScreenFileNormal = "shared\\shellcontent\\MBWallpaper.png";
        private const string LockScreenFileAlternative = "shared\\shellcontent\\MBWallpaper2.png";

        protected Uri ImageUri
        {
            get
            {
                return LockScreen.GetImageUri();
            }
            set
            {
                LockScreen.SetImageUri(value);
            }
        }

        protected string LockScreenImageUrl
        {
            get
            {
                return ImageUri.ToString().EndsWith("2.png") ? LockScreenImageUrlNormal : LockScreenImageUrlAlternative;
            }
        }

        protected string LockScreenFile
        {
            get
            {
                return ImageUri.ToString().EndsWith("2.png") ? LockScreenFileNormal : LockScreenFileAlternative;
            }
        }
#endif

        protected IStorageServiceHandler LocalStorage;

        public LockScreenService()
        {
            LocalStorage = new StorageService().Local;
        }

        public virtual Task SetLockScreenAsync(Uri uri)
        {
            throw new NotImplementedException();
        }

        public virtual Task SetLockScreenAsync(Stream stream)
        {
#if WINDOWS_PHONE_APP
            return ExceptionHelper.ThrowNotSupported<Task>();
#else
            return SaveStream(stream);
#endif
        }

        public virtual Uri GetCurrentLockScreenUri()
        {
#if WINDOWS_PHONE
            return new Uri(LockScreenImageUrl, UriKind.Absolute);
#elif WINDOWS_UWP || WINDOWS_APP
            return LockScreen.OriginalImageFile;
#else
            return ExceptionHelper.ThrowNotSupported<Uri>();
#endif
        }

        public virtual Task<LockScreenServiceRequestResult> RequestAccessAsync()
        {
            return ExceptionHelper.ThrowNotSupported<Task<LockScreenServiceRequestResult>>("To use this method, add Cimbalino.Toolkit assembly to the project and use the LockScreenWithRequestService instead. This method can't be called from a Background Agent.");
        }

#if WINDOWS_PHONE
        protected async Task SaveStream(Stream stream)
        {
            using (var fileStream = await LocalStorage.CreateFileAsync(LockScreenFile))
            {
                await stream.CopyToAsync(fileStream);
            }

            ImageUri = new Uri(LockScreenImageUrl, UriKind.RelativeOrAbsolute);
        }
#elif WINDOWS_APP || WINDOWS_UWP
        protected Task SaveStream(Stream stream)
        {
            return LockScreen.SetImageStreamAsync(stream.AsRandomAccessStream()).AsTask();
        }
#endif
    }
}
