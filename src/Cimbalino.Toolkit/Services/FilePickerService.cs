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

using System.Collections.Generic;
using System.Threading.Tasks;
using Cimbalino.Toolkit.Helpers;

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
        public virtual Task<FilePickerServiceFileResult> PickSingleFileAsync(FilePickerServiceOptions options)
        {
            return ExceptionHelper.ThrowNotSupported<Task<FilePickerServiceFileResult>>();
        }

        /// <summary>
        /// Shows the file picker so that the user can pick multiple files.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task<IEnumerable<FilePickerServiceFileResult>> PickMultipleFilesAsync(FilePickerServiceOptions options)
        {
            return ExceptionHelper.ThrowNotSupported<Task<IEnumerable<FilePickerServiceFileResult>>>();
        }
    }
}