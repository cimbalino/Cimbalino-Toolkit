// ****************************************************************************
// <copyright file="WindowsPhoneStoreServiceAppRatingsDistributionsNode.cs" company="Pedro Lamas">
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
    /// Represents an application ratings distribution information.
    /// </summary>
    public class WindowsPhoneStoreServiceAppRatingsDistributionsNode
    {
        #region Properties

        /// <summary>
        /// Gets the application one star ratings count.
        /// </summary>
        /// <value>The application one star ratings count.</value>
        public int OneStarRatings { get; private set; }

        /// <summary>
        /// Gets the application two star ratings count.
        /// </summary>
        /// <value>The application two star ratings count.</value>
        public int TwoStarRatings { get; private set; }

        /// <summary>
        /// Gets the application three star ratings count.
        /// </summary>
        /// <value>The application three star ratings count.</value>
        public int ThreeStarRatings { get; private set; }

        /// <summary>
        /// Gets the application four star ratings count.
        /// </summary>
        /// <value>The application four star ratings count.</value>
        public int FourStarRatings { get; private set; }

        /// <summary>
        /// Gets the application five star ratings count.
        /// </summary>
        /// <value>The application five star ratings count.</value>
        public int FiveStarRatings { get; private set; }

        #endregion

        internal static WindowsPhoneStoreServiceAppRatingsDistributionsNode ParseXml(XmlReader reader)
        {
            var node = new WindowsPhoneStoreServiceAppRatingsDistributionsNode();

            reader.ReadStartElement();

            while (reader.NodeType != XmlNodeType.EndElement)
            {
                switch (reader.Name)
                {
                    case "oneStarRatings":
                        node.OneStarRatings = reader.ReadElementContentAsInt();
                        break;

                    case "twoStarRatings":
                        node.TwoStarRatings = reader.ReadElementContentAsInt();
                        break;

                    case "threeStarRatings":
                        node.ThreeStarRatings = reader.ReadElementContentAsInt();
                        break;

                    case "fourStarRatings":
                        node.FourStarRatings = reader.ReadElementContentAsInt();
                        break;

                    case "fiveStarRatings":
                        node.FiveStarRatings = reader.ReadElementContentAsInt();
                        break;

                    default:
                        reader.Skip();
                        break;
                }
            }

            return node;
        }
    }
}