// ****************************************************************************
// <copyright file="NavigationServiceBackKeyPressedBehavior.cs" company="Pedro Lamas">
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

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Indicates the expected behavior for when the user presses the hardware Back button.
    /// </summary>
    public enum NavigationServiceBackKeyPressedBehavior
    {
        /// <summary>
        /// Navigate to the most recent item in back navigation history.
        /// </summary>
        GoBack,

        /// <summary>
        /// Hide the app and returns to the main screen.
        /// </summary>
        HideApp,

        /// <summary>
        /// Shuts down the app.
        /// </summary>
        ExitApp,

        /// <summary>
        /// Do nothing.
        /// </summary>
        DoNothing
    }
}