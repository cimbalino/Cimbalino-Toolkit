#if !WINDOWS_PHONE
using Windows.UI.Xaml.Navigation;
using Cimbalino.Toolkit.Extensions;
using Cimbalino.Toolkit.Navigation;
using Windows.UI.Xaml.Controls;
using Cimbalino.Toolkit.Services;
#else
using System.Windows.Navigation;
using Cimbalino.Toolkit.Extensions;
using Cimbalino.Toolkit.Navigation;
using Cimbalino.Toolkit.Services;
using Page = Microsoft.Phone.Controls.PhoneApplicationPage;
#endif

namespace Cimbalino.Toolkit.Controls
{
    public abstract class ExtendedPageBase : Page
    {
#if !WINDOWS_APP
        public new abstract INavigationService NavigationService { get; }
#endif

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
#if !WINDOWS_APP
            if (NavigationService != null)
            {
                NavigationService.BackKeyPressed -= OnBackKeyPressed;
            }
#endif

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
#if !WINDOWS_APP
            if (NavigationService != null)
            {
                NavigationService.BackKeyPressed += OnBackKeyPressed;
            }
#endif

            var vm = DataContext as INavigatedTo;
#if WINDOWS_PHONE
            vm?.OnNavigatedTo(e.NavigationMode.ToNavigationMode());
#else
            vm?.OnNavigatedTo(e.NavigationMode.ToNavigationMode(), e.Parameter);
#endif

            base.OnNavigatedTo(e);
        }

#if !WINDOWS_APP
        protected virtual void OnBackKeyPressed(object sender, NavigationServiceBackKeyPressedEventArgs e)
        {
        }
#endif
    }
}
