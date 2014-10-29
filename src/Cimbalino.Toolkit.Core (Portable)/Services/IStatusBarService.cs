// ****************************************************************************
// <copyright file="IStatusBarService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2014
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <project>Cimbalino.Toolkit.Core</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System.Threading.Tasks;

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of handling the application status bar.
    /// </summary>
    public interface IStatusBarService
    {
        /// <summary>
        /// Shows the status bar with the specified text.
        /// </summary>
        /// <param name="text">The text to display in the status bar.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowAsync(string text);

        /// <summary>
        /// Shows the status bar with the specified text and an optional indeterminate progress indicator.
        /// </summary>
        /// <param name="text">The text to display in the status bar.</param>
        /// <param name="isIndeterminate">true if the progress indicator is indeterminate; otherwise, false.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowAsync(string text, bool isIndeterminate);

        /// <summary>
        /// Shows the status bar with the specified text and progress value.
        /// </summary>
        /// <param name="text">The text to display in the status bar.</param>
        /// <param name="value">The progress indicator value.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowAsync(string text, double value);

        /// <summary>
        /// Hides the status bar.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task HideAsync();
    }
}