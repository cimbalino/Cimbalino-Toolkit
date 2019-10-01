// ****************************************************************************
// <copyright file="WindowsPhoneStoreServiceAppHwCapabilityNode.cs" company="Pedro Lamas">
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
    /// Represents an application hardware capability information.
    /// </summary>
    public class WindowsPhoneStoreServiceAppHwCapabilityNode
    {
        #region Properties

        /// <summary>
        /// Gets the application hardware capability requirement type.
        /// </summary>
        /// <value>The application hardware capability requirement type.</value>
        public string RequirementType { get; private set; }

        /// <summary>
        /// Gets the application hardware capability identifier.
        /// </summary>
        /// <value>The application hardware capability identifier.</value>
        public string Id { get; private set; }

        /// <summary>
        /// Gets the application hardware capability title.
        /// </summary>
        /// <value>The application hardware capability title.</value>
        public string Title { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the application hardware capability is required.
        /// </summary>
        /// <value>true if the application hardware capability is required; otherwise, false.</value>
        public bool? Required { get; private set; }

        #endregion

        internal static WindowsPhoneStoreServiceAppHwCapabilityNode ParseXml(XmlReader reader)
        {
            var node = new WindowsPhoneStoreServiceAppHwCapabilityNode();

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
                        case "requirementType":
                            node.RequirementType = reader.ReadElementContentAsString();
                            break;

                        case "id":
                            node.Id = reader.ReadElementContentAsString();
                            break;

                        case "string":
                            node.Title = reader.ReadElementContentAsString();
                            break;

                        case "required":
                            node.Required = reader.ReadElementContentAsBoolean();
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