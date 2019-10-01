// ****************************************************************************
// <copyright file="FilePickerServiceLocationId.cs" company="Pedro Lamas">
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
    /// Identifies the storage location that the file picker presents to the user.
    /// </summary>
    public enum FilePickerServiceLocationId
    {
        /// <summary>
        /// The Documents library.
        /// </summary>
        DocumentsLibrary,

        /// <summary>
        /// The Computer folder.
        /// </summary>
        ComputerFolder,

        /// <summary>
        /// The Windows desktop.
        /// </summary>
        Desktop,

        /// <summary>
        /// The Downloads folder.
        /// </summary>
        Downloads,

        /// <summary>
        /// The HomeGroup.
        /// </summary>
        HomeGroup,

        /// <summary>
        /// The Music library.
        /// </summary>
        MusicLibrary,

        /// <summary>
        /// The Pictures library.
        /// </summary>
        PicturesLibrary,

        /// <summary>
        /// The Videos library.
        /// </summary>
        VideosLibrary,

        /// <summary>
        /// The Objects library.
        /// </summary>
        Objects3D,

        /// <summary>
        /// An unspecified location.
        /// </summary>
        Unspecified,
    }
}