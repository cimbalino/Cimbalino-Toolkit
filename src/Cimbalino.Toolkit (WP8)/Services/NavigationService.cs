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
using System.Windows;
using System.Windows.Documents;
using Cimbalino.Toolkit.Helpers;
using Microsoft.Phone.Controls;

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="INavigationService"/>.
    /// </summary>
    public class NavigationService : INavigationService
    {
        private PhoneApplicationFrame _mainFrame;
        private System.Windows.Navigation.NavigationService _navigationService;

        /// <summary>
        /// Occurs when the content that is being navigated to has been found and is available, although it may not have completed loading.
        /// </summary>
        public event EventHandler Navigated;

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
                if (EnsureNavigationService())
                {
                    return _mainFrame.CurrentSource;
                }

                return null;
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
                if (EnsureNavigationService())
                {
                    var page = _mainFrame.Content as PhoneApplicationPage;

                    if (page != null && page.NavigationContext != null)
                    {
                        return page.NavigationContext.QueryString;
                    }
                }

                return null;
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
            return EnsureNavigationService() && _navigationService.Navigate(source);
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
                return EnsureNavigationService() && _navigationService.CanGoBack;
            }
        }

        /// <summary>
        /// Navigates to the most recent item in back navigation history.
        /// </summary>
        public virtual void GoBack()
        {
            if (CanGoBack)
            {
                _navigationService.GoBack();
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
                return EnsureNavigationService() && _navigationService.CanGoForward;
            }
        }

        /// <summary>
        /// Navigates to the most recent item in forward navigation history.
        /// </summary>
        public virtual void GoForward()
        {
            if (CanGoForward)
            {
                _navigationService.GoForward();
            }
        }

        /// <summary>
        /// Removes the most recent available entry from the back stack.
        /// </summary>
        /// <returns>true if successfully removed the most recent available entry from the back stack; otherwise, false.</returns>
        public virtual bool RemoveBackEntry()
        {
            if (EnsureNavigationService() && _navigationService.CanGoBack)
            {
                _navigationService.RemoveBackEntry();

                return true;
            }

            return false;
        }

        /// <summary>
        /// Ensure that a <see cref="System.Windows.Navigation.NavigationService"/> instance has been found.
        /// </summary>
        /// <returns>true if a <see cref="System.Windows.Navigation.NavigationService"/> instance has been found; otherwise, false.</returns>
        protected virtual bool EnsureNavigationService()
        {
            if (_navigationService != null)
            {
                return true;
            }

            if (_mainFrame == null)
            {
                _mainFrame = Application.Current.RootVisual as PhoneApplicationFrame;

                if (_mainFrame != null)
                {
                    _mainFrame.Navigated += (s, e) =>
                    {
                        if (_navigationService == null)
                        {
                            GetNavigationServiceFromPage(e.Content as PhoneApplicationPage);
                        }

                        RaiseNavigated(null);
                    };

                    _mainFrame.BackKeyPress += (s, e) =>
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
                    };

                    if (GetNavigationServiceFromPage(_mainFrame.Content as PhoneApplicationPage))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Raises the <see cref="Navigated"/> event with the provided event data.
        /// </summary>
        /// <param name="eventArgs">The event data.</param>
        protected virtual void RaiseNavigated(EventArgs eventArgs)
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

        private bool GetNavigationServiceFromPage(PhoneApplicationPage page)
        {
            return page != null && (_navigationService = page.NavigationService) != null;
        }
    }
}