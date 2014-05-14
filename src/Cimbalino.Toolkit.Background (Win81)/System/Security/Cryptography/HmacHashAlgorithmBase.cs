// ****************************************************************************
// <copyright file="HmacHashAlgorithmBase.cs" company="Pedro Lamas">
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

using System.Linq;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;

namespace System.Security.Cryptography
{
    /// <summary>
    /// Represents the abstract class from which all implementations of Hash-based Message Authentication Code (HMAC) must derive.
    /// </summary>
    public class HmacHashAlgorithmBase : HashAlgorithmBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HmacHashAlgorithmBase"/> class.
        /// </summary>
        /// <param name="hashAlgorithmName">The hash algorithm name.</param>
        protected HmacHashAlgorithmBase(string hashAlgorithmName)
            : base(hashAlgorithmName)
        {
        }

        /// <summary>
        /// Gets or sets the key to use in the hash algorithm.
        /// </summary>
        /// <value>The key to use in the hash algorithm.</value>
        public byte[] Key { get; set; }

        /// <summary>
        /// Computes the hash value for the specified byte array.
        /// </summary>
        /// <param name="buffer">The input to compute the hash code for.</param>
        /// <returns>The computed hash code.</returns>
        public override byte[] ComputeHash(byte[] buffer)
        {
            var inputBuffer = CryptographicBuffer.CreateFromByteArray(buffer.ToArray());

            var macHashAlgorithm = MacAlgorithmProvider.OpenAlgorithm(HashAlgorithmName);
            var cryptographicKey = macHashAlgorithm.CreateKey(CryptographicBuffer.CreateFromByteArray(Key));
            var outputBuffer = CryptographicEngine.Sign(cryptographicKey, inputBuffer);

            byte[] hash;

            CryptographicBuffer.CopyToByteArray(outputBuffer, out hash);

            return hash;
        }
    }
}