// ****************************************************************************
// <copyright file="ApplicationManifestLanguageNode.cs" company="Pedro Lamas">
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
using System.Xml;
#endif

namespace Cimbalino.Toolkit.Helpers
{
    /// <summary>
    /// Represents a language in the application manifest.
    /// </summary>
    public class ApplicationManifestLanguageNode
    {
        #region Properties

        /// <summary>
        /// Gets or sets the language code.
        /// </summary>
        /// <value>The language code.</value>
        public string Code { get; set; }

        #endregion

#if WINDOWS_PHONE
        internal static ApplicationManifestLanguageNode ParseXml(XmlReader reader)
        {
            var node = new ApplicationManifestLanguageNode()
            {
                Code = reader.GetAttribute("code")
            };

            reader.Skip();

            return node;
        }

#endif
    }
}