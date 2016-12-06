// ****************************************************************************
// <copyright file="MasterDetailView.cs" company="Pedro Lamas">
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
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;

namespace Cimbalino.Toolkit.Controls
{
    /// <summary>
    /// A master detail control.
    /// </summary>
    [TemplateVisualState(Name = DisplayModeStatesName, GroupName = MasterDetailStateName)]
    [TemplateVisualState(Name = DisplayModeStatesName, GroupName = CompactMasterStateName)]
    [TemplateVisualState(Name = DisplayModeStatesName, GroupName = CompactDetailStateName)]
    [ContentProperty(Name = "Master")]
    public class MasterDetailView : Control, IMasterDetailView
    {
        private const string DisplayModeStatesName = "DisplayModeStates";
        private const string MasterDetailStateName = "MasterDetail";
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
            DependencyProperty.Register(nameof(Master), typeof(UIElement), typeof(MasterDetailView), null);

        /// <summary>
        /// Gets or sets the detail.
        /// </summary>
        /// <value>The detail.</value>
        public UIElement Detail
        {
            get { return (UIElement)GetValue(DetailProperty); }
            set { SetValue(DetailProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="Detail" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty DetailProperty =
            DependencyProperty.Register(nameof(Detail), typeof(UIElement), typeof(MasterDetailView), new PropertyMetadata(null, OnPropertyChanged));

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
            DependencyProperty.Register(nameof(MasterLength), typeof(double), typeof(MasterDetailView), new PropertyMetadata(0));

        /// <summary>
        /// Gets or sets the display mode.
        /// </summary>
        /// <value>The display mode.</value>
        public MasterDetailViewDisplayMode DisplayMode
        {
            get { return (MasterDetailViewDisplayMode)GetValue(DisplayModeProperty); }
            set { SetValue(DisplayModeProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="DisplayMode" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty DisplayModeProperty =
            DependencyProperty.Register(nameof(DisplayMode), typeof(MasterDetailViewDisplayMode), typeof(MasterDetailView), new PropertyMetadata(MasterDetailViewDisplayMode.Normal, OnPropertyChanged));

        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var masterDetailView = (MasterDetailView)d;

            masterDetailView.Update();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MasterDetailView" /> class.
        /// </summary>
        public MasterDetailView()
        {
            DefaultStyleKey = typeof(MasterDetailView);
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
                case MasterDetailViewDisplayMode.Normal:
                    VisualStateManager.GoToState(this, MasterDetailStateName, true);
                    break;

                case MasterDetailViewDisplayMode.Compact:
                    VisualStateManager.GoToState(this, Detail == null ? CompactMasterStateName : CompactDetailStateName, true);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        bool IMasterDetailView.HandleBackKeyPress()
        {
            var handled = false;

            if (DisplayMode == MasterDetailViewDisplayMode.Compact && Detail != null)
            {
                Detail = null;

                handled = true;
            }

            return handled;
        }
    }
}