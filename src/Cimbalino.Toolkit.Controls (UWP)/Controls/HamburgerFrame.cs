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

using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Cimbalino.Toolkit.Controls
{
    /// <summary>
    /// A hamburger title frame.
    /// </summary>
    [TemplatePart(Name = "RootGrid", Type = typeof(Grid))]
    [TemplatePart(Name = "PaneContentPresenter", Type = typeof(ContentPresenter))]
    public class HamburgerFrame : Frame
    {
        private Grid _rootGrid;
        private ContentPresenter _paneContentPresenter;
        private FrameworkElement _observedContainer;

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
            DependencyProperty.Register("VisualStateNarrowMinWidth", typeof(double), typeof(HamburgerFrame), null);

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
            DependencyProperty.Register("VisualStateNormalMinWidth", typeof(double), typeof(HamburgerFrame), null);

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
            DependencyProperty.Register("VisualStateWideMinWidth", typeof(double), typeof(HamburgerFrame), null);

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
            DependencyProperty.Register("DisplayMode", typeof(SplitViewDisplayMode), typeof(HamburgerFrame), null);

        /// <summary>
        /// Gets or sets the width of the internal <see cref="SplitView"/> pane when it's fully expanded.
        /// </summary>
        /// <value>The width of the internal <see cref="SplitView"/> pane when it's fully expanded.</value>
        public double OpenPaneLength
        {
            get { return (double)GetValue(OpenPaneLengthProperty); }
            set { SetValue(OpenPaneLengthProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="OpenPaneLength" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty OpenPaneLengthProperty =
            DependencyProperty.Register("OpenPaneLength", typeof(double), typeof(HamburgerFrame), null);

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
            DependencyProperty.Register("IsPaneOpen", typeof(bool), typeof(HamburgerFrame), null);

        /// <summary>
        /// Gets or sets the title area content.
        /// </summary>
        /// <value>The title area content.</value>
        public object TitleBarContent
        {
            get { return (object)GetValue(TitleBarContentProperty); }
            set { SetValue(TitleBarContentProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="TitleBarContent" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty TitleBarContentProperty =
            DependencyProperty.Register("TitleBarContent", typeof(object), typeof(HamburgerFrame), null);

        /// <summary>
        /// Gets or sets the internal <see cref="SplitView"/> pane content.
        /// </summary>
        /// <value>The internal <see cref="SplitView"/> pane content.</value>
        public object PaneContent
        {
            get { return (object)GetValue(PaneContentProperty); }
            set { SetValue(PaneContentProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="PaneContent" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty PaneContentProperty =
            DependencyProperty.Register("PaneContent", typeof(object), typeof(HamburgerFrame), null);

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
            base.OnApplyTemplate();

            _rootGrid = (Grid)this.GetTemplateChild("RootGrid");
            _paneContentPresenter = (ContentPresenter)this.GetTemplateChild("PaneContentPresenter");

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

        private void ResetInternalMargin()
        {
            if (_paneContentPresenter == null)
            {
                return;
            }

            var page = (Page)_observedContainer.Parent;

            var internalMargin = new Thickness(0, 0, page.ActualWidth - _observedContainer.ActualWidth, page.ActualHeight - _observedContainer.ActualHeight);

            if (!_paneContentPresenter.Margin.Equals(internalMargin))
            {
                _paneContentPresenter.Margin = internalMargin;
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
                _observedContainer = page.Content as FrameworkElement;

                if (_observedContainer != null)
                {
                    _observedContainer.SizeChanged += ObservedContainer_SizeChanged;

                    ResetInternalMargin();
                }
            }
        }

        private void ApplicationView_VisibleBoundsChanged(ApplicationView sender, object args)
        {
            ResetApplicationViewVisibleMargin(sender);
        }

        private void ObservedContainer_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ResetInternalMargin();
        }
    }
}