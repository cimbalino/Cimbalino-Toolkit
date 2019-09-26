// ****************************************************************************
// <copyright file="AfterAutoFocusEventArgs.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2014
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <project>Cimbalino.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using Windows.UI.Xaml.Controls;

namespace Cimbalino.Toolkit.Behaviors
{
    /// <summary>
    /// Provides data for <see cref="AutoFocusBehavior.AfterAutoFocus"/> events.
    /// </summary>
    public class AfterAutoFocusEventArgs : EventArgs
    {
        #region Properties

        /// <summary>
        /// Gets the previous focused control.
        /// </summary>
        /// <value>The previous focused control.</value>
        public Control FromControl { get; private set; }

        /// <summary>
        /// Gets the current focused control.
        /// </summary>
        /// <value>The current focused control.</value>
        public Control ToControl { get; private set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="AfterAutoFocusEventArgs"/> class.
        /// </summary>
        /// <param name="fromControl">The previous focused control.</param>
        /// <param name="toControl">The current focused control.</param>
        public AfterAutoFocusEventArgs(Control fromControl, Control toControl)
        {
            FromControl = fromControl;
            ToControl = toControl;
        }
    }
}