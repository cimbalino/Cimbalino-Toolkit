namespace Cimbalino.Toolkit.Services
{
    public class WebAuthenticationResult
    {
        public string ResponseData { get; set; }
        public uint ResponseErrorData { get; set; }
        public WebAuthenticationStatus ResponseStatus { get; set; }
    }
}