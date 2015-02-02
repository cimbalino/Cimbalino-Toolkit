// ****************************************************************************
// <copyright file="DateTimeExtensions.cs" company="Pedro Lamas">
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
    /// Provides a set of static (Shared in Visual Basic) methods for <see cref="DateTime"/> instances.
    /// </summary>
    public static class DateTimeExtensions
    {
        private static readonly DateTime EpochDateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Converts the indicated <see cref="DateTime"/> instance to the equivalent unix time representation.
        /// </summary>
        /// <param name="dateTime">The <see cref="DateTime"/> instance.</param>
        /// <returns>The unix time representation of the <see cref="DateTime"/> instance.</returns>
        public static double ToUnixTime(this DateTime dateTime)
        {
            return dateTime.ToUniversalTime().Subtract(EpochDateTime).TotalSeconds;
        }
    }
}