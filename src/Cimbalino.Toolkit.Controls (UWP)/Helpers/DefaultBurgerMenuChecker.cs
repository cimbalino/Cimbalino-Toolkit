// ****************************************************************************
// <copyright file="DefaultBurgerMenuChecker.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2014
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <project>Cimbalino.Toolkit.Controls</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using Cimbalino.Toolkit.Controls;
using Cimbalino.Toolkit.Services;

namespace Cimbalino.Toolkit.Helpers
{
    /// <summary>
    /// The default implmentation of <see cref="IBurgerMenuChecker" />
    /// </summary>
    /// <seealso cref="IBurgerMenuChecker" />
    public class DefaultBurgerMenuChecker : IBurgerMenuChecker
    {
        /// <summary>
        /// Determines whether the specified button is active.
        /// </summary>
        /// <param name="button">The button.</param>
        /// <param name="args">The <see cref="NavigationServiceNavigationEventArgs" /> instance containing the event data.</param>
        /// <returns>
        /// True if menu item is active
        /// </returns>
        public bool IsActive(HamburgerMenuButton button, NavigationServiceNavigationEventArgs args)
        {
            return button.NavigationSourcePageType == args.SourcePageType;
        }
    }
}
