// ****************************************************************************
// <copyright file="HamburgerMenuButton.cs" company="Pedro Lamas">
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
using Cimbalino.Toolkit.Extensions;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace Cimbalino.Toolkit.Controls
{
    /// <summary>
    /// A hamburger menu button.
    /// </summary>
    public class HamburgerMenuButton : ToggleButton
    {
        private HamburgerFrame _hamburgerFrame;

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
            DependencyProperty.Register("Icon", typeof(IconElement), typeof(HamburgerMenuButton), new PropertyMetadata(null));

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
            DependencyProperty.Register("LabelVisibility", typeof(Visibility), typeof(HamburgerMenuButton), new PropertyMetadata(Visibility.Visible));

        /// <summary>
        /// Gets or sets the navigation source page type.
        /// </summary>
        /// <value>The navigation source page type.</value>
        public Type NavigationSourcePageType
        {
            get { return (Type)GetValue(NavigationSourcePageTypeProperty); }
            set { SetValue(NavigationSourcePageTypeProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="NavigationSourcePageType" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty NavigationSourcePageTypeProperty =
            DependencyProperty.Register("NavigationSourcePageType", typeof(Type), typeof(HamburgerMenuButton), new PropertyMetadata(null));

        /// <summary>
        /// Initializes a new instance of the <see cref="HamburgerMenuButton" /> class.
        /// </summary>
        public HamburgerMenuButton()
        {
            DefaultStyleKey = typeof(HamburgerMenuButton);

            Loaded += HamburgerMenuButton_Loaded;
            Unloaded += HamburgerMenuButton_Unloaded;
        }

        /// <summary>
        /// Called when the ToggleButton receives toggle stimulus. Overrided to disable the auto-toggling of the control.
        /// </summary>
        protected override void OnToggle()
        {
        }

        private void HamburgerMenuButton_Loaded(object sender, RoutedEventArgs e)
        {
            _hamburgerFrame = this.GetVisualAncestor<HamburgerFrame>();

            if (_hamburgerFrame != null)
            {
                _hamburgerFrame.RegisterHamburgerMenuButton(this);
            }
        }

        private void HamburgerMenuButton_Unloaded(object sender, RoutedEventArgs e)
        {
            if (_hamburgerFrame != null)
            {
                _hamburgerFrame.UnregisterHamburgerMenuButton(this);

                _hamburgerFrame = null;
            }
        }
    }
}