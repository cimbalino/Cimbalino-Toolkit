// ****************************************************************************
// <copyright file="IMasterDetailFrame.cs" company="Pedro Lamas">
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

namespace Cimbalino.Toolkit.Controls
{
    /// <summary>
    /// Represents the basic operations for the MasterDetail control.
    /// </summary>
    public interface IMasterDetailFrame
    {
        /// <summary>
        /// Called when the user presses the hardware back button.
        /// </summary>
        /// <returns>true if the back button press has been handled; otherwise, false.</returns>
        bool HandleBackKeyPress();
    }
}