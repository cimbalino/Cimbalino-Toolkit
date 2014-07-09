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

using System.ComponentModel;
using System.Windows;
using System.Windows.Interactivity;
using Microsoft.Phone.Controls;

namespace Cimbalino.Toolkit.Behaviors
{
    /// <summary>
    /// The behavior that controls the screen capture feature on Windows Phone.
    /// </summary>
    public class ScreenCaptureBehavior : Behavior<PhoneApplicationPage>
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
            DependencyProperty.Register("IsEnabled", typeof(bool), typeof(ScreenCaptureBehavior), new PropertyMetadata(true, OnIsEnabledChanged));

        private static void OnIsEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var screenCaptureBehavior = (ScreenCaptureBehavior)d;

            screenCaptureBehavior.SetIsScreenCaptureEnabled((bool)e.NewValue);
        }

        private void SetIsScreenCaptureEnabled(bool enabled)
        {
            if (DesignerProperties.IsInDesignTool || AssociatedObject == null)
            {
                return;
            }

            var propertyInfo = typeof(PhoneApplicationPage).GetProperty("IsScreenCaptureEnabled");

            if (propertyInfo != null)
            {
                propertyInfo.SetValue(AssociatedObject, enabled, null);
            }
        }
    }
}