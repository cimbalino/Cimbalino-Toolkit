// ****************************************************************************
// <copyright file="ApplicationManifestNamedNode.cs" company="Pedro Lamas">
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

#if WP8
using System.Xml;
#endif

namespace Cimbalino.Toolkit.Helpers
{
    /// <summary>
    /// Represents a named node in the application manifest.
    /// </summary>
    public class ApplicationManifestNamedNode
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Name attribute value.
        /// </summary>
        /// <value>The Name attribute value.</value>
        public string Name { get; set; }

        #endregion

#if WP8
        internal static ApplicationManifestNamedNode ParseXml(XmlReader reader)
        {
            var node = new ApplicationManifestNamedNode()
            {
                Name = reader.GetAttribute("Name")
            };

            reader.Skip();

            return node;
        }

#endif
    }
}