// ****************************************************************************
// <copyright file="StatusBarService.cs" company="Pedro Lamas">
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

using System.Threading.Tasks;
using System.Windows;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IStatusBarService"/>.
    /// </summary>
    public class StatusBarService : IStatusBarService
    {
        private readonly ProgressIndicator _progressIndicator = new ProgressIndicator();

        private bool _initialized;

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusBarService" /> class.
        /// </summary>
        public StatusBarService()
        {
            Deployment.Current.Dispatcher.BeginInvoke(EnsureInitialization);
        }

        /// <summary>
        /// Shows the status bar with the specified text.
        /// </summary>
        /// <param name="text">The text to display in the status bar.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task ShowAsync(string text)
        {
            return ShowAsync(text, 0, false);
        }

        /// <summary>
        /// Shows the status bar with the specified text and an optional indeterminate progress indicator.
        /// </summary>
        /// <param name="text">The text to display in the status bar.</param>
        /// <param name="isIndeterminate">true if the progress indicator is indeterminate; otherwise, false.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task ShowAsync(string text, bool isIndeterminate)
        {
            return ShowAsync(text, 0, isIndeterminate);
        }

        /// <summary>
        /// Shows the status bar with the specified text and progress value.
        /// </summary>
        /// <param name="text">The text to display in the status bar.</param>
        /// <param name="value">The progress indicator value.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task ShowAsync(string text, double value)
        {
            return ShowAsync(text, value, false);
        }

        /// <summary>
        /// Hides the status bar.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task HideAsync()
        {
            _progressIndicator.IsVisible = false;

            return Task.FromResult(0);
        }

        private Task ShowAsync(string text, double value, bool isIndeterminate)
        {
            _progressIndicator.Text = text;
            _progressIndicator.Value = value;
            _progressIndicator.IsIndeterminate = isIndeterminate;
            _progressIndicator.IsVisible = true;

            return Task.FromResult(0);
        }

        private void EnsureInitialization()
        {
            if (_initialized)
            {
                return;
            }

            var mainFrame = Application.Current.RootVisual as PhoneApplicationFrame;

            if (mainFrame != null)
            {
                mainFrame.Navigated += (s, e) =>
                {
                    SetPageProgressIndicator(e.Content as PhoneApplicationPage);
                };

                SetPageProgressIndicator(mainFrame.Content as PhoneApplicationPage);

                _initialized = true;
            }
        }

        private void SetPageProgressIndicator(PhoneApplicationPage page)
        {
            if (page != null)
            {
                SystemTray.SetProgressIndicator(page, _progressIndicator);
            }
        }
    }
}