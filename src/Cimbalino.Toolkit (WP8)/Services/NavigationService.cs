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
        /// Gets the uniform resource identifier (URI) of the content that is currently displayed.
        /// </summary>
        /// <value>Returns a value that represents the <see cref="Uri"/> of content that is currently displayed.</value>
        public Uri CurrentSource
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
        /// Gets a collection of query string values.
        /// </summary>
        /// <value>Returns a <see cref="IDictionary{TKey,TValue}"/> collection that contains the query string values.</value>
        public IDictionary<string, string> QueryString
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
        public bool Navigate(string source)
        {
            return Navigate(new Uri(source, UriKind.Relative));
        }

        /// <summary>
        /// Navigates to the content specified by the uniform resource identifier (URI).
        /// </summary>
        /// <param name="source">A <see cref="Uri"/> initialized with the URI for the desired content.</param>
        /// <returns>true if navigation is not canceled; otherwise, false.</returns>
        public bool Navigate(Uri source)
        {
            return EnsureNavigationService() && _navigationService.Navigate(source);
        }

        /// <summary>
        /// Navigates to the content specified by the type reference.
        /// </summary>
        /// <typeparam name="T">The page to navigate to, specified as a type reference to its partial class type.</typeparam>
        /// <returns>true if navigation is not canceled; otherwise, false.</returns>
        public bool Navigate<T>()
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Navigates to the content specified by the type reference.
        /// </summary>
        /// <typeparam name="T">The page to navigate to, specified as a type reference to its partial class type.</typeparam>
        /// <param name="parameter">The navigation parameter to pass to the target page; must have a basic type (string, char, numeric, or GUID).</param>
        /// <returns>true if navigation is not canceled; otherwise, false.</returns>
        public bool Navigate<T>(object parameter)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Gets a value indicating whether there is at least one entry in back navigation history.
        /// </summary>
        /// <value>true if there is at least one entry in back navigation history; false if there are no entries in back navigation history.</value>
        public bool CanGoBack
        {
            get
            {
                return EnsureNavigationService() && _navigationService.CanGoBack;
            }
        }

        /// <summary>
        /// Navigates to the most recent item in back navigation history.
        /// </summary>
        public void GoBack()
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
        public bool CanGoForward
        {
            get
            {
                return EnsureNavigationService() && _navigationService.CanGoForward;
            }
        }

        /// <summary>
        /// Navigates to the most recent item in forward navigation history.
        /// </summary>
        public void GoForward()
        {
            if (CanGoForward)
            {
                _navigationService.GoForward();
            }
        }

        /// <summary>
        /// Removes the most recent available entry from the back stack.
        /// </summary>
        public void RemoveBackEntry()
        {
            if (EnsureNavigationService() && _navigationService.CanGoBack)
            {
                _navigationService.RemoveBackEntry();
            }
        }

        private bool EnsureNavigationService()
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
                    };

                    if (GetNavigationServiceFromPage(_mainFrame.Content as PhoneApplicationPage))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool GetNavigationServiceFromPage(PhoneApplicationPage page)
        {
            return page != null && (_navigationService = page.NavigationService) != null;
        }
    }
}