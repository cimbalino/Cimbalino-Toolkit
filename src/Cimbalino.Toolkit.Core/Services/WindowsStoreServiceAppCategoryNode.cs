// ****************************************************************************
// <copyright file="WindowsStoreServiceAppCategoryNode.cs" company="Pedro Lamas">
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
    /// Represents an application category information.
    /// </summary>
    public class WindowsStoreServiceAppCategoryNode
    {
        #region Properties

        /// <summary>
        /// Gets the application category identifier.
        /// </summary>
        /// <value>The application category identifier.</value>
        public int? Id { get; private set; }

        /// <summary>
        /// Gets the application category name.
        /// </summary>
        /// <value>The application category name.</value>
        public string Name { get; private set; }

        #endregion

        internal static WindowsStoreServiceAppCategoryNode ParseXml(XmlReader reader)
        {
            var node = new WindowsStoreServiceAppCategoryNode();

            reader.ReadStartElement();

            while (reader.NodeType != XmlNodeType.EndElement)
            {
                switch (reader.Name)
                {
                    case "I":
                        node.Id = reader.ReadElementContentAsInt();
                        break;

                    case "N":
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