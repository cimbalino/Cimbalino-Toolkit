#if !WINDOWS_PHONE
using Windows.UI.Xaml.Navigation;
using Cimbalino.Toolkit.Extensions;
using Cimbalino.Toolkit.Navigation;
using Windows.UI.Xaml.Controls;
#else
using System.Windows.Navigation;
using Cimbalino.Toolkit.Extensions;
using Cimbalino.Toolkit.Navigation;
using Page = Microsoft.Phone.Controls.PhoneApplicationPage;
#endif

namespace Cimbalino.Toolkit.Controls
{
    public class ExtendedPageBase : Page
    {
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            var vm = DataContext as INavigatedFrom;
#if WINDOWS_PHONE
            vm?.OnNavigatedFrom(e.NavigationMode.ToNavigationMode());
#else
            vm?.OnNavigatedFrom(e.NavigationMode.ToNavigationMode(), e.Parameter);
#endif
            
            base.OnNavigatedFrom(e);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var vm = DataContext as INavigatedTo;
#if WINDOWS_PHONE
            vm?.OnNavigatedTo(e.NavigationMode.ToNavigationMode());
#else
            vm?.OnNavigatedTo(e.NavigationMode.ToNavigationMode(), e.Parameter);
#endif

            base.OnNavigatedTo(e);
        }
    }
}
