#if !WINDOWS_PHONE
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
#else
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Interactivity;
using KeyRoutedEventArgs = System.Windows.Input.KeyEventArgs;
using VirtualKey = System.Windows.Input.Key;
#endif
using System.Windows.Input;

namespace Cimbalino.Toolkit.Behaviors
{
    /// <summary>
    /// Updates the Text binding when the text changes rather than when the TextBox loses focus
    /// </summary>
    public class UpdateTextBindingOnPropertyChanged : Behavior<TextBox>
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
            AssociatedObject.TextChanged += OnTextChanged;
            AssociatedObject.KeyUp += OnKeyUp;
        }
        /// <summary>
        /// Called when [key up].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="keyEventArgs">The <see cref="KeyRoutedEventArgs"/> instance containing the event data.</param>
        private void OnKeyUp(object sender, KeyRoutedEventArgs keyEventArgs)
        {
            if (keyEventArgs.Key != VirtualKey.Enter) return;
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
            AssociatedObject.TextChanged -= OnTextChanged;
            _expression = null;
        }

        /// <summary>
        /// Called when [text changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="TextChangedEventArgs"/> instance containing the event data.</param>
        private void OnTextChanged(object sender, TextChangedEventArgs args)
        {
            _expression.UpdateSource();
        }
    }
}
