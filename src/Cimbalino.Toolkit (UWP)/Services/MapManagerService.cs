// ****************************************************************************
// <copyright file="MapManagerService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2014
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <project>Cimbalino.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using Windows.Services.Maps;

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IMapManagerService"/>.
    /// </summary>
    public class MapManagerService : IMapManagerService
    {
        /// <summary>
        /// Displays the UI that lets users download maps for offline use.
        /// </summary>
        public virtual void ShowDownloadedMapsUI() => MapManager.ShowDownloadedMapsUI();

        /// <summary>
        /// Displays the UI that lets users update maps that were previously downloaded for offline use.
        /// </summary>
        public virtual void ShowMapsUpdateUI() => MapManager.ShowMapsUpdateUI();
    }
}