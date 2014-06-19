namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// The network status changed event handler.
    /// </summary>
    /// <param name="sender">
    /// The sender.
    /// </param>
    public delegate void NetworkStatusChangedEventHandler(object sender);

    /// <summary>
    /// The NetworkInformationService interface.
    /// </summary>
    public interface INetworkInformationService
    {
        /// <summary>
        /// The network status changed.
        /// </summary>
        event NetworkStatusChangedEventHandler NetworkStatusChanged;

        /// <summary>
        /// Gets a value indicating whether is network available.
        /// </summary>
        /// <value>
        /// The is network available.
        /// </value>
        bool IsNetworkAvailable { get;}
    }
}
