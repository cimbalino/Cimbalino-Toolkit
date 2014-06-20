// ****************************************************************************
// <copyright file="IEnumerableExtensions.cs" company="Pedro Lamas">
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
using System.Collections.ObjectModel;
using System.Linq;
using Cimbalino.Toolkit.Helpers;

namespace Cimbalino.Toolkit.Extensions
{
    /// <summary>
    /// Provides a set of static (Shared in Visual Basic) methods for <see cref="IEnumerable{TResult}"/> instances.
    /// </summary>
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Applies the specified <see cref="Action{TResult}"/> to the enumerable.
        /// </summary>
        /// <param name="source">The enumerable.</param>
        /// <param name="action">The action to apply.</param>
        /// <typeparam name="TResult">The type of items in the enumerable.</typeparam>
        public static void Apply<TResult>(this IEnumerable<TResult> source, Action<TResult> action)
        {
            foreach (var item in source)
            {
                action(item);
            }
        }

        /// <summary>
        /// Applies the specified <see cref="Action{TResult,Int32}"/> to the enumerable.
        /// </summary>
        /// <param name="source">The enumerable.</param>
        /// <param name="action">The action to apply.</param>
        /// <typeparam name="TResult">The type of items in the enumerable.</typeparam>
        public static void Apply<TResult>(this IEnumerable<TResult> source, Action<TResult, int> action)
        {
            var index = 0;

            foreach (var item in source)
            {
                action(item, index);

                index++;
            }
        }

        /// <summary>
        /// Returns a collection of the descendant elements for this enumerable, using the specified <see cref="Func{TResult,IEnumerable}"/> function.
        /// </summary>
        /// <param name="source">The enumerable.</param>
        /// <param name="descendBy">The function to use for descending.</param>
        /// <returns>All the descendant items.</returns>
        /// <typeparam name="TResult">The type of items in the enumerable.</typeparam>
        public static IEnumerable<TResult> Descendants<TResult>(this IEnumerable<TResult> source, Func<TResult, IEnumerable<TResult>> descendBy)
        {
            foreach (var value in source)
            {
                yield return value;

                foreach (var child in descendBy(value).Descendants<TResult>(descendBy))
                {
                    yield return child;
                }
            }
        }

        /// <summary>
        /// Creates an <see cref="ObservableCollection{TResult}"/> from this enumerable.
        /// </summary>
        /// <param name="source">The enumerable.</param>
        /// <returns>An <see cref="ObservableCollection{TResult}"/> that contains the elements from the input sequence.</returns>
        /// <typeparam name="TResult">The type of items in the enumerable.</typeparam>
        public static ObservableCollection<TResult> ToObservableCollection<TResult>(this IEnumerable<TResult> source)
        {
            return new ObservableCollection<TResult>(source);
        }

        /// <summary>
        /// Creates an <see cref="OptimizedObservableCollection{T}"/> from this enumerable.
        /// </summary>
        /// <param name="source">The enumerable.</param>
        /// <returns>An <see cref="OptimizedObservableCollection{TResult}"/> that contains the elements from the input sequence.</returns>
        /// <typeparam name="TResult">The type of items in the enumerable.</typeparam>
        public static OptimizedObservableCollection<TResult> ToOptimizedObservableCollection<TResult>(this IEnumerable<TResult> source)
        {
            return new OptimizedObservableCollection<TResult>(source);
        }

        /// <summary>
        /// Produces a sequence containing the current elements along with the specified element.
        /// </summary>
        /// <param name="source">The enumerable.</param>
        /// <param name="element">A <typeparamref name="TResult"/> element to include in the sequence.</param>
        /// <returns>An <see cref="IEnumerable{TResult}"/> that contains the current elements along with the specified element.</returns>
        /// <typeparam name="TResult">The type of items in the enumerable.</typeparam>
        public static IEnumerable<TResult> Concat<TResult>(this IEnumerable<TResult> source, TResult element)
        {
            foreach (var value in source)
            {
                yield return value;
            }

            yield return element;
        }

        /// <summary>
        /// Produces a sequence containing a subset of the current elements, starting from the specified position.
        /// </summary>
        /// <param name="source">The enumerable.</param>
        /// <param name="offset">The zero-based offset at which to begin returning items from the enumerable.</param>
        /// <param name="count">The number of items to return from the enumerable.</param>
        /// <returns>An <see cref="IEnumerable{TResult}"/> that contains a subset of the current elements, starting from the specified position.</returns>
        /// <typeparam name="TResult">The type of items in the enumerable.</typeparam>
        public static IEnumerable<TResult> Slice<TResult>(this IEnumerable<TResult> source, int offset, int count)
        {
            return source
                .Skip(offset)
                .Take(count);
        }

        /// <summary>
        /// Produces a sequence containing the current elements randomly shuffled.
        /// </summary>
        /// <typeparam name="TResult">The type of items in the enumerable.</typeparam>
        /// <param name="source">The enumerable.</param>
        /// <returns>A sequence containing the current elements randomly shuffled.</returns>
        public static IEnumerable<TResult> Shuffle<TResult>(this IEnumerable<TResult> source)
        {
            var random = new Random();

            return source
                .OrderBy(x => random.Next());
        }

        /// <summary>
        /// Produces a sequence containing the current elements randomly shuffled, using the specified seed to calculate a starting value for the pseudo-random number sequence.
        /// </summary>
        /// <typeparam name="TResult">The type of items in the enumerable.</typeparam>
        /// <param name="source">The enumerable.</param>
        /// <param name="seed">A number used to calculate a starting value for the pseudo-random number sequence. If a negative number is specified, the absolute value of the number is used.</param>
        /// <returns>A sequence containing the current elements randomly shuffled.</returns>
        public static IEnumerable<TResult> Shuffle<TResult>(this IEnumerable<TResult> source, int seed)
        {
            var random = new Random(seed);

            return source
                .OrderBy(x => random.Next());
        }

        /// <summary>
        /// Produces a sequence containing batches of the current elements with the specified size.
        /// </summary>
        /// <param name="source">The enumerable.</param>
        /// <param name="batchSize">The batch size.</param>
        /// <typeparam name="TResult">The type of items in the enumerable.</typeparam>
        /// <returns>A sequence containing batches of the current elements with the specified size.</returns>
        /// <exception cref="ArgumentException">If the batch size is below 1.</exception>
        public static IEnumerable<IEnumerable<TResult>> Batch<TResult>(this IEnumerable<TResult> source, int batchSize)
        {
            if (batchSize < 1)
            {
                throw new ArgumentException("Batch size must be greater or equal to 1", "batchSize");
            }

            var buffer = new List<TResult>();

            foreach (var item in source)
            {
                buffer.Add(item);

                if (buffer.Count == batchSize)
                {
                    yield return buffer
                        .ToArray();

                    buffer.Clear();
                }
            }

            if (buffer.Count > 0)
            {
                yield return buffer
                    .ToArray();
            }
        }
    }
}