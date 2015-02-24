// ****************************************************************************
// <copyright file="UpdatePasswordBindingOnPropertyChanged.cs" company="Pedro Lamas">
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

using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace Cimbalino.Toolkit.Behaviors
{
    /// <summary>
    /// The behavior that updates a <see cref="PasswordBox.Password"/> binding when the text changes rather than when it loses focus.
    /// </summary>
    public class UpdatePasswordBindingOnPropertyChanged : Behavior<PasswordBox>
    {
        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        /// <remarks>
        /// Override this to hook up functionality to the AssociatedObject.
        /// </remarks>
        protected override void OnAttached()
        {
            AssociatedObject.PasswordChanged += AssociatedObjectPasswordChanged;

            base.OnAttached();
        }

        /// <summary>
        /// Called when the behavior is being detached from its AssociatedObject, but before it has actually occurred.
        /// </summary>
        /// <remarks>
        /// Override this to unhook functionality from the AssociatedObject.
        /// </remarks>
        protected override void OnDetaching()
        {
            AssociatedObject.PasswordChanged -= AssociatedObjectPasswordChanged;

            base.OnDetaching();
        }

        private void AssociatedObjectPasswordChanged(object sender, RoutedEventArgs args)
        {
            var binding = AssociatedObject.GetBindingExpression(TextBox.TextProperty);

            if (binding != null)
            {
                binding.UpdateSource();
            }
        }
    }
}