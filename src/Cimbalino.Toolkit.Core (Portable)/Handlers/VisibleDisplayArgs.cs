// ****************************************************************************
// <copyright file="VisibleDisplayArgs.cs" company="Pedro Lamas">
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

namespace Cimbalino.Toolkit.Handlers
{
    /// <summary>
    /// The event args for IsDetailVisibleChanged event
    /// </summary>
    public class VisibleDisplayArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VisibleDisplayArgs"/> class.
        /// </summary>
        /// <param name="visibleDisplay">The visible display.</param>
        internal VisibleDisplayArgs(VisibleDisplay visibleDisplay)
        {
            VisibleDisplay = visibleDisplay;
        }

        /// <summary>
        /// Gets or sets the visible display.
        /// </summary>
        /// <value>
        /// The visible display.
        /// </value>
        public VisibleDisplay VisibleDisplay { get; set; }
    }
}
