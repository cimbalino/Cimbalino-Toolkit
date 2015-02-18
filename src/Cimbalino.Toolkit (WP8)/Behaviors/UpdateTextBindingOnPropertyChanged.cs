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
    public class UpdateTextBindingOnPropertyChanged : Behavior<TextBox>
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
            AssociatedObject.TextChanged += OnTextChanged;
            AssociatedObject.KeyUp += OnKeyUp;
        }
        private void OnKeyUp(object sender, KeyRoutedEventArgs keyEventArgs)
        {
            if (keyEventArgs.Key != VirtualKey.Enter) return;
            if (EnterHitCommand != null && EnterHitCommand.CanExecute(null))
            {
                EnterHitCommand.Execute(null);
            }
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.TextChanged -= OnTextChanged;
            _expression = null;
        }

        private void OnTextChanged(object sender, TextChangedEventArgs args)
        {
            _expression.UpdateSource();
        }
    }
}
