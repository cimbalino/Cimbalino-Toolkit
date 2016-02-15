// ****************************************************************************
// <copyright file="HamburgerButton.cs" company="Pedro Lamas">
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

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Cimbalino.Toolkit.Controls
{
    /// <summary>
    /// A hamburger button.
    /// </summary>
    public class HamburgerButton : Button
    {
        /// <summary>
        /// Gets or sets the <see cref="IconElement"/> for this button.
        /// </summary>
        /// <value>The <see cref="IconElement"/> for this button.</value>
        public IconElement Icon
        {
            get { return (IconElement)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="IconProperty" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(IconElement), typeof(HamburgerButton), null);

        /// <summary>
        /// Gets or sets the visibility of the label.
        /// </summary>
        /// <value>The visibility of the label.</value>
        public Visibility LabelVisibility
        {
            get { return (Visibility)GetValue(LabelVisibilityProperty); }
            set { SetValue(LabelVisibilityProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="LabelVisibility" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty LabelVisibilityProperty =
            DependencyProperty.Register("LabelVisibility", typeof(Visibility), typeof(HamburgerButton), null);

        /// <summary>
        /// Initializes a new instance of the <see cref="HamburgerButton" /> class.
        /// </summary>
        public HamburgerButton()
        {
            DefaultStyleKey = typeof(HamburgerButton);
        }
    }
}