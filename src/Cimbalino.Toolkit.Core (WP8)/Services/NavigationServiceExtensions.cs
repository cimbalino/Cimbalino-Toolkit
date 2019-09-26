// ****************************************************************************
// <copyright file="NavigationServiceExtensions.cs" company="Pedro Lamas">
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

using System;
using Windows.UI.Xaml.Navigation;

namespace Cimbalino.Toolkit.Services
{
    internal static class NavigationServiceExtensions
    {
        public static NavigationServiceNavigationEventArgs ToNavigationServiceNavigationEventArgs(this NavigationEventArgs navigationEventArgs)
        {
            return new NavigationServiceNavigationEventArgs(navigationEventArgs.NavigationMode.ToNavigationServiceNavigationMode(), navigationEventArgs.SourcePageType, navigationEventArgs.Parameter, navigationEventArgs.Uri);
        }

        public static NavigationServiceNavigatingCancelEventArgs ToNavigationServiceNavigatingCancelEventArgs(this NavigatingCancelEventArgs navigatingCancelEventArgs)
        {
            return new NavigationServiceNavigatingCancelEventArgs(navigatingCancelEventArgs.NavigationMode.ToNavigationServiceNavigationMode(), navigatingCancelEventArgs.SourcePageType, navigatingCancelEventArgs.Parameter, null, true);
        }

        public static NavigationServiceNavigationMode ToNavigationServiceNavigationMode(this NavigationMode navigationMode)
        {
            switch (navigationMode)
            {
                case NavigationMode.New:
                    return NavigationServiceNavigationMode.New;

                case NavigationMode.Back:
                    return NavigationServiceNavigationMode.Back;

                case NavigationMode.Forward:
                    return NavigationServiceNavigationMode.Forward;

                case NavigationMode.Refresh:
                    return NavigationServiceNavigationMode.Refresh;

                default:
                    throw new ArgumentOutOfRangeException(nameof(navigationMode), navigationMode, null);
            }
        }
    }
}