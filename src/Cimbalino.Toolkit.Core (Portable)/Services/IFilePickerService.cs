using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Interface for file pickers
    /// </summary>
    public interface IFilePickerService
    {
        /// <summary>
        /// Opens the single file picker asynchronous.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>A FilePickerResult</returns>
        Task<FilePickerResult> OpenSingleFilePickerAsync(FilePickerOptions options);

        /// <summary>
        /// Opens the multiple files picker asynchronous.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>A list of FilePickerResult objects</returns>
        Task<List<FilePickerResult>> OpenMultipleFilesPickerAsync(FilePickerOptions options);
    }
}
