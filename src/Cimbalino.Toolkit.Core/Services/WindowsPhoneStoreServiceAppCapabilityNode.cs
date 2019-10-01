// ****************************************************************************
// <copyright file="WindowsPhoneStoreServiceAppCapabilityNode.cs" company="Pedro Lamas">
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
    /// Represents an application capability information.
    /// </summary>
    public class WindowsPhoneStoreServiceAppCapabilityNode
    {
        #region Properties

        /// <summary>
        /// Gets the application capability identifier.
        /// </summary>
        /// <value>The application capability identifier.</value>
        public string Id { get; private set; }

        /// <summary>
        /// Gets the application capability title.
        /// </summary>
        /// <value>The application capability title.</value>
        public string Title { get; private set; }

        /// <summary>
        /// Gets the application capability disclosure state.
        /// </summary>
        /// <value>The application capability disclosure state.</value>
        public string Disclosure { get; private set; }

        #endregion

        internal static WindowsPhoneStoreServiceAppCapabilityNode ParseXml(XmlReader reader)
        {
            var node = new WindowsPhoneStoreServiceAppCapabilityNode();

            if (reader.IsEmptyElement)
            {
                reader.Skip();
            }
            else
            {
                reader.ReadStartElement();

                while (reader.NodeType != XmlNodeType.EndElement)
                {
                    switch (reader.Name)
                    {
                        case "id":
                            node.Id = reader.ReadElementContentAsString();
                            break;

                        case "string":
                            node.Title = reader.ReadElementContentAsString();
                            break;

                        case "disclosure":
                            node.Disclosure = reader.ReadElementContentAsString();
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