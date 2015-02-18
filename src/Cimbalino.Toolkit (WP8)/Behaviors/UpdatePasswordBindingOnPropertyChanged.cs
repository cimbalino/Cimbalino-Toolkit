using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Interactivity;
using System.Windows.Input;

namespace Cimbalino.Toolkit.Behaviors
{
    public class UpdatePasswordBindingOnPropertyChanged : Behavior<PasswordBox>
    {
        public static readonly DependencyProperty EnterHitCommandProperty =
            DependencyProperty.Register("EnterHitCommand", typeof (ICommand), typeof (UpdateTextBindingOnPropertyChanged), new PropertyMetadata(default(ICommand)));

        public ICommand EnterHitCommand
        {
            get { return (ICommand) GetValue(EnterHitCommandProperty); }
            set { SetValue(EnterHitCommandProperty, value); }
        }

        // Fields
        private BindingExpression _expression;

        // Methods
        protected override void OnAttached()
        {
            base.OnAttached();
            _expression = AssociatedObject.GetBindingExpression(TextBox.TextProperty);
            AssociatedObject.PasswordChanged += OnTextChanged;
            AssociatedObject.KeyUp += OnKeyUp;
        }

        private void OnKeyUp(object sender, KeyEventArgs keyEventArgs)
        {
            if (keyEventArgs.Key != Key.Enter) return;
            if (EnterHitCommand != null && EnterHitCommand.CanExecute(null))
            {
                EnterHitCommand.Execute(null);
            }
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.PasswordChanged -= OnTextChanged;
            _expression = null;
        }

        private void OnTextChanged(object sender, RoutedEventArgs args)
        {
            _expression.UpdateSource();
        }
    }
}
