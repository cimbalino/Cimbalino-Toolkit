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

#if WINDOWS_PHONE
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using Cimbalino.Toolkit.Helpers;
#else
using System;
using System.IO;
using System.Threading.Tasks;
using Cimbalino.Toolkit.Helpers;
#endif

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
        public virtual bool ContainsText { get; } = ExceptionHelper.ThrowNotSupported<bool>();

        /// <summary>
        /// Gets a value indicating whether the clipboard contains a bitmap.
        /// </summary>
        /// <value>A value indicating whether the clipboard contains a bitmap.</value>
        public virtual bool ContainsBitmap { get; } = ExceptionHelper.ThrowNotSupported<bool>();

        /// <summary>
        /// Gets a value indicating whether the clipboard contains HTML text.
        /// </summary>
        /// <value>A value indicating whether the clipboard contains HTML text.</value>
        public virtual bool ContainsHtml { get; } = ExceptionHelper.ThrowNotSupported<bool>();

        /// <summary>
        /// Gets a value indicating whether the clipboard contains RTF text.
        /// </summary>
        /// <value>A value indicating whether the clipboard contains RTF text.</value>
        public virtual bool ContainsRtf { get; } = ExceptionHelper.ThrowNotSupported<bool>();

        /// <summary>
        /// Gets a value indicating whether the clipboard contains a web link.
        /// </summary>
        /// <value>A value indicating whether the clipboard contains a web link.</value>
        public virtual bool ContainsWebLink { get; } = ExceptionHelper.ThrowNotSupported<bool>();

        /// <summary>
        /// Gets a value indicating whether the clipboard contains an application link.
        /// </summary>
        /// <value>A value indicating whether the clipboard contains an application link.</value>
        public virtual bool ContainsApplicationLink { get; } = ExceptionHelper.ThrowNotSupported<bool>();

        /// <summary>
        /// Gets the text in the clipboard.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task<string> GetTextAsync()
        {
            return ExceptionHelper.ThrowNotSupported<Task<string>>();
        }

        /// <summary>
        /// Gets the web link in the clipboard.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task<Uri> GetWebLinkAsync()
        {
            return ExceptionHelper.ThrowNotSupported<Task<Uri>>();
        }

        /// <summary>
        /// Gets the HTML text in the clipboard.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task<string> GetHtmlAsync()
        {
            return ExceptionHelper.ThrowNotSupported<Task<string>>();
        }

        /// <summary>
        /// Gets the RTF text in the clipboard.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task<string> GetRtfAsync()
        {
            return ExceptionHelper.ThrowNotSupported<Task<string>>();
        }

        /// <summary>
        /// Gets the application link in the clipboard.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task<Uri> GetApplicationLinkAsync()
        {
            return ExceptionHelper.ThrowNotSupported<Task<Uri>>();
        }

        /// <summary>
        /// Gets the bitmap in the clipboard.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task<Stream> GetBitmapAsync()
        {
            return ExceptionHelper.ThrowNotSupported<Task<Stream>>();
        }

        /// <summary>
        /// Sets the current text content that is stored in the clipboard.
        /// </summary>
        /// <param name="content">The text content that is stored in the clipboard.</param>
        public virtual void SetText(string content)
        {
#if WINDOWS_PHONE
            Clipboard.SetText(content);
#else
            ExceptionHelper.ThrowNotSupported();
#endif
        }

        /// <summary>
        /// Sets the current web link content that is stored in the clipboard.
        /// </summary>
        /// <param name="content">The web link content that is stored in the clipboard.</param>
        public virtual void SetWebLink(Uri content)
        {
            ExceptionHelper.ThrowNotSupported();
        }

        /// <summary>
        /// Sets the current application link content that is stored in the clipboard.
        /// </summary>
        /// <param name="content">application link content that is stored in the clipboard.</param>
        public virtual void SetApplicationLink(Uri content)
        {
            ExceptionHelper.ThrowNotSupported();
        }

        /// <summary>
        /// Sets the current RTF text content that is stored in the clipboard.
        /// </summary>
        /// <param name="content">The RTF text content that is stored in the clipboard.</param>
        public virtual void SetRtf(string content)
        {
            ExceptionHelper.ThrowNotSupported();
        }

        /// <summary>
        /// Sets the current HTML text content that is stored in the clipboard.
        /// </summary>
        /// <param name="content">The HTML text content that is stored in the clipboard.</param>
        public virtual void SetHtml(string content)
        {
            ExceptionHelper.ThrowNotSupported();
        }

        /// <summary>
        /// Sets the current bitmap content that is stored in the clipboard.
        /// </summary>
        /// <param name="content">The bitmap content that is stored in the clipboard.</param>
        public virtual void SetBitmap(Stream content)
        {
            ExceptionHelper.ThrowNotSupported();
        }
    }
}