// ****************************************************************************
// <copyright file="INavigationService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2014
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <project>Cimbalino.Toolkit.Portable</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.Collections.Generic;

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of handling the application navigation.
    /// </summary>
    public interface INavigationService
    {
        /// <summary>
        /// Gets the uniform resource identifier (URI) of the content that is currently displayed.
        /// </summary>
        /// <value>Returns a value that represents the <see cref="Uri"/> of content that is currently displayed.</value>
        Uri CurrentSource { get; }

        /// <summary>
        /// Gets a collection of query string values.
        /// </summary>
        /// <value>Returns a <see cref="IDictionary{String,String}"/> collection that contains the query string values.</value>
        IDictionary<string, string> QueryString { get; }

        /// <summary>
        /// Navigates to the content specified by the uniform resource identifier (URI).
        /// </summary>
        /// <param name="source">The URI for the desired content.</param>
        /// <returns>true if navigation is not canceled; otherwise, false.</returns>
        bool Navigate(string source);

        /// <summary>
        /// Navigates to the content specified by the uniform resource identifier (URI).
        /// </summary>
        /// <param name="source">A <see cref="Uri"/> initialized with the URI for the desired content.</param>
        /// <returns>true if navigation is not canceled; otherwise, false.</returns>
        bool Navigate(Uri source);

        /// <summary>
        /// Navigates to the content specified by the type reference.
        /// </summary>
        /// <typeparam name="T">The page to navigate to, specified as a type reference to its partial class type.</typeparam>
        /// <returns>true if navigation is not canceled; otherwise, false.</returns>
        bool Navigate<T>();

        /// <summary>
        /// Navigates to the content specified by the type reference.
        /// </summary>
        /// <typeparam name="T">The page to navigate to, specified as a type reference to its partial class type.</typeparam>
        /// <param name="parameter">The navigation parameter to pass to the target page; must have a basic type (string, char, numeric, or GUID).</param>
        /// <returns>true if navigation is not canceled; otherwise, false.</returns>
        bool Navigate<T>(object parameter);

        /// <summary>
        /// Gets a value indicating whether there is at least one entry in back navigation history.
        /// </summary>
        /// <value>true if there is at least one entry in back navigation history; false if there are no entries in back navigation history.</value>
        bool CanGoBack { get; }

        /// <summary>
        /// Navigates to the most recent item in back navigation history.
        /// </summary>
        void GoBack();

        /// <summary>
        /// Gets a value indicating whether there is at least one entry in forward navigation history.
        /// </summary>
        /// <value>true if there is at least one entry in forward navigation history; false if there are no entries in forward navigation history.</value>
        bool CanGoForward { get; }

        /// <summary>
        /// Navigates to the most recent item in forward navigation history.
        /// </summary>
        void GoForward();

        /// <summary>
        /// Removes the most recent available entry from the back stack.
        /// </summary>
        void RemoveBackEntry();
    }
}