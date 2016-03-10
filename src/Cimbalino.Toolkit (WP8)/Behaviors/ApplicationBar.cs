// ****************************************************************************
// <copyright file="ApplicationBar.cs" company="Pedro Lamas">
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

using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Phone.Shell;

namespace Cimbalino.Toolkit.Behaviors
{
    /// <summary>
    /// An Application Bar control.
    /// </summary>
    [System.Windows.Markup.ContentProperty("Buttons")]
    public class ApplicationBar : DependencyObject
    {
        internal readonly IApplicationBar InternalApplicationBar;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationBar" /> class.
        /// </summary>
        public ApplicationBar()
        {
            InternalApplicationBar = new Microsoft.Phone.Shell.ApplicationBar();

            Buttons = new ApplicationBarIconButtonCollection(InternalApplicationBar.Buttons);
            MenuItems = new ApplicationBarMenuItemCollection(InternalApplicationBar.MenuItems);

            InternalApplicationBar.StateChanged += ApplicationBarStateChanged;
        }

        /// <summary>
        /// Occurs when the user opens or closes the menu.
        /// </summary>
        public event EventHandler<ApplicationBarStateChangedEventArgs> StateChanged;

        /// <summary>
        /// Gets the list of the menu items that appear on the Application Bar.
        /// </summary>
        /// <value>The list of menu items.</value>
        [Category("Common")]
        public ApplicationBarMenuItemCollection MenuItems
        {
            get
            {
                return (ApplicationBarMenuItemCollection)GetValue(MenuItemsProperty);
            }
            private set
            {
                SetValue(MenuItemsProperty, value);
            }
        }

        /// <summary>
        /// Identifier for the <see cref="MenuItems" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty MenuItemsProperty =
            DependencyProperty.Register(nameof(MenuItems), typeof(ApplicationBarMenuItemCollection), typeof(ApplicationBar), null);

        /// <summary>
        /// Gets the list of the buttons that appear on the Application Bar.
        /// </summary>
        /// <value>The Application Bar buttons.</value>
        [Category("Common")]
        public ApplicationBarIconButtonCollection Buttons
        {
            get
            {
                return (ApplicationBarIconButtonCollection)GetValue(ButtonsProperty);
            }
            private set
            {
                SetValue(ButtonsProperty, value);
            }
        }

        /// <summary>
        /// Identifier for the <see cref="Buttons" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty ButtonsProperty =
            DependencyProperty.Register(nameof(Buttons), typeof(ApplicationBarIconButtonCollection), typeof(ApplicationBar), null);

        /// <summary>
        /// Gets or sets the background color of the Application Bar.
        /// </summary>
        /// <value>The background color of the Application Bar.</value>
        [Category("Appearance")]
        public Color BackgroundColor
        {
            get
            {
                return (Color)GetValue(BackgroundColorProperty);
            }
            set
            {
                SetValue(BackgroundColorProperty, value);
            }
        }

        /// <summary>
        /// Identifier for the <see cref="BackgroundColor" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty BackgroundColorProperty =
            DependencyProperty.Register(nameof(BackgroundColor), typeof(Color), typeof(ApplicationBar), new PropertyMetadata(OnBackgroundColorChanged));

        /// <summary>
        /// Called after the background color of the ApplicationBar is changed.
        /// </summary>
        /// <param name="d">The <see cref="DependencyObject" />.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs" /> instance containing the event data.</param>
        protected static void OnBackgroundColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((ApplicationBar)d).InternalApplicationBar.BackgroundColor = (Color)e.NewValue;
        }

        /// <summary>
        /// Gets or sets the foreground color of the Application Bar.
        /// </summary>
        /// <value>The foreground color of the Application Bar.</value>
        [Category("Appearance")]
        public Color ForegroundColor
        {
            get
            {
                return (Color)GetValue(ForegroundColorProperty);
            }
            set
            {
                SetValue(ForegroundColorProperty, value);
            }
        }

        /// <summary>
        /// Identifier for the <see cref="ForegroundColor" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty ForegroundColorProperty =
            DependencyProperty.Register(nameof(ForegroundColor), typeof(Color), typeof(ApplicationBar), new PropertyMetadata(OnForegroundColorChanged));

        /// <summary>
        /// Called after the foreground color of the ApplicationBar is changed.
        /// </summary>
        /// <param name="d">The <see cref="DependencyObject" />.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs" /> instance containing the event data.</param>
        protected static void OnForegroundColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((ApplicationBar)d).InternalApplicationBar.ForegroundColor = (Color)e.NewValue;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the user can open the menu.
        /// </summary>
        /// <value>true if the menu is enabled; otherwise, false.</value>
        [Category("Common")]
        public bool IsMenuEnabled
        {
            get
            {
                return (bool)GetValue(IsMenuEnabledProperty);
            }
            set
            {
                SetValue(IsMenuEnabledProperty, value);
            }
        }

        /// <summary>
        /// Identifier for the <see cref="IsMenuEnabled" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty IsMenuEnabledProperty =
            DependencyProperty.Register(nameof(IsMenuEnabled), typeof(bool), typeof(ApplicationBar), new PropertyMetadata(true, OnIsMenuEnabledChanged));

        /// <summary>
        /// Called after the menu enabled state of the Application Bar is changed.
        /// </summary>
        /// <param name="d">The <see cref="DependencyObject" />.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs" /> instance containing the event data.</param>
        protected static void OnIsMenuEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((ApplicationBar)d).InternalApplicationBar.IsMenuEnabled = (bool)e.NewValue;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the Application Bar is visible.
        /// </summary>
        /// <value>true if the Application Bar is visible; otherwise, false.</value>
        [Category("Appearance")]
        public bool IsVisible
        {
            get { return (bool)GetValue(IsVisibleProperty); }
            set { SetValue(IsVisibleProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="IsVisible" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty IsVisibleProperty =
            DependencyProperty.Register(nameof(IsVisible), typeof(bool), typeof(ApplicationBar), new PropertyMetadata(true, OnIsVisibleChanged));

        /// <summary>
        /// Called after the visible state of the Application Bar is changed.
        /// </summary>
        /// <param name="d">The <see cref="DependencyObject" />.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs" /> instance containing the event data.</param>
        private static void OnIsVisibleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((ApplicationBar)d).InternalApplicationBar.IsVisible = (bool)e.NewValue;
        }

        /// <summary>
        /// Gets or sets the size of the Application Bar.
        /// </summary>
        /// <value>One of the enumeration values that indicates the size of the Application Bar.</value>
        public ApplicationBarMode Mode
        {
            get
            {
                return (ApplicationBarMode)GetValue(ModeProperty);
            }
            set
            {
                SetValue(ModeProperty, value);
            }
        }

        /// <summary>
        /// Identifier for the <see cref="Mode" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty ModeProperty =
            DependencyProperty.Register(nameof(Mode), typeof(ApplicationBarMode), typeof(ApplicationBar), new PropertyMetadata(ApplicationBarMode.Default, OnModeChanged));

        /// <summary>
        /// Called after the size of the ApplicationBar is changed.
        /// </summary>
        /// <param name="d">The <see cref="DependencyObject" />.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs" /> instance containing the event data.</param>
        protected static void OnModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((ApplicationBar)d).InternalApplicationBar.Mode = (ApplicationBarMode)e.NewValue;
        }

        /// <summary>
        /// Gets or sets the opacity of the Application Bar.
        /// </summary>
        /// <value>The opacity of the Application Bar.</value>
        [Category("Appearance")]
        public double Opacity
        {
            get
            {
                return (double)GetValue(OpacityProperty);
            }
            set
            {
                SetValue(OpacityProperty, value);
            }
        }

        /// <summary>
        /// Identifier for the <see cref="Opacity" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty OpacityProperty =
            DependencyProperty.Register(nameof(Opacity), typeof(double), typeof(ApplicationBar), new PropertyMetadata(1.0, OnOpacityChanged));

        /// <summary>
        /// Called after the opacity of the ApplicationBar is changed.
        /// </summary>
        /// <param name="d">The <see cref="DependencyObject" />.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs" /> instance containing the event data.</param>
        protected static void OnOpacityChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((ApplicationBar)d).InternalApplicationBar.Opacity = (double)e.NewValue;
        }

        /// <summary>
        /// Gets or sets the command to invoke when the user opens or closes the menu. This is a DependencyProperty.
        /// </summary>
        /// <value>The command to invoke when the user opens or closes the menu. The default is null.</value>
        [Category("Common")]
        public ICommand StateChangedCommand
        {
            get { return (ICommand)GetValue(StateChangedCommandProperty); }
            set { SetValue(StateChangedCommandProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="StateChangedCommand" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty StateChangedCommandProperty =
            DependencyProperty.Register(nameof(StateChangedCommand), typeof(ICommand), typeof(ApplicationBar), null);

        private void ApplicationBarStateChanged(object sender, ApplicationBarStateChangedEventArgs e)
        {
            var eventHandler = StateChanged;

            if (eventHandler != null)
            {
                eventHandler(sender, e);
            }

            var command = StateChangedCommand;

            if (command != null)
            {
                var commandParameter = e;

                if (command.CanExecute(commandParameter))
                {
                    command.Execute(commandParameter);
                }
            }
        }
    }
}