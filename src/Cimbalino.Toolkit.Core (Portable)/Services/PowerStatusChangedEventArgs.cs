using System;

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Provides data for <see cref="IDeviceStatusService.PowerStatusChanged"/> events.
    /// </summary>
    public class PowerStatusChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the a value indicating the percent of the battery remaining on the device
        /// </summary>
        /// <value>null if the platform can't report this, otherwise, the battery percentage</value>
        public int? RemainingChargePercent { get; private set; }

        /// <summary>
        /// Gets the value indicating if the device is in power saver mode.
        /// </summary>
        /// <value>
        /// Null if the platform can't report this, otherwise [true] if in power saver mode
        /// </value>
        public bool? IsInPowerSaverMode { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PowerStatusChangedEventArgs"/> class.
        /// </summary>
        /// <param name="remainingChargePercent">A value representing the amount of charge left in the device battery</param>
        /// <param name="isInPowerSaverMode">A value represeting whether the device is in power saver mode</param>
        public PowerStatusChangedEventArgs(int? remainingChargePercent, bool? isInPowerSaverMode)
        {
            RemainingChargePercent = remainingChargePercent;
            IsInPowerSaverMode = isInPowerSaverMode;
        }
    }
}