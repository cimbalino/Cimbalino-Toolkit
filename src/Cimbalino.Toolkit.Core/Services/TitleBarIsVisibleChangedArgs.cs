// ****************************************************************************
// <copyright file="TitleBarIsVisibleChangedArgs.cs" company="Pedro Lamas">
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

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Provides data for <see cref="ITitleBarService.IsVisibleChanged"/> events.
    /// </summary>
    public class TitleBarIsVisibleChangedArgs : EventArgs
    {
        /// <summary>
        /// Gets a value indicating whether the title bar is visible.
        /// </summary>
        /// <value>true if the title bar is visible; otherwise, false.</value>
        public bool IsVisible { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TitleBarIsVisibleChangedArgs"/> class.
        /// </summary>
        /// <param name="isVisible">The title bar visibility state.</param>
        public TitleBarIsVisibleChangedArgs(bool isVisible)
        {
            IsVisible = isVisible;
        }
    }
}