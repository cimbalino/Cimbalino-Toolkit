// ****************************************************************************
// <copyright file="HandledNavigationMode.cs" company="Pedro Lamas">
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

namespace Cimbalino.Toolkit.Handlers
{
    /// <summary>
    /// Specifies the navigation stack characteristics of a navigation.
    /// </summary>
    public enum HandledNavigationMode
    {
        /// <summary>
        /// Navigation is to a new instance of a page (not going forward or backward in the stack).
        /// </summary>
        New = 0,

        /// <summary>
        /// Navigation is going backward in the stack.
        /// </summary>
        Back = 1,

        /// <summary>
        /// Navigation is going forward in the stack.
        /// </summary>
        Forward = 2,

        /// <summary>
        /// Navigation is to the current page (perhaps with different data).
        /// </summary>
        Refresh = 3,

        /// <summary>
        /// Navigation is to reset the current page (perhaps with same data).
        /// </summary>
        Reset = 4
    }
}