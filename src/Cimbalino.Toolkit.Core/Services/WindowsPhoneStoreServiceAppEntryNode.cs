// ****************************************************************************
// <copyright file="WindowsPhoneStoreServiceAppEntryNode.cs" company="Pedro Lamas">
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
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Xml;
using Cimbalino.Toolkit.Extensions;

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents the contents of the application entry information from the store.
    /// </summary>
    public class WindowsPhoneStoreServiceAppEntryNode
    {
        #region Properties

        /// <summary>
        /// Gets the application entry .
        /// </summary>
        /// <value>The application entry .</value>
        public DateTime? Updated { get; private set; }

        /// <summary>
        /// Gets the application entry title.
        /// </summary>
        /// <value>The application entry title.</value>
        public WindowsPhoneStoreServiceAppContentNode Title { get; private set; }

        /// <summary>
        /// Gets the application entry identifier.
        /// </summary>
        /// <value>The application entry identifier.</value>
        public string Id { get; private set; }

        /// <summary>
        /// Gets the application entry version.
        /// </summary>
        /// <value>The application entry version.</value>
        public string Version { get; private set; }

        /// <summary>
        /// Gets the application entry payload identifier.
        /// </summary>
        /// <value>The application entry payload identifier.</value>
        public string PayloadId { get; private set; }

        /// <summary>
        /// Gets the application entry sku identifier.
        /// </summary>
        /// <value>The application entry sku identifier.</value>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public string SkuId { get; private set; }

        /// <summary>
        /// Gets the application entry sku last updated.
        /// </summary>
        /// <value>The application entry sku last updated.</value>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public DateTime? SkuLastUpdated { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the application entry is available in the country.
        /// </summary>
        /// <value>true if the application entry is available in the country; otherwise, false.</value>
        public bool? IsAvailableInCountry { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the application entry is available in the store.
        /// </summary>
        /// <value>true if the application entry is available in the store; otherwise, false.</value>
        public bool? IsAvailableInStore { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the application entry is compatible with the client type.
        /// </summary>
        /// <value>true if the application entry is compatible with the client type; otherwise, false.</value>
        public bool? IsClientTypeCompatible { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the application entry is compatible with the hardware.
        /// </summary>
        /// <value>true if the application entry is compatible with the hardware; otherwise, false.</value>
        public bool? IsHardwareCompatible { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the application entry is blacklisted.
        /// </summary>
        /// <value>true if the application entry is blacklisted; otherwise, false.</value>
        public bool? IsBlacklisted { get; private set; }

        /// <summary>
        /// Gets the application entry url.
        /// </summary>
        /// <value>The application entry url.</value>
        public string Url { get; private set; }

        /// <summary>
        /// Gets the application entry package size.
        /// </summary>
        /// <value>The application entry package size.</value>
        public int? PackageSize { get; private set; }

        /// <summary>
        /// Gets the application entry install size.
        /// </summary>
        /// <value>The application entry install size.</value>
        public int? InstallSize { get; private set; }

        /// <summary>
        /// Gets the application entry client types.
        /// </summary>
        /// <value>The application entry client types.</value>
        public string[] ClientTypes { get; private set; }

        /// <summary>
        /// Gets the application entry supported languages.
        /// </summary>
        /// <value>The application entry supported languages.</value>
        public string[] SupportedLanguages { get; private set; }

        /// <summary>
        /// Gets the application entry device capabilities.
        /// </summary>
        /// <value>The application entry device capabilities.</value>
        public WindowsPhoneStoreServiceAppCapabilitiesNode DeviceCapabilities { get; private set; }

        #endregion

        internal static WindowsPhoneStoreServiceAppEntryNode ParseXml(XmlReader reader)
        {
            var node = new WindowsPhoneStoreServiceAppEntryNode();

            reader.ReadStartElement();

            while (reader.NodeType != XmlNodeType.EndElement)
            {
                switch (reader.Name)
                {
                    case "a:updated":
                        node.Updated = reader.ReadElementContentAsNullable<DateTime>();
                        break;

                    case "a:title":
                        node.Title = WindowsPhoneStoreServiceAppContentNode.ParseXml(reader);
                        break;

                    case "a:id":
                        node.Id = reader.ReadElementContentAsUrn();
                        break;

                    case "version":
                        node.Version = reader.ReadElementContentAsString();
                        break;

                    case "payloadId":
                        node.PayloadId = reader.ReadElementContentAsUrn();
                        break;

                    case "skuId":
                        node.SkuId = reader.ReadElementContentAsUrn();
                        break;

                    case "skuLastUpdated":
                        node.SkuLastUpdated = reader.ReadElementContentAsNullable<DateTime>();
                        break;

                    case "isAvailableInCountry":
                        node.IsAvailableInCountry = reader.ReadElementContentAsBoolean();
                        break;

                    case "isAvailableInStore":
                        node.IsAvailableInStore = reader.ReadElementContentAsBoolean();
                        break;

                    case "isClientTypeCompatible":
                        node.IsClientTypeCompatible = reader.ReadElementContentAsBoolean();
                        break;

                    case "isHardwareCompatible":
                        node.IsHardwareCompatible = reader.ReadElementContentAsBoolean();
                        break;

                    case "isBlacklisted":
                        node.IsBlacklisted = reader.ReadElementContentAsBoolean();
                        break;

                    case "url":
                        node.Url = reader.ReadElementContentAsString();
                        break;

                    case "packageSize":
                        node.PackageSize = reader.ReadElementContentAsInt();
                        break;

                    case "installSize":
                        node.InstallSize = reader.ReadElementContentAsInt();
                        break;

                    case "clientTypes":
                        node.ClientTypes = reader.ReadElementContentAsArray(x => x.ReadElementContentAsString());
                        break;

                    case "supportedLanguages":
                        node.SupportedLanguages = reader.ReadElementContentAsArray(x => x.ReadElementContentAsString());
                        break;

                    case "deviceCapabilities":
                        var deviceCapabilitiesString = reader.ReadElementContentAsString();

                        if (!string.IsNullOrEmpty(deviceCapabilitiesString))
                        {
                            deviceCapabilitiesString = string.Format("<root>{0}</root>", deviceCapabilitiesString);

                            using (var stringReader = new StringReader(deviceCapabilitiesString))
                            {
                                using (var reader2 = XmlReader.Create(stringReader))
                                {
                                    reader2.ReadStartElement();

                                    node.DeviceCapabilities = WindowsPhoneStoreServiceAppCapabilitiesNode.ParseXml(reader2);

                                    reader2.ReadEndElement();
                                }
                            }
                        }
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