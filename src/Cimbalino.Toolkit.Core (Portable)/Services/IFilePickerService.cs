// ****************************************************************************
// <copyright file="IFilePickerService.cs" company="Pedro Lamas">
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

#if !NETFX_CORE
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
#else
using System.Collections.Generic;
using System.Threading.Tasks;
#endif

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of handling the file pickers.
    /// </summary>
#if !NETFX_CORE
    [CLSCompliant(false)]
#endif
    public interface IFilePickerService
    {
        /// <summary>
        /// Shows the file picker so that the user can pick one file.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task<FilePickerServiceFileResult> PickSingleFileAsync(FilePickerServiceOptions options);

        /// <summary>
        /// Shows the file picker so that the user can pick multiple files.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task<IEnumerable<FilePickerServiceFileResult>> PickMultipleFilesAsync(FilePickerServiceOptions options);
    }
}