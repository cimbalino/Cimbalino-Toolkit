// ****************************************************************************
// <copyright file="ICollectionExtensions.cs" company="Pedro Lamas">
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

using System.Collections.Generic;

namespace Cimbalino.Toolkit.Extensions
{
    /// <summary>
    /// Provides a set of static (Shared in Visual Basic) methods for <see cref="ICollection{TSource}"/> instances.
    /// </summary>
    public static class ICollectionExtensions
    {
        /// <summary>
        /// Determines whether the specified <see cref="ICollection{TSource}"/> is empty.
        /// </summary>
        /// <param name="collection">The <see cref="ICollection{TSource}"/> to check.</param>
        /// <typeparam name="TSource">The collection items type.</typeparam>
        /// <returns>True if the collection is empty; otherwise, false.</returns>
        public static bool IsEmpty<TSource>(this ICollection<TSource> collection)
        {
            return collection.Count == 0;
        }

        /// <summary>
        /// Adds the elements of the specified collection to the end of the <see cref="ICollection{TSource}"/>.
        /// </summary>
        /// <param name="sourceCollection">The <see cref="ICollection{TSource}"/>.</param>
        /// <param name="collection">The collection whose elements should be added to the end of the <see cref="ICollection{TSource}"/>. The collection itself cannot be null, but it can contain elements that are null, if type TSource is a reference type.</param>
        /// <typeparam name="TSource">The collection items type.</typeparam>
        public static void AddRange<TSource>(this ICollection<TSource> sourceCollection, IEnumerable<TSource> collection)
        {
            foreach (var item in collection)
            {
                sourceCollection.Add(item);
            }
        }
    }
}