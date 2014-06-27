// ****************************************************************************
// <copyright file="IMapManagerService.cs" company="Pedro Lamas">
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

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of displaying the UI that lets users download maps for offline use, or update maps that were previously downloaded.
    /// </summary>
    public interface IMapManagerService
    {
        /// <summary>
        /// Displays the UI that lets users download maps for offline use.
        /// </summary>
        void ShowDownloadedMapsUI();

        /// <summary>
        /// Displays the UI that lets users update maps that were previously downloaded for offline use.
        /// </summary>
        void ShowMapsUpdateUI();
    }
}