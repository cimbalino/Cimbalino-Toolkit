// ****************************************************************************
// <copyright file="IBurgerMenuChecker.cs" company="Pedro Lamas">
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

using System;
using Cimbalino.Toolkit.Controls;

namespace Cimbalino.Toolkit.Helpers
{
    /// <summary>
    /// Interface for determining if the burger menu item is active
    /// </summary>
    public interface IBurgerMenuChecker
    {
        /// <summary>
        /// Determines whether the specified button is active.
        /// </summary>
        /// <param name="button">The button.</param>
        /// <param name="compareAgainst">The compare against.</param>
        /// <returns>True if menu item is active</returns>
        bool IsActive(HamburgerMenuButton button, Type compareAgainst);
    }
}