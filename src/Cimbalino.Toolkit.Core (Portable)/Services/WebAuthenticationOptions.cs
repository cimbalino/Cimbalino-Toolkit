﻿namespace Cimbalino.Toolkit.Services
{
    public enum WebAuthenticationOptions : uint
    {
        //
        // Summary:
        //     No options are requested.
        None,
        //
        // Summary:
        //     Tells the web authentication broker to not render any UI. This option will throw
        //     an exception if used with AuthenticateAndContinue; AuthenticateSilentlyAsync,
        //     which includes this option implicitly, should be used instead.
        SilentMode,
        //
        // Summary:
        //     Tells the web authentication broker to return the window title string of the
        //     webpage in the ResponseData property.
        UseTitle,
        //
        // Summary:
        //     Tells the web authentication broker to return the body of the HTTP POST in the
        //     ResponseData property. For use with single sign-on (SSO) only.
        UseHttpPost = 4,
        //
        // Summary:
        //     Tells the web authentication broker to render the webpage in an app container
        //     that supports privateNetworkClientServer, enterpriseAuthentication, and sharedUserCertificate
        //     capabilities. Note the application that uses this flag must have these capabilities
        //     as well.
        UseCorporateNetwork = 8
    }
}