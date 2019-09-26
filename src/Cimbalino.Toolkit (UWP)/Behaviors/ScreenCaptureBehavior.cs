// ****************************************************************************
// <copyright file="ScreenCaptureBehavior.cs" company="Pedro Lamas">
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

using Microsoft.Xaml.Interactivity;
using Windows.ApplicationModel;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Cimbalino.Toolkit.Behaviors
{
    /// <summary>
    /// The behavior that controls the screen capture feature on Windows Phone.
    /// </summary>
    [TypeConstraint(typeof(Page))]
    public class ScreenCaptureBehavior : Behavior<Page>
    {
        /// <summary>
        /// Gets or sets a value indicating whether the screen capture functionality is enabled.
        /// </summary>
        /// <value>true if the screen capture functionality is enabled; otherwise, false.</value>
        public bool IsEnabled
        {
            get { return (bool)GetValue(IsEnabledProperty); }
            set { SetValue(IsEnabledProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="IsEnabled" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty IsEnabledProperty =
            DependencyProperty.Register(nameof(IsEnabled), typeof(bool), typeof(ScreenCaptureBehavior), new PropertyMetadata(true, OnIsEnabledChanged));

        private static void OnIsEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var screenCaptureBehavior = (ScreenCaptureBehavior)d;

            screenCaptureBehavior.Update();
        }

        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();

            Update();
        }

        private void Update()
        {
            if (DesignMode.DesignModeEnabled || AssociatedObject == null)
            {
                return;
            }

            ApplicationView.GetForCurrentView().IsScreenCaptureEnabled = IsEnabled;
        }
    }
}