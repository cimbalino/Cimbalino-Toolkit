// ****************************************************************************
// <copyright file="StorageServiceHandler.cs" company="Pedro Lamas">
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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Cimbalino.Toolkit.Extensions;
using Windows.Storage;

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IStorageServiceHandler"/>.
    /// </summary>
#if !NETFX_CORE
    [CLSCompliant(false)]
#endif
    public class StorageServiceHandler : IStorageServiceHandler
    {
        protected readonly StorageFolder StorageFolder;

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageServiceHandler"/> class.
        /// </summary>
        /// <param name="storageFolder">The root <see cref="StorageFolder"/> instance.</param>
        public StorageServiceHandler(StorageFolder storageFolder)
        {
            StorageFolder = storageFolder;
        }

        /// <summary>
        /// Copies an existing file to a new file.
        /// </summary>
        /// <param name="sourceFileName">The name of the file to copy.</param>
        /// <param name="destinationFileName">The name of the destination file. This cannot be a directory or an existing file.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task CopyFileAsync(string sourceFileName, string destinationFileName)
        {
            return CopyFileAsync(sourceFileName, destinationFileName, false);
        }

        /// <summary>
        /// Copies an existing file to a new file, and optionally overwrites an existing file.
        /// </summary>
        /// <param name="sourceFileName">The name of the file to copy.</param>
        /// <param name="destinationFileName">The name of the destination file. This cannot be a directory.</param>
        /// <param name="overwrite">true if the destination file can be overwritten; otherwise, false.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public async virtual Task CopyFileAsync(string sourceFileName, string destinationFileName, bool overwrite)
        {
            var file = await StorageFolder.GetFileAsync(sourceFileName);

            var destinationFolderName = Path.GetDirectoryName(destinationFileName);
            var destinationFolder = await StorageFolder.GetFolderAsync(destinationFolderName);

            destinationFileName = Path.GetFileName(destinationFileName);

            var nameCollisionOption = overwrite ? NameCollisionOption.ReplaceExisting : NameCollisionOption.FailIfExists;

            await file.CopyAsync(destinationFolder, destinationFileName, nameCollisionOption);
        }

        /// <summary>
        /// Moves an existing file to a new file.
        /// </summary>
        /// <param name="sourceFileName">The name of the file to move.</param>
        /// <param name="destinationFileName">The name of the destination file. This cannot be a directory or an existing file.</param>
        /// <returns>The <see cref="Task" /> object representing the asynchronous operation.</returns>
        public virtual Task MoveFileAsync(string sourceFileName, string destinationFileName)
        {
            return MoveFileAsync(sourceFileName, destinationFileName, false);
        }

        /// <summary>
        /// Moves an existing file to a new file, and optionally overwrites an existing file.
        /// </summary>
        /// <param name="sourceFileName">The name of the file to move.</param>
        /// <param name="destinationFileName">The name of the destination file. This cannot be a directory.</param>
        /// <param name="overwrite">true if the destination file can be overwritten; otherwise, false.</param>
        /// <returns>The <see cref="Task" /> object representing the asynchronous operation.</returns>
        public async virtual Task MoveFileAsync(string sourceFileName, string destinationFileName, bool overwrite)
        {
            var file = await StorageFolder.GetFileAsync(sourceFileName);

            var destinationFolderName = Path.GetDirectoryName(destinationFileName);
            var destinationFolder = await StorageFolder.GetFolderAsync(destinationFolderName);

            destinationFileName = Path.GetFileName(destinationFileName);

            var nameCollisionOption = overwrite ? NameCollisionOption.ReplaceExisting : NameCollisionOption.FailIfExists;

            await file.MoveAsync(destinationFolder, destinationFileName, nameCollisionOption);
        }

        /// <summary>
        /// Creates a directory in the storage scope.
        /// </summary>
        /// <param name="dir">The relative path of the directory to create within the storage.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public async virtual Task CreateDirectoryAsync(string dir)
        {
            await StorageFolder.CreateFolderAsync(dir);
        }

        /// <summary>
        /// Creates a file in the store.
        /// </summary>
        /// <param name="path">The relative path of the file to be created in the store.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task<Stream> CreateFileAsync(string path)
        {
            return StorageFolder.OpenStreamForWriteAsync(path, CreationCollisionOption.ReplaceExisting);
        }

        /// <summary>
        /// Deletes a directory in the storage scope.
        /// </summary>
        /// <param name="dir">The relative path of the directory to delete within the storage scope.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public async virtual Task DeleteDirectoryAsync(string dir)
        {
            var folder = await StorageFolder.GetFolderAsync(dir);

            await folder.DeleteAsync();
        }

        /// <summary>
        /// Deletes the specified file.
        /// </summary>
        /// <param name="path">The name of the file to be deleted. Wildcard characters are not supported.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public async virtual Task DeleteFileAsync(string path)
        {
            var file = await StorageFolder.GetFileAsync(path);

            await file.DeleteAsync();
        }

        /// <summary>
        /// Determines whether the specified path refers to an existing directory in the store.
        /// </summary>
        /// <param name="dir">The path to test.</param>
        /// <returns>true if path refers to an existing directory in the store and is not null; otherwise, false.</returns>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public async virtual Task<bool> DirectoryExistsAsync(string dir)
        {
#if WINDOWS_APP
            return await StorageFolder.TryGetItemAsync(dir) is StorageFolder;
#else
            try
            {
                var folder = await StorageFolder.GetFolderAsync(dir);

                return folder != null;
            }
            catch
            {
                return false;
            }
#endif
        }

        /// <summary>
        /// Determines whether the specified path refers to an existing file in the store.
        /// </summary>
        /// <param name="path">The path and file name to test.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public async virtual Task<bool> FileExistsAsync(string path)
        {
#if WINDOWS_APP
            return await StorageFolder.TryGetItemAsync(path) is StorageFile;
#else
            try
            {
                var file = await StorageFolder.GetItemAsync(path);

                return file != null;
            }
            catch (FileNotFoundException)
            {
                return false;
            }
#endif
        }

        /// <summary>
        /// Enumerates the directories in the root of a store.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public async virtual Task<string[]> GetDirectoryNamesAsync()
        {
            var folders = await StorageFolder.GetFoldersAsync();

            return folders
                .Select(x => x.Name)
                .ToArray();
        }

        /// <summary>
        /// Enumerates directories in a storage scope that match a given pattern.
        /// </summary>
        /// <param name="searchPattern">A search pattern. Both single-character ("?") and multi-character ("*") wildcards are supported.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public async virtual Task<string[]> GetDirectoryNamesAsync(string searchPattern)
        {
            var folderName = Path.GetDirectoryName(searchPattern);
            var folder = string.IsNullOrEmpty(folderName) ? StorageFolder : await StorageFolder.GetFolderAsync(folderName);

            var folders = await folder.GetFoldersAsync();

            searchPattern = Path.GetFileName(searchPattern);

            if (string.IsNullOrEmpty(searchPattern))
            {
                return folders
                    .Select(x => x.Name)
                    .ToArray();
            }

            var regexPattern = FilePatternToRegex(searchPattern);

            return folders
                .Where(x => regexPattern.IsMatch(x.Name))
                .Select(x => x.Name)
                .ToArray();
        }

        /// <summary>
        /// Obtains the names of files in the root of a store.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public async virtual Task<string[]> GetFileNamesAsync()
        {
            var files = await StorageFolder.GetFilesAsync();

            return files
                .Select(x => x.Name)
                .ToArray();
        }

        /// <summary>
        /// Enumerates files in storage scope that match a given pattern.
        /// </summary>
        /// <param name="searchPattern">A search pattern. Both single-character ("?") and multi-character ("*") wildcards are supported.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public async virtual Task<string[]> GetFileNamesAsync(string searchPattern)
        {
            var folderName = Path.GetDirectoryName(searchPattern);
            var folder = string.IsNullOrEmpty(folderName) ? StorageFolder : await StorageFolder.GetFolderAsync(folderName);

            var files = await folder.GetFilesAsync();

            searchPattern = Path.GetFileName(searchPattern);

            if (string.IsNullOrEmpty(searchPattern))
            {
                return files
                    .Select(x => x.Name)
                    .ToArray();
            }

            var regexPattern = FilePatternToRegex(searchPattern);

            return files
                .Where(x => regexPattern.IsMatch(x.Name))
                .Select(x => x.Name)
                .ToArray();
        }

        /// <summary>
        /// Opens a file in the specified mode.
        /// </summary>
        /// <param name="path">The relative path of the file within the store.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task<Stream> OpenFileForReadAsync(string path)
        {
            return StorageFolder.OpenStreamForReadAsync(path);
        }

        /// <summary>
        /// Opens a text file, reads all lines of the file, and then closes the file.
        /// </summary>
        /// <param name="path">The file to open for reading.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public async virtual Task<string> ReadAllTextAsync(string path)
        {
            using (var fileStream = await OpenFileForReadAsync(path).ConfigureAwait(false))
            {
                using (var streamReader = new StreamReader(fileStream))
                {
                    return await streamReader.ReadToEndAsync().ConfigureAwait(false);
                }
            }
        }

        /// <summary>
        /// Opens a file, reads all lines of the file with the specified encoding, and then closes the file.
        /// </summary>
        /// <param name="path">The file to open for reading.</param>
        /// <param name="encoding">The encoding applied to the contents of the file.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public async virtual Task<string> ReadAllTextAsync(string path, Encoding encoding)
        {
            using (var fileStream = await OpenFileForReadAsync(path).ConfigureAwait(false))
            {
                using (var streamReader = new StreamReader(fileStream, encoding))
                {
                    return await streamReader.ReadToEndAsync().ConfigureAwait(false);
                }
            }
        }

        /// <summary>
        /// Opens a text file, reads all lines of the file, and then closes the file.
        /// </summary>
        /// <param name="path">The file to open for reading.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public async virtual Task<string[]> ReadAllLinesAsync(string path)
        {
            using (var fileStream = await OpenFileForReadAsync(path).ConfigureAwait(false))
            {
                var lines = new List<string>();

                using (var streamReader = new StreamReader(fileStream))
                {
                    while (!streamReader.EndOfStream)
                    {
                        lines.Add(await streamReader.ReadLineAsync().ConfigureAwait(false));
                    }
                }

                return lines.ToArray();
            }
        }

        /// <summary>
        /// Opens a file, reads all lines of the file with the specified encoding, and then closes the file.
        /// </summary>
        /// <param name="path">The file to open for reading.</param>
        /// <param name="encoding">The encoding applied to the contents of the file.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public async virtual Task<string[]> ReadAllLinesAsync(string path, Encoding encoding)
        {
            using (var fileStream = await OpenFileForReadAsync(path).ConfigureAwait(false))
            {
                var lines = new List<string>();

                using (var streamReader = new StreamReader(fileStream, encoding))
                {
                    while (!streamReader.EndOfStream)
                    {
                        lines.Add(await streamReader.ReadLineAsync().ConfigureAwait(false));
                    }
                }

                return lines.ToArray();
            }
        }

        /// <summary>
        /// Opens a binary file, reads the contents of the file into a byte array, and then closes the file. Returns null, if an exception is raised.
        /// </summary>
        /// <param name="path">The file to open for reading.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public async virtual Task<byte[]> ReadAllBytesAsync(string path)
        {
            using (var fileStream = await OpenFileForReadAsync(path).ConfigureAwait(false))
            {
                return await fileStream.ToArrayAsync().ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Creates a new file, writes the specified string to the file, and then closes the file. If the target file already exists, it is overwritten.
        /// </summary>
        /// <param name="path">The file to write to.</param>
        /// <param name="contents">The string to write to the file.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public async virtual Task WriteAllTextAsync(string path, string contents)
        {
            using (var fileStream = await CreateFileAsync(path).ConfigureAwait(false))
            {
                using (var streamWriter = new StreamWriter(fileStream))
                {
                    await streamWriter.WriteAsync(contents).ConfigureAwait(false);
                }
            }
        }

        /// <summary>
        /// Creates a new file, writes the specified string to the file using the specified encoding, and then closes the file. If the target file already exists, it is overwritten.
        /// </summary>
        /// <param name="path">The file to write to.</param>
        /// <param name="contents">The string to write to the file.</param>
        /// <param name="encoding">The encoding to apply to the string.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public async virtual Task WriteAllTextAsync(string path, string contents, Encoding encoding)
        {
            using (var fileStream = await CreateFileAsync(path).ConfigureAwait(false))
            {
                using (var streamWriter = new StreamWriter(fileStream, encoding))
                {
                    await streamWriter.WriteAsync(contents).ConfigureAwait(false);
                }
            }
        }

        /// <summary>
        /// Creates a new file, writes a collection of strings to the file, and then closes the file.
        /// </summary>
        /// <param name="path">The file to write to.</param>
        /// <param name="contents">The lines to write to the file.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public async virtual Task WriteAllLinesAsync(string path, IEnumerable<string> contents)
        {
            using (var fileStream = await CreateFileAsync(path).ConfigureAwait(false))
            {
                using (var streamWriter = new StreamWriter(fileStream))
                {
                    foreach (var line in contents)
                    {
                        await streamWriter.WriteLineAsync(line).ConfigureAwait(false);
                    }
                }
            }
        }

        /// <summary>
        /// Creates a new file by using the specified encoding, writes a collection of strings to the file, and then closes the file.
        /// </summary>
        /// <param name="path">The file to write to.</param>
        /// <param name="contents">The lines to write to the file.</param>
        /// <param name="encoding">The character encoding to use.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public async virtual Task WriteAllLinesAsync(string path, IEnumerable<string> contents, Encoding encoding)
        {
            using (var fileStream = await CreateFileAsync(path).ConfigureAwait(false))
            {
                using (var streamWriter = new StreamWriter(fileStream, encoding))
                {
                    foreach (var line in contents)
                    {
                        await streamWriter.WriteLineAsync(line).ConfigureAwait(false);
                    }
                }
            }
        }

        /// <summary>
        /// Creates a new file, writes the specified byte array to the file, and then closes the file. If the target file already exists, it is overwritten.
        /// </summary>
        /// <param name="path">The file to write to.</param>
        /// <param name="bytes">The bytes to write to the file.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public async virtual Task WriteAllBytesAsync(string path, byte[] bytes)
        {
            using (var fileStream = await CreateFileAsync(path).ConfigureAwait(false))
            {
                await fileStream.WriteAsync(bytes, 0, bytes.Length).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Opens a file, appends the specified string to the file, and then closes the file. If the file does not exist, this method creates a file, writes the specified string to the file, then closes the file.
        /// </summary>
        /// <param name="path">The file to append the specified string to.</param>
        /// <param name="contents">The string to append to the file.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public async virtual Task AppendAllText(string path, string contents)
        {
            using (var fileStream = await StorageFolder.OpenStreamForWriteAsync(path, CreationCollisionOption.OpenIfExists).ConfigureAwait(false))
            {
                using (var streamWriter = new StreamWriter(fileStream))
                {
                    await streamWriter.WriteAsync(contents).ConfigureAwait(false);
                }
            }
        }

        /// <summary>
        /// Appends the specified string to the file, creating the file if it does not already exist.
        /// </summary>
        /// <param name="path">The file to append the specified string to.</param>
        /// <param name="contents">The string to append to the file.</param>
        /// <param name="encoding">The character encoding to use.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public async virtual Task AppendAllText(string path, string contents, Encoding encoding)
        {
            using (var fileStream = await StorageFolder.OpenStreamForWriteAsync(path, CreationCollisionOption.OpenIfExists).ConfigureAwait(false))
            {
                using (var streamWriter = new StreamWriter(fileStream, encoding))
                {
                    await streamWriter.WriteAsync(contents).ConfigureAwait(false);
                }
            }
        }

        /// <summary>
        /// Appends lines to a file, and then closes the file.
        /// </summary>
        /// <param name="path">The file to append the lines to. The file is created if it does not already exist.</param>
        /// <param name="contents">The lines to append to the file.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public async virtual Task AppendAllLines(string path, IEnumerable<string> contents)
        {
            using (var fileStream = await StorageFolder.OpenStreamForWriteAsync(path, CreationCollisionOption.OpenIfExists).ConfigureAwait(false))
            {
                using (var streamWriter = new StreamWriter(fileStream))
                {
                    foreach (var line in contents)
                    {
                        await streamWriter.WriteLineAsync(line).ConfigureAwait(false);
                    }
                }
            }
        }

        /// <summary>
        /// Appends lines to a file by using a specified encoding, and then closes the file.
        /// </summary>
        /// <param name="path">The file to append the lines to. The file is created if it does not already exist.</param>
        /// <param name="contents">The lines to append to the file.</param>
        /// <param name="encoding">The character encoding to use.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public async virtual Task AppendAllLines(string path, IEnumerable<string> contents, Encoding encoding)
        {
            using (var fileStream = await StorageFolder.OpenStreamForWriteAsync(path, CreationCollisionOption.OpenIfExists).ConfigureAwait(false))
            {
                using (var streamWriter = new StreamWriter(fileStream, encoding))
                {
                    foreach (var line in contents)
                    {
                        await streamWriter.WriteLineAsync(line).ConfigureAwait(false);
                    }
                }
            }
        }

        private Regex FilePatternToRegex(string pattern)
        {
            var regexPattern = Regex.Replace(pattern, "[*?]|[^*?]+", m =>
            {
                switch (m.Value)
                {
                    case "*":
                        return ".*";

                    case "?":
                        return ".";

                    default:
                        return Regex.Escape(m.Value);
                }
            });

            return new Regex(regexPattern);
        }
    }
}