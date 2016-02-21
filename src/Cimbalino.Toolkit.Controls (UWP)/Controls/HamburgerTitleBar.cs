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
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Cimbalino.Toolkit.Controls
{
    /// <summary>
    /// A hamburger title bar.
    /// </summary>
    [TemplatePart(Name = "LeftButton", Type = typeof(Button))]
    [TemplatePart(Name = "RightButton", Type = typeof(Button))]
    public class HamburgerTitleBar : Control
    {
        private Button _leftButton;
        private Button _rightButton;

        /// <summary>
        /// Occurs when the left button is clicked.
        /// </summary>
        public event EventHandler<RoutedEventArgs> LeftButtonClick;

        /// <summary>
        /// Occurs when the right button is clicked.
        /// </summary>
        public event EventHandler<RoutedEventArgs> RightButtonClick;

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
        /// Gets or sets the <see cref="IconElement"/> for the left button.
        /// </summary>
        /// <value>The <see cref="IconElement"/> for the left button.</value>
        public IconElement LeftButtonIcon
        {
            get { return (IconElement)GetValue(LeftButtonIconProperty); }
            set { SetValue(LeftButtonIconProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="LeftButtonIcon" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty LeftButtonIconProperty =
            DependencyProperty.Register("LeftButtonIcon", typeof(IconElement), typeof(HamburgerTitleBar), new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the command to invoke when the left button is pressed.
        /// </summary>
        /// <value>The command to invoke when the left button is pressed.</value>
        public ICommand LeftButtonCommand
        {
            get { return (ICommand)GetValue(LeftButtonCommandProperty); }
            set { SetValue(LeftButtonCommandProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="LeftButtonCommand" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty LeftButtonCommandProperty =
            DependencyProperty.Register("LeftButtonCommand", typeof(ICommand), typeof(HamburgerTitleBar), new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the visibility of the left button.
        /// </summary>
        /// <value>The visibility of the left button.</value>
        public Visibility LeftButtonVisibility
        {
            get { return (Visibility)GetValue(LeftButtonVisibilityProperty); }
            set { SetValue(LeftButtonVisibilityProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="LeftButtonVisibility" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty LeftButtonVisibilityProperty =
            DependencyProperty.Register("LeftButtonVisibility", typeof(Visibility), typeof(HamburgerTitleBar), new PropertyMetadata(Visibility.Visible));

        /// <summary>
        /// Gets or sets a value indicating whether the user can interact with the left button.
        /// </summary>
        /// <value>true if the user can interact with the left button; otherwise, false.</value>
        public bool LeftButtonIsEnabled
        {
            get { return (bool)GetValue(LeftButtonIsEnabledProperty); }
            set { SetValue(LeftButtonIsEnabledProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="LeftButtonIsEnabled" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty LeftButtonIsEnabledProperty =
            DependencyProperty.Register("LeftButtonIsEnabled", typeof(bool), typeof(HamburgerTitleBar), new PropertyMetadata(true));

        /// <summary>
        /// Gets or sets the <see cref="IconElement"/> for the right button.
        /// </summary>
        /// <value>The <see cref="IconElement"/> for the right button.</value>
        public IconElement RightButtonIcon
        {
            get { return (IconElement)GetValue(RightButtonIconProperty); }
            set { SetValue(RightButtonIconProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="RightButtonIcon" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty RightButtonIconProperty =
            DependencyProperty.Register("RightButtonIcon", typeof(IconElement), typeof(HamburgerTitleBar), new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the command to invoke when the right button is pressed.
        /// </summary>
        /// <value>The command to invoke when the right button is pressed.</value>
        public ICommand RightButtonCommand
        {
            get { return (ICommand)GetValue(RightButtonCommandProperty); }
            set { SetValue(RightButtonCommandProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="RightButtonCommand" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty RightButtonCommandProperty =
            DependencyProperty.Register("RightButtonCommand", typeof(ICommand), typeof(HamburgerTitleBar), new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the visibility of the right button.
        /// </summary>
        /// <value>The visibility of the right button.</value>
        public Visibility RightButtonVisibility
        {
            get { return (Visibility)GetValue(RightButtonVisibilityProperty); }
            set { SetValue(RightButtonVisibilityProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="RightButtonVisibility" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty RightButtonVisibilityProperty =
            DependencyProperty.Register("RightButtonVisibility", typeof(Visibility), typeof(HamburgerTitleBar), new PropertyMetadata(Visibility.Collapsed));

        /// <summary>
        /// Gets or sets a value indicating whether the user can interact with the right button.
        /// </summary>
        /// <value>true if the user can interact with the right button; otherwise, false.</value>
        public bool RightButtonIsEnabled
        {
            get { return (bool)GetValue(RightButtonIsEnabledProperty); }
            set { SetValue(RightButtonIsEnabledProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="RightButtonIsEnabled" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty RightButtonIsEnabledProperty =
            DependencyProperty.Register("RightButtonIsEnabled", typeof(bool), typeof(HamburgerTitleBar), new PropertyMetadata(true));

        /// <summary>
        /// Initializes a new instance of the <see cref="HamburgerTitleBar" /> class.
        /// </summary>
        public HamburgerTitleBar()
        {
            DefaultStyleKey = typeof(HamburgerTitleBar);
        }

        /// <summary>
        /// When overridden in a derived class, is invoked whenever application code or internal processes call ApplyTemplate.
        /// </summary>
        protected override void OnApplyTemplate()
        {
            if (_leftButton != null)
            {
                _leftButton.Click -= LeftButton_Click;
            }
            if (_rightButton != null)
            {
                _rightButton.Click -= RightButton_Click;
            }

            base.OnApplyTemplate();

            _leftButton = (Button)GetTemplateChild("LeftButton");
            _rightButton = (Button)GetTemplateChild("RightButton");

            if (_leftButton != null)
            {
                _leftButton.Click += LeftButton_Click;
            }
            if (_rightButton != null)
            {
                _rightButton.Click += RightButton_Click;
            }
        }

        private void LeftButton_Click(object sender, RoutedEventArgs e)
        {
            var eventHandler = LeftButtonClick;

            if (eventHandler != null)
            {
                eventHandler(this, e);
            }
        }

        private void RightButton_Click(object sender, RoutedEventArgs e)
        {
            var eventHandler = RightButtonClick;

            if (eventHandler != null)
            {
                eventHandler(this, e);
            }
        }
    }
}