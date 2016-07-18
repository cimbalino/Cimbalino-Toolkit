// ****************************************************************************
// <copyright file="ExtendedPageBase.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2014
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <project>Cimbalino.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

#if WINDOWS_PHONE || WINDOWS_PHONE_81
using System.Windows.Navigation;
using Cimbalino.Toolkit.Handlers;
using Page = Microsoft.Phone.Controls.PhoneApplicationPage;
#else
using Cimbalino.Toolkit.Handlers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
#endif

namespace Cimbalino.Toolkit.Controls
{
    /// <summary>
    /// An extended base page for apps using Cimbalino
    /// </summary>
    public abstract class ExtendedPageBase : Page
    {
        /// <summary>Called when a page is no longer the active page in a frame.</summary>
        /// <param name="e">An object that contains the event data.</param>
        protected override async void OnNavigatedFrom(NavigationEventArgs e)
        {
            var viewModel = DataContext as IHandleNavigatedFrom;

            if (viewModel != null)
            {
#if WINDOWS_PHONE || WINDOWS_PHONE_81
                await viewModel.OnNavigatedFromAsync(e.NavigationMode.ToHandledNavigationMode(), e.Uri);
#else
                await viewModel.OnNavigatedFromAsync(e.NavigationMode.ToHandledNavigationMode(), e.Parameter);
#endif
            }

            base.OnNavigatedFrom(e);
        }

        /// <summary>Called when a page becomes the active page in a frame.</summary>
        /// <param name="e">An object that contains the event data.</param>
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            var viewModel = DataContext as IHandleNavigatedTo;

            if (viewModel != null)
            {
#if WINDOWS_PHONE || WINDOWS_PHONE_81
                await viewModel.OnNavigatedToAsync(e.NavigationMode.ToHandledNavigationMode(), e.Uri);
#else
                await viewModel.OnNavigatedToAsync(e.NavigationMode.ToHandledNavigationMode(), e.Parameter);
#endif
            }

            base.OnNavigatedTo(e);
        }
    }
}