// ****************************************************************************
// <copyright file="NavigationService.cs" company="Pedro Lamas">
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

#if WINDOWS_PHONE_APP
using System;
using System.Collections.Generic;
using Cimbalino.Toolkit.Extensions;
using Cimbalino.Toolkit.Helpers;
using Windows.Phone.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
#elif WINDOWS_UWP
using System;
using System.Collections.Generic;
using Cimbalino.Toolkit.Extensions;
using Cimbalino.Toolkit.Helpers;
using Windows.Phone.UI.Input;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
#else
using System;
using System.Collections.Generic;
using Cimbalino.Toolkit.Extensions;
using Cimbalino.Toolkit.Helpers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
#endif

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="INavigationService"/>.
    /// </summary>
    public class NavigationService : INavigationService
    {
        private Frame _mainFrame;

        /// <summary>
        /// Occurs when the content that is being navigated to has been found and is available, although it may not have completed loading.
        /// </summary>
        public event EventHandler Navigated;

        /// <summary>
        /// Occurs when the user presses the hardware Back button.
        /// </summary>
#if WINDOWS_PHONE_APP || WINDOWS_UWP
        public event EventHandler<NavigationServiceBackKeyPressedEventArgs> BackKeyPressed;
#else
        public event EventHandler<NavigationServiceBackKeyPressedEventArgs> BackKeyPressed
        {
            add
            {
                ExceptionHelper.ThrowNotSupported();
            }
            remove
            {
            }
        }
#endif

        /// <summary>
        /// Gets the uniform resource identifier (URI) of the content that is currently displayed.
        /// </summary>
        /// <value>Returns a value that represents the <see cref="Uri"/> of content that is currently displayed.</value>
        public virtual Uri CurrentSource
        {
            get
            {
                if (EnsureMainFrame())
                {
                    return _mainFrame.BaseUri;
                }

                return null;
            }
        }

        /// <summary>
        /// Gets any parameter object passed to the target page for the navigation.
        /// </summary>
        /// <value>Any parameter object passed to the target page for the navigation.</value>
        public object CurrentParameter { get; private set; }

        /// <summary>
        /// Gets a collection of query string values.
        /// </summary>
        /// <value>Returns a <see cref="IDictionary{TKey,TValue}"/> collection that contains the query string values.</value>
        public virtual IEnumerable<KeyValuePair<string, string>> QueryString
        {
            get
            {
                if (EnsureMainFrame())
                {
                    return _mainFrame.BaseUri.QueryString();
                }

                return null;
            }
        }

#if WINDOWS_PHONE_APP || WINDOWS_UWP
        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationService"/> class.
        /// </summary>
        public NavigationService()
        {
            if (ApiHelper.SupportsBackButton)
            {
                HardwareButtons.BackPressed += HardwareButtons_BackPressed;
            }

#if WINDOWS_UWP
            SystemNavigationManager.GetForCurrentView().BackRequested -= OnBackRequested;
            SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;
#endif
        }
#endif

        /// <summary>
        /// Navigates to the content specified by the uniform resource identifier (URI).
        /// </summary>
        /// <param name="source">The URI for the desired content.</param>
        /// <returns>true if navigation is not canceled; otherwise, false.</returns>
        public virtual bool Navigate(string source)
        {
            return EnsureMainFrame() && _mainFrame.Navigate(Type.GetType(source));
        }

        /// <summary>
        /// Navigates to the content specified by the uniform resource identifier (URI).
        /// </summary>
        /// <param name="source">A <see cref="Uri"/> initialized with the URI for the desired content.</param>
        /// <returns>true if navigation is not canceled; otherwise, false.</returns>
        public virtual bool Navigate(Uri source)
        {
            return ExceptionHelper.ThrowNotSupported<bool>();
        }

        /// <summary>
        /// Navigates to the content specified by the type reference.
        /// </summary>
        /// <typeparam name="T">The page to navigate to, specified as a type reference to its partial class type.</typeparam>
        /// <returns>true if navigation is not canceled; otherwise, false.</returns>
        public virtual bool Navigate<T>()
        {
            return Navigate(typeof(T));
        }

        /// <summary>
        /// Navigates to the content specified by the type reference.
        /// </summary>
        /// <typeparam name="T">The page to navigate to, specified as a type reference to its partial class type.</typeparam>
        /// <param name="parameter">The navigation parameter to pass to the target page; must have a basic type (string, char, numeric, or GUID).</param>
        /// <returns>true if navigation is not canceled; otherwise, false.</returns>
        public virtual bool Navigate<T>(object parameter)
        {
            return Navigate(typeof(T), parameter);
        }

        /// <summary>
        /// Navigates to the content specified by the type reference.
        /// </summary>
        /// <param name="type">The page to navigate to, specified as a type reference to its partial class type.</param>
        /// <returns>true if navigation is not canceled; otherwise, false.</returns>
        public virtual bool Navigate(Type type)
        {
            return EnsureMainFrame() && _mainFrame.Navigate(type);
        }

        /// <summary>
        /// Navigates to the content specified by the type reference.
        /// </summary>
        /// <param name="type">The page to navigate to, specified as a type reference to its partial class type.</param>
        /// <param name="parameter">The navigation parameter to pass to the target page; must have a basic type (string, char, numeric, or GUID).</param>
        /// <returns>true if navigation is not canceled; otherwise, false.</returns>
        public virtual bool Navigate(Type type, object parameter)
        {
            return EnsureMainFrame() && _mainFrame.Navigate(type, parameter);
        }

        /// <summary>
        /// Gets a value indicating whether there is at least one entry in back navigation history.
        /// </summary>
        /// <value>true if there is at least one entry in back navigation history; false if there are no entries in back navigation history.</value>
        public virtual bool CanGoBack
        {
            get
            {
                return EnsureMainFrame() && _mainFrame.CanGoBack;
            }
        }

        /// <summary>
        /// Navigates to the most recent item in back navigation history.
        /// </summary>
        public virtual void GoBack()
        {
            if (EnsureMainFrame() && _mainFrame.CanGoBack)
            {
                _mainFrame.GoBack();
            }
        }

        /// <summary>
        /// Gets a value indicating whether there is at least one entry in forward navigation history.
        /// </summary>
        /// <value>true if there is at least one entry in forward navigation history; false if there are no entries in forward navigation history.</value>
        public virtual bool CanGoForward
        {
            get
            {
                return EnsureMainFrame() && _mainFrame.CanGoForward;
            }
        }

        /// <summary>
        /// Navigates to the most recent item in forward navigation history.
        /// </summary>
        public virtual void GoForward()
        {
            if (EnsureMainFrame() && _mainFrame.CanGoForward)
            {
                _mainFrame.GoForward();
            }
        }

        /// <summary>
        /// Removes the most recent available entry from the back stack.
        /// </summary>
        /// <returns>true if successfully removed the most recent available entry from the back stack; otherwise, false.</returns>
        public virtual bool RemoveBackEntry()
        {
            if (EnsureMainFrame() && _mainFrame.CanGoBack)
            {
                _mainFrame.BackStack.RemoveAt(_mainFrame.BackStackDepth - 1);

                // This is for Windows 10 apps
                ShowHideBackButtonVisibility();

                return true;
            }

            return false;
        }

        /// <summary>
        /// Ensure that a <see cref="Frame"/> instance has been found.
        /// </summary>
        /// <returns>true if a <see cref="Frame"/> instance has been found; otherwise, false.</returns>
        protected virtual bool EnsureMainFrame()
        {
            _mainFrame = Window.Current.Content as Frame;

            if (_mainFrame != null)
            {
                _mainFrame.Navigated -= Frame_Navigated;
                _mainFrame.Navigated += Frame_Navigated;

                return true;
            }

            return false;
        }

        private void Frame_Navigated(object sender, Windows.UI.Xaml.Navigation.NavigationEventArgs e)
        {
            CurrentParameter = e.Parameter;

            RaiseNavigated(EventArgs.Empty);

            ShowHideBackButtonVisibility();
        }

        /// <summary>
        /// Raises the <see cref="Navigated"/> event with the provided event data.
        /// </summary>
        /// <param name="eventArgs">The event data.</param>
        protected virtual void RaiseNavigated(EventArgs eventArgs)
        {
            var eventHandler = Navigated;
            eventHandler?.Invoke(this, eventArgs);
        }

#if WINDOWS_UWP
        private void OnBackRequested(object sender, BackRequestedEventArgs e)
        {
            e.Handled = HandleBackKeyPress();
            ShowHideBackButtonVisibility();
        }

        public static bool HandleBackButtonVisibility { get; set; } = true;
#endif

        private void ShowHideBackButtonVisibility()
        {
#if WINDOWS_UWP
            if (HandleBackButtonVisibility)
            {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = _mainFrame?.CanGoBack ?? false ? AppViewBackButtonVisibility.Visible : AppViewBackButtonVisibility.Collapsed;
            }
#endif
        }

#if WINDOWS_PHONE_APP || WINDOWS_UWP
        private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            e.Handled = HandleBackKeyPress();

            ShowHideBackButtonVisibility();
        }

        private bool HandleBackKeyPress()
        {
            var handled = false;
            var eventArgs = new NavigationServiceBackKeyPressedEventArgs();
            RaiseBackKeyPressed(eventArgs);
            switch (eventArgs.Behavior)
            {
                case NavigationServiceBackKeyPressedBehavior.GoBack:
                    if (_mainFrame.CanGoBack)
                    {
                        _mainFrame.GoBack();
                        handled = true;
                    }
                    break;
                case NavigationServiceBackKeyPressedBehavior.HideApp:
                    break;
                case NavigationServiceBackKeyPressedBehavior.ExitApp:
                    handled = true;
                    Application.Current.Exit();
                    break;
                case NavigationServiceBackKeyPressedBehavior.DoNothing:
                    handled = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return handled;
        }

        /// <summary>
        /// Raises the <see cref="BackKeyPressed"/> event with the provided event data.
        /// </summary>
        /// <param name="eventArgs">The event data.</param>
        protected virtual void RaiseBackKeyPressed(NavigationServiceBackKeyPressedEventArgs eventArgs)
        {
            var eventHandler = BackKeyPressed;
            eventHandler?.Invoke(this, eventArgs);
        }
#endif
    }
}