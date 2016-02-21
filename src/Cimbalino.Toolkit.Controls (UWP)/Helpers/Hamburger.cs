// ****************************************************************************
// <copyright file="Hamburger.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2014
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <project>Cimbalino.Toolkit.Controls</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using Cimbalino.Toolkit.Controls;
using Windows.UI.Xaml;

namespace Cimbalino.Toolkit.Helpers
{
    /// <summary>
    /// Static class that owns the Hamburger attached properties.
    /// </summary>
    public class Hamburger
    {
        /// <summary>
        /// Gets the <see cref="HamburgerFrame.Header"/> value.
        /// </summary>
        /// <param name="obj">The attached object.</param>
        /// <returns>The <see cref="HamburgerFrame.Header"/> value.</returns>
        public static UIElement GetHeader(DependencyObject obj)
        {
            return DoWithHamburgerFrame(x => x.Header);
        }

        /// <summary>
        /// Sets the <see cref="HamburgerFrame.Header"/> value.
        /// </summary>
        /// <param name="obj">The attached object.</param>
        /// <param name="value">The new <see cref="HamburgerFrame.Header"/> value.</param>
        public static void SetHeader(DependencyObject obj, UIElement value)
        {
            DoWithHamburgerFrame(x => x.Header = value);
        }

        /// <summary>
        /// Identifier for the Header attached property.
        /// </summary>
        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.RegisterAttached("Header", typeof(UIElement), typeof(Hamburger), new PropertyMetadata(null));

        /// <summary>
        /// Gets the <see cref="HamburgerFrame.Pane"/> value.
        /// </summary>
        /// <param name="obj">The attached object.</param>
        /// <returns>The <see cref="HamburgerFrame.Pane"/> value.</returns>
        public static UIElement GetPane(DependencyObject obj)
        {
            return DoWithHamburgerFrame(x => x.Pane);
        }

        /// <summary>
        /// Sets the <see cref="HamburgerFrame.Pane"/> value.
        /// </summary>
        /// <param name="obj">The attached object.</param>
        /// <param name="value">The new <see cref="HamburgerFrame.Pane"/> value.</param>
        public static void SetPane(DependencyObject obj, UIElement value)
        {
            DoWithHamburgerFrame(x => x.Pane = value);
        }

        /// <summary>
        /// Identifier for the Pane attached property.
        /// </summary>
        public static readonly DependencyProperty PaneProperty =
            DependencyProperty.RegisterAttached("Pane", typeof(UIElement), typeof(Hamburger), new PropertyMetadata(null));

        /// <summary>
        /// Gets the <see cref="HamburgerFrame.IsPaneOpen"/> value.
        /// </summary>
        /// <param name="obj">The attached object.</param>
        /// <returns>The <see cref="HamburgerFrame.IsPaneOpen"/> value.</returns>
        public static bool GetIsPaneOpen(DependencyObject obj)
        {
            return DoWithHamburgerFrame(x => x.IsPaneOpen);
        }

        /// <summary>
        /// Sets the <see cref="HamburgerFrame.IsPaneOpen"/> value.
        /// </summary>
        /// <param name="obj">The attached object.</param>
        /// <param name="value">The new <see cref="HamburgerFrame.IsPaneOpen"/> value.</param>
        public static void SetIsPaneOpen(DependencyObject obj, bool value)
        {
            DoWithHamburgerFrame(x => x.IsPaneOpen = value);
        }

        /// <summary>
        /// Identifier for the IsPaneOpen attached property.
        /// </summary>
        public static readonly DependencyProperty IsPaneOpenProperty =
            DependencyProperty.RegisterAttached("IsPaneOpen", typeof(bool), typeof(Hamburger), new PropertyMetadata(false));

        private static T DoWithHamburgerFrame<T>(Func<HamburgerFrame, T> function)
        {
            var hamburgerFrame = Window.Current.Content as HamburgerFrame;

            if (hamburgerFrame != null)
            {
                return function(hamburgerFrame);
            }

            return default(T);
        }
    }
}