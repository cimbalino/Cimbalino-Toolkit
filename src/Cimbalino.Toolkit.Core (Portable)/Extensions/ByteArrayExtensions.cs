// ****************************************************************************
// <copyright file="ByteArrayExtensions.cs" company="Pedro Lamas">
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
using System.Text;
#else
using System;
using System.Security.Cryptography;
using System.Text;
#endif

namespace Cimbalino.Toolkit.Extensions
{
    /// <summary>
    /// Provides a set of static (Shared in Visual Basic) methods for <see cref="byte"/> array instances.
    /// </summary>
    public static class ByteArrayExtensions
    {
        /// <summary>
        /// Converts an array of 8-bit unsigned integers to its equivalent <see cref="string"/> representation encoded with base 64 digits.
        /// </summary>
        /// <param name="input">An array of 8-bit unsigned integers.</param>
        /// <returns>The string representation, in base 64, of the contents of <paramref name="input"/>.</returns>
        public static string ToBase64String(this byte[] input)
        {
            return Convert.ToBase64String(input);
        }

        /// <summary>
        /// Converts an array of 8-bit unsigned integers to its equivalent <see cref="string"/> representation, using the specified <see cref="Encoding"/>.
        /// </summary>
        /// <param name="input">An array of 8-bit unsigned integers.</param>
        /// <param name="encoding">The <see cref="Encoding"/> to use for encoding the characters.</param>
        /// <returns>The string representation, of the contents of <paramref name="input"/>.</returns>
        public static string ToString(this byte[] input, Encoding encoding)
        {
            return encoding.GetString(input, 0, input.Length);
        }

        /// <summary>
        /// Computes the SHA1 hash for the current byte array using the managed library.
        /// </summary>
        /// <param name="input">An array of 8-bit unsigned integers.</param>
        /// <returns>The computed hash code.</returns>
        public static byte[] ComputeSHA1Hash(this byte[] input)
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
        /// Computes the SHA1 hash for the current byte array using the managed library.
        /// </summary>
        /// <param name="input">An array of 8-bit unsigned integers.</param>
        /// <param name="offset">The offset into the byte array from which to begin using data.</param>
        /// <param name="count">The number of bytes in the array to use as data.</param>
        /// <returns>The computed hash code.</returns>
        public static byte[] ComputeSHA1Hash(this byte[] input, int offset, int count)
        {
#if PORTABLE
            return null;
#else
            using (var hash = new SHA1Managed())
            {
                return hash.ComputeHash(input, offset, count);
            }
#endif
        }

        /// <summary>
        /// Computes the SHA256 hash for the current byte array using the managed library.
        /// </summary>
        /// <param name="input">An array of 8-bit unsigned integers.</param>
        /// <returns>The computed hash code.</returns>
        public static byte[] ComputeSHA256Hash(this byte[] input)
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
        /// Computes the SHA256 hash for the current byte array using the managed library.
        /// </summary>
        /// <param name="input">An array of 8-bit unsigned integers.</param>
        /// <param name="offset">The offset into the byte array from which to begin using data.</param>
        /// <param name="count">The number of bytes in the array to use as data.</param>
        /// <returns>The computed hash code.</returns>
        public static byte[] ComputeSHA256Hash(this byte[] input, int offset, int count)
        {
#if PORTABLE
            return null;
#else
            using (var hash = new SHA256Managed())
            {
                return hash.ComputeHash(input, offset, count);
            }
#endif
        }

        /// <summary>
        /// Computes the MD5 hash for the current byte array using the managed library.
        /// </summary>
        /// <param name="input">An array of 8-bit unsigned integers.</param>
        /// <returns>The computed hash code.</returns>
        public static byte[] ComputeMD5Hash(this byte[] input)
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
        /// Computes the MD5 hash for the current byte array using the managed library.
        /// </summary>
        /// <param name="input">An array of 8-bit unsigned integers.</param>
        /// <param name="offset">The offset into the byte array from which to begin using data.</param>
        /// <param name="count">The number of bytes in the array to use as data.</param>
        /// <returns>The computed hash code.</returns>
        public static byte[] ComputeMD5Hash(this byte[] input, int offset, int count)
        {
#if PORTABLE
            return null;
#else
            using (var hash = new MD5Managed())
            {
                return hash.ComputeHash(input, offset, count);
            }
#endif
        }

        /// <summary>
        /// Computes the HMACSHA1 hash for the current byte array using the managed library.
        /// </summary>
        /// <param name="input">An array of 8-bit unsigned integers.</param>
        /// <param name="key">The key to use in the hash algorithm.</param>
        /// <returns>The computed hash code.</returns>
        public static byte[] ComputeHMACSHA1Hash(this byte[] input, byte[] key)
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
        /// Computes the HMACSHA1 hash for the current byte array using the managed library.
        /// </summary>
        /// <param name="input">An array of 8-bit unsigned integers.</param>
        /// <param name="key">The key to use in the hash algorithm.</param>
        /// <param name="offset">The offset into the byte array from which to begin using data.</param>
        /// <param name="count">The number of bytes in the array to use as data.</param>
        /// <returns>The computed hash code.</returns>
        public static byte[] ComputeHMACSHA1Hash(this byte[] input, byte[] key, int offset, int count)
        {
#if PORTABLE
            return null;
#else
            using (var hash = new HMACSHA1())
            {
                hash.Key = key;

                return hash.ComputeHash(input, offset, count);
            }
#endif
        }

        /// <summary>
        /// Computes the HMACSHA256 hash for the current byte array using the managed library.
        /// </summary>
        /// <param name="input">An array of 8-bit unsigned integers.</param>
        /// <param name="key">The key to use in the hash algorithm.</param>
        /// <returns>The computed hash code.</returns>
        public static byte[] ComputeHMACSHA256Hash(this byte[] input, byte[] key)
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
        /// Computes the HMACSHA256 hash for the current byte array using the managed library.
        /// </summary>
        /// <param name="input">An array of 8-bit unsigned integers.</param>
        /// <param name="key">The key to use in the hash algorithm.</param>
        /// <param name="offset">The offset into the byte array from which to begin using data.</param>
        /// <param name="count">The number of bytes in the array to use as data.</param>
        /// <returns>The computed hash code.</returns>
        public static byte[] ComputeHMACSHA256Hash(this byte[] input, byte[] key, int offset, int count)
        {
#if PORTABLE
            return null;
#else
            using (var hash = new HMACSHA256())
            {
                hash.Key = key;

                return hash.ComputeHash(input, offset, count);
            }
#endif
        }

        /// <summary>
        /// Computes the HMACMD5 hash for the current byte array using the managed library.
        /// </summary>
        /// <param name="input">An array of 8-bit unsigned integers.</param>
        /// <param name="key">The key to use in the hash algorithm.</param>
        /// <returns>The computed hash code.</returns>
        public static byte[] ComputeHMACMD5Hash(this byte[] input, byte[] key)
        {
#if PORTABLE
            return null;
#else
            using (var hash = new HMACMD5())
            {
                hash.Key = key;

                return hash.ComputeHash(input);
            }
#endif
        }

        /// <summary>
        /// Computes the HMACMD5 hash for the current byte array using the managed library.
        /// </summary>
        /// <param name="input">An array of 8-bit unsigned integers.</param>
        /// <param name="key">The key to use in the hash algorithm.</param>
        /// <param name="offset">The offset into the byte array from which to begin using data.</param>
        /// <param name="count">The number of bytes in the array to use as data.</param>
        /// <returns>The computed hash code.</returns>
        public static byte[] ComputeHMACMD5Hash(this byte[] input, byte[] key, int offset, int count)
        {
#if PORTABLE
            return null;
#else
            using (var hash = new HMACMD5())
            {
                hash.Key = key;

                return hash.ComputeHash(input, offset, count);
            }
#endif
        }
    }
}