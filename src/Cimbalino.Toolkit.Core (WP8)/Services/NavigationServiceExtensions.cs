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

#if WINDOWS_PHONE || WINDOWS_PHONE_81
using System;
using System.Windows.Navigation;
#else
using System;
using Windows.UI.Xaml.Navigation;
#endif

namespace Cimbalino.Toolkit.Services
{
    internal static class NavigationServiceExtensions
    {
        public static NavigationServiceNavigationEventArgs ToNavigationServiceNavigationEventArgs(this NavigationEventArgs navigationEventArgs)
        {
#if WINDOWS_PHONE || WINDOWS_PHONE_81
            return new NavigationServiceNavigationEventArgs(navigationEventArgs.NavigationMode.ToNavigationServiceNavigationMode(), null, null, navigationEventArgs.Uri);
#else
            return new NavigationServiceNavigationEventArgs(navigationEventArgs.NavigationMode.ToNavigationServiceNavigationMode(), navigationEventArgs.SourcePageType, navigationEventArgs.Parameter, navigationEventArgs.Uri);
#endif
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

#if WINDOWS_PHONE || WINDOWS_PHONE_81
                case NavigationMode.Reset:
                    return NavigationServiceNavigationMode.Reset;
#endif

                default:
                    throw new ArgumentOutOfRangeException(nameof(navigationMode), navigationMode, null);
            }
        }
    }
}