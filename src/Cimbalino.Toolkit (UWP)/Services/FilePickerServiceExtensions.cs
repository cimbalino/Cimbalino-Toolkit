// ****************************************************************************
// <copyright file="FilePickerServiceExtensions.cs" company="Pedro Lamas">
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

using System;
using Windows.Storage.Pickers;

namespace Cimbalino.Toolkit.Services
{
    internal static class FilePickerServiceExtensions
    {
        public static PickerLocationId ToPickerLocationId(this FilePickerServiceLocationId locationId)
        {
            switch (locationId)
            {
                case FilePickerServiceLocationId.DocumentsLibrary:
                    return PickerLocationId.DocumentsLibrary;

                case FilePickerServiceLocationId.ComputerFolder:
                    return PickerLocationId.ComputerFolder;

                case FilePickerServiceLocationId.Desktop:
                    return PickerLocationId.Desktop;

                case FilePickerServiceLocationId.Downloads:
                    return PickerLocationId.Downloads;

                case FilePickerServiceLocationId.HomeGroup:
                    return PickerLocationId.HomeGroup;

                case FilePickerServiceLocationId.MusicLibrary:
                    return PickerLocationId.MusicLibrary;

                case FilePickerServiceLocationId.PicturesLibrary:
                    return PickerLocationId.PicturesLibrary;

                case FilePickerServiceLocationId.VideosLibrary:
                    return PickerLocationId.VideosLibrary;

                case FilePickerServiceLocationId.Objects3D:
                    return PickerLocationId.Objects3D;

                case FilePickerServiceLocationId.Unspecified:
                    return PickerLocationId.Unspecified;

                default:
                    throw new ArgumentOutOfRangeException(nameof(locationId), locationId, null);
            }
        }

        public static PickerViewMode ToPickerViewMode(this FilePickerServiceViewMode viewMode)
        {
            switch (viewMode)
            {
                case FilePickerServiceViewMode.List:
                    return PickerViewMode.List;

                case FilePickerServiceViewMode.Thumbnail:
                    return PickerViewMode.Thumbnail;

                default:
                    throw new ArgumentOutOfRangeException(nameof(viewMode), viewMode, null);
            }
        }
    }
}