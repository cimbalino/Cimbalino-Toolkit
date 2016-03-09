// ****************************************************************************
// <copyright file="CompressionLevel.cs" company="Pedro Lamas">
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

namespace Cimbalino.Toolkit.Compression
{
    /// <summary>
    /// Specifies values that indicate whether a compression operation emphasizes speed or compression size.
    /// </summary>
    public enum CompressionLevel
    {
        /// <summary>
        /// The compression operation should be optimally compressed, even if the operation takes a longer time to complete.
        /// </summary>
        Optimal,

        /// <summary>
        /// The compression operation should complete as quickly as possible, even if the resulting file is not optimally compressed.
        /// </summary>
        Fastest,

        /// <summary>
        /// No compression should be performed on the file.
        /// </summary>
        NoCompression
    }
}