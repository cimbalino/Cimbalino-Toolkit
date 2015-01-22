// ****************************************************************************
// <copyright file="WindowsPhoneStoreServiceAppNode.cs" company="Pedro Lamas">
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
using System.Xml;
using Cimbalino.Toolkit.Extensions;

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents the contents of the application information from the store.
    /// </summary>
    public class WindowsPhoneStoreServiceAppNode
    {
        #region Properties

        /// <summary>
        /// Gets a value indicating whether the application is updated.
        /// </summary>
        /// <value>true if the application is updated; otherwise false.</value>
        public DateTime? Updated { get; private set; }

        /// <summary>
        /// Gets the application title.
        /// </summary>
        /// <value>The application title.</value>
        public string Title { get; private set; }

        /// <summary>
        /// Gets the application identifier.
        /// </summary>
        /// <value>The application identifier.</value>
        public string Id { get; private set; }

        /// <summary>
        /// Gets the application content information.
        /// </summary>
        /// <value>The application content information.</value>
        public WindowsPhoneStoreServiceAppContentNode Content { get; private set; }

        /// <summary>
        /// Gets the application content iap count.
        /// </summary>
        /// <value>The application content iap count.</value>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public int? IapCount { get; private set; }

        /// <summary>
        /// Gets the application user rating count distributions.
        /// </summary>
        /// <value>The application user rating count distributions.</value>
        public WindowsPhoneStoreServiceAppRatingsDistributionsNode UserRatingCountDistributions { get; private set; }

        /// <summary>
        /// Gets the application sort title.
        /// </summary>
        /// <value>The application sort title.</value>
        public string SortTitle { get; private set; }

        /// <summary>
        /// Gets the application release date.
        /// </summary>
        /// <value>The application release date.</value>
        public DateTime? ReleaseDate { get; private set; }

        /// <summary>
        /// Gets the application visibility state.
        /// </summary>
        /// <value>The application visibility state.</value>
        public string VisibilityStatus { get; private set; }

        /// <summary>
        /// Gets the application publisher.
        /// </summary>
        /// <value>The application publisher.</value>
        public string Publisher { get; private set; }

        /// <summary>
        /// Gets the application average user rating.
        /// </summary>
        /// <value>The application average user rating.</value>
        public double? AverageUserRating { get; private set; }

        /// <summary>
        /// Gets the application user rating count.
        /// </summary>
        /// <value>The application user rating count.</value>
        public int? UserRatingCount { get; private set; }

        /// <summary>
        /// Gets the application image.
        /// </summary>
        /// <value>The application image.</value>
        public WindowsPhoneStoreServiceAppImageNode Image { get; private set; }

        /// <summary>
        /// Gets the application screenshots.
        /// </summary>
        /// <value>The application screenshots.</value>
        public WindowsPhoneStoreServiceAppImageNode[] Screenshots { get; private set; }

        /// <summary>
        /// Gets the application categories.
        /// </summary>
        /// <value>The application categories.</value>
        public WindowsPhoneStoreServiceAppCategoryNode[] Categories { get; private set; }

        /// <summary>
        /// Gets the application tags.
        /// </summary>
        /// <value>The application tags.</value>
        public string[] Tags { get; private set; }

        /// <summary>
        /// Gets the application tax string.
        /// </summary>
        /// <value>The application tax string.</value>
        public string TaxString { get; private set; }

        /// <summary>
        /// Gets the application background image.
        /// </summary>
        /// <value>The application background image.</value>
        public WindowsPhoneStoreServiceAppImageNode BackgroundImage { get; private set; }

        /// <summary>
        /// Gets the application available offers.
        /// </summary>
        /// <value>The application available offers.</value>
        public WindowsPhoneStoreServiceAppOfferNode[] Offers { get; private set; }

        /// <summary>
        /// Gets the application publisher identifier.
        /// </summary>
        /// <value>The application publisher identifier.</value>
        public string PublisherId { get; private set; }

        /// <summary>
        /// Gets the application publisher unique identifier.
        /// </summary>
        /// <value>The application publisher unique identifier.</value>
        public string PublisherGuid { get; private set; }

        /// <summary>
        /// Gets the application entry information.
        /// </summary>
        /// <value>The application entry information.</value>
        public WindowsPhoneStoreServiceAppEntryNode Entry { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the application is an Universal App.
        /// </summary>
        /// <value>true if the application is an Universal App; otherwise, false.</value>
        public bool? IsUniversal { get; private set; }

        #endregion

        internal static WindowsPhoneStoreServiceAppNode ParseXml(XmlReader reader)
        {
            var node = new WindowsPhoneStoreServiceAppNode();

            reader.ReadStartElement();

            while (reader.NodeType != XmlNodeType.EndElement)
            {
                switch (reader.Name)
                {
                    case "a:updated":
                        node.Updated = reader.ReadElementContentAsNullable<DateTime>();
                        break;

                    case "a:title":
                        node.Title = reader.ReadElementContentAsString();
                        break;

                    case "a:id":
                        node.Id = reader.ReadElementContentAsUrn();
                        break;

                    case "a:content":
                        node.Content = WindowsPhoneStoreServiceAppContentNode.ParseXml(reader);
                        break;

                    case "iapCount":
                        node.IapCount = reader.ReadElementContentAsInt();
                        break;

                    case "userRatingCountDistributions":
                        node.UserRatingCountDistributions = WindowsPhoneStoreServiceAppRatingsDistributionsNode.ParseXml(reader);
                        break;

                    case "sortTitle":
                        node.SortTitle = reader.ReadElementContentAsString();
                        break;

                    case "releaseDate":
                        node.ReleaseDate = reader.ReadElementContentAsNullable<DateTime>();
                        break;

                    case "visibilityStatus":
                        node.VisibilityStatus = reader.ReadElementContentAsString();
                        break;

                    case "publisher":
                        node.Publisher = reader.ReadElementContentAsString();
                        break;

                    case "averageUserRating":
                        node.AverageUserRating = reader.ReadElementContentAsDouble();
                        break;

                    case "userRatingCount":
                        node.UserRatingCount = reader.ReadElementContentAsInt();
                        break;

                    case "image":
                        node.Image = WindowsPhoneStoreServiceAppImageNode.ParseXml(reader);
                        break;

                    case "screenshots":
                        node.Screenshots = reader.ReadElementContentAsArray(WindowsPhoneStoreServiceAppImageNode.ParseXml);
                        break;

                    case "categories":
                        node.Categories = reader.ReadElementContentAsArray(WindowsPhoneStoreServiceAppCategoryNode.ParseXml);
                        break;

                    case "tags":
                        node.Tags = reader.ReadElementContentAsArray(x => x.ReadElementContentAsString());
                        break;

                    case "taxString":
                        node.TaxString = reader.ReadElementContentAsString();
                        break;

                    case "backgroundImage":
                        node.BackgroundImage = WindowsPhoneStoreServiceAppImageNode.ParseXml(reader);
                        break;

                    case "offers":
                        node.Offers = reader.ReadElementContentAsArray(WindowsPhoneStoreServiceAppOfferNode.ParseXml);
                        break;

                    case "publisherId":
                        node.PublisherId = reader.ReadElementContentAsString();
                        break;

                    case "publisherGuid":
                        node.PublisherGuid = reader.ReadElementContentAsUrn();
                        break;

                    case "a:entry":
                        node.Entry = WindowsPhoneStoreServiceAppEntryNode.ParseXml(reader);
                        break;

                    case "isUniversal":
                        node.IsUniversal = reader.ReadElementContentAsBoolean();
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