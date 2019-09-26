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

using System.Linq;
using Microsoft.Xaml.Interactivity;
using Windows.UI.Xaml;

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
                return behaviorsCollection.OfType<T>().FirstOrDefault();
            }

            return null;
        }
    }
}