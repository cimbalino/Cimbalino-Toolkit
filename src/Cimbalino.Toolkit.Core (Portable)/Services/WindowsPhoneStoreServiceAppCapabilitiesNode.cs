// ****************************************************************************
// <copyright file="WindowsPhoneStoreServiceAppCapabilitiesNode.cs" company="Pedro Lamas">
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

using System.Collections.Generic;
using System.Xml;

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents the application capabilities information.
    /// </summary>
    public class WindowsPhoneStoreServiceAppCapabilitiesNode
    {
        #region Properties

        /// <summary>
        /// Gets the application capabilities information.
        /// </summary>
        /// <value>The application capabilities information.</value>
        public WindowsPhoneStoreServiceAppCapabilityNode[] Capabilities { get; private set; }

        /// <summary>
        /// Gets the application hardware capabilities information.
        /// </summary>
        /// <value>The application hardware capabilities information.</value>
        public WindowsPhoneStoreServiceAppHwCapabilityNode[] HardwareCapabilities { get; private set; }

        #endregion

        internal static WindowsPhoneStoreServiceAppCapabilitiesNode ParseXml(XmlReader reader)
        {
            var node = new WindowsPhoneStoreServiceAppCapabilitiesNode();

            var capabilities = new List<WindowsPhoneStoreServiceAppCapabilityNode>();
            var hardwareCapabilities = new List<WindowsPhoneStoreServiceAppHwCapabilityNode>();

            if (reader.IsEmptyElement)
            {
                reader.Skip();
            }
            else
            {
                while (reader.NodeType != XmlNodeType.EndElement)
                {
                    switch (reader.Name)
                    {
                        case "capability":
                            capabilities.Add(WindowsPhoneStoreServiceAppCapabilityNode.ParseXml(reader));
                            break;

                        case "hwCapability":
                            hardwareCapabilities.Add(WindowsPhoneStoreServiceAppHwCapabilityNode.ParseXml(reader));
                            break;

                        default:
                            reader.Skip();
                            break;
                    }
                }
            }

            node.Capabilities = capabilities.ToArray();
            node.HardwareCapabilities = hardwareCapabilities.ToArray();

            return node;
        }
    }
}