// ****************************************************************************
// <copyright file="WindowsStoreServiceAppArchitectureNode.cs" company="Pedro Lamas">
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
    /// Represents an application supported architecture information.
    /// </summary>
    public class WindowsStoreServiceAppArchitectureNode
    {
        #region Properties

        /// <summary>
        /// Gets the application supported architecture name.
        /// </summary>
        /// <value>The application supported architecture name.</value>
        public string Name { get; private set; }

        #endregion

        internal static WindowsStoreServiceAppArchitectureNode ParseXml(XmlReader reader)
        {
            var node = new WindowsStoreServiceAppArchitectureNode();

            reader.ReadStartElement();

            while (reader.NodeType != XmlNodeType.EndElement)
            {
                switch (reader.Name)
                {
                    case "An":
                        node.Name = reader.ReadElementContentAsString();
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