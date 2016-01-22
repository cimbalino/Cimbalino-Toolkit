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

#if WINDOWS_UWP
using System;
using Windows.ApplicationModel.Core;
#else
using System;
using System.Reflection;
using Cimbalino.Toolkit.Helpers;
using Windows.ApplicationModel.Core;
#endif

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="ITitleBarService"/>.
    /// </summary>
    public class TitleBarService : ITitleBarService
    {
#if WINDOWS_UWP
        private readonly CoreApplicationViewTitleBar _titleBar;
#else
        private readonly object _titleBar;
#endif

        /// <summary>
        /// Initializes a new instance of the <see cref="TitleBarService"/> class.
        /// </summary>
        public TitleBarService()
        {
            var coreApplicationView = CoreApplication.GetCurrentView();

            if (coreApplicationView != null)
            {
#if WINDOWS_UWP
                _titleBar = coreApplicationView.TitleBar;

                if (_titleBar != null)
                {
                    _titleBar.IsVisibleChanged += TitleBarOnIsVisibleChanged;
                }
#else
                var titleBarPropertyInfo = coreApplicationView.GetType().GetRuntimeProperty("TitleBar");

                if (titleBarPropertyInfo != null)
                {
                    _titleBar = titleBarPropertyInfo.GetValue(coreApplicationView, null);
                }
#endif
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
#if WINDOWS_UWP
                if (_titleBar != null)
                {
                    return _titleBar.ExtendViewIntoTitleBar;
                }
#else
                var propertyInfo = GetTitleBarPropertyInfo("ExtendViewIntoTitleBar");

                if (propertyInfo != null)
                {
                    return (bool)propertyInfo.GetValue(_titleBar);
                }
#endif

                return false;
            }
            set
            {
#if WINDOWS_UWP
                if (_titleBar != null)
                {
                    _titleBar.ExtendViewIntoTitleBar = value;
                }
#else
                var propertyInfo = GetTitleBarPropertyInfo("ExtendViewIntoTitleBar");

                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(_titleBar, value);
                }
#endif
            }
        }

#if WINDOWS_UWP
        /// <summary>
        /// Occurs when the visibility of the title bar changes.
        /// </summary>
        public event EventHandler<TitleBarIsVisibleChangedArgs> IsVisibleChanged;
#else
        /// <summary>
        /// Occurs when the visibility of the title bar changes.
        /// </summary>
        public event EventHandler<TitleBarIsVisibleChangedArgs> IsVisibleChanged
        {
            add
            {
                ExceptionHelper.ThrowNotSupported();
            }
            remove
            {
            }
        }
#endif

        /// <summary>
        /// Gets the title bar height.
        /// </summary>
        /// <value>The title bar height.</value>
        public virtual double Height
        {
            get
            {
#if WINDOWS_UWP
                if (_titleBar != null)
                {
                    return _titleBar.Height;
                }
#else
                var propertyInfo = GetTitleBarPropertyInfo("Height");

                if (propertyInfo != null)
                {
                    return (double)propertyInfo.GetValue(_titleBar);
                }
#endif

                return -1;
            }
        }

#if WINDOWS_UWP
        private void TitleBarOnIsVisibleChanged(CoreApplicationViewTitleBar sender, object args)
        {
            var eventHandler = IsVisibleChanged;

            if (eventHandler != null)
            {
                eventHandler(sender, new TitleBarIsVisibleChangedArgs(sender.IsVisible));
            }
        }
#else
        private PropertyInfo GetTitleBarPropertyInfo(string propertyName)
        {
            if (_titleBar != null)
            {
                return _titleBar.GetType().GetRuntimeProperty(propertyName);
            }

            return null;
        }
#endif
    }
}