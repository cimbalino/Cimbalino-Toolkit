// ****************************************************************************
// <copyright file="IWebAuthenticationBrokerService.cs" company="Pedro Lamas">
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
using System.Threading.Tasks;

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Interface for a service to aid with using the web authentication broker
    /// </summary>
    public interface IWebAuthenticationBrokerService
    {
        /// <summary>
        /// Authenticates the.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="uri">The URI.</param>
        /// <param name="callbackUri">The callback URI.</param>
        /// <returns></returns>
        Task<WebAuthenticationResult> AuthenticateAsync(WebAuthenticationOptions options, Uri uri, Uri callbackUri = null);
        
        /// <summary>
        /// Authenticates and continues.
        /// </summary>
        /// <param name="uri">The URI.</param>
        void AuthenticateAndContinue(Uri uri);

        /// <summary>
        /// Authenticates and continues.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <param name="callbackUri">The callback URI.</param>
        void AuthenticateAndContinue(Uri uri, Uri callbackUri);

        /// <summary>
        /// Authenticates and continues.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <param name="callbackUri">The callback URI.</param>
        /// <param name="valueSet">The value set.</param>
        /// <param name="options">The options.</param>
        void AuthenticateAndContinue(Uri uri, Uri callbackUri, Dictionary<string, object> valueSet, WebAuthenticationOptions options);
       
        /// <summary>
        /// Authenticates the silently.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <param name="options">The options.</param>
        /// <returns></returns>
        Task<WebAuthenticationResult> AuthenticateSilentlyAsync(Uri uri, WebAuthenticationOptions? options = null);
        
        /// <summary>
        /// Gets the current application callback URI.
        /// </summary>
        /// <returns></returns>
        Uri GetCurrentApplicationCallbackUri();
    }
}