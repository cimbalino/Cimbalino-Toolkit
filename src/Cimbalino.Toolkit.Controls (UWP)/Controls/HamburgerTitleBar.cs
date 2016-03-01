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
    [TemplatePart(Name = "BackButton", Type = typeof(Button))]
    public class HamburgerTitleBar : Control
    {
        /// <summary>
        /// Occurs when the menu button is clicked.
        /// </summary>
        public event EventHandler<RoutedEventArgs> MenuButtonClick;

        /// <summary>
        /// Occurs when the back button is clicked.
        /// </summary>
        public event EventHandler<RoutedEventArgs> BackButtonClick;

        private HamburgerFrame _hamburgerFrame;

        private Button _menuButton;
        private Button _backButton;

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
            DependencyProperty.Register("Title", typeof(string), typeof(HamburgerTitleBar), new PropertyMetadata(null));

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
            DependencyProperty.Register("MenuButtonVisibility", typeof(Visibility), typeof(HamburgerTitleBar), new PropertyMetadata(Visibility.Visible));

        /// <summary>
        /// Gets or sets the visibility of the back button.
        /// </summary>
        /// <value>The visibility of the back button.</value>
        public Visibility BackButtonVisibility
        {
            get { return (Visibility)GetValue(BackButtonVisibilityProperty); }
            set { SetValue(BackButtonVisibilityProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="BackButtonVisibility" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty BackButtonVisibilityProperty =
            DependencyProperty.Register("BackButtonVisibility", typeof(Visibility), typeof(HamburgerTitleBar), new PropertyMetadata(Visibility.Collapsed));

        /// <summary>
        /// Gets or sets a value indicating whether to automatically handle the back button visibility.
        /// </summary>
        /// <value>true to automatically handle the back button visibility; otherwise, false.</value>
        public bool HandleBackButtonVisibility
        {
            get { return (bool)GetValue(HandleBackButtonVisibilityProperty); }
            set { SetValue(HandleBackButtonVisibilityProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="HandleBackButtonVisibility" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty HandleBackButtonVisibilityProperty =
            DependencyProperty.Register("HandleBackButtonVisibility", typeof(bool), typeof(HamburgerTitleBar), new PropertyMetadata(true));

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
            if (_backButton != null)
            {
                _backButton.Click -= InternalBackButton_Click;
            }

            base.OnApplyTemplate();

            _menuButton = (Button)GetTemplateChild("MenuButton");
            _backButton = (Button)GetTemplateChild("BackButton");

            if (_menuButton != null)
            {
                _menuButton.Click += InternalMenuButtonClick;
            }
            if (_backButton != null)
            {
                _backButton.Click += InternalBackButton_Click;
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

        private void InternalBackButton_Click(object sender, RoutedEventArgs e)
        {
            var eventHandler = BackButtonClick;

            if (eventHandler != null)
            {
                eventHandler(this, e);
            }
        }
    }
}