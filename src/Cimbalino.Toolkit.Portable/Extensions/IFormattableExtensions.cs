// ****************************************************************************
// <copyright file="IFormattableExtensions.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2014
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <project>Cimbalino.Toolkit.Portable</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.Globalization;

namespace Cimbalino.Toolkit.Extensions
{
    /// <summary>
    /// Provides a set of static (Shared in Visual Basic) methods for <see cref="IFormattable"/> instances.
    /// </summary>
    public static class IFormattableExtensions
    {
        /// <summary>
        /// Converts the value of this instance to its equivalent string representation, using the specified format and an <see cref="CultureInfo.InvariantCulture"/>.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="format">A standard or custom format string.</param>
        /// <returns>The string representation of the value of this instance as specified by <paramref name="format"/>.</returns>
        public static string ToStringInvariantCulture(this IFormattable input, string format)
        {
            return input.ToString(format, CultureInfo.InvariantCulture);
        }
    }
}