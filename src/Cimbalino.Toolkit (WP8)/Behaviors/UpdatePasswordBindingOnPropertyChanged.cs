using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Interactivity;
using System.Windows.Input;

namespace Cimbalino.Toolkit.Behaviors
{
    /// <summary>
    /// Updates the Password binding when the text changes rather than when the PasswordBox loses focus
    /// </summary>
    public class UpdatePasswordBindingOnPropertyChanged : Behavior<PasswordBox>
    {
        /// <summary>
        /// The enter hit command property
        /// </summary>
        public static readonly DependencyProperty EnterHitCommandProperty =
            DependencyProperty.Register("EnterHitCommand", typeof (ICommand), typeof (UpdateTextBindingOnPropertyChanged), new PropertyMetadata(default(ICommand)));

        /// <summary>
        /// Gets or sets the enter hit command.
        /// </summary>
        /// <value>
        /// The enter hit command.
        /// </value>
        public ICommand EnterHitCommand
        {
            get { return (ICommand) GetValue(EnterHitCommandProperty); }
            set { SetValue(EnterHitCommandProperty, value); }
        }

        // Fields
        private BindingExpression _expression;

        // Methods
        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        /// <remarks>
        /// Override this to hook up functionality to the AssociatedObject.
        /// </remarks>
        protected override void OnAttached()
        {
            base.OnAttached();
            _expression = AssociatedObject.GetBindingExpression(TextBox.TextProperty);
            AssociatedObject.PasswordChanged += OnTextChanged;
            AssociatedObject.KeyUp += OnKeyUp;
        }

        /// <summary>
        /// Called when [key up].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="keyEventArgs">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void OnKeyUp(object sender, KeyEventArgs keyEventArgs)
        {
            if (keyEventArgs.Key != Key.Enter) return;
            if (EnterHitCommand != null && EnterHitCommand.CanExecute(null))
            {
                EnterHitCommand.Execute(null);
            }
        }

        /// <summary>
        /// Called when the behavior is being detached from its AssociatedObject, but before it has actually occurred.
        /// </summary>
        /// <remarks>
        /// Override this to unhook functionality from the AssociatedObject.
        /// </remarks>
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.PasswordChanged -= OnTextChanged;
            _expression = null;
        }

        /// <summary>
        /// Called when [text changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void OnTextChanged(object sender, RoutedEventArgs args)
        {
            _expression.UpdateSource();
        }
    }
}
