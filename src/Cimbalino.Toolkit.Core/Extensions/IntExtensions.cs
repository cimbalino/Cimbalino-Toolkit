// ****************************************************************************
// <copyright file="IntExtensions.cs" company="Pedro Lamas">
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
using System.Collections.Generic;
using System.Linq;

namespace Cimbalino.Toolkit.Extensions
{
    /// <summary>
    /// Provides a set of static (Shared in Visual Basic) methods for <see cref="int"/> instances.
    /// </summary>
    public static class IntExtensions
    {
        /// <summary>
        /// Repeats the specified <see cref="Action"/> the number of times.
        /// </summary>
        /// <param name="input">The number of times to repeat the <see cref="Action"/>.</param>
        /// <param name="action">The <see cref="Action"/> to repeat.</param>
        public static void Times(this int input, Action action)
        {
            while (input-- > 0)
            {
                action();
            }
        }

        /// <summary>
        /// Repeats the specified <see cref="Action{Int32}"/> the number of times.
        /// </summary>
        /// <param name="input">The number of times to repeat the <see cref="Action{Int32}"/>.</param>
        /// <param name="action">The <see cref="Action{Int32}"/> to repeat.</param>
        public static void Times(this int input, Action<int> action)
        {
            var count = 0;

            while (count < input)
            {
                action(count);

                count++;
            }
        }

        /// <summary>
        /// Repeats the specified <see cref="Func{T}"/> the number of times.
        /// </summary>
        /// <param name="input">The number of times to repeat the <see cref="Action"/>.</param>
        /// <param name="function">The <see cref="Func{T}"/> to repeat.</param>
        /// <typeparam name="T">The return value type.</typeparam>
        /// <returns>An enumerable with the results.</returns>
        public static IEnumerable<T> Times<T>(this int input, Func<T> function)
        {
            while (input-- > 0)
            {
                yield return function();
            }
        }

        /// <summary>
        /// Repeats the specified <see cref="Func{Int32,T}"/> the number of times.
        /// </summary>
        /// <param name="input">The number of times to repeat the <see cref="Action"/>.</param>
        /// <param name="function">The <see cref="Func{Int32,T}"/> to repeat.</param>
        /// <typeparam name="T">The return value type.</typeparam>
        /// <returns>An enumerable with the results.</returns>
        public static IEnumerable<T> Times<T>(this int input, Func<int, T> function)
        {
            var count = 0;

            while (count < input)
            {
                yield return function(count);

                count++;
            }
        }

        /// <summary>
        /// Generates a sequence of integral numbers within a specified range.
        /// </summary>
        /// <param name="first">The value of the first integer in the sequence.</param>
        /// <param name="count">The number of sequential integers to generate.</param>
        /// <returns>An <see cref="IEnumerable{Int32}"/> that contains a range of sequential integral numbers.</returns>
        public static IEnumerable<int> Range(this int first, int count)
        {
            return Enumerable.Range(first, count);
        }

        /// <summary>
        /// Generates a sequence of integral numbers within a specified range.
        /// </summary>
        /// <param name="first">The value of the first integer in the sequence.</param>
        /// <param name="last">The value of the last integer in the sequence.</param>
        /// <returns>An <see cref="IEnumerable{Int32}"/> that contains a range of sequential integral numbers.</returns>
        public static IEnumerable<int> To(this int first, int last)
        {
            return first.Range(last - first + 1);
        }

        /// <summary>
        /// Indicates whether the value is a prime number.
        /// </summary>
        /// <param name="input">The number to test.</param>
        /// <returns>true if the value is a prime number; otherwise, false.</returns>
        public static bool IsPrime(this int input)
        {
            if (input <= 3)
            {
                return input > 1;
            }

            if (input % 2 == 0 || input % 3 == 0)
            {
                return false;
            }

            for (var divider = 5; divider * divider <= input; divider += 6)
            {
                if (input % divider == 0 || input % (divider + 2) == 0)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Generates a list with all the prime factors for the input number.
        /// </summary>
        /// <param name="input">The number.</param>
        /// <returns>A list with all the prime factors for the input number.</returns>
        public static IEnumerable<int> PrimeFactors(this int input)
        {
            if (input == 1)
            {
                yield return 1;
            }

            while (input > 1)
            {
                var factor = 1;

                if (input % 2 == 0)
                {
                    factor = 2;
                }
                else if (input % 3 == 0)
                {
                    factor = 3;
                }
                else
                {
                    for (var divider = 5; divider <= input; divider += 6)
                    {
                        if (input % divider == 0)
                        {
                            factor = divider;

                            break;
                        }

                        if (input % (divider + 2) == 0)
                        {
                            factor = divider + 2;

                            break;
                        }
                    }
                }

                if (factor != 1)
                {
                    yield return factor;

                    input = input / factor;
                }
            }
        }
    }
}