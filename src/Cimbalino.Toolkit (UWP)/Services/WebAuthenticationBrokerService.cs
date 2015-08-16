// ****************************************************************************
// <copyright file="WebAuthenticationBrokerService.cs" company="Pedro Lamas">
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
#if WINDOWS_PHONE
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cimbalino.Toolkit.Helpers;
#elif WINDOWS_APP
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Security.Authentication.Web;
using Cimbalino.Toolkit.Helpers;
#else
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Foundation.Collections;
using Windows.Security.Authentication.Web;
using Cimbalino.Toolkit.Helpers;
#endif

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// A service to aid with Web Authentication Broker calls
    /// </summary>
    public class WebAuthenticationBrokerService : IWebAuthenticationBrokerService
    {
        /// <summary>
        /// Authenticates.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="uri">The URI.</param>
        /// <param name="callbackUri">The callback URI.</param>
        /// <returns>The task</returns>
        public virtual async Task<WebAuthenticationResult> AuthenticateAsync(WebAuthenticationOptions options, Uri uri, Uri callbackUri = null)
        {
#if WINDOWS_PHONE
            var message = WebAuthenticationHelper.IsSupported() ? "WebAuthenticationBroker is not supported on this platform" : "AuthenticateAsync is not supported on this platform";
            return ExceptionHelper.ThrowNotSupported<WebAuthenticationResult>(message);
#else
            var result = await WebAuthenticationBroker.AuthenticateAsync((Windows.Security.Authentication.Web.WebAuthenticationOptions) options, uri, callbackUri);
            return new WebAuthenticationResult
            {
                ResponseData = result.ResponseData,
                ResponseErrorData = result.ResponseErrorDetail,
                ResponseStatus = (WebAuthenticationStatus)result.ResponseStatus
            };
#endif
        }

        /// <summary>
        /// Authenticates and continues.
        /// </summary>
        /// <param name="uri">The URI.</param>
        public virtual void AuthenticateAndContinue(Uri uri)
        {
#if WINDOWS_PHONE
            if (WebAuthenticationHelper.IsSupported())
            {
                var broker = WebAuthenticationHelper.CreateBroker();
                var methodInfo = broker.GetMethod("AuthenticateAndContinue", new[] { typeof(Uri) });
                methodInfo.Invoke(null, new object[] { uri });
            }
            else
            {
                ExceptionHelper.ThrowNotSupported();
            }
#elif WINDOWS_APP
            ExceptionHelper.ThrowNotSupported("AuthenticateAndContinue does not exist in Windows 8.1 Store apps");
#else
            WebAuthenticationBroker.AuthenticateAndContinue(uri);
#endif
        }

        /// <summary>
        /// Authenticates and continues.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <param name="callbackUri">The callback URI.</param>
        public virtual void AuthenticateAndContinue(Uri uri, Uri callbackUri)
        {
#if WINDOWS_PHONE
            if (WebAuthenticationHelper.IsSupported())
            {
                var broker = WebAuthenticationHelper.CreateBroker();
                var methodInfo = broker.GetMethod("AuthenticateAndContinue", new[] { typeof(Uri), typeof(Uri) });
                methodInfo.Invoke(null, new object[] { uri });
            }
            else
            {
                ExceptionHelper.ThrowNotSupported();
            }
#elif WINDOWS_APP
            ExceptionHelper.ThrowNotSupported("AuthenticateAndContinue does not exist in Windows 8.1 Store apps");
#else
            WebAuthenticationBroker.AuthenticateAndContinue(uri, callbackUri);
#endif
        }

        /// <summary>
        /// Authenticates and continues.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <param name="callbackUri">The callback URI.</param>
        /// <param name="valueSet">The value set.</param>
        /// <param name="options">The options.</param>
        public virtual void AuthenticateAndContinue(Uri uri, Uri callbackUri, Dictionary<string, object> valueSet, WebAuthenticationOptions options)
        {
#if WINDOWS_PHONE
            if (WebAuthenticationHelper.IsSupported())
            {
                var broker = WebAuthenticationHelper.CreateBroker();
                var methodInfo = broker.GetMethod("AuthenticateAndContinue", new[] { typeof(Uri), typeof(Uri), WebAuthenticationHelper.GetValueSetType(), WebAuthenticationHelper.GetOptionsType() });
                methodInfo.Invoke(null, new object[] { uri, callbackUri, WebAuthenticationHelper.CreateValueSet(valueSet), options });
            }
            else
            {
                ExceptionHelper.ThrowNotSupported();
            }
#elif WINDOWS_APP
            ExceptionHelper.ThrowNotSupported("AuthenticateAndContinue does not exist in Windows 8.1 Store apps");
#else
            var vs = new ValueSet();
            if (valueSet != null)
            {
                foreach (var value in valueSet)
                {
                    vs.Add(value);
                }
            }

            WebAuthenticationBroker.AuthenticateAndContinue(uri, callbackUri, vs, (Windows.Security.Authentication.Web.WebAuthenticationOptions) options);
#endif
        }

        /// <summary>
        /// Authenticates the silently asynchronous.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <param name="options">The options.</param>
        /// <returns>The web authentication results</returns>
        public virtual async Task<WebAuthenticationResult> AuthenticateSilentlyAsync(Uri uri, WebAuthenticationOptions? options = null)
        {
#if WINDOWS_PHONE
            if (WebAuthenticationHelper.IsSupported())
            {
                var broker = WebAuthenticationHelper.CreateBroker();
                dynamic result;

                if (options.HasValue)
                {
                    var methodInfo = broker.GetMethod("AuthenticateSilentlyAsync", new[] { typeof(Uri), WebAuthenticationHelper.GetOptionsType() });
                    result = await (dynamic)methodInfo.Invoke(null, new object[] { uri, (uint)options });
                }
                else
                {
                    var methodInfo = broker.GetMethod("AuthenticateSilentlyAsync", new[] { typeof(Uri) });
                    result = await (dynamic)methodInfo.Invoke(null, new object[] { uri });
                }

                return new WebAuthenticationResult
                {
                    ResponseData = result.ResponseData,
                    ResponseErrorData = result.ResponseErrorDetail,
                    ResponseStatus = (WebAuthenticationStatus)result.ResponseStatus
                };
            }
            else
            {
                return ExceptionHelper.ThrowNotSupported<WebAuthenticationResult>();
            }
#elif WINDOWS_APP
            return ExceptionHelper.ThrowNotSupported<WebAuthenticationResult>("AuthenticateSilentlyAsync does not exist in Windows 8.1 Store apps");
#else
            Windows.Security.Authentication.Web.WebAuthenticationResult result;
            if (options.HasValue)
            {
                result = await WebAuthenticationBroker.AuthenticateSilentlyAsync(uri, (Windows.Security.Authentication.Web.WebAuthenticationOptions) options);
            }
            else
            {
                result = await WebAuthenticationBroker.AuthenticateSilentlyAsync(uri);
            }

            return new WebAuthenticationResult
            {
                ResponseData = result.ResponseData,
                ResponseErrorData = result.ResponseErrorDetail,
                ResponseStatus = (WebAuthenticationStatus)result.ResponseStatus
            };
#endif
        }

        /// <summary>
        /// Gets the current application callback URI.
        /// </summary>
        /// <returns>The call back uri</returns>
        public virtual Uri GetCurrentApplicationCallbackUri()
        {
#if WINDOWS_PHONE
            if (WebAuthenticationHelper.IsSupported())
            {
                var broker = WebAuthenticationHelper.CreateBroker();
                var methodInfo = broker.GetMethod("GetCurrentApplicationCallbackUri");
                var result = methodInfo.Invoke(null, null);
                return (Uri)result;
            }
            else
            {
                return ExceptionHelper.ThrowNotSupported<Uri>();
            }
#else
            return WebAuthenticationBroker.GetCurrentApplicationCallbackUri();
#endif
        }
    }
}
