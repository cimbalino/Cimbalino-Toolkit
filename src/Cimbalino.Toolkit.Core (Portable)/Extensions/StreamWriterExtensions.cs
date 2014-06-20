// ****************************************************************************
// <copyright file="StreamWriterExtensions.cs" company="Pedro Lamas">
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
using System.Threading.Tasks;

namespace Cimbalino.Toolkit.Extensions
{
    /// <summary>
    /// Provides a set of static (Shared in Visual Basic) methods for <see cref="StreamWriter"/> instances.
    /// </summary>
    public static class StreamWriterExtensions
    {
        /// <summary>
        /// Writes all lines.
        /// </summary>
        /// <param name="streamWriter">The stream writer.</param>
        /// <param name="lines">The lines.</param>
        public static void WriteAllLines(this StreamWriter streamWriter, IEnumerable<string> lines)
        {
            foreach (var line in lines)
            {
                streamWriter.WriteLine(line);
            }
        }

        /// <summary>
        /// Writes all lines.
        /// </summary>
        /// <param name="streamWriter">The stream writer.</param>
        /// <param name="lines">The lines.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public async static Task WriteAllLinesAsync(this StreamWriter streamWriter, IEnumerable<string> lines)
        {
            foreach (var line in lines)
            {
                await streamWriter.WriteLineAsync(line).ConfigureAwait(false);
            }
        }
    }
}