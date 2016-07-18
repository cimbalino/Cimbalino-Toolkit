// ****************************************************************************
// <copyright file="ExtendedPageBaseExtensions.cs" company="Pedro Lamas">
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

#if WINDOWS_PHONE || WINDOWS_PHONE_81
using System;
using System.Windows.Navigation;
using Cimbalino.Toolkit.Handlers;
#else
using System;
using Cimbalino.Toolkit.Handlers;
using Windows.UI.Xaml.Navigation;
#endif

namespace Cimbalino.Toolkit.Controls
{
    internal static class ExtendedPageBaseExtensions
    {
        public static HandledNavigationMode ToHandledNavigationMode(this NavigationMode navigationMode)
        {
            switch (navigationMode)
            {
                case NavigationMode.New:
                    return HandledNavigationMode.New;

                case NavigationMode.Back:
                    return HandledNavigationMode.Back;

                case NavigationMode.Forward:
                    return HandledNavigationMode.Forward;

                case NavigationMode.Refresh:
                    return HandledNavigationMode.Refresh;

#if WINDOWS_PHONE || WINDOWS_PHONE_81
                case NavigationMode.Reset:
                    return HandledNavigationMode.Reset;
#endif

                default:
                    throw new ArgumentOutOfRangeException(nameof(navigationMode), navigationMode, null);
            }
        }
    }
}