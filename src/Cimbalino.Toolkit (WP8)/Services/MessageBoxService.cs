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

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Popups;

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
            return ShowAsync(text, CancellationToken.None);
        }

        /// <summary>
        /// Displays a message box that contains the specified text and an OK button.
        /// </summary>
        /// <param name="text">The message to display.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task ShowAsync(string text, CancellationToken cancellationToken)
        {
            var message = new MessageDialog(text);

            return message.ShowAsync()
                .AsTask(cancellationToken);
        }

        /// <summary>
        /// Displays a message box that contains the specified text, title bar caption, and an OK button.
        /// </summary>
        /// <param name="text">The message to display.</param>
        /// <param name="caption">The title of the message box.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task ShowAsync(string text, string caption)
        {
            return ShowAsync(text, caption, CancellationToken.None);
        }

        /// <summary>
        /// Displays a message box that contains the specified text, title bar caption, and an OK button.
        /// </summary>
        /// <param name="text">The message to display.</param>
        /// <param name="caption">The title of the message box.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task ShowAsync(string text, string caption, CancellationToken cancellationToken)
        {
            var message = new MessageDialog(text, caption);

            return message.ShowAsync()
                .AsTask(cancellationToken);
        }

        /// <summary>
        /// Displays a message box that contains the specified text, title bar caption, and response buttons.
        /// </summary>
        /// <param name="text">The message to display.</param>
        /// <param name="caption">The title of the message box.</param>
        /// <param name="buttons">The captions for message box buttons. The maximum number of buttons is two.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task<int> ShowAsync(string text, string caption, IEnumerable<string> buttons)
        {
            return ShowAsync(text, caption, buttons, CancellationToken.None);
        }

        /// <summary>
        /// Displays a message box that contains the specified text, title bar caption, and response buttons.
        /// </summary>
        /// <param name="text">The message to display.</param>
        /// <param name="caption">The title of the message box.</param>
        /// <param name="buttons">The captions for message box buttons. The maximum number of buttons is two.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual async Task<int> ShowAsync(string text, string caption, IEnumerable<string> buttons, CancellationToken cancellationToken)
        {
            var message = new MessageDialog(text, caption);

            foreach (var button in buttons)
            {
                message.Commands.Add(new UICommand(button));
            }

            var command = await message.ShowAsync()
                .AsTask(cancellationToken);

            if (command != null)
            {
                return message.Commands.IndexOf(command);
            }

            return -1;
        }
    }
}