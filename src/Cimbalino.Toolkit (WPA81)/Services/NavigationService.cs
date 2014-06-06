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
using Cimbalino.Toolkit.Extensions;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="INavigationService"/>.
    /// </summary>
    public class NavigationService : INavigationService
    {
        private Frame _mainFrame;

        /// <summary>
        /// Gets the uniform resource identifier (URI) of the content that is currently displayed.
        /// </summary>
        /// <value>Returns a value that represents the <see cref="Uri"/> of content that is currently displayed.</value>
        public Uri CurrentSource
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
        /// Gets a collection of query string values.
        /// </summary>
        /// <value>Returns a <see cref="IDictionary{TKey,TValue}"/> collection that contains the query string values.</value>
        public IDictionary<string, string> QueryString
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

        /// <summary>
        /// Navigates to the content specified by the uniform resource identifier (URI).
        /// </summary>
        /// <param name="source">The URI for the desired content.</param>
        /// <returns>true if navigation is not canceled; otherwise, false.</returns>
        public bool Navigate(string source)
        {
            return EnsureMainFrame() && _mainFrame.Navigate(Type.GetType(source));
        }

        /// <summary>
        /// Navigates to the content specified by the uniform resource identifier (URI).
        /// </summary>
        /// <param name="source">A <see cref="Uri"/> initialized with the URI for the desired content.</param>
        /// <returns>true if navigation is not canceled; otherwise, false.</returns>
        public bool Navigate(Uri source)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Navigates to the content specified by the type reference.
        /// </summary>
        /// <typeparam name="T">The page to navigate to, specified as a type reference to its partial class type.</typeparam>
        /// <returns>true if navigation is not canceled; otherwise, false.</returns>
        public bool Navigate<T>()
        {
            return EnsureMainFrame() && _mainFrame.Navigate(typeof(T));
        }

        /// <summary>
        /// Navigates to the content specified by the type reference.
        /// </summary>
        /// <typeparam name="T">The page to navigate to, specified as a type reference to its partial class type.</typeparam>
        /// <param name="parameter">The navigation parameter to pass to the target page; must have a basic type (string, char, numeric, or GUID).</param>
        /// <returns>true if navigation is not canceled; otherwise, false.</returns>
        public bool Navigate<T>(object parameter)
        {
            return EnsureMainFrame() && _mainFrame.Navigate(typeof(T), parameter);
        }

        /// <summary>
        /// Gets a value indicating whether there is at least one entry in back navigation history.
        /// </summary>
        /// <value>true if there is at least one entry in back navigation history; false if there are no entries in back navigation history.</value>
        public bool CanGoBack
        {
            get
            {
                return EnsureMainFrame() && _mainFrame.CanGoBack;
            }
        }

        /// <summary>
        /// Navigates to the most recent item in back navigation history.
        /// </summary>
        public void GoBack()
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
        public bool CanGoForward
        {
            get
            {
                return EnsureMainFrame() && _mainFrame.CanGoForward;
            }
        }

        /// <summary>
        /// Navigates to the most recent item in forward navigation history.
        /// </summary>
        public void GoForward()
        {
            if (EnsureMainFrame() && _mainFrame.CanGoForward)
            {
                _mainFrame.GoForward();
            }
        }

        /// <summary>
        /// Removes the most recent available entry from the back stack.
        /// </summary>
        public void RemoveBackEntry()
        {
            if (EnsureMainFrame() && _mainFrame.CanGoBack)
            {
                _mainFrame.BackStack.RemoveAt(_mainFrame.BackStackDepth - 1);
            }
        }

        private bool EnsureMainFrame()
        {
            if (_mainFrame != null)
            {
                return true;
            }

            _mainFrame = Window.Current.Content as Frame;

            return _mainFrame != null;
        }
    }
}