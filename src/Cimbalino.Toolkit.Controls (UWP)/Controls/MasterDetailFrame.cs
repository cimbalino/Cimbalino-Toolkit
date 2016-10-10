// ****************************************************************************
// <copyright file="MasterDetailFrame.cs" company="Pedro Lamas">
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
using Cimbalino.Toolkit.Services;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Cimbalino.Toolkit.Controls
{
    /// <summary>
    /// A master detail frame.
    /// </summary>
    [TemplateVisualState(Name = DisplayModeStatesName, GroupName = DefaultStateName)]
    [TemplateVisualState(Name = DisplayModeStatesName, GroupName = CompactMasterStateName)]
    public class MasterDetailFrame : Frame, IMasterDetailFrame
    {
        private const string DisplayModeStatesName = "DisplayModeStates";
        private const string DefaultStateName = "Default";
        private const string CompactMasterStateName = "CompactMaster";
        private const string CompactDetailStateName = "CompactDetail";

        /// <summary>
        /// Gets or sets the master.
        /// </summary>
        /// <value>The master.</value>
        public UIElement Master
        {
            get { return (UIElement)GetValue(MasterProperty); }
            set { SetValue(MasterProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="Master" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty MasterProperty =
            DependencyProperty.Register(nameof(Master), typeof(UIElement), typeof(MasterDetailFrame), new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the background of the master.
        /// </summary>
        /// <value>The background of the master.</value>
        public Brush MasterBackground
        {
            get { return (Brush)GetValue(MasterBackgroundProperty); }
            set { SetValue(MasterBackgroundProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="MasterBackground" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty MasterBackgroundProperty =
            DependencyProperty.Register(nameof(MasterBackground), typeof(Brush), typeof(MasterDetailFrame), new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the width of the master.
        /// </summary>
        /// <value>The width of the master.</value>
        public double MasterLength
        {
            get { return (double)GetValue(MasterLengthProperty); }
            set { SetValue(MasterLengthProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="MasterLength" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty MasterLengthProperty =
            DependencyProperty.Register(nameof(MasterLength), typeof(double), typeof(MasterDetailFrame), new PropertyMetadata(0));

        /// <summary>
        /// Gets or sets the display mode.
        /// </summary>
        /// <value>The display mode.</value>
        public MasterDetailFrameDisplayMode DisplayMode
        {
            get { return (MasterDetailFrameDisplayMode)GetValue(DisplayModeProperty); }
            set { SetValue(DisplayModeProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="DisplayMode" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty DisplayModeProperty =
            DependencyProperty.Register(nameof(DisplayMode), typeof(MasterDetailFrameDisplayMode), typeof(MasterDetailFrame), new PropertyMetadata(MasterDetailFrameDisplayMode.Normal, OnDisplayModeChanged));

        private static void OnDisplayModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var masterDetailFrame = (MasterDetailFrame)d;

            masterDetailFrame.Update();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MasterDetailFrame" /> class.
        /// </summary>
        public MasterDetailFrame()
        {
            DefaultStyleKey = typeof(MasterDetailFrame);

            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                return;
            }

            this.Navigated += MasterDetailFrame_Navigated;

            this.Navigate(typeof(Page));
        }

        /// <summary>
        /// When overridden in a derived class, is invoked whenever application code or internal processes call ApplyTemplate.
        /// </summary>
        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            Update();
        }

        private void Update()
        {
            switch (DisplayMode)
            {
                case MasterDetailFrameDisplayMode.Normal:
                    VisualStateManager.GoToState(this, DefaultStateName, true);
                    break;

                case MasterDetailFrameDisplayMode.Compact:
                    VisualStateManager.GoToState(this, this.CanGoBack ? CompactDetailStateName : CompactMasterStateName, true);
                    SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = this.CanGoBack && NavigationService.HandleWindowBackButton ? AppViewBackButtonVisibility.Visible : AppViewBackButtonVisibility.Collapsed;
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void MasterDetailFrame_Navigated(object sender, Windows.UI.Xaml.Navigation.NavigationEventArgs e)
        {
            while (this.BackStackDepth > 1)
            {
                this.BackStack.RemoveAt(this.BackStackDepth - 1);
            }

            Update();
        }

        bool IMasterDetailFrame.HandleBackKeyPress()
        {
            var handled = false;

            if (DisplayMode == MasterDetailFrameDisplayMode.Compact && this.CanGoBack)
            {
                this.GoBack();

                handled = true;
            }

            return handled;
        }
    }
}