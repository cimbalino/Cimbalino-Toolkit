// ****************************************************************************
// <copyright file="WindowsPhoneStoreServiceAppOfferNode.cs" company="Pedro Lamas">
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
    /// Represents the contents of the application offer information from the store.
    /// </summary>
    public class WindowsPhoneStoreServiceAppOfferNode
    {
        #region Properties

        /// <summary>
        /// Gets the offer identifier.
        /// </summary>
        /// <value>The offer identifier.</value>
        public string OfferId { get; private set; }

        /// <summary>
        /// Gets the offer media instance identifier.
        /// </summary>
        /// <value>The offer media instance identifier.</value>
        public string MediaInstanceId { get; private set; }

        /// <summary>
        /// Gets the offer client types.
        /// </summary>
        /// <value>The offer client types.</value>
        public string[] ClientTypes { get; private set; }

        /// <summary>
        /// Gets the offer payment types.
        /// </summary>
        /// <value>The offer payment types.</value>
        public string[] PaymentTypes { get; private set; }

        /// <summary>
        /// Gets the offer store.
        /// </summary>
        /// <value>The offer store.</value>
        public string Store { get; private set; }

        /// <summary>
        /// Gets the offer price.
        /// </summary>
        /// <value>The offer price.</value>
        public double? Price { get; private set; }

        /// <summary>
        /// Gets the offer display price.
        /// </summary>
        /// <value>The offer display price.</value>
        public string DisplayPrice { get; private set; }

        /// <summary>
        /// Gets the offer price currency code.
        /// </summary>
        /// <value>The offer price currency code.</value>
        public string PriceCurrencyCode { get; private set; }

        /// <summary>
        /// Gets the offer license right.
        /// </summary>
        /// <value>The offer license right.</value>
        public string LicenseRight { get; private set; }

        /// <summary>
        /// Gets the offer expiration.
        /// </summary>
        /// <value>The offer expiration.</value>
        public DateTime? Expiration { get; private set; }

        #endregion

        internal static WindowsPhoneStoreServiceAppOfferNode ParseXml(XmlReader reader)
        {
            var node = new WindowsPhoneStoreServiceAppOfferNode();

            reader.ReadStartElement();

            while (reader.NodeType != XmlNodeType.EndElement)
            {
                switch (reader.LocalName)
                {
                    case "offerId":
                        node.OfferId = reader.ReadElementContentAsUrn();
                        break;

                    case "mediaInstanceId":
                        node.MediaInstanceId = reader.ReadElementContentAsUrn();
                        break;

                    case "clientTypes":
                        node.ClientTypes = reader.ReadElementContentAsArray(x => x.ReadElementContentAsString());
                        break;

                    case "paymentTypes":
                        node.PaymentTypes = reader.ReadElementContentAsArray(x => x.ReadElementContentAsString());
                        break;

                    case "store":
                        node.Store = reader.ReadElementContentAsString();
                        break;

                    case "price":
                        node.Price = reader.ReadElementContentAsDouble();
                        break;

                    case "displayPrice":
                        node.DisplayPrice = reader.ReadElementContentAsString();
                        break;

                    case "priceCurrencyCode":
                        node.PriceCurrencyCode = reader.ReadElementContentAsString();
                        break;

                    case "licenseRight":
                        node.LicenseRight = reader.ReadElementContentAsString();
                        break;

                    case "expiration":
                        node.Expiration = reader.ReadElementContentAsNullable<DateTime>();
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