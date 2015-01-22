// ****************************************************************************
// <copyright file="WindowsStoreServiceAppNode.cs" company="Pedro Lamas">
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
    /// Represents the contents of the application information from the store.
    /// </summary>
    public class WindowsStoreServiceAppNode
    {
        #region Properties

        /// <summary>
        /// Gets the application package.
        /// </summary>
        /// <value>The application package.</value>
        public WindowsStoreServiceAppPackageNode Package { get; private set; }

        /// <summary>
        /// Gets the application description.
        /// </summary>
        /// <value>The application description.</value>
        public string Description { get; private set; }

        /// <summary>
        /// Gets the application features.
        /// </summary>
        /// <value>The application features.</value>
        public string[] Features { get; private set; }

        /// <summary>
        /// Gets the application update description.
        /// </summary>
        /// <value>The application update description.</value>
        public string UpdateDescription { get; private set; }

        /// <summary>
        /// Gets the application base language.
        /// </summary>
        /// <value>The application base language.</value>
        public string BaseLanguage { get; private set; }

        /// <summary>
        /// Gets the application supported languages.
        /// </summary>
        /// <value>The application supported languages.</value>
        public string[] SupportedLanguages { get; private set; }

        /// <summary>
        /// Gets the application developer name.
        /// </summary>
        /// <value>The application developer name.</value>
        public string DeveloperName { get; private set; }

        /// <summary>
        /// Gets the application developer id.
        /// </summary>
        /// <value>The application developer id.</value>
        public string DeveloperId { get; private set; }

        /// <summary>
        /// Gets the application copyright.
        /// </summary>
        /// <value>The application copyright.</value>
        public string Copyright { get; private set; }

        /// <summary>
        /// Gets the application website.
        /// </summary>
        /// <value>The application website.</value>
        public string Website { get; private set; }

        /// <summary>
        /// Gets the application support website.
        /// </summary>
        /// <value>The application support website.</value>
        public string SupportWebsite { get; private set; }

        /// <summary>
        /// Gets the application privacy policy website.
        /// </summary>
        /// <value>The application privacy policy website.</value>
        public string PrivacyPolicyWebsite { get; private set; }

        /// <summary>
        /// Gets the application end user license agreement.
        /// </summary>
        /// <value>The application end user license agreement.</value>
        public string EndUserLicenseAgreement { get; private set; }

        /// <summary>
        /// Gets the application supported architectures.
        /// </summary>
        /// <value>The application supported architectures.</value>
        public WindowsStoreServiceAppArchitectureNode[] SupportedArchitectures { get; private set; }

        /// <summary>
        /// Gets the application screenshots.
        /// </summary>
        /// <value>The application screenshots.</value>
        public WindowsStoreServiceAppScreenshotNode[] Screenshots { get; private set; }

        #endregion

        internal static WindowsStoreServiceAppNode ParseXml(XmlReader reader)
        {
            var node = new WindowsStoreServiceAppNode();

            reader.ReadStartElement();

            while (reader.NodeType != XmlNodeType.EndElement)
            {
                switch (reader.Name)
                {
                    case "Pt":
                        node.Package = WindowsStoreServiceAppPackageNode.ParseXml(reader);
                        break;

                    case "D":
                        node.Description = reader.ReadElementContentAsString();
                        break;

                    case "Dbps":
                        node.Features = reader.ReadElementContentAsArray(x => x.ReadElementContentAsString());
                        break;

                    case "Ud":
                        node.UpdateDescription = reader.ReadElementContentAsString();
                        break;

                    case "Bsl":
                        node.BaseLanguage = reader.ReadElementContentAsString();
                        break;

                    case "Sls":
                        node.SupportedLanguages = reader.ReadElementContentAsArray(x => x.ReadElementContentAsString());
                        break;

                    case "Dev":
                        node.DeveloperName = reader.ReadElementContentAsString();
                        break;

                    case "DevI":
                        node.DeveloperId = reader.ReadElementContentAsString();
                        break;

                    case "Cr":
                        node.Copyright = reader.ReadElementContentAsString();
                        break;

                    case "Ws":
                        node.Website = reader.ReadElementContentAsString();
                        break;

                    case "Sws":
                        node.SupportWebsite = reader.ReadElementContentAsString();
                        break;

                    case "Pu":
                        node.PrivacyPolicyWebsite = reader.ReadElementContentAsString();
                        break;

                    case "Eula":
                        node.EndUserLicenseAgreement = reader.ReadElementContentAsString();
                        break;

                    case "Sas2":
                        node.SupportedArchitectures = reader.ReadElementContentAsArray(WindowsStoreServiceAppArchitectureNode.ParseXml);
                        break;

                    case "Sss":
                        node.Screenshots = reader.ReadElementContentAsArray(WindowsStoreServiceAppScreenshotNode.ParseXml);
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