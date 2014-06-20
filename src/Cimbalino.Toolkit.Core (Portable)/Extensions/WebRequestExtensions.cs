// ****************************************************************************
// <copyright file="WebRequestExtensions.cs" company="Pedro Lamas">
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
using System.Globalization;
using System.Net;

namespace Cimbalino.Toolkit.Extensions
{
    /// <summary>
    /// Provides a set of static (Shared in Visual Basic) methods for <see cref="WebRequest"/> instances.
    /// </summary>
    public static class WebRequestExtensions
    {
        private const string NoCacheHeaderValue = "no-cache";

        /// <summary>
        /// Set <see cref="WebRequest.Headers"/> collection with "no-cache header values.
        /// </summary>
        /// <param name="request">The web request.</param>
        public static void SetNoCacheHeaders(this WebRequest request)
        {
            request.Headers[HttpRequestHeader.CacheControl] = NoCacheHeaderValue;
            request.Headers[HttpRequestHeader.Pragma] = NoCacheHeaderValue;
            request.Headers[HttpRequestHeader.IfModifiedSince] = DateTime.UtcNow.ToString(CultureInfo.InvariantCulture);
        }
    }
}