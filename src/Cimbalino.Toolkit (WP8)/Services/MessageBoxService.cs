// ****************************************************************************
// <copyright file="MessageBoxService.cs" company="Pedro Lamas">
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
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Xna.Framework.GamerServices;
#else
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Popups;
#endif

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IMessageBoxService"/>.
    /// </summary>
    public class MessageBoxService : IMessageBoxService
    {
        /// <summary>
        /// Displays a message box that contains the specified text and an OK button.
        /// </summary>
        /// <param name="text">The message to display.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task ShowAsync(string text)
        {
#if WINDOWS_PHONE || WINDOWS_PHONE_81
            MessageBox.Show(text);

            return Task.FromResult(0);
#else
            var message = new MessageDialog(text);

            return message.ShowAsync().AsTask();
#endif
        }

        /// <summary>
        /// Displays a message box that contains the specified text, title bar caption, and an OK button.
        /// </summary>
        /// <param name="text">The message to display.</param>
        /// <param name="caption">The title of the message box.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task ShowAsync(string text, string caption)
        {
#if WINDOWS_PHONE || WINDOWS_PHONE_81
            MessageBox.Show(text, caption, MessageBoxButton.OK);

            return Task.FromResult(0);
#else
            var message = new MessageDialog(text, caption);

            return message.ShowAsync().AsTask();
#endif
        }

        /// <summary>
        /// Displays a message box that contains the specified text, title bar caption, and response buttons.
        /// </summary>
        /// <param name="text">The message to display.</param>
        /// <param name="caption">The title of the message box.</param>
        /// <param name="buttons">The captions for message box buttons. The maximum number of buttons is two.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
#if WINDOWS_PHONE || WINDOWS_PHONE_81
        public virtual Task<int> ShowAsync(string text, string caption, IEnumerable<string> buttons)
        {
            var taskCompletionSource = new TaskCompletionSource<int>();

            Guide.BeginShowMessageBox(caption, text, buttons, 0, MessageBoxIcon.None, ar =>
            {
                var buttonIndex = Guide.EndShowMessageBox(ar);

                Deployment.Current.Dispatcher.BeginInvoke(() => taskCompletionSource.SetResult(buttonIndex.GetValueOrDefault(-1)));
            }, null);

            return taskCompletionSource.Task;
        }
#else
        public virtual async Task<int> ShowAsync(string text, string caption, IEnumerable<string> buttons)
        {
            var message = new MessageDialog(text, caption);

            foreach (var button in buttons)
            {
                message.Commands.Add(new UICommand(button));
            }

            var command = await message.ShowAsync();

            if (command != null)
            {
                return message.Commands.IndexOf(command);
            }

            return -1;
        }
#endif
    }
}