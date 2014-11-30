// ****************************************************************************
// <copyright file="ApplicationManifestBackgroundServiceAgentNode.cs" company="Pedro Lamas">
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

#if WINDOWS_PHONE
using System.Diagnostics.CodeAnalysis;
using System.Xml;
#else
using System.Diagnostics.CodeAnalysis;
#endif

namespace Cimbalino.Toolkit.Helpers
{
    /// <summary>
    /// Represents a background service agent in the application manifest.
    /// </summary>
    public class ApplicationManifestBackgroundServiceAgentNode
    {
        #region Properties

        /// <summary>
        /// Gets or sets the background service agent specifier.
        /// </summary>
        /// <value>The background service agent specifier.</value>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public string Specifier { get; set; }

        /// <summary>
        /// Gets or sets the background service agent name.
        /// </summary>
        /// <value>The background service agent name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the background service agent source.
        /// </summary>
        /// <value>The background service agent source.</value>
        public string Source { get; set; }

        /// <summary>
        /// Gets or sets the background service agent type.
        /// </summary>
        /// <value>The background service agent type.</value>
        public string Type { get; set; }

        #endregion

#if WINDOWS_PHONE
        internal static ApplicationManifestBackgroundServiceAgentNode ParseXml(XmlReader reader)
        {
            var node = new ApplicationManifestBackgroundServiceAgentNode()
            {
                Specifier = reader.GetAttribute("Specifier"),
                Name = reader.GetAttribute("Name"),
                Source = reader.GetAttribute("Source"),
                Type = reader.GetAttribute("Type")
            };

            reader.Skip();

            return node;
        }
#endif
    }
}