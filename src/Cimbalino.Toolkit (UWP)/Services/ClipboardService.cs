#if WINDOWS_PHONE 
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using Cimbalino.Toolkit.Helpers;
#elif WINDOWS_PHONE_APP
using System;
using System.IO;
using System.Threading.Tasks;
using Cimbalino.Toolkit.Helpers;
using Windows.ApplicationModel.DataTransfer;
#else
using System;
using System.IO;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage.Streams;
#endif

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Implementation of IClipboardService that allows access to the clipboard, where possible
    /// </summary>
    public class ClipboardService : IClipboardService
    {
        /// <summary>
        /// Gets a value indicating whether [contains text].
        /// </summary>
        public virtual bool ContainsText { get; } = IsTypeInClipboard(StandardDataFormats.Text);

        /// <summary>
        /// Gets a value indicating whether [contains bitmap].
        /// </summary>
        public virtual bool ContainsBitmap { get; } = IsTypeInClipboard(StandardDataFormats.Bitmap);

        /// <summary>
        /// Gets a value indicating whether [contains HTML].
        /// </summary>
        public virtual bool ContainsHtml { get; } = IsTypeInClipboard(StandardDataFormats.Html);

        /// <summary>
        /// Gets a value indicating whether [contains RTF].
        /// </summary>
        public virtual bool ContainsRtf { get; } = IsTypeInClipboard(StandardDataFormats.Rtf);

        /// <summary>
        /// Gets a value indicating whether [contains web link].
        /// </summary>
        public virtual bool ContainsWebLink { get; } = IsTypeInClipboard(StandardDataFormats.WebLink);

        /// <summary>
        /// Gets a value indicating whether [contains application link].
        /// </summary>
        public virtual bool ContainsApplicationLink { get; } = IsTypeInClipboard(StandardDataFormats.ApplicationLink);

        /// <summary>
        /// Gets the text.
        /// </summary>
        /// <returns>The text</returns>
        public virtual async Task<string> GetTextAsync()
        {
#if WINDOWS_PHONE || WINDOWS_PHONE_APP
            return ExceptionHelper.ThrowNotSupported<string>();
#else
            var clipboard = Clipboard.GetContent();
            var text = await clipboard.GetTextAsync();
            return text;
#endif
        }

        /// <summary>
        /// Gets the web link.
        /// </summary>
        /// <returns>The weblink</returns>
        public virtual async Task<Uri> GetWebLinkAsync()
        {
#if WINDOWS_PHONE || WINDOWS_PHONE_APP
            return ExceptionHelper.ThrowNotSupported<Uri>();
#else
            var clipboard = Clipboard.GetContent();
            var uri = await clipboard.GetWebLinkAsync();
            return uri;
#endif
        }

        /// <summary>
        /// Gets the HTML.
        /// </summary>
        /// <returns>The html</returns>
        public virtual async Task<string> GetHtmlAsync()
        {
#if WINDOWS_PHONE || WINDOWS_PHONE_APP
            return ExceptionHelper.ThrowNotSupported<string>();
#else
            var clipboard = Clipboard.GetContent();
            var text = await clipboard.GetHtmlFormatAsync();
            return text;
#endif
        }

        /// <summary>
        /// Gets the RTF.
        /// </summary>
        /// <returns>The text</returns>
        public virtual async Task<string> GetRtfAsync()
        {
#if WINDOWS_PHONE || WINDOWS_PHONE_APP
            return ExceptionHelper.ThrowNotSupported<string>();
#else
            var clipboard = Clipboard.GetContent();
            var text = await clipboard.GetRtfAsync();
            return text;
#endif
        }

        /// <summary>
        /// Gets the application link.
        /// </summary>
        /// <returns>The application link</returns>
        public virtual async Task<Uri> GetApplicationLinkAsync()
        {
#if WINDOWS_PHONE || WINDOWS_PHONE_APP
            return ExceptionHelper.ThrowNotSupported<Uri>();
#else
            var clipboard = Clipboard.GetContent();
            var uri = await clipboard.GetApplicationLinkAsync();
            return uri;
#endif
        }

        /// <summary>
        /// Gets the bitmap.
        /// </summary>
        /// <returns>The bitmap</returns>
        public virtual async Task<Stream> GetBitmapAsync()
        {
#if WINDOWS_PHONE_APP || WINDOWS_PHONE
            return ExceptionHelper.ThrowNotSupported<Stream>();
#else
            var clipboard = Clipboard.GetContent();
            var bitmap = await clipboard.GetBitmapAsync();
            using (var stream = await bitmap.OpenReadAsync())
            {
                return stream.AsStream();
            }
#endif
        }

        /// <summary>
        /// Sets the text.
        /// </summary>
        /// <param name="content">The content.</param>
        public virtual void SetText(string content)
        {
#if WINDOWS_PHONE
            ExceptionHelper.ThrowNotSupported();
#elif WINDOWS_PHONE_APP
            ExceptionHelper.ThrowNotSupported();
#else
            var package = new DataPackage();
            package.SetText(content);
            Clipboard.SetContent(package);
#endif
        }

        /// <summary>
        /// Sets the web link.
        /// </summary>
        /// <param name="content">The content.</param>
        public virtual void SetWebLink(Uri content)
        {
#if WINDOWS_PHONE || WINDOWS_PHONE_APP
            ExceptionHelper.ThrowNotSupported();
#else
            var package = new DataPackage();
            package.SetWebLink(content);
            Clipboard.SetContent(package);
#endif

        }

        /// <summary>
        /// Sets the application link.
        /// </summary>
        /// <param name="content">The content.</param>
        public virtual void SetApplicationLink(Uri content)
        {
#if WINDOWS_PHONE || WINDOWS_PHONE_APP
            ExceptionHelper.ThrowNotSupported();
#else
            var package = new DataPackage();
            package.SetApplicationLink(content);
            Clipboard.SetContent(package);
#endif
        }

        /// <summary>
        /// Sets the RTF.
        /// </summary>
        /// <param name="content">The content.</param>
        public virtual void SetRtf(string content)
        {
#if WINDOWS_PHONE || WINDOWS_PHONE_APP
            ExceptionHelper.ThrowNotSupported();
#else
            var package = new DataPackage();
            package.SetRtf(content);
            Clipboard.SetContent(package);
#endif
        }

        /// <summary>
        /// Sets the HTML.
        /// </summary>
        /// <param name="content">The content.</param>
        public virtual void SetHtml(string content)
        {
#if WINDOWS_PHONE || WINDOWS_PHONE_APP
            ExceptionHelper.ThrowNotSupported();
#else
            var package = new DataPackage();
            package.SetHtmlFormat(content);
            Clipboard.SetContent(package);
#endif
        }

        /// <summary>
        /// Sets the bitmap.
        /// </summary>
        /// <param name="content">The content.</param>
        public virtual void SetBitmap(Stream content)
        {
#if WINDOWS_PHONE || WINDOWS_PHONE_APP
            ExceptionHelper.ThrowNotSupported();
#else
            var package = new DataPackage();
            var random = content.AsRandomAccessStream();
            var reference = RandomAccessStreamReference.CreateFromStream(random);
            package.SetBitmap(reference);
#endif
        }

        private static bool IsTypeInClipboard(string format)
        {
#if WINDOWS_PHONE || WINDOWS_PHONE_APP
            return false;
#else
            var content = Clipboard.GetContent();
            return content.Contains(format);
#endif
        }

#if WINDOWS_PHONE
        /// <summary>
        /// Make shift class as it doesn't exist in Silverlight
        /// </summary>
        private static class StandardDataFormats
        {
            public static string Text { get; } = "Text";
            public static string Bitmap { get; } = "Bitmap";
            public static string Html { get; } = "Html";
            public static string Rtf { get; } = "Rtf";
            public static string WebLink { get; } = "WebLink";
            public static string ApplicationLink { get; } = "ApplicationLink";
        }
#endif
    }
}
