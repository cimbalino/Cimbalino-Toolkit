// ****************************************************************************
// <copyright file="HamburgerFrame.cs" company="Pedro Lamas">
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
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Cimbalino.Toolkit.Controls
{
    /// <summary>
    /// A hamburger frame.
    /// </summary>
    [TemplatePart(Name = "RootGrid", Type = typeof(Grid))]
    [TemplatePart(Name = "RootSplitView", Type = typeof(SplitView))]
    [TemplatePart(Name = "PaneBorder", Type = typeof(Border))]
    public class HamburgerFrame : Frame
    {
        private Grid _rootGrid;
        private Border _paneBorder;
        private SplitView _rootSplitView;
        private FrameworkElement _observedContainer;

        /// <summary>
        /// Occurs when the internal <see cref="SplitView"/> pane is closing.
        /// </summary>
        public event EventHandler<SplitViewPaneClosingEventArgs> PaneClosing;

        /// <summary>
        /// Occurs when the internal <see cref="SplitView"/> pane is closed.
        /// </summary>
        public event EventHandler PaneClosed;

        /// <summary>
        /// Gets or sets the minimal window width at which the hamburger frame will use a narrow style.
        /// </summary>
        /// <value>The minimal window width at which the hamburger frame will use a narrow style.</value>
        public double VisualStateNarrowMinWidth
        {
            get { return (double)GetValue(VisualStateNarrowMinWidthProperty); }
            set { SetValue(VisualStateNarrowMinWidthProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="VisualStateNarrowMinWidth" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty VisualStateNarrowMinWidthProperty =
            DependencyProperty.Register("VisualStateNarrowMinWidth", typeof(double), typeof(HamburgerFrame), new PropertyMetadata(0));

        /// <summary>
        /// Gets or sets the minimal window width at which the hamburger frame will use a normal style.
        /// </summary>
        /// <value>The minimal window width at which the hamburger frame will use a normal style.</value>
        public double VisualStateNormalMinWidth
        {
            get { return (double)GetValue(VisualStateNormalMinWidthProperty); }
            set { SetValue(VisualStateNormalMinWidthProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="VisualStateNormalMinWidth" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty VisualStateNormalMinWidthProperty =
            DependencyProperty.Register("VisualStateNormalMinWidth", typeof(double), typeof(HamburgerFrame), new PropertyMetadata(521));

        /// <summary>
        /// Gets or sets the minimal window width at which the hamburger frame will use a wide style.
        /// </summary>
        /// <value>The minimal window width at which the hamburger frame will use a wide style.</value>
        public double VisualStateWideMinWidth
        {
            get { return (double)GetValue(VisualStateWideMinWidthProperty); }
            set { SetValue(VisualStateWideMinWidthProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="VisualStateWideMinWidth" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty VisualStateWideMinWidthProperty =
            DependencyProperty.Register("VisualStateWideMinWidth", typeof(double), typeof(HamburgerFrame), new PropertyMetadata(1200));

        /// <summary>
        /// Gets or sets a value that specifies how the pane and content areas of the internal <see cref="SplitView"/> are shown.
        /// </summary>
        /// <value>A value that specifies how the pane and content areas of the internal <see cref="SplitView"/> are shown.</value>
        public SplitViewDisplayMode DisplayMode
        {
            get { return (SplitViewDisplayMode)GetValue(DisplayModeProperty); }
            set { SetValue(DisplayModeProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="DisplayMode" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty DisplayModeProperty =
            DependencyProperty.Register("DisplayMode", typeof(SplitViewDisplayMode), typeof(HamburgerFrame), new PropertyMetadata(SplitViewDisplayMode.Overlay));

        /// <summary>
        /// Gets or sets the width of the internal <see cref="SplitView"/> pane when it's open.
        /// </summary>
        /// <value>The width of the internal <see cref="SplitView"/> pane when it's open.</value>
        public double OpenPaneLength
        {
            get { return (double)GetValue(OpenPaneLengthProperty); }
            set { SetValue(OpenPaneLengthProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="OpenPaneLength" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty OpenPaneLengthProperty =
            DependencyProperty.Register("OpenPaneLength", typeof(double), typeof(HamburgerFrame), new PropertyMetadata(320));

        /// <summary>
        /// Gets or sets the width of the internal <see cref="SplitView"/> pane when it's compact.
        /// </summary>
        /// <value>The width of the internal <see cref="SplitView"/> pane when it's compact.</value>
        public double CompactPaneLength
        {
            get { return (double)GetValue(CompactPaneLengthProperty); }
            set { SetValue(CompactPaneLengthProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="CompactPaneLength" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty CompactPaneLengthProperty =
            DependencyProperty.Register("CompactPaneLength", typeof(double), typeof(HamburgerFrame), new PropertyMetadata(48));

        /// <summary>
        /// Gets or sets a value indicating whether the internal <see cref="SplitView"/> pane is expanded to its full width.
        /// </summary>
        /// <value>A value that specifies whether the internal <see cref="SplitView"/> pane is expanded to its full width.</value>
        public bool IsPaneOpen
        {
            get { return (bool)GetValue(IsPaneOpenProperty); }
            set { SetValue(IsPaneOpenProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="IsPaneOpen" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty IsPaneOpenProperty =
            DependencyProperty.Register("IsPaneOpen", typeof(bool), typeof(HamburgerFrame), new PropertyMetadata(false));

        /// <summary>
        /// Gets or sets the header.
        /// </summary>
        /// <value>The header.</value>
        public UIElement Header
        {
            get { return (UIElement)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="Header" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(UIElement), typeof(HamburgerFrame), new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the background of the header.
        /// </summary>
        /// <value>The background of the header.</value>
        public Brush HeaderBackground
        {
            get { return (Brush)GetValue(HeaderBackgroundProperty); }
            set { SetValue(HeaderBackgroundProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="HeaderBackground" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty HeaderBackgroundProperty =
            DependencyProperty.Register("HeaderBackground", typeof(Brush), typeof(HamburgerFrame), new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the subheader.
        /// </summary>
        /// <value>The subheader.</value>
        public UIElement SubHeader
        {
            get { return (UIElement)GetValue(SubHeaderProperty); }
            set { SetValue(SubHeaderProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="SubHeader" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty SubHeaderProperty =
            DependencyProperty.Register("SubHeader", typeof(UIElement), typeof(HamburgerFrame), new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the background of the subheader.
        /// </summary>
        /// <value>The background of the subheader.</value>
        public Brush SubHeaderBackground
        {
            get { return (Brush)GetValue(SubHeaderBackgroundProperty); }
            set { SetValue(SubHeaderBackgroundProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="SubHeaderBackground" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty SubHeaderBackgroundProperty =
            DependencyProperty.Register("SubHeaderBackground", typeof(Brush), typeof(HamburgerFrame), new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the internal <see cref="SplitView"/> pane.
        /// </summary>
        /// <value>The internal <see cref="SplitView"/> pane.</value>
        public UIElement Pane
        {
            get { return (UIElement)GetValue(PaneProperty); }
            set { SetValue(PaneProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="Pane" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty PaneProperty =
            DependencyProperty.Register("Pane", typeof(UIElement), typeof(HamburgerFrame), new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the background of the internal <see cref="SplitView"/> pane.
        /// </summary>
        /// <value>The background of the internal <see cref="SplitView"/> pane.</value>
        public Brush PaneBackground
        {
            get { return (Brush)GetValue(PaneBackgroundProperty); }
            set { SetValue(PaneBackgroundProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="PaneBackground" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty PaneBackgroundProperty =
            DependencyProperty.Register("PaneBackground", typeof(Brush), typeof(HamburgerFrame), new PropertyMetadata(null));

        /// <summary>
        /// Initializes a new instance of the <see cref="HamburgerFrame" /> class.
        /// </summary>
        public HamburgerFrame()
        {
            DefaultStyleKey = typeof(HamburgerFrame);

            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                return;
            }

            this.Navigated += HamburgerFrame_Navigated;

            ApplicationView.GetForCurrentView().VisibleBoundsChanged += ApplicationView_VisibleBoundsChanged;
        }

        /// <summary>
        /// When overridden in a derived class, is invoked whenever application code or internal processes call ApplyTemplate.
        /// </summary>
        protected override void OnApplyTemplate()
        {
            if (_rootSplitView != null)
            {
                _rootSplitView.PaneClosing -= RootSplitView_PaneClosing;
                _rootSplitView.PaneClosed -= RootSplitView_PaneClosed;
            }

            base.OnApplyTemplate();

            _rootGrid = (Grid)this.GetTemplateChild("RootGrid");
            _rootSplitView = (SplitView)this.GetTemplateChild("RootSplitView");
            _paneBorder = (Border)this.GetTemplateChild("PaneBorder");

            if (_rootSplitView != null)
            {
                _rootSplitView.PaneClosing += RootSplitView_PaneClosing;
                _rootSplitView.PaneClosed += RootSplitView_PaneClosed;
            }

            ResetApplicationViewVisibleMargin(ApplicationView.GetForCurrentView());
        }

        private void ResetApplicationViewVisibleMargin(ApplicationView applicationView)
        {
            if (_rootGrid == null)
            {
                return;
            }

            var bounds = Window.Current.Bounds;
            var visibleBounds = applicationView.VisibleBounds;

            var applicationViewVisibleMargin = new Thickness(visibleBounds.Left - bounds.Left, visibleBounds.Top - bounds.Top, bounds.Right - visibleBounds.Right, bounds.Bottom - visibleBounds.Bottom);

            if (!_rootGrid.Margin.Equals(applicationViewVisibleMargin))
            {
                _rootGrid.Margin = applicationViewVisibleMargin;
            }
        }

        private void ResetInternalMargin(Page page, FrameworkElement observedContainer)
        {
            if (_paneBorder == null)
            {
                return;
            }

            var internalMargin = new Thickness(0, 0, page.ActualWidth - observedContainer.ActualWidth, page.ActualHeight - observedContainer.ActualHeight);

            if (!_paneBorder.Margin.Equals(internalMargin))
            {
                _paneBorder.Margin = internalMargin;
            }
        }

        private void HamburgerFrame_Navigated(object sender, Windows.UI.Xaml.Navigation.NavigationEventArgs e)
        {
            if (_observedContainer != null)
            {
                _observedContainer.SizeChanged -= ObservedContainer_SizeChanged;
                _observedContainer = null;
            }

            var page = e.Content as Page;

            if (page != null)
            {
                var observedContainer = page.Content as FrameworkElement;

                if (observedContainer != null)
                {
                    observedContainer.SizeChanged += ObservedContainer_SizeChanged;

                    ResetInternalMargin(page, observedContainer);

                    _observedContainer = observedContainer;
                }
            }
        }

        private void RootSplitView_PaneClosing(SplitView sender, SplitViewPaneClosingEventArgs args)
        {
            var eventHandler = PaneClosing;

            if (eventHandler != null)
            {
                eventHandler(this, args);
            }
        }

        private void RootSplitView_PaneClosed(SplitView sender, object args)
        {
            var eventHandler = PaneClosed;

            if (eventHandler != null)
            {
                eventHandler(this, EventArgs.Empty);
            }
        }

        private void ApplicationView_VisibleBoundsChanged(ApplicationView sender, object args)
        {
            ResetApplicationViewVisibleMargin(sender);
        }

        private void ObservedContainer_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var observedContainer = sender as FrameworkElement;

            if (observedContainer != null)
            {
                var page = observedContainer.Parent as Page;

                if (page != null)
                {
                    ResetInternalMargin(page, observedContainer);
                }
            }
        }
    }
}