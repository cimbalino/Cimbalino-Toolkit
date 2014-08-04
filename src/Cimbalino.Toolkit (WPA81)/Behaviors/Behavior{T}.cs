// ****************************************************************************
// <copyright file="Behavior{T}.cs" company="Pedro Lamas">
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

using Windows.UI.Xaml;

namespace Cimbalino.Toolkit.Behaviors
{
    /// <summary>
    /// Behavior is the base class for providing attachable state and commands to an object.
    /// </summary>
    /// <typeparam name="T">The AssociatedObject type.</typeparam>
    public abstract class Behavior<T> : Behavior
        where T : DependencyObject
    {
        /// <summary>
        /// Gets the object to which this <see cref="Behavior{T}"/> is attached.
        /// </summary>
        /// <value>The object to which this <see cref="Behavior{T}"/> is attached.</value>
        protected new T AssociatedObject
        {
            get
            {
                return (T)base.AssociatedObject;
            }
        }
    }
}