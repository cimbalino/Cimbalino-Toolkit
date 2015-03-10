using Microsoft.Phone.Info;

namespace Cimbalino.Toolkit.Services
{
    public class DeviceStatusServiceWithKeyboard : DeviceStatusService
    {
        /// <summary>
        /// Gets a value indicating whether the user has deployed the physical hardware keyboard of the device.
        /// </summary>
        /// <value>true if the keyboard is deployed; otherwise, false.</value>
        public virtual bool IsKeyboardDeployed
        {
            get
            {
                return DeviceStatus.IsKeyboardDeployed;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the device contains a physical hardware keyboard.
        /// </summary>
        /// <value>
        /// true if the device contains a physical hardware keyboard; otherwise, false.
        /// </value>
        public virtual bool IsKeyboardPresent
        {
            get
            {
                return DeviceStatus.IsKeyboardPresent;
            }
        }
    }
}
