#if !WINDOWS_PHONE
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
#else
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;
using KeyRoutedEventArgs = System.Windows.Input.KeyEventArgs;
using VirtualKey = System.Windows.Input.Key;
#endif

namespace Cimbalino.Toolkit.Behaviors
{
    /// <summary>
    /// Provides a behavior for handling the Enter key press to move to the next control or to
    /// execute a command.
    /// </summary>
    public class EnterKeyHandler : Behavior<Control>
    {
        /// <summary>
        /// Identifies the <see cref="P:CommandString"/> attached property.
        /// </summary>
        public static readonly DependencyProperty CommandStringProperty =
            DependencyProperty.Register(
                "Command",
                typeof(ICommand),
                typeof(EnterKeyHandler),
                null);
        
        /// <summary>
        /// Gets or sets the name of the command to execute.
        /// </summary>
        /// <value>The name of the command to execute.</value>
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandStringProperty); }
            set { SetValue(CommandStringProperty, value); }
        }

        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        /// <remarks>Override this to hook up functionality to the AssociatedObject.</remarks>
        protected override void OnAttached()
        {
            base.OnAttached();

            if (null != AssociatedObject)
            {
                AssociatedObject.KeyDown += Control_KeyDown;
            }
        }

        /// <summary>
        /// Called when the behavior is being detached from its AssociatedObject, but before it has actually occurred.
        /// </summary>
        /// <remarks>Override this to unhook functionality from the AssociatedObject.</remarks>
        protected override void OnDetaching()
        {
            base.OnDetaching();

            if (null != AssociatedObject)
            {
                AssociatedObject.KeyDown -= Control_KeyDown;
            }
        }

        private void Control_KeyDown(object sender, KeyRoutedEventArgs args)
        {
            if ((VirtualKey.Enter == args.Key))
            {
                if (Command != null)
                {
                    Command.Execute(null);
                }
            }
        }
    }
}