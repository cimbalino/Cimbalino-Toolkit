// ****************************************************************************
// <copyright file="HamburgerTitleBar.cs" company="Pedro Lamas">
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

namespace Cimbalino.Toolkit.Controls
{
    /// <summary>
    /// A hamburger title bar.
    /// </summary>
    [TemplatePart(Name = "MenuButton", Type = typeof(Button))]
    public class HamburgerTitleBar : Control
    {
        /// <summary>
        /// Occurs when the menu button is clicked.
        /// </summary>
        public event EventHandler<RoutedEventArgs> MenuButtonClick;

        private HamburgerFrame _hamburgerFrame;

        private Button _menuButton;

        /// <summary>
        /// Gets or sets the displayed title of the title bar.
        /// </summary>
        /// <value>The displayed title of the title bar.</value>
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="Title" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register(nameof(Title), typeof(string), typeof(HamburgerTitleBar), new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the visibility of the menu button.
        /// </summary>
        /// <value>The visibility of the menu button.</value>
        public Visibility MenuButtonVisibility
        {
            get { return (Visibility)GetValue(MenuButtonVisibilityProperty); }
            set { SetValue(MenuButtonVisibilityProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="MenuButtonVisibility" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty MenuButtonVisibilityProperty =
            DependencyProperty.Register(nameof(MenuButtonVisibility), typeof(Visibility), typeof(HamburgerTitleBar), new PropertyMetadata(Visibility.Visible));

        /// <summary>
        /// Initializes a new instance of the <see cref="HamburgerTitleBar" /> class.
        /// </summary>
        public HamburgerTitleBar()
        {
            DefaultStyleKey = typeof(HamburgerTitleBar);

            Loaded += HamburgerTitleBar_Loaded;
            Unloaded += HamburgerTitleBar_Unloaded;
        }

        /// <summary>
        /// When overridden in a derived class, is invoked whenever application code or internal processes call ApplyTemplate.
        /// </summary>
        protected override void OnApplyTemplate()
        {
            if (_menuButton != null)
            {
                _menuButton.Click -= InternalMenuButtonClick;
            }

            base.OnApplyTemplate();

            _menuButton = (Button)this.GetTemplateChild("MenuButton");

            if (_menuButton != null)
            {
                _menuButton.Click += InternalMenuButtonClick;
            }
        }

        private void HamburgerTitleBar_Loaded(object sender, RoutedEventArgs e)
        {
            _hamburgerFrame = this.GetVisualAncestor<HamburgerFrame>();

            if (_hamburgerFrame != null)
            {
                _hamburgerFrame.RegisterHamburgerTitleBar(this);
            }
        }

        private void HamburgerTitleBar_Unloaded(object sender, RoutedEventArgs e)
        {
            if (_hamburgerFrame != null)
            {
                _hamburgerFrame.UnregisterHamburgerTitleBar(this);

                _hamburgerFrame = null;
            }
        }

        private void InternalMenuButtonClick(object sender, RoutedEventArgs e)
        {
            var eventHandler = MenuButtonClick;

            if (eventHandler != null)
            {
                eventHandler(this, e);
            }
        }
    }
}