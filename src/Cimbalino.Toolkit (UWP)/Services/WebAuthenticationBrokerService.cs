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
    public class WebAuthenticationBrokerService : IWebAuthenticationBrokerService
    {
        public async Task<WebAuthenticationResult> AuthenticateAsync(WebAuthenticationOptions options, Uri uri, Uri callbackUri = null)
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

        public void AuthenticateAndContinue(Uri uri)
        {
#if WINDOWS_PHONE
            if (WebAuthenticationHelper.IsSupported())
            {
                var broker = WebAuthenticationHelper.CreateBroker();
                var methodInfo = broker.GetMethod("AuthenticateAndContinue", new []{typeof(Uri)});
                methodInfo.Invoke(null, new object [] { uri });
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

        public void AuthenticateAndContinue(Uri uri, Uri callbackUri)
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

        public void AuthenticateAndContinue(Uri uri, Uri callbackUri, Dictionary<string, object> valueSet, WebAuthenticationOptions options)
        {
#if WINDOWS_PHONE
            if (WebAuthenticationHelper.IsSupported())
            {
                var broker = WebAuthenticationHelper.CreateBroker();
                var methodInfo = broker.GetMethod("AuthenticateAndContinue", new[] { typeof(Uri), typeof(Uri), WebAuthenticationHelper.GetValueSetType(), WebAuthenticationHelper.GetOptionsType() });
                methodInfo.Invoke(null, new object[] { uri, callbackUri, WebAuthenticationHelper.CreateValueSet(valueSet), options});
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

        public async Task<WebAuthenticationResult> AuthenticateSilentlyAsync(Uri uri, WebAuthenticationOptions? options = null)
        {
#if WINDOWS_PHONE
            if (WebAuthenticationHelper.IsSupported())
            {
                var broker = WebAuthenticationHelper.CreateBroker();
                dynamic result;

                if (options.HasValue)
                {
                    var methodInfo = broker.GetMethod("AuthenticateSilentlyAsync", new [] {typeof (Uri), WebAuthenticationHelper.GetOptionsType()});
                    result = await (dynamic)methodInfo.Invoke(null, new object[] { uri, (uint)options});
                }
                else
                {
                    var methodInfo = broker.GetMethod("AuthenticateSilentlyAsync", new[] { typeof(Uri)});
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

        public Uri GetCurrentApplicationCallbackUri()
        {
#if WINDOWS_PHONE
            return ExceptionHelper.ThrowNotSupported<Uri>();
#else
            return WebAuthenticationBroker.GetCurrentApplicationCallbackUri();
#endif
        }
    }
}
