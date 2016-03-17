// ****************************************************************************
// <copyright file="FilePickerServiceViewMode.cs" company="Pedro Lamas">
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
    /// Indicates the view mode that the file picker is using to present items.
    /// </summary>
    public enum FilePickerServiceViewMode
    {
        /// <summary>
        /// A list of items.
        /// </summary>
        List,

        /// <summary>
        /// A set of thumbnail images.
        /// </summary>
        Thumbnail
    }
}