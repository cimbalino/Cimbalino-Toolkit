// ****************************************************************************
// <copyright file="IMessageBoxService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2014
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <project>Cimbalino.Toolkit.Portable</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of showing message boxes.
    /// </summary>
    public interface IMessageBoxService
    {
        /// <summary>
        /// Displays a message box that contains the specified text and an OK button.
        /// </summary>
        /// <param name="text">The message to display.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowAsync(string text);

        /// <summary>
        /// Displays a message box that contains the specified text, title bar caption, and an OK button.
        /// </summary>
        /// <param name="text">The message to display.</param>
        /// <param name="caption">The title of the message box.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowAsync(string text, string caption);

        /// <summary>
        /// Displays a message box that contains the specified text, title bar caption, and response buttons.
        /// </summary>
        /// <param name="text">The message to display.</param>
        /// <param name="caption">The title of the message box.</param>
        /// <param name="buttons">The captions for message box buttons. The maximum number of buttons is two.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task<int> ShowAsync(string text, string caption, IEnumerable<string> buttons);
    }
}