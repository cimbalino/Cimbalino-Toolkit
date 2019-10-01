// ****************************************************************************
// <copyright file="ITitleBarService.cs" company="Pedro Lamas">
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
    /// Represents a service capable of managing the window title bar.
    /// </summary>
    public interface ITitleBarService
    {
        /// <summary>
        /// Occurs when the visibility of the title bar changes.
        /// </summary>
        event EventHandler<TitleBarIsVisibleChangedArgs> IsVisibleChanged;

        /// <summary>
        /// Gets or sets a value indicating whether this title bar should replace the default window title bar.
        /// </summary>
        /// <value>true if this title bar should replace the default window title bar; otherwise, false.</value>
        bool ExtendViewIntoTitleBar { get; set; }

        /// <summary>
        /// Gets the title bar height.
        /// </summary>
        /// <value>The title bar height.</value>
        double Height { get; }
    }
}
