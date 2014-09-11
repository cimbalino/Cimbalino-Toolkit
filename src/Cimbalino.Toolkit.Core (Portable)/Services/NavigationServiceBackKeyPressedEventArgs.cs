// ****************************************************************************
// <copyright file="NavigationServiceBackKeyPressedEventArgs.cs" company="Pedro Lamas">
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
    /// Provides information for the <see cref="INavigationService.BackKeyPressed"/> event.
    /// </summary>
    public class NavigationServiceBackKeyPressedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the expected behavior for when the user presses the hardware Back button.
        /// </summary>
        /// <value>The expected behavior for when the user presses the hardware Back button.</value>
        public NavigationServiceBackKeyPressedBehavior Behavior { get; set; }
    }
}