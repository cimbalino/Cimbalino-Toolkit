// ****************************************************************************
// <copyright file="UriExtensions.cs" company="Pedro Lamas">
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
using System.Net;

namespace Cimbalino.Toolkit.Extensions
{
    /// <summary>
    /// Provides a set of static (Shared in Visual Basic) methods for <see cref="Uri"/> instances.
    /// </summary>
    public static class UriExtensions
    {
        /// <summary>
        /// Gets a collection of query string values.
        /// </summary>
        /// <param name="uri">The current uri.</param>
        /// <returns>A collection that contains the query string values.</returns>
        public static IDictionary<string, string> QueryString(this Uri uri)
        {
            var uriString = uri.IsAbsoluteUri ? uri.AbsoluteUri : uri.OriginalString;

            var queryIndex = uriString.IndexOf("?", StringComparison.OrdinalIgnoreCase);

            if (queryIndex == -1)
            {
                return new Dictionary<string, string>();
            }

            var query = uriString.Substring(queryIndex + 1);

            return query.Split('&')
                .Where(x => !string.IsNullOrEmpty(x))
                .Select(x => x.Split('='))
                .ToDictionary(x => WebUtility.UrlDecode(x[0]), x => x.Length == 2 && !string.IsNullOrEmpty(x[1]) ? WebUtility.UrlDecode(x[1]) : null);
        }
    }
}