// ****************************************************************************
// <copyright file="DateTimeOffsetExtensions.cs" company="Pedro Lamas">
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

namespace Cimbalino.Toolkit.Extensions
{
    /// <summary>
    /// Provides a set of static (Shared in Visual Basic) methods for <see cref="DateTimeOffset"/> instances.
    /// </summary>
    public static class DateTimeOffsetExtensions
    {
        private static readonly DateTimeOffset EpochDateTime = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);

        /// <summary>
        /// Converts the indicated <see cref="DateTimeOffset"/> instance to the equivalent unix time representation.
        /// </summary>
        /// <param name="dateTimeOffset">The <see cref="DateTimeOffset"/> instance.</param>
        /// <returns>The unix time representation of the <see cref="DateTimeOffset"/> instance.</returns>
        public static double ToUnixTime(this DateTimeOffset dateTimeOffset)
        {
            return dateTimeOffset.ToUniversalTime().Subtract(EpochDateTime).TotalSeconds;
        }
    }
}