using System;
using System.IO;
using System.Threading.Tasks;

namespace Cimbalino.Toolkit.Services
{
    public interface IClipboardService
    {
        /// <summary>
        /// Gets a value indicating whether [contains text].
        /// </summary>
        bool ContainsText { get; }

        /// <summary>
        /// Gets a value indicating whether [contains bitmap].
        /// </summary>
        bool ContainsBitmap { get; }

        /// <summary>
        /// Gets a value indicating whether [contains HTML].
        /// </summary>
        bool ContainsHtml { get; }

        /// <summary>
        /// Gets a value indicating whether [contains RTF].
        /// </summary>
        bool ContainsRtf { get; }

        /// <summary>
        /// Gets a value indicating whether [contains web link].
        /// </summary>
        bool ContainsWebLink { get; }

        /// <summary>
        /// Gets a value indicating whether [contains application link].
        /// </summary>
        bool ContainsApplicationLink { get; }

        /// <summary>
        /// Gets the text.
        /// </summary>
        /// <returns>The text</returns>
        Task<string> GetTextAsync();

        /// <summary>
        /// Gets the web link.
        /// </summary>
        /// <returns>The weblink</returns>
        Task<Uri> GetWebLinkAsync();

        /// <summary>
        /// Gets the HTML.
        /// </summary>
        /// <returns>The html</returns>
        Task<string> GetHtmlAsync();

        /// <summary>
        /// Gets the RTF.
        /// </summary>
        /// <returns>The text</returns>
        Task<string> GetRtfAsync();

        /// <summary>
        /// Gets the application link.
        /// </summary>
        /// <returns>The application link</returns>
        Task<Uri> GetApplicationLinkAsync();

        /// <summary>
        /// Gets the bitmap.
        /// </summary>
        /// <returns>The bitmap</returns>
        Task<Stream> GetBitmapAsync();

        /// <summary>
        /// Sets the text.
        /// </summary>
        /// <param name="content">The content.</param>
        void SetText(string content);

        /// <summary>
        /// Sets the web link.
        /// </summary>
        /// <param name="content">The content.</param>
        void SetWebLink(Uri content);

        /// <summary>
        /// Sets the application link.
        /// </summary>
        /// <param name="content">The content.</param>
        void SetApplicationLink(Uri content);

        /// <summary>
        /// Sets the RTF.
        /// </summary>
        /// <param name="content">The content.</param>
        void SetRtf(string content);

        /// <summary>
        /// Sets the HTML.
        /// </summary>
        /// <param name="content">The content.</param>
        void SetHtml(string content);

        /// <summary>
        /// Sets the bitmap.
        /// </summary>
        /// <param name="content">The content.</param>
        void SetBitmap(Stream content);
    }
}
