// ****************************************************************************
// <copyright file="IClipboardService.cs" company="Pedro Lamas">
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
    /// Represents a service capable of handling the system clipboard.
    /// </summary>
    public interface IClipboardService
    {
        /// <summary>
        /// Gets a value indicating whether the clipboard contains text.
        /// </summary>
        /// <value>A value indicating whether the clipboard contains text.</value>
        bool ContainsText { get; }

        /// <summary>
        /// Gets a value indicating whether the clipboard contains a bitmap.
        /// </summary>
        /// <value>A value indicating whether the clipboard contains a bitmap.</value>
        bool ContainsBitmap { get; }

        /// <summary>
        /// Gets a value indicating whether the clipboard contains HTML text.
        /// </summary>
        /// <value>A value indicating whether the clipboard contains HTML text.</value>
        bool ContainsHtml { get; }

        /// <summary>
        /// Gets a value indicating whether the clipboard contains RTF text.
        /// </summary>
        /// <value>A value indicating whether the clipboard contains RTF text.</value>
        bool ContainsRtf { get; }

        /// <summary>
        /// Gets a value indicating whether the clipboard contains a web link.
        /// </summary>
        /// <value>A value indicating whether the clipboard contains a web link.</value>
        bool ContainsWebLink { get; }

        /// <summary>
        /// Gets a value indicating whether the clipboard contains an application link.
        /// </summary>
        /// <value>A value indicating whether the clipboard contains an application link.</value>
        bool ContainsApplicationLink { get; }

        /// <summary>
        /// Gets the text in the clipboard.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task<string> GetTextAsync();

        /// <summary>
        /// Gets the web link in the clipboard.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task<Uri> GetWebLinkAsync();

        /// <summary>
        /// Gets the HTML text in the clipboard.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task<string> GetHtmlAsync();

        /// <summary>
        /// Gets the RTF text in the clipboard.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task<string> GetRtfAsync();

        /// <summary>
        /// Gets the application link in the clipboard.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task<Uri> GetApplicationLinkAsync();

        /// <summary>
        /// Gets the bitmap in the clipboard.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task<Stream> GetBitmapAsync();

        /// <summary>
        /// Sets the current text content that is stored in the clipboard.
        /// </summary>
        /// <param name="content">The text content that is stored in the clipboard.</param>
        void SetText(string content);

        /// <summary>
        /// Sets the current web link content that is stored in the clipboard.
        /// </summary>
        /// <param name="content">The web link content that is stored in the clipboard.</param>
        void SetWebLink(Uri content);

        /// <summary>
        /// Sets the current application link content that is stored in the clipboard.
        /// </summary>
        /// <param name="content">application link content that is stored in the clipboard.</param>
        void SetApplicationLink(Uri content);

        /// <summary>
        /// Sets the current RTF text content that is stored in the clipboard.
        /// </summary>
        /// <param name="content">The RTF text content that is stored in the clipboard.</param>
        void SetRtf(string content);

        /// <summary>
        /// Sets the current HTML text content that is stored in the clipboard.
        /// </summary>
        /// <param name="content">The HTML text content that is stored in the clipboard.</param>
        void SetHtml(string content);

        /// <summary>
        /// Sets the current bitmap content that is stored in the clipboard.
        /// </summary>
        /// <param name="content">The bitmap content that is stored in the clipboard.</param>
        void SetBitmap(Stream content);
    }
}
