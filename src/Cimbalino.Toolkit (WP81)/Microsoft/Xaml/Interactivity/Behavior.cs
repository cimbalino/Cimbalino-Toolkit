// ****************************************************************************
// <copyright file="Behavior.cs" company="Pedro Lamas">
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

namespace Microsoft.Xaml.Interactivity
{
    /// <summary>
    /// Behavior is the base class for providing attachable state and commands to an object.
    /// </summary>
    public class Behavior : DependencyObject, IBehavior
    {
        private DependencyObject _associatedObject;

        /// <summary>
        /// Gets the object to which this <see cref="Behavior"/> is attached.
        /// </summary>
        /// <value>The object to which this <see cref="Behavior"/> is attached.</value>
        protected DependencyObject AssociatedObject
        {
            get
            {
                return _associatedObject;
            }
        }

        /// <summary>
        /// Attaches to the specified object.
        /// </summary>
        /// <param name="associatedObject">The <see cref="T:Windows.UI.Xaml.DependencyObject"/> to which the <seealso cref="Behavior"/> will be attached.</param>
        public void Attach(DependencyObject associatedObject)
        {
            _associatedObject = associatedObject;

            OnAttached();
        }

        /// <summary>
        /// Detaches this instance from its associated object.
        /// </summary>
        public void Detach()
        {
            OnDetaching();

            _associatedObject = null;
        }

        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        protected virtual void OnAttached()
        {
        }

        /// <summary>
        /// Called when the behavior is being detached from its AssociatedObject, but before it has actually occurred.
        /// </summary>
        protected virtual void OnDetaching()
        {
        }

        #region IBehavior Interface

        DependencyObject IBehavior.AssociatedObject
        {
            get
            {
                return AssociatedObject;
            }
        }

        #endregion
    }
}