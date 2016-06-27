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
    /// <summary>
    /// An extended base page for apps using Cimbalino
    /// </summary>
    public abstract class ExtendedPageBase : Page
    {
#if !WINDOWS_APP
        public new abstract INavigationService NavigationService { get; }
#endif

        /// <summary>
        /// Raises the <see cref="E:NavigatedFrom" /> event.
        /// </summary>
        /// <param name="e">The <see cref="Windows.UI.Xaml.Navigation.NavigationEventArgs" /> instance containing the event data.</param>
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
#if !WINDOWS_APP
            if (NavigationService != null)
            {
                NavigationService.BackKeyPressed -= OnBackKeyPressed;
            }
#endif

            var vm = DataContext as INavigatedFrom;
#if WINDOWS_PHONE || WINDOWS_PHONE_81
            vm?.OnNavigatedFrom(e.NavigationMode.ToNavigationMode());
#else
            vm?.OnNavigatedFrom(e.NavigationMode.ToNavigationMode(), e.Parameter);
#endif

            base.OnNavigatedFrom(e);
        }

        /// <summary>
        /// Raises the <see cref="E:NavigatedTo" /> event.
        /// </summary>
        /// <param name="e">The <see cref="Windows.UI.Xaml.Navigation.NavigationEventArgs" /> instance containing the event data.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
#if !WINDOWS_APP
            if (NavigationService != null)
            {
                NavigationService.BackKeyPressed += OnBackKeyPressed;
            }
#endif

            var vm = DataContext as INavigatedTo;
#if WINDOWS_PHONE || WINDOWS_PHONE_81
            vm?.OnNavigatedTo(e.NavigationMode.ToNavigationMode());
#else
            vm?.OnNavigatedTo(e.NavigationMode.ToNavigationMode(), e.Parameter);
#endif

            base.OnNavigatedTo(e);
        }

#if !WINDOWS_APP
        /// <summary>
        /// Called when [back key pressed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Cimbalino.Toolkit.Services.NavigationServiceBackKeyPressedEventArgs" /> instance containing the event data.</param>
        protected virtual void OnBackKeyPressed(object sender, NavigationServiceBackKeyPressedEventArgs e)
        {
        }
#endif
    }
}
