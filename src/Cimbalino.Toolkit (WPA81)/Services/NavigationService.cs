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
        private readonly object _frameLock = new object();

        private Frame _frame;

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
                return GetFrame()?.BaseUri;
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
                return GetFrame()?.BaseUri.QueryString();
            }
        }

#if WINDOWS_PHONE_APP
        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationService"/> class.
        /// </summary>
        public NavigationService()
        {
            HardwareButtons.BackPressed += HardwareButtons_BackPressed;
        }
#elif WINDOWS_UWP
        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationService"/> class.
        /// </summary>
        public NavigationService()
        {
            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
            {
                HardwareButtons.BackPressed += HardwareButtons_BackPressed;
            }

            SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;
        }
#endif

        /// <summary>
        /// Navigates to the content specified by the uniform resource identifier (URI).
        /// </summary>
        /// <param name="source">The URI for the desired content.</param>
        /// <returns>true if navigation is not canceled; otherwise, false.</returns>
        public virtual bool Navigate(string source)
        {
            return GetFrame()?.Navigate(Type.GetType(source)) ?? false;
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
            return GetFrame()?.Navigate(type) ?? false;
        }

        /// <summary>
        /// Navigates to the content specified by the type reference.
        /// </summary>
        /// <param name="type">The page to navigate to, specified as a type reference to its partial class type.</param>
        /// <param name="parameter">The navigation parameter to pass to the target page; must have a basic type (string, char, numeric, or GUID).</param>
        /// <returns>true if navigation is not canceled; otherwise, false.</returns>
        public virtual bool Navigate(Type type, object parameter)
        {
            return GetFrame()?.Navigate(type, parameter) ?? false;
        }

        /// <summary>
        /// Gets a value indicating whether there is at least one entry in back navigation history.
        /// </summary>
        /// <value>true if there is at least one entry in back navigation history; false if there are no entries in back navigation history.</value>
        public virtual bool CanGoBack
        {
            get
            {
                return GetFrame()?.CanGoBack ?? false;
            }
        }

        /// <summary>
        /// Navigates to the most recent item in back navigation history.
        /// </summary>
        public virtual void GoBack()
        {
            var frame = GetFrame();

            if (frame?.CanGoBack ?? false)
            {
                frame.GoBack();
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
                return GetFrame()?.CanGoForward ?? false;
            }
        }

        /// <summary>
        /// Navigates to the most recent item in forward navigation history.
        /// </summary>
        public virtual void GoForward()
        {
            var frame = GetFrame();

            if (frame?.CanGoForward ?? false)
            {
                frame.GoForward();
            }
        }

        /// <summary>
        /// Removes the most recent available entry from the back stack.
        /// </summary>
        /// <returns>true if successfully removed the most recent available entry from the back stack; otherwise, false.</returns>
        public virtual bool RemoveBackEntry()
        {
            var frame = GetFrame();

            if (frame?.CanGoBack ?? false)
            {
                frame.BackStack.RemoveAt(frame.BackStackDepth - 1);

                SetBackButtonVisibility();

                return true;
            }

            return false;
        }

        /// <summary>
        /// Registers the specified <see cref="Frame"/> instance.
        /// </summary>
        /// <param name="frame">The <see cref="Frame"/> instance.</param>
        public virtual void RegisterFrame(Frame frame)
        {
            lock (_frameLock)
            {
                var oldFrame = _frame;

                if (oldFrame != null)
                {
                    oldFrame.Navigated -= Frame_Navigated;
                }

                _frame = frame;

                if (frame != null)
                {
                    frame.Navigated += Frame_Navigated;
                }
            }
        }

        /// <summary>
        /// Returns the current <see cref="Frame"/> instance.
        /// </summary>
        /// <returns>The current <see cref="Frame"/> instance.</returns>
        private Frame GetFrame()
        {
            var frame = _frame;

            if (frame == null)
            {
                frame = Window.Current.Content as Frame;

                if (frame != null)
                {
                    RegisterFrame(frame);
                }
            }

            return frame;
        }

        private void Frame_Navigated(object sender, Windows.UI.Xaml.Navigation.NavigationEventArgs e)
        {
            CurrentParameter = e.Parameter;

            RaiseNavigated(EventArgs.Empty);

            SetBackButtonVisibility();
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

            SetBackButtonVisibility();
        }

        /// <summary>
        /// Gets or sets a value indicating whether the back button visibility will be handled automatically.
        /// </summary>
        /// <value>true if the back button visibility will be handled automatically; otherwise, false.</value>
        public static bool HandleBackButtonVisibility { get; set; } = true;
#endif

        private void SetBackButtonVisibility()
        {
#if WINDOWS_UWP
            if (HandleBackButtonVisibility)
            {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = CanGoBack ? AppViewBackButtonVisibility.Visible : AppViewBackButtonVisibility.Collapsed;
            }
#endif
        }

#if WINDOWS_PHONE_APP || WINDOWS_UWP
        private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            e.Handled = HandleBackKeyPress();

            SetBackButtonVisibility();
        }

        private bool HandleBackKeyPress()
        {
            var handled = false;

            var eventArgs = new NavigationServiceBackKeyPressedEventArgs();

            RaiseBackKeyPressed(eventArgs);

            switch (eventArgs.Behavior)
            {
                case NavigationServiceBackKeyPressedBehavior.GoBack:
                    var frame = GetFrame();

                    if (frame?.CanGoBack ?? false)
                    {
                        frame.GoBack();
                        handled = true;
                    }
                    break;

                case NavigationServiceBackKeyPressedBehavior.HideApp:
                    break;

                case NavigationServiceBackKeyPressedBehavior.ExitApp:
                    handled = true;
                    Application.Current?.Exit();
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

            if (eventHandler != null)
            {
                eventHandler(this, eventArgs);
            }
        }
#endif

        void INavigationService.RegisterFrame(object frame)
        {
            RegisterFrame(frame as Frame);
        }
    }
}