// ****************************************************************************
// <copyright file="WriteableBitmapExtensions.cs" company="Pedro Lamas">
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

#if WINDOWS_PHONE
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Cimbalino.Toolkit.Compression;
using Cimbalino.Toolkit.Helpers;
#else
using System;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Graphics.Imaging;
using Windows.UI.Xaml.Media.Imaging;
#endif

namespace Cimbalino.Toolkit.Extensions
{
    /// <summary>
    /// Provides a set of static (Shared in Visual Basic) methods for <see cref="WriteableBitmap"/> instances.
    /// </summary>
    public static class WriteableBitmapExtensions
    {
#if WINDOWS_PHONE
        private const string PngChunkTypeHeader = "IHDR";
        private const string PngChunkTypePhysical = "pHYs";
        ////private const string PngChunkTypeGamma = "gAMA";
        private const string PngChunkTypeData = "IDAT";
        private const string PngChunkTypeEnd = "IEND";

        private const byte PngHeaderBitDepth = 8;
        private const byte PngHeaderColorType = 6;
        private const byte PngHeaderCompressionMethod = 0;
        private const byte PngHeaderFilterMethod = 0;
        private const byte PngHeaderInterlaceMethod = 0;

        private const int MaximumChunkSize = 0xFFFF;
        private const double MetreToInch = 39.3700787d;
        private const double ResolutionDpi = 75.0;
#else
        private const double ResolutionDpi = 96.0;
#endif

        /// <summary>
        /// Encodes a WriteableBitmap object into a PNG stream.
        /// </summary>
        /// <param name="writeableBitmap">The writeable bitmap.</param>
        /// <param name="outputStream">The image data stream.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
#if WINDOWS_PHONE
        public static Task SavePngAsync(this WriteableBitmap writeableBitmap, Stream outputStream)
        {
            WriteHeader(outputStream, writeableBitmap);

            WritePhysics(outputStream);

            ////WriteGamma(outputStream);

            WriteDataChunks(outputStream, writeableBitmap);

            WriteFooter(outputStream);

            outputStream.Flush();

            return Task.FromResult(0);
        }
#else
        public static async Task SavePngAsync(this WriteableBitmap writeableBitmap, Stream outputStream)
        {
            var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, outputStream.AsRandomAccessStream());
            var pixels = writeableBitmap.PixelBuffer.ToArray();

            encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Straight, (uint)writeableBitmap.PixelWidth, (uint)writeableBitmap.PixelHeight, ResolutionDpi, ResolutionDpi, pixels);

            await encoder.FlushAsync();
        }
#endif

        /// <summary>
        /// Encodes a WriteableBitmap object into a JPEG stream, with parameters for setting the target quality of the JPEG file.
        /// </summary>
        /// <param name="writeableBitmap">The WriteableBitmap object.</param>
        /// <param name="outputStream">The image data stream.</param>
        /// <param name="quality">This parameter represents the quality of the JPEG photo with a range between 0 and 100, with 100 being the best photo quality. We recommend that you do not fall lower than a value of 70. because JPEG picture quality diminishes significantly below that level. </param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
#if WINDOWS_PHONE
        public static Task SaveJpegAsync(this WriteableBitmap writeableBitmap, Stream outputStream, int quality)
        {
            writeableBitmap.SaveJpeg(outputStream, writeableBitmap.PixelWidth, writeableBitmap.PixelHeight, 0, quality);

            return Task.FromResult(0);
        }
#else
        public static async Task SaveJpegAsync(this WriteableBitmap writeableBitmap, Stream outputStream, int quality)
        {
            var propertySet = new BitmapPropertySet
            {
                { "ImageQuality", new BitmapTypedValue(quality, PropertyType.Single) }
            };

            var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.JpegEncoderId, outputStream.AsRandomAccessStream(), propertySet);
            var pixels = writeableBitmap.PixelBuffer.ToArray();

            encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Premultiplied, (uint)writeableBitmap.PixelWidth, (uint)writeableBitmap.PixelHeight, ResolutionDpi, ResolutionDpi, pixels);

            await encoder.FlushAsync();
        }
#endif

#if WINDOWS_PHONE
        private static void WriteHeader(Stream outputStream, WriteableBitmap writeableBitmap)
        {
            outputStream.Write(new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A }, 0, 8);

            var chunkData = CreateChunk(
                writeableBitmap.PixelWidth,
                writeableBitmap.PixelHeight,
                PngHeaderBitDepth,
                PngHeaderColorType,
                PngHeaderCompressionMethod,
                PngHeaderFilterMethod,
                PngHeaderInterlaceMethod);

            WriteChunk(outputStream, PngChunkTypeHeader, chunkData);
        }

        private static void WritePhysics(Stream outputStream)
        {
            var dpmX = (int)Math.Round(ResolutionDpi * MetreToInch);
            var dpmY = (int)Math.Round(ResolutionDpi * MetreToInch);

            var chunkData = CreateChunk(dpmX, dpmY, (byte)1);

            WriteChunk(outputStream, PngChunkTypePhysical, chunkData);
        }

        ////private static void WriteGamma(Stream outputStream)
        ////{
        ////    var gammaValue = (int)(parameters.Gamma * 100000f);

        ////    var chunkData = CreateChunk(gammaValue);

        ////    WriteChunk(outputStream, PngChunkTypeGamma, chunkData);
        ////}

        private static void WriteDataChunks(Stream outputStream, WriteableBitmap writeableBitmap)
        {
            using (var chunkedStream = new ChunkedStream(MaximumChunkSize, data => WriteChunk(outputStream, PngChunkTypeData, data)))
            {
                using (var zlibStream = new ZlibStream(chunkedStream, CompressionMode.Compress, true))
                {
                    var pixels = writeableBitmap.Pixels;
                    var width = writeableBitmap.PixelWidth;
                    var height = writeableBitmap.PixelHeight;
                    var index = 0;

                    var dataRowLength = width * 4;
                    var dataRow = new byte[dataRowLength];

                    for (var y = 0; y < height; y++)
                    {
                        zlibStream.WriteByte(0);

                        for (var x = 0; x < width; x++)
                        {
                            var color = pixels[index++];

                            var alpha = (byte)(color >> 24);

                            int alphaInt = alpha;

                            if (alphaInt == 0)
                            {
                                alphaInt = 1;
                            }

                            alphaInt = (255 << 8) / alphaInt;

                            var dataRowOffset = x * 4;

                            dataRow[dataRowOffset] = (byte)((((color >> 16) & 0xFF) * alphaInt) >> 8);
                            dataRow[dataRowOffset + 1] = (byte)((((color >> 8) & 0xFF) * alphaInt) >> 8);
                            dataRow[dataRowOffset + 2] = (byte)(((color & 0xFF) * alphaInt) >> 8);
                            dataRow[dataRowOffset + 3] = alpha;
                        }

                        zlibStream.Write(dataRow, 0, dataRowLength);
                    }
                }
            }
        }

        private static void WriteFooter(Stream outputStream)
        {
            WriteChunk(outputStream, PngChunkTypeEnd, null);
        }

        private static void WriteChunk(Stream outputStream, string type, byte[] data)
        {
            var length = data != null ? data.Length : 0;

            outputStream.Write(CreateChunkFromInt(length), 0, 4);

            var typeData = CreateChunkFromString(type);

            outputStream.Write(typeData, 0, 4);

            var crc = Crc32.Update(0, typeData, 0, 4);

            if (data != null)
            {
                outputStream.Write(data, 0, length);

                crc = Crc32.Update(crc, data, 0, length);
            }

            outputStream.Write(CreateChunkFromUint(crc), 0, 4);
        }

        private static byte[] CreateChunk(params object[] paramObjects)
        {
            return paramObjects.SelectMany(x =>
            {
                if (x is byte)
                {
                    return new[] { (byte)x };
                }

                if (x is int)
                {
                    return CreateChunkFromInt((int)x);
                }

                if (x is uint)
                {
                    return CreateChunkFromUint((uint)x);
                }

                var stringValue = x as string;

                if (stringValue != null)
                {
                    return CreateChunkFromString(stringValue);
                }

                throw new ArgumentException();
            }).ToArray();
        }

        private static byte[] CreateChunkFromInt(int value)
        {
            var dataChunk = BitConverter.GetBytes(value);

            Array.Reverse(dataChunk);

            return dataChunk;
        }

        private static byte[] CreateChunkFromUint(uint value)
        {
            var dataChunk = BitConverter.GetBytes(value);

            Array.Reverse(dataChunk);

            return dataChunk;
        }

        private static byte[] CreateChunkFromString(string value)
        {
            return value
                .Select(x => (byte)x)
                .ToArray();
        }
#endif
    }
}