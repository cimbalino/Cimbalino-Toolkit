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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Navigation;
using Cimbalino.Toolkit.Helpers;
using Microsoft.Phone.Controls;
using PhoneNavigationService = System.Windows.Navigation.NavigationService;

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="INavigationService"/>.
    /// </summary>
    public class NavigationService : INavigationService
    {
        private readonly object _frameLock = new object();

        private PhoneApplicationFrame _frame;
        private PhoneNavigationService _navigationService;

        /// <summary>
        /// Occurs when the content that is being navigated to has been found and is available, although it may not have completed loading.
        /// </summary>
        public event EventHandler<NavigationServiceNavigationEventArgs> Navigated;

        /// <summary>
        /// Occurs when the user presses the hardware Back button.
        /// </summary>
        public event EventHandler<NavigationServiceBackKeyPressedEventArgs> BackKeyPressed;

        /// <summary>
        /// Gets the uniform resource identifier (URI) of the content that is currently displayed.
        /// </summary>
        /// <value>Returns a value that represents the <see cref="Uri"/> of content that is currently displayed.</value>
        public virtual Uri CurrentSource
        {
            get
            {
                return GetFrame()?.CurrentSource;
            }
        }

        /// <summary>
        /// Gets any parameter object passed to the target page for the navigation.
        /// </summary>
        /// <value>Any parameter object passed to the target page for the navigation.</value>
        public virtual object CurrentParameter
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Gets a collection of query string values.
        /// </summary>
        /// <value>Returns a <see cref="IDictionary{TKey,TValue}"/> collection that contains the query string values.</value>
        public virtual IEnumerable<KeyValuePair<string, string>> QueryString
        {
            get
            {
                var page = GetFrame()?.Content as PhoneApplicationPage;

                return page?.NavigationContext?.QueryString;
            }
        }

        /// <summary>
        /// Navigates to the content specified by the uniform resource identifier (URI).
        /// </summary>
        /// <param name="source">The URI for the desired content.</param>
        /// <returns>true if navigation is not canceled; otherwise, false.</returns>
        public virtual bool Navigate(string source)
        {
            return Navigate(new Uri(source, UriKind.Relative));
        }

        /// <summary>
        /// Navigates to the content specified by the uniform resource identifier (URI).
        /// </summary>
        /// <param name="source">A <see cref="Uri"/> initialized with the URI for the desired content.</param>
        /// <returns>true if navigation is not canceled; otherwise, false.</returns>
        public virtual bool Navigate(Uri source)
        {
            return GetNavigationService()?.Navigate(source) ?? false;
        }

        /// <summary>
        /// Navigates to the content specified by the type reference.
        /// </summary>
        /// <typeparam name="T">The page to navigate to, specified as a type reference to its partial class type.</typeparam>
        /// <returns>true if navigation is not canceled; otherwise, false.</returns>
        public virtual bool Navigate<T>()
        {
            return ExceptionHelper.ThrowNotSupported<bool>();
        }

        /// <summary>
        /// Navigates to the content specified by the type reference.
        /// </summary>
        /// <typeparam name="T">The page to navigate to, specified as a type reference to its partial class type.</typeparam>
        /// <param name="parameter">The navigation parameter to pass to the target page; must have a basic type (string, char, numeric, or GUID).</param>
        /// <returns>true if navigation is not canceled; otherwise, false.</returns>
        public virtual bool Navigate<T>(object parameter)
        {
            return ExceptionHelper.ThrowNotSupported<bool>();
        }

        /// <summary>
        /// Navigates to the content specified by the type reference.
        /// </summary>
        /// <param name="type">The page to navigate to, specified as a type reference to its partial class type.</param>
        /// <returns>true if navigation is not canceled; otherwise, false.</returns>
        public virtual bool Navigate(Type type)
        {
            return ExceptionHelper.ThrowNotSupported<bool>();
        }

        /// <summary>
        /// Navigates to the content specified by the type reference.
        /// </summary>
        /// <param name="type">The page to navigate to, specified as a type reference to its partial class type.</param>
        /// <param name="parameter">The navigation parameter to pass to the target page; must have a basic type (string, char, numeric, or GUID).</param>
        /// <returns>true if navigation is not canceled; otherwise, false.</returns>
        public virtual bool Navigate(Type type, object parameter)
        {
            return ExceptionHelper.ThrowNotSupported<bool>();
        }

        /// <summary>
        /// Gets a value indicating whether there is at least one entry in back navigation history.
        /// </summary>
        /// <value>true if there is at least one entry in back navigation history; false if there are no entries in back navigation history.</value>
        public virtual bool CanGoBack
        {
            get
            {
                return GetNavigationService()?.CanGoBack ?? false;
            }
        }

        /// <summary>
        /// Navigates to the most recent item in back navigation history.
        /// </summary>
        public virtual void GoBack()
        {
            var navigationService = GetNavigationService();

            if (navigationService?.CanGoBack ?? false)
            {
                navigationService.GoBack();
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
                return GetNavigationService()?.CanGoForward ?? false;
            }
        }

        /// <summary>
        /// Navigates to the most recent item in forward navigation history.
        /// </summary>
        public virtual void GoForward()
        {
            var navigationService = GetNavigationService();

            if (navigationService?.CanGoForward ?? false)
            {
                navigationService.GoForward();
            }
        }

        /// <summary>
        /// Removes the most recent available entry from the back stack.
        /// </summary>
        /// <returns>true if successfully removed the most recent available entry from the back stack; otherwise, false.</returns>
        public virtual bool RemoveBackEntry()
        {
            var navigationService = GetNavigationService();

            if (navigationService?.CanGoBack ?? false)
            {
                navigationService.RemoveBackEntry();

                return true;
            }

            return false;
        }

        /// <summary>
        /// Clears the backstack for the frame in its entirety.
        /// </summary>
        public virtual void ClearBackstack()
        {
            while (CanGoBack)
            {
                RemoveBackEntry();
            }
        }

        /// <summary>
        /// Registers the specified <see cref="PhoneApplicationFrame"/> instance.
        /// </summary>
        /// <param name="frame">The <see cref="PhoneApplicationFrame"/> instance.</param>
        public virtual void RegisterFrame(PhoneApplicationFrame frame)
        {
            lock (_frameLock)
            {
                if (_frame != null)
                {
                    _frame.Navigated -= Frame_Navigated;
                    _frame.BackKeyPress -= Frame_BackKeyPress;
                }

                _frame = frame;

                if (_frame != null)
                {
                    _frame.Navigated += Frame_Navigated;
                    _frame.BackKeyPress += Frame_BackKeyPress;

                    _navigationService = (_frame.Content as PhoneApplicationPage)?.NavigationService;
                }
                else
                {
                    _navigationService = null;
                }
            }
        }

        /// <summary>
        /// Returns the current <see cref="PhoneApplicationFrame"/> instance.
        /// </summary>
        /// <returns>The current <see cref="PhoneApplicationFrame"/> instance.</returns>
        protected virtual PhoneApplicationFrame GetFrame()
        {
            var frame = _frame;

            if (frame == null)
            {
                frame = Application.Current.RootVisual as PhoneApplicationFrame;

                if (frame != null)
                {
                    RegisterFrame(frame);
                }
            }

            return frame;
        }

        /// <summary>
        /// Returns the current <see cref="PhoneNavigationService"/> instance.
        /// </summary>
        /// <returns>The current <see cref="PhoneNavigationService"/> instance.</returns>
        protected virtual PhoneNavigationService GetNavigationService()
        {
            var navigationService = _navigationService;

            if (navigationService == null)
            {
                GetFrame();
            }

            return _navigationService;
        }

        /// <summary>
        /// Raises the <see cref="Navigated"/> event with the provided event data.
        /// </summary>
        /// <param name="eventArgs">The event data.</param>
        protected virtual void RaiseNavigated(NavigationServiceNavigationEventArgs eventArgs)
        {
            var eventHandler = Navigated;

            if (eventHandler != null)
            {
                eventHandler(this, eventArgs);
            }
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

        private void Frame_Navigated(object s, NavigationEventArgs e)
        {
            if (_navigationService == null)
            {
                _navigationService = (e.Content as PhoneApplicationPage)?.NavigationService;
            }

            RaiseNavigated(e.ToNavigationServiceNavigationEventArgs());
        }

        private void Frame_BackKeyPress(object s, CancelEventArgs e)
        {
            var eventArgs = new NavigationServiceBackKeyPressedEventArgs();

            RaiseBackKeyPressed(eventArgs);

            switch (eventArgs.Behavior)
            {
                case NavigationServiceBackKeyPressedBehavior.GoBack:
                    break;

                case NavigationServiceBackKeyPressedBehavior.HideApp:
                    ExceptionHelper.ThrowNotSupported();
                    break;
                case NavigationServiceBackKeyPressedBehavior.ExitApp:
                    e.Cancel = true;
                    Application.Current.Terminate();
                    break;

                case NavigationServiceBackKeyPressedBehavior.DoNothing:
                    e.Cancel = true;
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        void INavigationService.RegisterFrame(object frame)
        {
            RegisterFrame(frame as PhoneApplicationFrame);
        }
    }
}