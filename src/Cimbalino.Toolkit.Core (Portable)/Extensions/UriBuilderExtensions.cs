// ****************************************************************************
// <copyright file="UriBuilderExtensions.cs" company="Pedro Lamas">
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
using System.Net;

namespace Cimbalino.Toolkit.Extensions
{
    /// <summary>
    /// Provides a set of static (Shared in Visual Basic) methods for <see cref="UriBuilder"/> instances.
    /// </summary>
    public static class UriBuilderExtensions
    {
        /// <summary>
        /// Sets the scheme name of the URI.
        /// </summary>
        /// <param name="uriBuilder">The <see cref="UriBuilder"/> instance.</param>
        /// <param name="scheme">The scheme name of the uri.</param>
        /// <returns>The same <see cref="UriBuilder"/> instance.</returns>
        public static UriBuilder SetScheme(this UriBuilder uriBuilder, string scheme)
        {
            uriBuilder.Scheme = scheme;

            return uriBuilder;
        }

        /// <summary>
        /// Sets the user name associated with the user that accesses the URI.
        /// </summary>
        /// <param name="uriBuilder">The <see cref="UriBuilder"/> instance.</param>
        /// <param name="userName">The user name associated with the user that accesses the URI.</param>
        /// <returns>The same <see cref="UriBuilder"/> instance.</returns>
        public static UriBuilder SetUserName(this UriBuilder uriBuilder, string userName)
        {
            uriBuilder.UserName = userName;

            return uriBuilder;
        }

        /// <summary>
        /// Sets the password associated with the user that accesses the URI.
        /// </summary>
        /// <param name="uriBuilder">The <see cref="UriBuilder"/> instance.</param>
        /// <param name="password">The password associated with the user that accesses the URI.</param>
        /// <returns>The same <see cref="UriBuilder"/> instance.</returns>
        public static UriBuilder SetPassword(this UriBuilder uriBuilder, string password)
        {
            uriBuilder.Password = password;

            return uriBuilder;
        }

        /// <summary>
        /// Sets the Domain Name System (DNS) host name or IP address of a server.
        /// </summary>
        /// <param name="uriBuilder">The <see cref="UriBuilder"/> instance.</param>
        /// <param name="host">The Domain Name System (DNS) host name or IP address of a server.</param>
        /// <returns>The same <see cref="UriBuilder"/> instance.</returns>
        public static UriBuilder SetHost(this UriBuilder uriBuilder, string host)
        {
            uriBuilder.Host = host;

            return uriBuilder;
        }

        /// <summary>
        /// Sets the port number of the URI.
        /// </summary>
        /// <param name="uriBuilder">The <see cref="UriBuilder"/> instance.</param>
        /// <param name="port">The port number of the URI.</param>
        /// <returns>The same <see cref="UriBuilder"/> instance.</returns>
        public static UriBuilder SetPort(this UriBuilder uriBuilder, int port)
        {
            uriBuilder.Port = port;

            return uriBuilder;
        }

        /// <summary>
        /// Sets the path to the resource referenced by the URI.
        /// </summary>
        /// <param name="uriBuilder">The <see cref="UriBuilder"/> instance.</param>
        /// <param name="path">The path to the resource referenced by the URI.</param>
        /// <returns>The same <see cref="UriBuilder"/> instance.</returns>
        public static UriBuilder SetPath(this UriBuilder uriBuilder, string path)
        {
            uriBuilder.Path = path;

            return uriBuilder;
        }

        /// <summary>
        /// Sets the path to the resource referenced by the URI.
        /// </summary>
        /// <param name="uriBuilder">The <see cref="UriBuilder"/> instance.</param>
        /// <param name="path">The path to the resource referenced by the URI, as a composite format string.</param>
        /// <param name="parameters">An object array that contains zero or more objects to format.</param>
        /// <returns>The same <see cref="UriBuilder"/> instance.</returns>
        public static UriBuilder SetPath(this UriBuilder uriBuilder, string path, params object[] parameters)
        {
            uriBuilder.Path = string.Format(path, parameters);

            return uriBuilder;
        }

        /// <summary>
        /// Sets the fragment portion of the URI.
        /// </summary>
        /// <param name="uriBuilder">The <see cref="UriBuilder"/> instance.</param>
        /// <param name="fragment">The fragment portion of the URI.</param>
        /// <returns>The same <see cref="UriBuilder"/> instance.</returns>
        public static UriBuilder SetFragment(this UriBuilder uriBuilder, string fragment)
        {
            uriBuilder.Fragment = fragment;

            return uriBuilder;
        }

        /// <summary>
        /// Sets any query information included in the URI.
        /// </summary>
        /// <param name="uriBuilder">The <see cref="UriBuilder"/> instance.</param>
        /// <param name="query">The query information included in the URI.</param>
        /// <returns>The same <see cref="UriBuilder"/> instance.</returns>
        public static UriBuilder SetQuery(this UriBuilder uriBuilder, string query)
        {
            uriBuilder.Query = query;

            return uriBuilder;
        }

        /// <summary>
        /// Appends a key value pair to the current query information included in the URI.
        /// </summary>
        /// <param name="uriBuilder">The <see cref="UriBuilder"/> instance.</param>
        /// <param name="key">The key to add to the current query information included in the URI.</param>
        /// <param name="value">The value to add to the current query information included in the URI.</param>
        /// <returns>The same <see cref="UriBuilder"/> instance.</returns>
        public static UriBuilder AppendQueryParameter(this UriBuilder uriBuilder, string key, string value)
        {
            var query = uriBuilder.Query;

            if (string.IsNullOrEmpty(query))
            {
                uriBuilder.Query = string.Format("{0}={1}",
                    WebUtility.UrlEncode(key),
                    WebUtility.UrlEncode(value));
            }
            else
            {
                uriBuilder.Query = string.Format("{0}&{1}={2}",
                    query.Substring(1),
                    WebUtility.UrlEncode(key),
                    WebUtility.UrlEncode(value));
            }

            return uriBuilder;
        }

        /// <summary>
        /// Appends a key value pair to the current query information included in the URI, if the value is not null or empty.
        /// </summary>
        /// <param name="uriBuilder">The <see cref="UriBuilder"/> instance.</param>
        /// <param name="key">The key to add to the current query information included in the URI.</param>
        /// <param name="value">The value to add to the current query information included in the URI.</param>
        /// <returns>The same <see cref="UriBuilder"/> instance.</returns>
        public static UriBuilder AppendQueryParameterIfValueNotEmpty(this UriBuilder uriBuilder, string key, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                uriBuilder.AppendQueryParameter(key, value);
            }

            return uriBuilder;
        }

        /// <summary>
        /// Gets the <see cref="Uri"/> instance constructed by the specified <see cref="UriBuilder"/> instance.
        /// </summary>
        /// <param name="uriBuilder">The <see cref="UriBuilder"/> instance.</param>
        /// <returns>The <see cref="Uri"/> instance constructed by the specified <see cref="UriBuilder"/> instance.</returns>
        public static Uri Build(this UriBuilder uriBuilder)
        {
            return uriBuilder.Uri;
        }
    }
}