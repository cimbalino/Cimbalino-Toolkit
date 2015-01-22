// ****************************************************************************
// <copyright file="WindowsPhoneStoreServiceAppImageNode.cs" company="Pedro Lamas">
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
using Cimbalino.Toolkit.Extensions;

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents an application image information.
    /// </summary>
    public class WindowsPhoneStoreServiceAppImageNode
    {
        #region Properties

        /// <summary>
        /// Gets the application image identifier.
        /// </summary>
        /// <value>The application image identifier.</value>
        public string Id { get; private set; }

        /// <summary>
        /// Gets the application image orientation.
        /// </summary>
        /// <value>The application image orientation.</value>
        public int? Orientation { get; private set; }

        #endregion

        internal static WindowsPhoneStoreServiceAppImageNode ParseXml(XmlReader reader)
        {
            var node = new WindowsPhoneStoreServiceAppImageNode();

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

                        case "orientation":
                            node.Orientation = reader.ReadElementContentAsInt();
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