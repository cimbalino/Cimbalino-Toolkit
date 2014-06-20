// ****************************************************************************
// <copyright file="ZlibStream.cs" company="Pedro Lamas">
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
using System.IO;
using System.IO.Compression;

namespace Cimbalino.Toolkit.Compression
{
    /// <summary>
    /// Provides methods and properties for compressing and decompressing streams by using the Zlib algorithm.
    /// </summary>
#if !NETFX_CORE
    [CLSCompliant(false)]
#endif
    public class ZlibStream : DeflateStream
    {
        private Stream _stream;
        private bool _leaveOpen;
        private uint _adler = 1;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZlibStream"/> class by using the specified stream and compression mode.
        /// </summary>
        /// <param name="stream">The stream to compress or decompress.</param>
        /// <param name="mode">One of the enumeration values that indicates whether to compress or decompress the stream.</param>
        public ZlibStream(Stream stream, CompressionMode mode)
            : this(stream, mode, true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZlibStream"/> class by using the specified stream and compression mode, and optionally leaves the stream open.
        /// </summary>
        /// <param name="stream">The stream to compress or decompress.</param>
        /// <param name="mode">One of the enumeration values that indicates whether to compress or decompress the stream.</param>
        /// <param name="leaveOpen">true to leave the stream open after disposing the DeflateStream object; otherwise, false.</param>
        public ZlibStream(Stream stream, CompressionMode mode, bool leaveOpen)
            : base(stream, mode, true)
        {
            _stream = stream;
            _leaveOpen = leaveOpen;

            WriteHeader();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZlibStream"/> class by using the specified stream and compression level.
        /// </summary>
        /// <param name="stream">The stream to compress or decompress.</param>
        /// <param name="compressionLevel">One of the enumeration values that indicates whether to emphasize speed or compression efficiency when compressing the stream.</param>
        public ZlibStream(Stream stream, CompressionLevel compressionLevel)
            : this(stream, compressionLevel, true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZlibStream"/> class by using the specified stream and compression level, and optionally leaves the stream open.
        /// </summary>
        /// <param name="stream">The stream to compress or decompress.</param>
        /// <param name="compressionLevel">One of the enumeration values that indicates whether to emphasize speed or compression efficiency when compressing the stream.</param>
        /// <param name="leaveOpen">true to leave the stream open after disposing the DeflateStream object; otherwise, false.</param>
        public ZlibStream(Stream stream, CompressionLevel compressionLevel, bool leaveOpen)
            : base(stream, compressionLevel, true)
        {
            _stream = stream;
            _leaveOpen = leaveOpen;

            WriteHeader();
        }

        /// <summary>
        /// Writes compressed bytes to the underlying stream from the specified byte array.
        /// </summary>
        /// <param name="array">The buffer that contains the data to compress.</param>
        /// <param name="offset">The byte offset in <paramref name="array"/> from which the bytes will be read.</param>
        /// <param name="count">The maximum number of bytes to write.</param>
        public override void Write(byte[] array, int offset, int count)
        {
            base.Write(array, offset, count);

            _adler = Adler32.Update(_adler, array, offset, count);
        }

        /// <summary>
        /// Releases the unmanaged resources used by the DeflateStream and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            WriteFooter();
        }

        private void WriteHeader()
        {
            _stream.Write(new byte[] { 0x58, 0x85 }, 0, 2);
        }

        private void WriteFooter()
        {
            var data = BitConverter.GetBytes(_adler);

            Array.Reverse(data);

            _stream.Write(data, 0, 4);

            if (!_leaveOpen)
            {
                _stream.Dispose();
            }

            _stream = null;
        }
    }
}