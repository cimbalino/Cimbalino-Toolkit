// ****************************************************************************
// <copyright file="StreamExtensions.cs" company="Pedro Lamas">
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
using System.IO;
using System.Threading.Tasks;
#else
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;
#endif

namespace Cimbalino.Toolkit.Extensions
{
    /// <summary>
    /// Provides a set of static (Shared in Visual Basic) methods for <see cref="Stream"/> instances.
    /// </summary>
    public static class StreamExtensions
    {
        /// <summary>
        /// Writes the stream contents to a byte array.
        /// </summary>
        /// <param name="input">The input stream.</param>
        /// <returns>A new byte array.</returns>
        public static byte[] ToArray(this Stream input)
        {
            using (var memoryStream = new MemoryStream())
            {
                input.CopyTo(memoryStream);

                return memoryStream.ToArray();
            }
        }

        /// <summary>
        /// Computes the SHA1 hash for the current byte array.
        /// </summary>
        /// <param name="input">The input <see cref="Stream"/> to compute the hash code for.</param>
        /// <returns>The computed hash code.</returns>
        public static byte[] ComputeSHA1Hash(this Stream input)
        {
#if PORTABLE
            return null;
#else
            using (var hash = new SHA1Managed())
            {
                return hash.ComputeHash(input);
            }
#endif
        }

        /// <summary>
        /// Computes the SHA256 hash for the current byte array.
        /// </summary>
        /// <param name="input">The input <see cref="Stream"/> to compute the hash code for.</param>
        /// <returns>The computed hash code.</returns>
        public static byte[] ComputeSHA256Hash(this Stream input)
        {
#if PORTABLE
            return null;
#else
            using (var hash = new SHA256Managed())
            {
                return hash.ComputeHash(input);
            }
#endif
        }

        /// <summary>
        /// Computes the MD5 hash for the current byte array.
        /// </summary>
        /// <param name="input">The input <see cref="Stream"/> to compute the hash code for.</param>
        /// <returns>The computed hash code.</returns>
        public static byte[] ComputeMD5Hash(this Stream input)
        {
#if PORTABLE
            return null;
#else
            using (var hash = new MD5Managed())
            {
                return hash.ComputeHash(input);
            }
#endif
        }

        /// <summary>
        /// Computes the HMACSHA1 hash for the current byte array.
        /// </summary>
        /// <param name="input">The input <see cref="Stream"/> to compute the hash code for.</param>
        /// <param name="key">The key to use in the hash algorithm.</param>
        /// <returns>The computed hash code.</returns>
        public static byte[] ComputeHMACSHA1Hash(this Stream input, byte[] key)
        {
#if PORTABLE
            return null;
#else
            using (var hash = new HMACSHA1())
            {
                hash.Key = key;

                return hash.ComputeHash(input);
            }
#endif
        }

        /// <summary>
        /// Computes the SHA256 hash for the current byte array.
        /// </summary>
        /// <param name="input">The input <see cref="Stream"/> to compute the hash code for.</param>
        /// <param name="key">The key to use in the hash algorithm.</param>
        /// <returns>The computed hash code.</returns>
        public static byte[] ComputeHMACSHA256Hash(this Stream input, byte[] key)
        {
#if PORTABLE
            return null;
#else
            using (var hash = new HMACSHA256())
            {
                hash.Key = key;

                return hash.ComputeHash(input);
            }
#endif
        }

        /// <summary>
        /// Writes the stream contents to a byte array.
        /// </summary>
        /// <param name="input">The input stream.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public static async Task<byte[]> ToArrayAsync(this Stream input)
        {
#if PORTABLE
            await Task.FromResult(0);

            return null;
#else
            var memoryStream = input as MemoryStream;

            if (memoryStream != null)
            {
                return memoryStream.ToArray();
            }

            using (memoryStream = new MemoryStream())
            {
                await input.CopyToAsync(memoryStream).ConfigureAwait(false);

                return memoryStream.ToArray();
            }
#endif
        }
    }
}