// ****************************************************************************
// <copyright file="WindowsPhoneStoreServiceAppContentNode.cs" company="Pedro Lamas">
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
    /// Represents an application content information.
    /// </summary>
    public class WindowsPhoneStoreServiceAppContentNode
    {
        #region Properties

        /// <summary>
        /// Gets the application content information type.
        /// </summary>
        /// <value>The application content information type.</value>
        public string Type { get; private set; }

        /// <summary>
        /// Gets the application content information text.
        /// </summary>
        /// <value>The application content information text.</value>
        public string Text { get; private set; }

        #endregion

        internal static WindowsPhoneStoreServiceAppContentNode ParseXml(XmlReader reader)
        {
            return new WindowsPhoneStoreServiceAppContentNode
            {
                Type = reader.GetAttribute("type"),
                Text = reader.ReadElementContentAsString()
            };
        }
    }
}