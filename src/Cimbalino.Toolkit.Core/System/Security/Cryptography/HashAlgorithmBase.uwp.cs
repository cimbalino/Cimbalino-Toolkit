// ****************************************************************************
// <copyright file="HashAlgorithmBase.uwp.cs" company="Pedro Lamas">
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

using System.IO;
using System.Linq;
using Cimbalino.Toolkit.Extensions;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;

namespace System.Security.Cryptography
{
    /// <summary>
    /// Represents the base class from which all implementations of cryptographic hash algorithms must derive.
    /// </summary>
    public abstract class HashAlgorithmBase : IDisposable
    {
        /// <summary>
        /// Gets the hash algorithm name.
        /// </summary>
        /// <value>The hash algorithm name.</value>
        public string HashAlgorithmName { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HashAlgorithmBase"/> class.
        /// </summary>
        /// <param name="hashAlgorithmName">The hash algorithm name.</param>
        protected HashAlgorithmBase(string hashAlgorithmName)
        {
            HashAlgorithmName = hashAlgorithmName;
        }

        /// <summary>
        /// Computes the hash value for the specified byte array.
        /// </summary>
        /// <param name="buffer">The input to compute the hash code for.</param>
        /// <returns>The computed hash code.</returns>
        public virtual byte[] ComputeHash(byte[] buffer)
        {
            var inputBuffer = CryptographicBuffer.CreateFromByteArray(buffer);

            var hashAlgorithm = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmName);
            var outputBuffer = hashAlgorithm.HashData(inputBuffer);

            byte[] hash;

            CryptographicBuffer.CopyToByteArray(outputBuffer, out hash);

            return hash;
        }

        /// <summary>
        /// Computes the hash value for the specified byte array.
        /// </summary>
        /// <param name="input">The input <see cref="Stream"/> to compute the hash code for.</param>
        /// <returns>The computed hash code.</returns>
        public virtual byte[] ComputeHash(Stream input)
        {
            return ComputeHash(input.ToArray());
        }

        /// <summary>
        /// Computes the hash value for the specified byte array.
        /// </summary>
        /// <param name="buffer">The input to compute the hash code for.</param>
        /// <param name="offset">The offset into the byte array from which to begin using data.</param>
        /// <param name="count">The number of bytes in the array to use as data.</param>
        /// <returns>The computed hash code.</returns>
        public virtual byte[] ComputeHash(byte[] buffer, int offset, int count)
        {
            buffer = buffer
                .Skip(offset)
                .Take(count)
                .ToArray();

            return ComputeHash(buffer);
        }

        #region IDisposable Interface

        void IDisposable.Dispose()
        {
        }

        #endregion
    }
}