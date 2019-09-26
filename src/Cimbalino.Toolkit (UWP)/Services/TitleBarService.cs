// ****************************************************************************
// <copyright file="TitleBarService.cs" company="Pedro Lamas">
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
using Windows.ApplicationModel.Core;

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="ITitleBarService"/>.
    /// </summary>
    public class TitleBarService : ITitleBarService
    {
        private readonly CoreApplicationViewTitleBar _titleBar;

        /// <summary>
        /// Initializes a new instance of the <see cref="TitleBarService"/> class.
        /// </summary>
        public TitleBarService()
        {
            var coreApplicationView = CoreApplication.GetCurrentView();

            if (coreApplicationView != null)
            {
                _titleBar = coreApplicationView.TitleBar;

                if (_titleBar != null)
                {
                    _titleBar.IsVisibleChanged += TitleBarOnIsVisibleChanged;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this title bar should replace the default window title bar.
        /// </summary>
        /// <value>true if this title bar should replace the default window title bar; otherwise, false.</value>
        public virtual bool ExtendViewIntoTitleBar
        {
            get
            {
                if (_titleBar != null)
                {
                    return _titleBar.ExtendViewIntoTitleBar;
                }

                return false;
            }
            set
            {
                if (_titleBar != null)
                {
                    _titleBar.ExtendViewIntoTitleBar = value;
                }
            }
        }

        /// <summary>
        /// Occurs when the visibility of the title bar changes.
        /// </summary>
        public event EventHandler<TitleBarIsVisibleChangedArgs> IsVisibleChanged;

        /// <summary>
        /// Gets the title bar height.
        /// </summary>
        /// <value>The title bar height.</value>
        public virtual double Height
        {
            get
            {
                if (_titleBar != null)
                {
                    return _titleBar.Height;
                }

                return -1;
            }
        }

        private void TitleBarOnIsVisibleChanged(CoreApplicationViewTitleBar sender, object args)
        {
            IsVisibleChanged?.Invoke(sender, new TitleBarIsVisibleChangedArgs(sender.IsVisible));
        }
    }
}