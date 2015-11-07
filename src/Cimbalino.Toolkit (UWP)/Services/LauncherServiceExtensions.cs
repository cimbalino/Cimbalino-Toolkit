// ****************************************************************************
// <copyright file="LauncherServiceExtensions.cs" company="Pedro Lamas">
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

using System.Collections.Generic;
using System.Linq;
using Windows.ApplicationModel;

namespace Cimbalino.Toolkit.Services
{
    internal static class LauncherServiceExtensions
    {
        public static IEnumerable<LauncherServiceAppInfo> ToLauncherServiceAppInfo(this IEnumerable<AppInfo> appInfos)
        {
            return appInfos.Select(x =>
            {
                if (x.DisplayInfo != null)
                {
                    return new LauncherServiceAppInfo(x.Id, x.AppUserModelId, x.PackageFamilyName, x.DisplayInfo.DisplayName, x.DisplayInfo.Description);
                }

                return new LauncherServiceAppInfo(x.Id, x.AppUserModelId, x.PackageFamilyName);
            });
        }
    }
}