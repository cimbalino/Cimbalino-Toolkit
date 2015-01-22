// ****************************************************************************
// <copyright file="WindowsPhoneStoreServiceAppCategoryNode.cs" company="Pedro Lamas">
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

using System;
using System.Xml;
using Cimbalino.Toolkit.Extensions;

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents an application category information.
    /// </summary>
    public class WindowsPhoneStoreServiceAppCategoryNode
    {
        #region Properties

        /// <summary>
        /// Gets the application category identifier.
        /// </summary>
        /// <value>The application category identifier.</value>
        public string Id { get; private set; }

        /// <summary>
        /// Gets the application category title.
        /// </summary>
        /// <value>The application category title.</value>
        public string Title { get; private set; }

        /// <summary>
        /// Gets a value indicating if this is a root category.
        /// </summary>
        /// <value>true if this is a root category; otherwise, false.</value>
        public bool? IsRoot { get; private set; }

        /// <summary>
        /// Gets the application category parent category identifier.
        /// </summary>
        /// <value>The application category parent category identifier.</value>
        public string ParentId { get; private set; }

        #endregion

        internal static WindowsPhoneStoreServiceAppCategoryNode ParseXml(XmlReader reader)
        {
            var node = new WindowsPhoneStoreServiceAppCategoryNode();

            if (reader.IsEmptyElement)
            {
                reader.Skip();
            }
            else
            {
                reader.ReadStartElement();

                while (reader.NodeType != XmlNodeType.EndElement)
                {
                    switch (reader.LocalName)
                    {
                        case "id":
                            node.Id = reader.ReadElementContentAsUrn();
                            break;

                        case "title":
                            node.Title = reader.ReadElementContentAsString();
                            break;

                        case "isRoot":
                            node.IsRoot = string.Equals(reader.ReadElementContentAsString(), bool.TrueString, StringComparison.OrdinalIgnoreCase);
                            break;

                        case "parentId":
                            node.ParentId = reader.ReadElementContentAsString();
                            break;

                        default:
                            reader.Skip();
                            break;
                    }
                }

                reader.ReadEndElement();
            }

            return node;
        }
    }
}