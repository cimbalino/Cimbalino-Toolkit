// ****************************************************************************
// <copyright file="WriteableBitmapExtensions.uwp.cs" company="Pedro Lamas">
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
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Graphics.Imaging;
using Windows.UI.Xaml.Media.Imaging;

namespace Cimbalino.Toolkit.Extensions
{
    /// <summary>
    /// Provides a set of static (Shared in Visual Basic) methods for <see cref="WriteableBitmap"/> instances.
    /// </summary>
    public static class WriteableBitmapExtensions
    {
        private const double ResolutionDpi = 96.0;

        /// <summary>
        /// Encodes a WriteableBitmap object into a PNG stream.
        /// </summary>
        /// <param name="writeableBitmap">The writeable bitmap.</param>
        /// <param name="outputStream">The image data stream.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public static async Task SavePngAsync(this WriteableBitmap writeableBitmap, Stream outputStream)
        {
            var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, outputStream.AsRandomAccessStream());
            var pixels = writeableBitmap.PixelBuffer.ToArray();

            encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Straight, (uint)writeableBitmap.PixelWidth, (uint)writeableBitmap.PixelHeight, ResolutionDpi, ResolutionDpi, pixels);

            await encoder.FlushAsync();
        }

        /// <summary>
        /// Encodes a WriteableBitmap object into a JPEG stream, with parameters for setting the target quality of the JPEG file.
        /// </summary>
        /// <param name="writeableBitmap">The WriteableBitmap object.</param>
        /// <param name="outputStream">The image data stream.</param>
        /// <param name="quality">This parameter represents the quality of the JPEG photo with a range between 0 and 100, with 100 being the best photo quality. We recommend that you do not fall lower than a value of 70. because JPEG picture quality diminishes significantly below that level. </param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public static async Task SaveJpegAsync(this WriteableBitmap writeableBitmap, Stream outputStream, int quality)
        {
            var propertySet = new BitmapPropertySet
            {
                { "ImageQuality", new BitmapTypedValue(quality, PropertyType.Single) },
            };

            var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.JpegEncoderId, outputStream.AsRandomAccessStream(), propertySet);
            var pixels = writeableBitmap.PixelBuffer.ToArray();

            encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Premultiplied, (uint)writeableBitmap.PixelWidth, (uint)writeableBitmap.PixelHeight, ResolutionDpi, ResolutionDpi, pixels);

            await encoder.FlushAsync();
        }
    }
}