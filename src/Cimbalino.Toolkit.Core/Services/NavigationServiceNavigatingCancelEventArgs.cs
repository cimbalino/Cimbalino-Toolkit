// ****************************************************************************
// <copyright file="NavigationServiceNavigatingCancelEventArgs.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2014
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <project>Cimbalino.Toolkit.Core</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.ComponentModel;
using Cimbalino.Toolkit.Handlers;

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Provides data for the <see cref="IHandleNavigatingFrom.OnNavigatingFromAsync"/> callback that can be used to cancel a navigation request from origination.
    /// </summary>
    public class NavigationServiceNavigatingCancelEventArgs : CancelEventArgs
    {
        /// <summary>
        /// Gets a value that indicates the direction of movement during navigation.
        /// </summary>
        /// <value>A value that indicates the direction of movement during navigation.</value>
        public NavigationServiceNavigationMode NavigationMode { get; private set; }

        /// <summary>
        /// Gets the data type of the source page.
        /// </summary>
        /// <value>The data type of the source page.</value>
        public Type SourcePageType { get; private set; }

        /// <summary>
        /// Gets any Parameter object passed to the target page for the navigation.
        /// </summary>
        /// <value>Any Parameter object passed to the target page for the navigation.</value>
        public object Parameter { get; private set; }

        /// <summary>
        /// Gets the Uniform Resource Identifier (URI) of the target.
        /// </summary>
        /// <value>The Uniform Resource Identifier (URI) of the target.</value>
        public Uri Uri { get; private set; }

        /// <summary>
        /// Gets a value indicating whether you can cancel the navigation.
        /// </summary>
        /// <value>true if you can cancel the navigation; otherwise, false.</value>
        public bool IsCancelable { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationServiceNavigatingCancelEventArgs"/> class.
        /// </summary>
        /// <param name="navigationMode">A value that indicates the direction of movement during navigation.</param>
        /// <param name="sourcePageType">The data type of the source page.</param>
        /// <param name="parameter">Any Parameter object passed to the target page for the navigation.</param>
        /// <param name="uri">The Uniform Resource Identifier (URI) of the target.</param>
        /// <param name="isCancelable">A value that indicates whether the navigation is cancelable.</param>
        public NavigationServiceNavigatingCancelEventArgs(NavigationServiceNavigationMode navigationMode, Type sourcePageType, object parameter, Uri uri, bool isCancelable)
        {
            NavigationMode = navigationMode;
            SourcePageType = sourcePageType;
            Parameter = parameter;
            Uri = uri;
            IsCancelable = isCancelable;
        }
    }
}