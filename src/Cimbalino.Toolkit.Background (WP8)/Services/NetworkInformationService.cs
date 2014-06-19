#if WINDOWS_PHONE
using Microsoft.Phone.Net.NetworkInformation;
#endif

using System;
using Windows.Networking.Connectivity;

namespace Cimbalino.Toolkit.Services
{
    public class NetworkInformationService : INetworkInformationService
    {
        public NetworkInformationService()
        {
            NetworkInformation.NetworkStatusChanged += NetworkInformation_NetworkStatusChanged;
        }

        private void NetworkInformation_NetworkStatusChanged(object sender)
        {
            OnNetworkStatusChanged(sender);
        }

        public void OnNetworkStatusChanged(object sender)
        {
            if (NetworkStatusChanged != null)
            {
                OnNetworkStatusChanged(sender);
            }
        }

        public event NetworkStatusChangedEventHandler NetworkStatusChanged;

        public bool IsNetworkAvailable 
        {
            get { return NetworkInformation.GetInternetConnectionProfile() != null; }
        }
    }

}
