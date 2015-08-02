// ****************************************************************************
// <copyright file="FrameworkElementExtensions.cs" company="Pedro Lamas">
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
using System.Linq;
using System.Windows;
using System.Windows.Interactivity;
using TriggerBase = System.Windows.Interactivity.TriggerBase;
using TriggerCollection = System.Windows.Interactivity.TriggerCollection;
#else
using System.Linq;
using Cimbalino.Toolkit.Behaviors;
using Microsoft.Xaml.Interactivity;
using Windows.UI.Xaml;
#endif

namespace Cimbalino.Toolkit.Extensions
{
    /// <summary>
    /// Provides a set of static (Shared in Visual Basic) methods for <see cref="FrameworkElement"/> instances.
    /// </summary>
    public static class FrameworkElementExtensions
    {
        /// <summary>
        /// Gets the <see cref="BehaviorCollection"/> associated with the framework element.
        /// </summary>
        /// <param name="frameworkElement">The framework element.</param>
        /// <returns>The <see cref="BehaviorCollection"/> associated with the framework element.</returns>
        public static BehaviorCollection GetBehaviors(this FrameworkElement frameworkElement)
        {
            return Interaction.GetBehaviors(frameworkElement);
        }

#if WINDOWS_PHONE
        /// <summary>
        /// Returns the <see cref="TriggerCollection"/> associated with the framework element.
        /// </summary>
        /// <param name="frameworkElement">The framework element.</param>
        /// <returns>The <see cref="TriggerCollection"/> associated with the framework element.</returns>
        public static TriggerCollection GetTriggers(this FrameworkElement frameworkElement)
        {
            return Interaction.GetTriggers(frameworkElement);
        }
#endif

        /// <summary>
        /// Returns the <see cref="Behavior"/> attached to the framework element with the specified type.
        /// </summary>
        /// <param name="frameworkElement">The framework element.</param>
        /// <typeparam name="T">The behavior type.</typeparam>
        /// <returns>The <see cref="Behavior"/> attached to the framework element with the specified type.</returns>
        public static T GetBehavior<T>(this FrameworkElement frameworkElement)
            where T : Behavior
        {
            var behaviorsCollection = Interaction.GetBehaviors(frameworkElement);

            if (behaviorsCollection != null)
            {
#if WINDOWS_UWP
                return (T)behaviorsCollection.FirstOrDefault(x => x.GetType() == typeof(T));
#else
                return behaviorsCollection.OfType<T>().FirstOrDefault();
#endif
            }

            return null;
        }

#if WINDOWS_PHONE
        /// <summary>
        /// Returns the <see cref="TriggerBase"/> attached to the framework element with the specified type.
        /// </summary>
        /// <param name="frameworkElement">The framework element.</param>
        /// <typeparam name="T">The trigger action type.</typeparam>
        /// <returns>The <see cref="TriggerBase"/> attached to the framework element with the specified type.</returns>
        public static T GetTrigger<T>(this FrameworkElement frameworkElement)
            where T : TriggerBase
        {
            var triggersCollection = Interaction.GetTriggers(frameworkElement);

            if (triggersCollection != null)
            {
                return triggersCollection.OfType<T>().FirstOrDefault();
            }

            return null;
        }
#endif
    }
}