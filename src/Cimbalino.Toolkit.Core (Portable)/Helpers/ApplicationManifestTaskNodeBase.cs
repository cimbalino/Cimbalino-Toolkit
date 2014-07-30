// ****************************************************************************
// <copyright file="ApplicationManifestTaskNodeBase.cs" company="Pedro Lamas">
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

#if WP8
using System.Xml;
using Cimbalino.Toolkit.Extensions;
#endif

namespace Cimbalino.Toolkit.Helpers
{
    /// <summary>
    /// Represents a task in the application manifest.
    /// </summary>
    public abstract class ApplicationManifestTaskNodeBase
    {
        #region Properties

        /// <summary>
        /// Gets or sets the name of the task.
        /// </summary>
        /// <value>The name of the task.</value>
        public string Name { get; set; }

        #endregion

#if WP8
        internal static ApplicationManifestTaskNodeBase ParseXml(XmlReader reader)
        {
            switch (reader.Name)
            {
                case "DefaultTask":
                    var node = new ApplicationManifestDefaultTaskNode()
                    {
                        Name = reader.GetAttribute("Name"),
                        NavigationPage = reader.GetAttribute("NavigationPage")
                    };

                    reader.Skip();

                    return node;

                case "ExtendedTask":
                    var node2 = new ApplicationManifestExtendedTaskNode
                    {
                        Name = reader.GetAttribute("Name"),
                        BackgroundServiceAgents = reader.ReadElementContentAsArray(ApplicationManifestBackgroundServiceAgentNode.ParseXml)
                    };

                    return node2;

                default:
                    reader.Skip();

                    return null;
            }
        }

#endif
    }
}