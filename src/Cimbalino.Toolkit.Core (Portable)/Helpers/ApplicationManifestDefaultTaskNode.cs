// ****************************************************************************
// <copyright file="ApplicationManifestDefaultTaskNode.cs" company="Pedro Lamas">
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
    /// Represents a default task in the application manifest.
    /// </summary>
    public class ApplicationManifestDefaultTaskNode : ApplicationManifestTaskNodeBase
    {
        #region Properties

        /// <summary>
        /// Gets or sets the page to navigate.
        /// </summary>
        /// <value>The page to navigate.</value>
        public string NavigationPage { get; set; }

        #endregion
    }
}