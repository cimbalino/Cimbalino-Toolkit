// ****************************************************************************
// <copyright file="WindowsStoreServiceAppPackageNode.cs" company="Pedro Lamas">
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
    /// Represents an application package information.
    /// </summary>
    public class WindowsStoreServiceAppPackageNode
    {
        #region Properties

        /// <summary>
        /// Gets the application package identifier.
        /// </summary>
        /// <value>The application package identifier.</value>
        public string Id { get; private set; }

        /// <summary>
        /// Gets the application package release identifier.
        /// </summary>
        /// <value>The application package release identifier.</value>
        public string ReleaseId { get; private set; }

        /// <summary>
        /// Gets the application package family name.
        /// </summary>
        /// <value>The application package family name.</value>
        public string FamilyName { get; private set; }

        /// <summary>
        /// Gets the application package language.
        /// </summary>
        /// <value>The application package language.</value>
        public string Language { get; private set; }

        /// <summary>
        /// Gets the application package title.
        /// </summary>
        /// <value>The application package title.</value>
        public string Title { get; private set; }

        /// <summary>
        /// Gets the application package icon.
        /// </summary>
        /// <value>The application package icon.</value>
        public string Icon { get; private set; }

        /// <summary>
        /// Gets the application package background color.
        /// </summary>
        /// <value>The application package background color.</value>
        public string BackgroundColor { get; private set; }

        /// <summary>
        /// Gets the application package foreground color.
        /// </summary>
        /// <value>The application package foreground color.</value>
        public string ForegroundColor { get; private set; }

        /// <summary>
        /// Gets the application package currency symbol.
        /// </summary>
        /// <value>The application package currency symbol.</value>
        public string CurrencySymbol { get; private set; }

        /// <summary>
        /// Gets the application package currency.
        /// </summary>
        /// <value>The application package currency.</value>
        public string Currency { get; private set; }

        /// <summary>
        /// Gets the application package price.
        /// </summary>
        /// <value>The application package price.</value>
        public double? Price { get; private set; }

        /// <summary>
        /// Gets the application package category.
        /// </summary>
        /// <value>The application package category.</value>
        public WindowsStoreServiceAppCategoryNode Category { get; private set; }

        /// <summary>
        /// Gets the application package sub-category.
        /// </summary>
        /// <value>The application package sub-category.</value>
        public WindowsStoreServiceAppCategoryNode SubCategory { get; private set; }

        /// <summary>
        /// Gets the application package last update.
        /// </summary>
        /// <value>The application package last update.</value>
        public DateTime? LastUpdate { get; private set; }

        #endregion

        internal static WindowsStoreServiceAppPackageNode ParseXml(XmlReader reader)
        {
            var node = new WindowsStoreServiceAppPackageNode();

            reader.ReadStartElement();

            while (reader.NodeType != XmlNodeType.EndElement)
            {
                switch (reader.Name)
                {
                    case "I":
                        node.Id = reader.ReadElementContentAsString();
                        break;

                    case "R":
                        node.ReleaseId = reader.ReadElementContentAsString();
                        break;

                    case "Pfn":
                        node.FamilyName = reader.ReadElementContentAsString();
                        break;

                    case "L":
                        node.Language = reader.ReadElementContentAsString();
                        break;

                    case "T":
                        node.Title = reader.ReadElementContentAsString();
                        break;

                    case "Ico":
                        node.Icon = reader.ReadElementContentAsString();
                        break;

                    case "Bg":
                        node.BackgroundColor = reader.ReadElementContentAsString();
                        break;

                    case "Fg":
                        node.ForegroundColor = reader.ReadElementContentAsString();
                        break;

                    case "Cs":
                        node.CurrencySymbol = reader.ReadElementContentAsString();
                        break;

                    case "Cc":
                        node.Currency = reader.ReadElementContentAsString();
                        break;

                    case "P":
                        node.Price = reader.ReadElementContentAsDouble();
                        break;

                    case "C":
                        node.Category = WindowsStoreServiceAppCategoryNode.ParseXml(reader);
                        break;

                    case "Sc":
                        node.SubCategory = WindowsStoreServiceAppCategoryNode.ParseXml(reader);
                        break;

                    case "Lud":
                        node.LastUpdate = reader.ReadElementContentAsNullable<DateTime>();
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