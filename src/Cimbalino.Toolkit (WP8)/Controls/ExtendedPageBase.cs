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
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Cimbalino.Toolkit.Extensions;
using Cimbalino.Toolkit.Handlers;
using Cimbalino.Toolkit.Services;
using Page = Microsoft.Phone.Controls.PhoneApplicationPage;
#else
using System;
using System.Threading.Tasks;
using Cimbalino.Toolkit.Handlers;
using Cimbalino.Toolkit.Services;
using Windows.UI.Core;
using Windows.UI.Xaml;
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

            var handler = DataContext as IHandleNavigatedFrom;

            if (handler != null)
            {
                await InvokeHandlerOnNavigatedFromAsync(handler, e.ToNavigationServiceNavigationEventArgs());
            }
        }

        /// <summary>
        /// Invokes the <see cref="IHandleNavigatedFrom.OnNavigatedFromAsync"/> for the current <see cref="FrameworkElement.DataContext"/>.
        /// </summary>
        /// <param name="handler">The <see cref="IHandleNavigatedFrom"/> instance.</param>
        /// <param name="e">An object that contains the event data.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        protected virtual Task InvokeHandlerOnNavigatedFromAsync(IHandleNavigatedFrom handler, NavigationServiceNavigationEventArgs e) => handler.OnNavigatedFromAsync(e);

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
                var handler = DataContext as IHandleNavigatingFrom;

#if WINDOWS_PHONE || WINDOWS_PHONE_81
                var shouldCancel = handler != null && e.IsCancelable;
#else
                var shouldCancel = handler != null;
#endif

                if (shouldCancel)
                {
                    e.Cancel = true;

                    await OnNavigatingFromAsync(e, handler);
                }
            }
        }

        /// <summary>
        /// Invokes the <see cref="IHandleNavigatingFrom.OnNavigatingFromAsync"/> for the current <see cref="FrameworkElement.DataContext"/>.
        /// </summary>
        /// <param name="handler">The <see cref="IHandleNavigatingFrom"/> instance.</param>
        /// <param name="e">An object that contains the event data.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        protected virtual Task InvokeHandlerOnNavigatingFromAsync(IHandleNavigatingFrom handler, NavigationServiceNavigatingCancelEventArgs e) => handler.OnNavigatingFromAsync(e);

        /// <summary>
        /// Invoked when the page is loaded and becomes the current source of a parent frame.
        /// </summary>
        /// <param name="e">An object that contains the event data.</param>
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var handler = DataContext as IHandleNavigatedTo;

            if (handler != null)
            {
                await InvokeHandlerOnNavigatedToAsync(handler, e.ToNavigationServiceNavigationEventArgs());
            }
        }

        /// <summary>
        /// Invokes the <see cref="IHandleNavigatedTo.OnNavigatedToAsync"/> for the current <see cref="FrameworkElement.DataContext"/>.
        /// </summary>
        /// <param name="handler">The <see cref="IHandleNavigatedTo"/> instance.</param>
        /// <param name="e">An object that contains the event data.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        protected virtual Task InvokeHandlerOnNavigatedToAsync(IHandleNavigatedTo handler, NavigationServiceNavigationEventArgs e) => handler.OnNavigatedToAsync(e);

        private async Task OnNavigatingFromAsync(NavigatingCancelEventArgs e, IHandleNavigatingFrom handler)
        {
            var navigationServiceNavigatingCancelEventArgs = e.ToNavigationServiceNavigatingCancelEventArgs();

            await InvokeHandlerOnNavigatingFromAsync(handler, navigationServiceNavigatingCancelEventArgs);

            if (!navigationServiceNavigatingCancelEventArgs.Cancel)
            {
                _alreadyPerformedOnNavigatingFrom = true;

#if WINDOWS_PHONE || WINDOWS_PHONE_81
                Dispatcher.BeginInvoke(() =>
                {
                    var frame = this.GetVisualAncestor<Frame>();

                    switch (e.NavigationMode)
                    {
                        case NavigationMode.New:
                            frame.Navigate(e.Uri);
                            break;
#else
                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    var frame = this.Frame;

                    switch (e.NavigationMode)
                    {
                        case NavigationMode.New:
                            frame.Navigate(e.SourcePageType, e.Parameter, e.NavigationTransitionInfo);
                            break;
#endif

                        case NavigationMode.Back:
                            frame.GoBack();
                            break;

                        case NavigationMode.Forward:
                            frame.GoForward();
                            break;
                    }
                });
            }
        }
    }
}