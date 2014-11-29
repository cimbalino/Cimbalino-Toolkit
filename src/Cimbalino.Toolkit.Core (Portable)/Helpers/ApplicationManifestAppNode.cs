// ****************************************************************************
// <copyright file="ApplicationManifestAppNode.cs" company="Pedro Lamas">
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

#if WINDOWS_PHONE
using System.Xml;
using Cimbalino.Toolkit.Extensions;
#endif

namespace Cimbalino.Toolkit.Helpers
{
    /// <summary>
    /// Represents the app detailed information in the application manifest.
    /// </summary>
    public class ApplicationManifestAppNode
    {
        #region Properties

        /// <summary>
        /// Gets or sets the app author’s name.
        /// </summary>
        /// <value>The app author’s name.</value>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets the bits per pixel of the app. 16 or 32 bits per pixel.
        /// </summary>
        /// <value>The bits per pixel of the app.</value>
        public string BitsPerPixel { get; set; }

        /// <summary>
        /// Gets or sets the description of the app.
        /// </summary>
        /// <value>The description of the app.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the app genre. The default value is either Apps.Normal or Apps.Game depending on the project type.
        /// </summary>
        /// <value>The app genre.</value>
        public string Genre { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the app supports settings.
        /// </summary>
        /// <value>true if the app supports settings; otherwise false.</value>
        public bool HasSettings { get; set; }

        /// <summary>
        /// Gets or sets the hub type of the app. Enables your app to appear in the Extras section of the Music + Videos Hub. It is used for testing before app submission, and must be manually entered in the manifest file. A value of 1 enables this functionality.
        /// </summary>
        /// <value>The hub type of the app.</value>
        public int HubType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the app is a beta app. This has consequences for the app license.
        /// </summary>
        /// <value>true if the app is a beta app; otherwise false.</value>
        public bool IsBeta { get; set; }

        /// <summary>
        /// Gets or sets the app product id. The default value is the GUID for the project (128 bit). During the app submission process, a new product ID is inserted into the manifest file.
        /// </summary>
        /// <value>The app product id.</value>
        public string ProductId { get; set; }

        /// <summary>
        /// Gets or sets the publisher of the app. This default value is the name of the project. This attribute is required for certain types of apps, such as push-enabled apps.
        /// </summary>
        /// <value>The publisher of the app.</value>
        public string Publisher { get; set; }

        /// <summary>
        /// Gets or sets the publisher id of the app. The default value is the GUID for the project (128 bit). During the app submission process, a new product ID is inserted into the manifest file.
        /// </summary>
        /// <value>The publisher id of the app.</value>
        public string PublisherId { get; set; }

        /// <summary>
        /// Gets or sets the title of the app that appears in the app list or Games Hub. The default value is the name of the project.
        /// </summary>
        /// <value>The title of the app that appears in the app list or Games Hub.</value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the app version. The default value is 1.0.0.0.
        /// </summary>
        /// <value>The app version.</value>
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the location of the app icon that is visible in the app list. The attributes are for internal use only.
        /// </summary>
        /// <value>The location of the app icon that is visible in the app list.</value>
        public ApplicationManifestIconPathNode IconPath { get; set; }

        /// <summary>
        /// Gets or sets the software capability requirements of the app.
        /// </summary>
        /// <value>The software capabilities requirements of the app.</value>
        public ApplicationManifestNamedNode[] Capabilities { get; set; }

        /// <summary>
        /// Gets or sets the resolutions that the app supports.
        /// </summary>
        /// <value>The resolutions that the app supports.</value>
        public ApplicationManifestNamedNode[] ScreenResolutions { get; set; }

        /// <summary>
        /// Gets or sets the hardware requirements of the app.
        /// </summary>
        /// <value>The hardware requirements of the app.</value>
        public ApplicationManifestNamedNode[] Requirements { get; set; }

        /// <summary>
        /// Gets or sets the tasks of the app.
        /// </summary>
        /// <value>The tasks of the app.</value>
        public ApplicationManifestTaskNodeBase[] Tasks { get; set; }

        /// <summary>
        /// Gets or sets the tokens of the app.
        /// </summary>
        /// <value>The tokens of the app.</value>
        public ApplicationManifestTokenNode[] Tokens { get; set; }

        #endregion

#if WINDOWS_PHONE
        internal static ApplicationManifestAppNode ParseXml(XmlReader reader)
        {
            var node = new ApplicationManifestAppNode()
            {
                Author = reader.GetAttribute("Author"),
                BitsPerPixel = reader.GetAttribute("BitsPerPixel"),
                Description = reader.GetAttribute("Description"),
                Genre = reader.GetAttribute("Genre"),
                HasSettings = reader.GetAttributeAsBool("HasSettings"),
                HubType = reader.GetAttributeAsInt("HubType"),
                IsBeta = reader.GetAttributeAsBool("IsBeta"),
                ProductId = reader.GetAttribute("ProductID"),
                Publisher = reader.GetAttribute("Publisher"),
                PublisherId = reader.GetAttribute("PublisherID"),
                Title = reader.GetAttribute("Title"),
                Version = reader.GetAttribute("Version"),
            };

            reader.ReadStartElement();

            while (reader.NodeType != XmlNodeType.EndElement)
            {
                switch (reader.Name)
                {
                    case "IconPath":
                        node.IconPath = ApplicationManifestIconPathNode.ParseXml(reader);

                        break;

                    case "Capabilities":
                        node.Capabilities = reader.ReadElementContentAsArray(ApplicationManifestNamedNode.ParseXml);

                        break;

                    case "ScreenResolutions":
                        node.ScreenResolutions = reader.ReadElementContentAsArray(ApplicationManifestNamedNode.ParseXml);

                        break;

                    case "Requirements":
                        node.Requirements = reader.ReadElementContentAsArray(ApplicationManifestNamedNode.ParseXml);

                        break;

                    case "Tasks":
                        node.Tasks = reader.ReadElementContentAsArray(ApplicationManifestTaskNodeBase.ParseXml);

                        break;

                    case "Tokens":
                        node.Tokens = reader.ReadElementContentAsArray(ApplicationManifestTokenNode.ParseXml);

                        break;

                    default:
                        reader.Skip();

                        break;
                }
            }

            reader.ReadEndElement();

            return node;
        }
#endif
    }
}