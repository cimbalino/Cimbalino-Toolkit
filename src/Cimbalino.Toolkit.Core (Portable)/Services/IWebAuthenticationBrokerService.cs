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
    public interface IWebAuthenticationBrokerService
    {
        Task<WebAuthenticationResult> AuthenticateAsync(WebAuthenticationOptions options, Uri uri, Uri callbackUri = null);
        void AuthenticateAndContinue(Uri uri);
        void AuthenticateAndContinue(Uri uri, Uri callbackUri);
        void AuthenticateAndContinue(Uri uri, Uri callbackUri, Dictionary<string, object> valueSet, WebAuthenticationOptions options);
        Task<WebAuthenticationResult> AuthenticateSilentlyAsync(Uri uri, WebAuthenticationOptions? options = null);
        Uri GetCurrentApplicationCallbackUri();
    }
}