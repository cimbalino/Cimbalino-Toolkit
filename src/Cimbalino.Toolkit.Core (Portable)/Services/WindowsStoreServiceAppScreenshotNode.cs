// ****************************************************************************
// <copyright file="WindowsStoreServiceAppScreenshotNode.cs" company="Pedro Lamas">
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

using System.Xml;

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents an application screenshot information.
    /// </summary>
    public class WindowsStoreServiceAppScreenshotNode
    {
        #region Properties

        /// <summary>
        /// Gets the application screenshot url.
        /// </summary>
        /// <value>The application screenshot url.</value>
        public string Url { get; private set; }

        /// <summary>
        /// Gets the application screenshot caption.
        /// </summary>
        /// <value>The application screenshot caption.</value>
        public string Caption { get; private set; }

        #endregion

        internal static WindowsStoreServiceAppScreenshotNode ParseXml(XmlReader reader)
        {
            var node = new WindowsStoreServiceAppScreenshotNode();

            reader.ReadStartElement();

            while (reader.NodeType != XmlNodeType.EndElement)
            {
                switch (reader.Name)
                {
                    case "U":
                        node.Url = reader.ReadElementContentAsString();
                        break;

                    case "Cap":
                        node.Caption = reader.ReadElementContentAsString();
                        break;

                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.ReadEndElement();

            return node;
        }
    }
}