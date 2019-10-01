// ****************************************************************************
// <copyright file="IComparableExtensions.cs" company="Pedro Lamas">
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
    /// Provides a set of static (Shared in Visual Basic) methods for <see cref="IComparable"/> instances.
    /// </summary>
    public static class IComparableExtensions
    {
        /// <summary>
        /// Checks if the value is between two other values.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="minValue">The lower value in the range.</param>
        /// <param name="maxValue">The upper value in the range.</param>
        /// <typeparam name="T">The values type.</typeparam>
        /// <returns>True if the value is between the two other values; otherwise, false.</returns>
        public static bool Between<T>(this T value, T minValue, T maxValue)
            where T : IComparable
        {
            return value.CompareTo(minValue) >= 0 && value.CompareTo(maxValue) <= 0;
        }

        /// <summary>
        /// Clamps the a value between two other values.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="minValue">The lower value in the range.</param>
        /// <param name="maxValue">The upper value in the range.</param>
        /// <typeparam name="T">The values type.</typeparam>
        /// <returns>The value clamped between the two other specified values.</returns>
        public static T Clamp<T>(this T value, T minValue, T maxValue)
            where T : IComparable
        {
            return value.Max(minValue).Min(maxValue);
        }

        /// <summary>
        /// Compares the current value with another value and returns the largest of the two.
        /// </summary>
        /// <param name="currentValue">The value.</param>
        /// <param name="value">The value to compare to.</param>
        /// <typeparam name="T">The values type.</typeparam>
        /// <returns>The largest of the two values.</returns>
        public static T Max<T>(this T currentValue, T value)
            where T : IComparable
        {
            if (currentValue.CompareTo(value) < 0)
            {
                return value;
            }

            return currentValue;
        }

        /// <summary>
        /// Compares the current value with another value and returns the smallest of the two.
        /// </summary>
        /// <param name="currentValue">The value.</param>
        /// <param name="value">The value to compare to.</param>
        /// <typeparam name="T">The values type.</typeparam>
        /// <returns>The smallest of the two values.</returns>
        public static T Min<T>(this T currentValue, T value)
            where T : IComparable
        {
            if (currentValue.CompareTo(value) > 0)
            {
                return value;
            }

            return currentValue;
        }

        /// <summary>
        /// Compares the current instance with another object of the same type and returns a boolean that indicates whether the ternary operation between the two values is true or false.
        /// </summary>
        /// <param name="currentValue">The value.</param>
        /// <param name="comparableOperator">The ternary operator.</param>
        /// <param name="value">The value to compare to.</param>
        /// <typeparam name="T">The values type.</typeparam>
        /// <returns>The bolean result of the ternary operation.</returns>
        public static bool CompareTo<T>(this T currentValue, ComparableOperator comparableOperator, T value)
            where T : IComparable
        {
            if (currentValue == null)
            {
                switch (comparableOperator)
                {
                    case ComparableOperator.Equal:
                    case ComparableOperator.LessThanOrEqual:
                    case ComparableOperator.GreaterThanOrEqual:
                        return value == null;

                    case ComparableOperator.NotEqual:
                    case ComparableOperator.LessThan:
                    case ComparableOperator.GreaterThan:
                        return value != null;

                    default:
                        throw new ArgumentOutOfRangeException(nameof(comparableOperator), comparableOperator, null);
                }
            }

            var result = currentValue.CompareTo(value);

            switch (comparableOperator)
            {
                case ComparableOperator.Equal:
                    return result == 0;

                case ComparableOperator.NotEqual:
                    return result != 0;

                case ComparableOperator.LessThan:
                    return result < 0;

                case ComparableOperator.LessThanOrEqual:
                    return result <= 0;

                case ComparableOperator.GreaterThan:
                    return result > 0;

                case ComparableOperator.GreaterThanOrEqual:
                    return result >= 0;

                default:
                    throw new ArgumentOutOfRangeException(nameof(comparableOperator), comparableOperator, null);
            }
        }
    }
}