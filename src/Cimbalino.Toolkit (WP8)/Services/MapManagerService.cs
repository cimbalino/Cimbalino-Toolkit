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

#if WINDOWS_PHONE
using Microsoft.Phone.Tasks;
#elif WINDOWS_PHONE_APP
using Windows.Services.Maps;
#elif WINDOWS_UAP
using Windows.Services.Maps;
#else
using System;
#endif

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
        public virtual void ShowDownloadedMapsUI()
        {
#if WINDOWS_PHONE
            new MapDownloaderTask().Show();
#elif WINDOWS_PHONE_APP || WINDOWS_UAP
            MapManager.ShowDownloadedMapsUI();
#else
            throw new NotSupportedException();
#endif
        }

        /// <summary>
        /// Displays the UI that lets users update maps that were previously downloaded for offline use.
        /// </summary>
        public virtual void ShowMapsUpdateUI()
        {
#if WINDOWS_PHONE
            new MapUpdaterTask().Show();
#elif WINDOWS_PHONE_APP || WINDOWS_UAP
            MapManager.ShowMapsUpdateUI();
#else
            throw new NotSupportedException();
#endif
        }
    }
}