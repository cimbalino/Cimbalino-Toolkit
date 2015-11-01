// ****************************************************************************
// <copyright file="ClipboardService.cs" company="Pedro Lamas">
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
using System.IO;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage.Streams;

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IClipboardService"/>.
    /// </summary>
    public class ClipboardService : IClipboardService
    {
        /// <summary>
        /// Gets a value indicating whether the clipboard contains text.
        /// </summary>
        /// <value>A value indicating whether the clipboard contains text.</value>
        public virtual bool ContainsText { get; } = IsTypeInClipboard(StandardDataFormats.Text);

        /// <summary>
        /// Gets a value indicating whether the clipboard contains a bitmap.
        /// </summary>
        /// <value>A value indicating whether the clipboard contains a bitmap.</value>
        public virtual bool ContainsBitmap { get; } = IsTypeInClipboard(StandardDataFormats.Bitmap);

        /// <summary>
        /// Gets a value indicating whether the clipboard contains HTML text.
        /// </summary>
        /// <value>A value indicating whether the clipboard contains HTML text.</value>
        public virtual bool ContainsHtml { get; } = IsTypeInClipboard(StandardDataFormats.Html);

        /// <summary>
        /// Gets a value indicating whether the clipboard contains RTF text.
        /// </summary>
        /// <value>A value indicating whether the clipboard contains RTF text.</value>
        public virtual bool ContainsRtf { get; } = IsTypeInClipboard(StandardDataFormats.Rtf);

        /// <summary>
        /// Gets a value indicating whether the clipboard contains a web link.
        /// </summary>
        /// <value>A value indicating whether the clipboard contains a web link.</value>
        public virtual bool ContainsWebLink { get; } = IsTypeInClipboard(StandardDataFormats.WebLink);

        /// <summary>
        /// Gets a value indicating whether the clipboard contains an application link.
        /// </summary>
        /// <value>A value indicating whether the clipboard contains an application link.</value>
        public virtual bool ContainsApplicationLink { get; } = IsTypeInClipboard(StandardDataFormats.ApplicationLink);

        /// <summary>
        /// Gets the text in the clipboard.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual async Task<string> GetTextAsync()
        {
            var clipboard = Clipboard.GetContent();

            return await clipboard.GetTextAsync();
        }

        /// <summary>
        /// Gets the web link in the clipboard.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual async Task<Uri> GetWebLinkAsync()
        {
            var clipboard = Clipboard.GetContent();

            return await clipboard.GetWebLinkAsync();
        }

        /// <summary>
        /// Gets the HTML text in the clipboard.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual async Task<string> GetHtmlAsync()
        {
            var clipboard = Clipboard.GetContent();

            return await clipboard.GetHtmlFormatAsync();
        }

        /// <summary>
        /// Gets the RTF text in the clipboard.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual async Task<string> GetRtfAsync()
        {
            var clipboard = Clipboard.GetContent();

            return await clipboard.GetRtfAsync();
        }

        /// <summary>
        /// Gets the application link in the clipboard.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual async Task<Uri> GetApplicationLinkAsync()
        {
            var clipboard = Clipboard.GetContent();

            return await clipboard.GetApplicationLinkAsync();
        }

        /// <summary>
        /// Gets the bitmap in the clipboard.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual async Task<Stream> GetBitmapAsync()
        {
            var clipboard = Clipboard.GetContent();

            var bitmap = await clipboard.GetBitmapAsync();

            var stream = await bitmap.OpenReadAsync();

            return stream.AsStream();
        }

        /// <summary>
        /// Sets the current text content that is stored in the clipboard.
        /// </summary>
        /// <param name="content">The text content that is stored in the clipboard.</param>
        public virtual void SetText(string content)
        {
            var package = new DataPackage();

            package.SetText(content);

            Clipboard.SetContent(package);
        }

        /// <summary>
        /// Sets the current web link content that is stored in the clipboard.
        /// </summary>
        /// <param name="content">The web link content that is stored in the clipboard.</param>
        public virtual void SetWebLink(Uri content)
        {
            var package = new DataPackage();

            package.SetWebLink(content);

            Clipboard.SetContent(package);
        }

        /// <summary>
        /// Sets the current application link content that is stored in the clipboard.
        /// </summary>
        /// <param name="content">application link content that is stored in the clipboard.</param>
        public virtual void SetApplicationLink(Uri content)
        {
            var package = new DataPackage();

            package.SetApplicationLink(content);

            Clipboard.SetContent(package);
        }

        /// <summary>
        /// Sets the current RTF text content that is stored in the clipboard.
        /// </summary>
        /// <param name="content">The RTF text content that is stored in the clipboard.</param>
        public virtual void SetRtf(string content)
        {
            var package = new DataPackage();

            package.SetRtf(content);

            Clipboard.SetContent(package);
        }

        /// <summary>
        /// Sets the current HTML text content that is stored in the clipboard.
        /// </summary>
        /// <param name="content">The HTML text content that is stored in the clipboard.</param>
        public virtual void SetHtml(string content)
        {
            var package = new DataPackage();

            package.SetHtmlFormat(content);

            Clipboard.SetContent(package);
        }

        /// <summary>
        /// Sets the current bitmap content that is stored in the clipboard.
        /// </summary>
        /// <param name="content">The bitmap content that is stored in the clipboard.</param>
        public virtual void SetBitmap(Stream content)
        {
            var package = new DataPackage();

            var random = content.AsRandomAccessStream();

            var reference = RandomAccessStreamReference.CreateFromStream(random);

            package.SetBitmap(reference);
        }

        private static bool IsTypeInClipboard(string format)
        {
            var content = Clipboard.GetContent();

            return content.Contains(format);
        }
    }
}