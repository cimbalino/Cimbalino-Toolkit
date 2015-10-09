// ****************************************************************************
// <copyright file="MonitoredInteraction.cs" company="Pedro Lamas">
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

#if WINDOWS_PHONE
using System;
using System.Reflection;
using System.Windows;
using System.Windows.Interactivity;
#else
using Microsoft.Xaml.Interactivity;
using Windows.UI.Xaml;
#endif

namespace Cimbalino.Toolkit.Behaviors
{
    /// <summary>
    /// Static class that owns the Behaviors attached properties.
    /// </summary>
    public class MonitoredInteraction
    {
        /// <summary>
        /// This property is used as the internal backing store for the public Behaviors attached property.
        /// </summary>
        public static readonly DependencyProperty BehaviorsProperty =
            DependencyProperty.RegisterAttached("Behaviors", typeof(BehaviorCollection), typeof(MonitoredInteraction), new PropertyMetadata(null, OnBehaviorsChanged));

        /// <summary>
        /// Gets the <see cref="BehaviorCollection"/> associated with a specified object.
        /// </summary>
        /// <param name="obj">The object from which to retrieve the <see cref="BehaviorCollection"/>.</param>
        /// <returns>A <see cref="BehaviorCollection"/> containing the behaviors associated with the specified object.</returns>
        public static BehaviorCollection GetBehaviors(DependencyObject obj)
        {
            var behaviorCollection = (BehaviorCollection)obj.GetValue(BehaviorsProperty);

            if (behaviorCollection == null)
            {
#if WINDOWS_PHONE
                behaviorCollection = (BehaviorCollection)typeof(BehaviorCollection)
                    .GetConstructor(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, Type.EmptyTypes, null)
                    .Invoke(null);
#else
                behaviorCollection = new BehaviorCollection();
#endif

                obj.SetValue(BehaviorsProperty, behaviorCollection);
                obj.SetValue(Interaction.BehaviorsProperty, behaviorCollection);

                var frameworkElement = obj as FrameworkElement;

                if (frameworkElement != null)
                {
                    frameworkElement.Loaded -= FrameworkElement_Loaded;
                    frameworkElement.Loaded += FrameworkElement_Loaded;
                    frameworkElement.Unloaded -= FrameworkElement_Unloaded;
                    frameworkElement.Unloaded += FrameworkElement_Unloaded;
                }
            }

            return behaviorCollection;
        }

        private static void OnBehaviorsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var oldBehaviorCollection = (BehaviorCollection)e.OldValue;
            var newBehaviorCollection = (BehaviorCollection)e.NewValue;

            if (oldBehaviorCollection == newBehaviorCollection)
            {
                return;
            }

            if (oldBehaviorCollection != null)
            {
#if WINDOWS_PHONE
                var associatedObject = typeof(BehaviorCollection)
                    .GetProperty("AssociatedObject", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                    .GetValue(oldBehaviorCollection);
#else
                var associatedObject = oldBehaviorCollection.AssociatedObject;
#endif
                if (associatedObject != null)
                {
                    oldBehaviorCollection.Detach();
                }
            }

            if (newBehaviorCollection == null || d == null)
            {
                return;
            }

            newBehaviorCollection.Attach(d);
        }

        private static void FrameworkElement_Loaded(object sender, RoutedEventArgs e)
        {
            var d = sender as DependencyObject;

            if (d != null)
            {
                GetBehaviors(d).Attach(d);
            }
        }

        private static void FrameworkElement_Unloaded(object sender, RoutedEventArgs e)
        {
            var d = sender as DependencyObject;

            if (d != null)
            {
                GetBehaviors(d).Detach();
            }
        }
    }
}