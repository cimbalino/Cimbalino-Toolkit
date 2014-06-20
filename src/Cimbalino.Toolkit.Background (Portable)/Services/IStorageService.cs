// ****************************************************************************
// <copyright file="IStorageService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2014
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <project>Cimbalino.Toolkit.Background</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of handling the application storage asynchronously.
    /// </summary>
    public interface IStorageService
    {
        /// <summary>
        /// Copies an existing file to a new file.
        /// </summary>
        /// <param name="sourceFileName">The name of the file to copy.</param>
        /// <param name="destinationFileName">The name of the destination file. This cannot be a directory or an existing file.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task CopyFileAsync(string sourceFileName, string destinationFileName);

        /// <summary>
        /// Copies an existing file to a new file, and optionally overwrites an existing file.
        /// </summary>
        /// <param name="sourceFileName">The name of the file to copy.</param>
        /// <param name="destinationFileName">The name of the destination file. This cannot be a directory.</param>
        /// <param name="overwrite">true if the destination file can be overwritten; otherwise, false.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task CopyFileAsync(string sourceFileName, string destinationFileName, bool overwrite);

        /// <summary>
        /// Creates a directory in the storage scope.
        /// </summary>
        /// <param name="dir">The relative path of the directory to create within the storage.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task CreateDirectoryAsync(string dir);

        /// <summary>
        /// Creates a file in the store.
        /// </summary>
        /// <param name="path">The relative path of the file to be created in the store.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task<Stream> CreateFileAsync(string path);

        /// <summary>
        /// Deletes a directory in the storage scope.
        /// </summary>
        /// <param name="dir">The relative path of the directory to delete within the storage scope.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task DeleteDirectoryAsync(string dir);

        /// <summary>
        /// Deletes the specified file.
        /// </summary>
        /// <param name="path">The name of the file to be deleted. Wildcard characters are not supported.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task DeleteFileAsync(string path);

        /// <summary>
        /// Determines whether the specified path refers to an existing directory in the store.
        /// </summary>
        /// <param name="dir">The path to test.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task<bool> DirectoryExistsAsync(string dir);

        /// <summary>
        /// Determines whether the specified path refers to an existing file in the store.
        /// </summary>
        /// <param name="path">The path and file name to test.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task<bool> FileExistsAsync(string path);

        /// <summary>
        /// Enumerates the directories in the root of a store.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task<string[]> GetDirectoryNamesAsync();

        /// <summary>
        /// Enumerates directories in a storage scope that match a given pattern.
        /// </summary>
        /// <param name="searchPattern">A search pattern. Both single-character ("?") and multi-character ("*") wildcards are supported.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task<string[]> GetDirectoryNamesAsync(string searchPattern);

        /// <summary>
        /// Obtains the names of files in the root of a store.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task<string[]> GetFileNamesAsync();

        /// <summary>
        /// Enumerates files in storage scope that match a given pattern.
        /// </summary>
        /// <param name="searchPattern">A search pattern. Both single-character ("?") and multi-character ("*") wildcards are supported.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task<string[]> GetFileNamesAsync(string searchPattern);

        /// <summary>
        /// Opens a file in the specified mode.
        /// </summary>
        /// <param name="path">The relative path of the file within the store.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task<Stream> OpenFileForReadAsync(string path);

        /// <summary>
        /// Opens a text file, reads all lines of the file, and then closes the file.
        /// </summary>
        /// <param name="path">The file to open for reading.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task<string> ReadAllTextAsync(string path);

        /// <summary>
        /// Opens a file, reads all lines of the file with the specified encoding, and then closes the file.
        /// </summary>
        /// <param name="path">The file to open for reading.</param>
        /// <param name="encoding">The encoding applied to the contents of the file.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task<string> ReadAllTextAsync(string path, Encoding encoding);

        /// <summary>
        /// Opens a text file, reads all lines of the file, and then closes the file.
        /// </summary>
        /// <param name="path">The file to open for reading.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task<string[]> ReadAllLinesAsync(string path);

        /// <summary>
        /// Opens a file, reads all lines of the file with the specified encoding, and then closes the file.
        /// </summary>
        /// <param name="path">The file to open for reading.</param>
        /// <param name="encoding">The encoding applied to the contents of the file.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task<string[]> ReadAllLinesAsync(string path, Encoding encoding);

        /// <summary>
        /// Opens a binary file, reads the contents of the file into a byte array, and then closes the file. Returns null, if an exception is raised.
        /// </summary>
        /// <param name="path">The file to open for reading.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task<byte[]> ReadAllBytesAsync(string path);

        /// <summary>
        /// Creates a new file, writes the specified string to the file, and then closes the file. If the target file already exists, it is overwritten.
        /// </summary>
        /// <param name="path">The file to write to.</param>
        /// <param name="contents">The string to write to the file.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task WriteAllTextAsync(string path, string contents);

        /// <summary>
        /// Creates a new file, writes the specified string to the file using the specified encoding, and then closes the file. If the target file already exists, it is overwritten.
        /// </summary>
        /// <param name="path">The file to write to.</param>
        /// <param name="contents">The string to write to the file.</param>
        /// <param name="encoding">The encoding to apply to the string.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task WriteAllTextAsync(string path, string contents, Encoding encoding);

        /// <summary>
        /// Creates a new file, writes a collection of strings to the file, and then closes the file.
        /// </summary>
        /// <param name="path">The file to write to.</param>
        /// <param name="contents">The lines to write to the file.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task WriteAllLinesAsync(string path, IEnumerable<string> contents);

        /// <summary>
        /// Creates a new file by using the specified encoding, writes a collection of strings to the file, and then closes the file.
        /// </summary>
        /// <param name="path">The file to write to.</param>
        /// <param name="contents">The lines to write to the file.</param>
        /// <param name="encoding">The character encoding to use.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task WriteAllLinesAsync(string path, IEnumerable<string> contents, Encoding encoding);

        /// <summary>
        /// Creates a new file, writes the specified byte array to the file, and then closes the file. If the target file already exists, it is overwritten.
        /// </summary>
        /// <param name="path">The file to write to.</param>
        /// <param name="bytes">The bytes to write to the file.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task WriteAllBytesAsync(string path, byte[] bytes);

        /// <summary>
        /// Opens a file, appends the specified string to the file, and then closes the file. If the file does not exist, this method creates a file, writes the specified string to the file, then closes the file.
        /// </summary>
        /// <param name="path">The file to append the specified string to.</param>
        /// <param name="contents">The string to append to the file.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task AppendAllText(string path, string contents);

        /// <summary>
        /// Appends the specified string to the file, creating the file if it does not already exist.
        /// </summary>
        /// <param name="path">The file to append the specified string to.</param>
        /// <param name="contents">The string to append to the file.</param>
        /// <param name="encoding">The character encoding to use.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task AppendAllText(string path, string contents, Encoding encoding);

        /// <summary>
        /// Appends lines to a file, and then closes the file.
        /// </summary>
        /// <param name="path">The file to append the lines to. The file is created if it does not already exist.</param>
        /// <param name="contents">The lines to append to the file.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task AppendAllLines(string path, IEnumerable<string> contents);

        /// <summary>
        /// Appends lines to a file by using a specified encoding, and then closes the file.
        /// </summary>
        /// <param name="path">The file to append the lines to. The file is created if it does not already exist.</param>
        /// <param name="contents">The lines to append to the file.</param>
        /// <param name="encoding">The character encoding to use.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task AppendAllLines(string path, IEnumerable<string> contents, Encoding encoding);
    }
}