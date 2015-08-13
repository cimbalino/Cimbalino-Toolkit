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
    public interface ITitleBarService
    {
        /// <summary>
        /// Sets the extend view into title bar.
        /// </summary>
        /// <param name="extend">if set to <c>true</c> [extend].</param>
        void SetExtendViewIntoTitleBar(bool extend);

        /// <summary>
        /// Occurs when [is visible changed].
        /// </summary>
        event EventHandler<TitleBarIsVisibleChangedArgs> IsVisibleChanged;

        /// <summary>
        /// Gets the height.
        /// </summary>
        /// <value>
        /// The height.
        /// </value>
        double Height { get; }
    }
}
