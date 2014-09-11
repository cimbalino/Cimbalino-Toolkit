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
using Windows.Phone.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
#else
using System;
using System.Collections.Generic;
using Cimbalino.Toolkit.Extensions;
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
#if WINDOWS_PHONE_APP
        public event EventHandler<NavigationServiceBackKeyPressedEventArgs> BackKeyPressed;
#else
        public event EventHandler<NavigationServiceBackKeyPressedEventArgs> BackKeyPressed
        {
            add
            {
                throw new NotSupportedException();
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
        /// Gets any parameter object passed to the target page for the navigation.
        /// </summary>
        /// <value>Any parameter object passed to the target page for the navigation.</value>
        public object CurrentParameter { get; private set; }

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
        /// <returns>true if successfully removed the most recent available entry from the back stack; otherwise, false.</returns>
        public bool RemoveBackEntry()
        {
            if (EnsureMainFrame() && _mainFrame.CanGoBack)
            {
                _mainFrame.BackStack.RemoveAt(_mainFrame.BackStackDepth - 1);

                return true;
            }

            return false;
        }

        private bool EnsureMainFrame()
        {
            if (_mainFrame != null)
            {
                return true;
            }

            _mainFrame = Window.Current.Content as Frame;

            if (_mainFrame != null)
            {
                _mainFrame.Navigated += (s, e) =>
                {
                    CurrentParameter = e.Parameter;

                    var eventHandler = Navigated;

                    if (eventHandler != null)
                    {
                        eventHandler(this, null);
                    }
                };

#if WINDOWS_PHONE_APP
                HardwareButtons.BackPressed += (s, e) =>
                {
                    var eventHandler = BackKeyPressed;
                    var eventArgs = new NavigationServiceBackKeyPressedEventArgs();

                    if (eventHandler != null)
                    {
                        eventHandler(this, eventArgs);
                    }

                    switch (eventArgs.Behavior)
                    {
                        case NavigationServiceBackKeyPressedBehavior.GoBack:
                            if (_mainFrame.CanGoBack)
                            {
                                _mainFrame.GoBack();

                                e.Handled = true;
                            }
                            break;

                        case NavigationServiceBackKeyPressedBehavior.HideApp:
                            break;

                        case NavigationServiceBackKeyPressedBehavior.ExitApp:
                            e.Handled = true;
                            Application.Current.Exit();
                            break;

                        case NavigationServiceBackKeyPressedBehavior.DoNothing:
                            e.Handled = true;
                            break;

                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                };
#endif

                return true;
            }

            return false;
        }
    }
}