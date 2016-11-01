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
using System.Windows.Controls;
using System.Windows.Navigation;
using Cimbalino.Toolkit.Extensions;
using Cimbalino.Toolkit.Handlers;
using Cimbalino.Toolkit.Services;
using Page = Microsoft.Phone.Controls.PhoneApplicationPage;
#else
using Cimbalino.Toolkit.Extensions;
using Cimbalino.Toolkit.Handlers;
using Cimbalino.Toolkit.Services;
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
        private bool _alreadyPerformedOnNavigatingFrom;

        /// <summary>
        /// Invoked immediately after the page is unloaded and is no longer the current source of a parent frame.
        /// </summary>
        /// <param name="e">An object that contains the event data.</param>
        protected override async void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            var viewModel = DataContext as IHandleNavigatedFrom;

            if (viewModel != null)
            {
                await viewModel.OnNavigatedFromAsync(e.ToNavigationServiceNavigationEventArgs());
            }
        }

        /// <summary>
        /// Invoked immediately before the page is unloaded and is no longer the current source of a parent frame.
        /// </summary>
        /// <param name="e">An object that contains the event data.</param>
        protected override async void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);

            if (_alreadyPerformedOnNavigatingFrom)
            {
                _alreadyPerformedOnNavigatingFrom = false;
            }
            else
            {
                var viewModel = DataContext as IHandleNavigatingFrom;

                if (viewModel != null)
                {
#if WINDOWS_PHONE || WINDOWS_PHONE_81
                    if (e.IsCancelable)
                    {
                        e.Cancel = true;
                    }
#else
                    e.Cancel = true;
#endif

                    var navigationServiceNavigatingCancelEventArgs = e.ToNavigationServiceNavigatingCancelEventArgs();

                    await viewModel.OnNavigatingFromAsync(navigationServiceNavigatingCancelEventArgs);

                    if (navigationServiceNavigatingCancelEventArgs.IsCancelable && !navigationServiceNavigatingCancelEventArgs.Cancel)
                    {
                        _alreadyPerformedOnNavigatingFrom = true;

#if WINDOWS_PHONE || WINDOWS_PHONE_81
                        this.GetVisualAncestor<Frame>().Navigate(e.Uri);
#else
                        this.GetVisualAncestor<Frame>().Navigate(e.SourcePageType, e.Parameter, e.NavigationTransitionInfo);
#endif
                    }
                }
            }
        }

        /// <summary>
        /// Invoked when the page is loaded and becomes the current source of a parent frame.
        /// </summary>
        /// <param name="e">An object that contains the event data.</param>
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var viewModel = DataContext as IHandleNavigatedTo;

            if (viewModel != null)
            {
                await viewModel.OnNavigatedToAsync(e.ToNavigationServiceNavigationEventArgs());
            }
        }
    }
}