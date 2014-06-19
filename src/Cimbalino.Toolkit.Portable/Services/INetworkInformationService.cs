namespace Cimbalino.Toolkit.Services
{
    public delegate void NetworkStatusChangedEventHandler(object sender);

    public interface INetworkInformationService
    {
        event NetworkStatusChangedEventHandler NetworkStatusChanged;
        bool IsNetworkAvailable { get;}
    }
}
