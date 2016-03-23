using Cimbalino.Toolkit.Navigation;
#if WINDOWS_PHONE || WINDOWS_PHONE_81
using DeviceNavigationMode = System.Windows.Navigation.NavigationMode;
#else
using DeviceNavigationMode = Windows.UI.Xaml.Navigation.NavigationMode;
#endif

namespace Cimbalino.Toolkit.Extensions
{
    /// <summary>
    /// Extension method for Navigation Mode enum
    /// </summary>
    public static class NavigationModeExtensions
    {
        /// <summary>
        /// To the navigation mode.
        /// </summary>
        /// <param name="mode">The mode.</param>
        /// <returns>The correct navigation mode</returns>
        public static NavigationMode ToNavigationMode(this DeviceNavigationMode mode)
        {
            var result = NavigationMode.New;

            switch (mode)
            {
                case DeviceNavigationMode.New:
                    break;

                case DeviceNavigationMode.Back:
                    result = NavigationMode.Back;
                    break;
                case DeviceNavigationMode.Forward:
                    result = NavigationMode.Forward;
                    break;
                case DeviceNavigationMode.Refresh:
                    result = NavigationMode.Refresh;
                    break;
#if WINDOWS_PHONE
                case DeviceNavigationMode.Reset:
                    result = NavigationMode.Reset;
                    break;
#endif
            }

            return result;
        }
    }
}
