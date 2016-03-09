using Cimbalino.Toolkit.Navigation;
#if WINDOWS_PHONE
using DeviceNavigationMode = System.Windows.Navigation.NavigationMode;
#else
using DeviceNavigationMode = Windows.UI.Xaml.Navigation.NavigationMode;
#endif

namespace Cimbalino.Toolkit.Extensions
{
    public static class NavigationModeExtensions
    {
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
