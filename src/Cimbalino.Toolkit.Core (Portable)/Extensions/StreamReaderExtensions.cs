// ****************************************************************************
// <copyright file="StreamReaderExtensions.cs" company="Pedro Lamas">
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

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Cimbalino.Toolkit.Extensions
{
    /// <summary>
    /// Provides a set of static (Shared in Visual Basic) methods for <see cref="StreamReader"/> instances.
    /// </summary>
    public static class StreamReaderExtensions
    {
        /// <summary>
        /// Reads the lines of a stream.
        /// </summary>
        /// <param name="streamReader">The <see cref="StreamReader"/> instance.</param>
        /// <returns>The lines of the stream.</returns>
        public static IEnumerable<string> ReadLines(this StreamReader streamReader)
        {
            while (!streamReader.EndOfStream)
            {
                yield return streamReader.ReadLine();
            }
        }

        /// <summary>
        /// Reads all lines of the stream.
        /// </summary>
        /// <param name="streamReader">The <see cref="StreamReader"/> instance.</param>
        /// <returns>A string array containing all lines of the stream.</returns>
        public static string[] ReadAllLines(this StreamReader streamReader)
        {
            return streamReader.ReadLines().ToArray();
        }

        /// <summary>
        /// Reads all lines of the stream.
        /// </summary>
        /// <param name="streamReader">The <see cref="StreamReader"/> instance.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public static Task<string[]> ReadAllLinesAsync(this StreamReader streamReader)
        {
            return Task.Factory.StartNew<string[]>(streamReader.ReadAllLines);
        }
    }
}