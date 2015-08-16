namespace Cimbalino.Toolkit.Services
{
    public enum WebAuthenticationStatus
    {
        //
        // Summary:
        //     The operation succeeded, and the response data is available.
        Success = 0,
        //
        // Summary:
        //     The operation was canceled by the user.
        UserCancel = 1,
        //
        // Summary:
        //     The operation failed because a specific HTTP error was returned, for example
        //     404.
        ErrorHttp = 2
    }
}