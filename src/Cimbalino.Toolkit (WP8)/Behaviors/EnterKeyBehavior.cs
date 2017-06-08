// ****************************************************************************
// <copyright file="EnterKeyBehavior.cs" company="Pedro Lamas">
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

#if WINDOWS_PHONE || WINDOWS_PHONE_81
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;
using KeyRoutedEventArgs = System.Windows.Input.KeyEventArgs;
using VirtualKey = System.Windows.Input.Key;
#else
using System.Windows.Input;
using Microsoft.Xaml.Interactivity;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
#endif

namespace Cimbalino.Toolkit.Behaviors
{
    /// <summary>
    /// The behavior that handles the Enter key press to execute a command.
    /// </summary>
#if !WINDOWS_PHONE || WINDOWS_PHONE_81
    [TypeConstraint(typeof(Control))]
#endif
    public class EnterKeyBehavior : Behavior<Control>
    {
        /// <summary>
        /// Gets or sets the command to invoke when the Enter key is pressed. This is a DependencyProperty.
        /// </summary>
        /// <value>The command to invoke when the Enter key is pressed. This is a DependencyProperty.</value>
        public ICommand Command
        {
            get
            {
                return (ICommand)GetValue(CommandProperty);
            }
            set
            {
                SetValue(CommandProperty, value);
            }
        }

        /// <summary>
        /// Identifier for the <see cref="Command" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register(nameof(Command), typeof(ICommand), typeof(EnterKeyBehavior), null);

        /// <summary>
        /// Gets or sets the parameter to pass to the <see cref="Command"/> property. This is a DependencyProperty.
        /// </summary>
        /// <value>The parameter to pass to the <see cref="Command"/> property. The default is null.</value>
        public object CommandParameter
        {
            get
            {
                return GetValue(CommandParameterProperty);
            }
            set
            {
                SetValue(CommandParameterProperty, value);
            }
        }

        /// <summary>
        /// Identifier for the <see cref="CommandParameter" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register(nameof(CommandParameter), typeof(object), typeof(EnterKeyBehavior), null);


        /// <summary>
        /// Enable or disable handling of already handled KeyDown events. Default is false.
        /// </summary>
        public bool AllowHandled
        {
            get { return (bool)GetValue(AllowHandledProperty); }
            set { SetValue(AllowHandledProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="AllowHandled"/> dependency property 
        /// </summary>
        public static readonly DependencyProperty AllowHandledProperty =
            DependencyProperty.Register("AllowHandled", typeof(bool), typeof(EnterKeyBehavior), new PropertyMetadata(false));


        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        /// <remarks>
        /// Override this to hook up functionality to the AssociatedObject.
        /// </remarks>
        protected override void OnAttached()
        {
            AssociatedObject.AddHandler(UIElement.KeyDownEvent, new KeyEventHandler(AssociatedObjectKeyDown), AllowHandled);
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
            AssociatedObject.RemoveHandler(UIElement.KeyDownEvent, new KeyEventHandler(AssociatedObjectKeyDown));
            base.OnDetaching();
        }

        private void AssociatedObjectKeyDown(object sender, KeyRoutedEventArgs args)
        {
            if (args.Key == VirtualKey.Enter)
            {
                var command = Command;

                if (command != null)
                {
                    var commandParameter = CommandParameter;

                    if (command.CanExecute(commandParameter))
                    {
                        command.Execute(commandParameter);
                    }
                }
            }
        }
    }
}