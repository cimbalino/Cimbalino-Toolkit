// ****************************************************************************
// <copyright file="ApplicationManifestTokenNode.cs" company="Pedro Lamas">
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
    /// Represents a token in the application manifest.
    /// </summary>
    public class ApplicationManifestTokenNode
    {
        #region Properties

        /// <summary>
        /// Gets or sets the token id.
        /// </summary>
        /// <value>The token id.</value>
        public string TokenId { get; set; }

        /// <summary>
        /// Gets or sets the token task name.
        /// </summary>
        /// <value>The token task name.</value>
        public string TaskName { get; set; }

        #endregion

#if WP8
        internal static ApplicationManifestTokenNode ParseXml(XmlReader reader)
        {
            var node = new ApplicationManifestTokenNode()
            {
                TokenId = reader.GetAttribute("TokenID"),
                TaskName = reader.GetAttribute("TaskName")
            };

            reader.Skip();

            return node;
        }

#endif
    }
}