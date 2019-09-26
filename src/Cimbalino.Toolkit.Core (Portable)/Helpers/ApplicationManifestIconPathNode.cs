// ****************************************************************************
// <copyright file="ApplicationManifestIconPathNode.cs" company="Pedro Lamas">
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

namespace Cimbalino.Toolkit.Helpers
{
    /// <summary>
    /// Represents the location of the app icon that is visible in the app list.
    /// </summary>
    public class ApplicationManifestIconPathNode
    {
        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether the icon location is relative.
        /// </summary>
        /// <value>true if the icon location is relative; otherwise false.</value>
        public bool IsRelative { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the icon is a resource.
        /// </summary>
        /// <value>true if the icon is a resource; otherwise false.</value>
        public bool IsResource { get; set; }

        /// <summary>
        /// Gets or sets the icon location.
        /// </summary>
        /// <value>The icon location.</value>
        public string Value { get; set; }

        #endregion
    }
}