// ****************************************************************************
// <copyright file="FilePickerServiceFileResult.cs" company="Pedro Lamas">
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

#if PORTABLE
using System;
using System.IO;
using System.Threading.Tasks;
using Cimbalino.Toolkit.Helpers;
#else
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
#endif

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents the result of the <see cref="IFilePickerService.PickSingleFileAsync"/> operation.
    /// </summary>
#if !NETFX_CORE
    [CLSCompliant(false)]
#endif
    public class FilePickerServiceFileResult
    {
#if !PORTABLE
        private readonly StorageFile _storageFile;
#endif

        /// <summary>
        /// Gets the name of the file including the file name extension.
        /// </summary>
        /// <value>The name of the file including the file name extension.</value>
        public string FileName
        {
            get
            {
#if PORTABLE
                return ExceptionHelper.ThrowNotSupported<string>();
#else
                return _storageFile.Name;
#endif
            }
        }

        /// <summary>
        /// Gets the type (file name extension) of the file.
        /// </summary>
        /// <value>The file name extension of the file.</value>
        public string FileType
        {
            get
            {
#if PORTABLE
                return ExceptionHelper.ThrowNotSupported<string>();
#else
                return _storageFile.FileType;
#endif
            }
        }

#if !PORTABLE
        /// <summary>
        /// Initializes a new instance of the <see cref="FilePickerServiceFileResult" /> class.
        /// </summary>
        /// <param name="storageFile">The selected <see cref="StorageFile"/>.</param>
        public FilePickerServiceFileResult(StorageFile storageFile)
        {
            _storageFile = storageFile;
        }
#endif

        /// <summary>
        /// Retrieves a stream for reading the selected file.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task<Stream> OpenStreamForReadAsync()
        {
#if PORTABLE
            return ExceptionHelper.ThrowNotSupported<Task<Stream>>();
#else
            return _storageFile.OpenStreamForReadAsync();
#endif
        }
    }
}