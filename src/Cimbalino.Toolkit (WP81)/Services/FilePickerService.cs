// ****************************************************************************
// <copyright file="FilePickerService.cs" company="Pedro Lamas">
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
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage.Pickers;

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IFilePickerService"/>.
    /// </summary>
    public class FilePickerService : IFilePickerService
    {
        /// <summary>
        /// Shows the file picker so that the user can pick one file.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual async Task<FilePickerServiceFileResult> PickSingleFileAsync(FilePickerServiceOptions options)
        {
            var filePicker = CreateFileOpenPicker(options);

            var selectedFile = await filePicker.PickSingleFileAsync();

            if (selectedFile != null)
            {
                return new FilePickerServiceFileResult(selectedFile);
            }

            return null;
        }

        /// <summary>
        /// Shows the file picker so that the user can pick multiple files.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual async Task<IEnumerable<FilePickerServiceFileResult>> PickMultipleFilesAsync(FilePickerServiceOptions options)
        {
            var filePicker = CreateFileOpenPicker(options);
            var selectedFiles = await filePicker.PickMultipleFilesAsync();

            if (selectedFiles != null && selectedFiles.Count > 0)
            {
                return selectedFiles.Select(x => new FilePickerServiceFileResult(x));
            }

            return null;
        }

        private FileOpenPicker CreateFileOpenPicker(FilePickerServiceOptions options)
        {
            var fileOpenPicker = new FileOpenPicker
            {
                SuggestedStartLocation = options.SuggestedStartLocation.ToPickerLocationId(),
                ViewMode = options.ViewMode.ToPickerViewMode()
            };

            if (options.FileTypeFilters != null)
            {
                foreach (var fileTypeFilter in options.FileTypeFilters)
                {
                    fileOpenPicker.FileTypeFilter.Add(fileTypeFilter);
                }
            }

            return fileOpenPicker;
        }
    }
}