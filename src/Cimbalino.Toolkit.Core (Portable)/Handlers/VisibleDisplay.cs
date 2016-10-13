// ****************************************************************************
// <copyright file="VisibleDisplay.cs" company="Pedro Lamas">
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
    /// Enum representing which display is visible in MasterDetailFrame
    /// </summary>
    public enum VisibleDisplay
    {
        /// <summary>
        /// Both Master and Detail are visible
        /// </summary>
        Both,

        /// <summary>
        /// Just Master is visible
        /// </summary>
        Master,

        /// <summary>
        /// The detail
        /// </summary>
        Detail
    }
}