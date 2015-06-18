using System;

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Provides data for <see cref="IDeviceStatusService.BatteryStatusChanged"/> events.
    /// </summary>
    public class BatteryStatusChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the a value indicating the percent of the battery remaining on the device
        /// </summary>
        /// <value>null if the platform can't report this, otherwise, the battery percentage</value>
        public int? RemainingChargePercent { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BatteryStatusChangedEventArgs"/> class.
        /// </summary>
        /// <param name="remainingChargePercent">A value representing the amount of charge left in the device battery</param>
        public BatteryStatusChangedEventArgs(int? remainingChargePercent)
        {
            RemainingChargePercent = remainingChargePercent;
        }
    }
}