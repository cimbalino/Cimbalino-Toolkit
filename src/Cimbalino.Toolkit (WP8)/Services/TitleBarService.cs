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
using Cimbalino.Toolkit.Helpers;
using Windows.ApplicationModel.Core;
#elif WINDOWS_APP
using System;
using System.Linq;
using System.Reflection;
using Cimbalino.Toolkit.Helpers;
using Windows.ApplicationModel.Core;
#else
using System;
using Cimbalino.Toolkit.Helpers;
#endif

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="ITitleBarService"/>.
    /// </summary>
    public class TitleBarService : ITitleBarService
    {
#if WINDOWS_UWP
        /// <summary>
        /// Initializes a new instance of the <see cref="TitleBarService"/> class.
        /// </summary>
        public TitleBarService()
        {
            CoreApplication.GetCurrentView().TitleBar.IsVisibleChanged += TitleBarOnIsVisibleChanged;
        }

        private void TitleBarOnIsVisibleChanged(CoreApplicationViewTitleBar sender, object args)
        {
            var titleBar = CoreApplication.GetCurrentView().TitleBar;

            var eventHandler = IsVisibleChanged;

            if (eventHandler != null)
            {
                eventHandler(sender, new TitleBarIsVisibleChangedArgs(titleBar.IsVisible));
            }
        }
#endif

        /// <summary>
        /// Gets or sets a value that specifies whether this title bar should replace the default window title bar.
        /// </summary>
        /// <value>true if this title bar should replace the default window title bar; otherwise, false.</value>
        public virtual bool ExtendViewIntoTitleBar
        {
            get
            {
#if WINDOWS_UWP || WINDOWS_APP
                var titleBar = GetTitleBar();

                if (titleBar == null)
                {
                    return ExceptionHelper.ThrowNotSupported<bool>();
                }

                return titleBar.ExtendViewIntoTitleBar;
#else
                return ExceptionHelper.ThrowNotSupported<bool>();
#endif
            }
            set
            {
#if WINDOWS_UWP || WINDOWS_APP
                var titleBar = GetTitleBar();

                if (titleBar == null)
                {
                    ExceptionHelper.ThrowNotSupported<bool>();

                    return;
                }

                titleBar.ExtendViewIntoTitleBar = value;
#else
                ExceptionHelper.ThrowNotSupported();
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
#if WINDOWS_UWP || WINDOWS_APP
                var titleBar = GetTitleBar();

                if (titleBar == null)
                {
                    return ExceptionHelper.ThrowNotSupported<double>();
                }

                return titleBar.Height;
#else
                return ExceptionHelper.ThrowNotSupported<double>();
#endif
            }
        }

#if WINDOWS_UWP
        private CoreApplicationViewTitleBar GetTitleBar()
        {
            return CoreApplication.GetCurrentView().TitleBar;
        }
#elif WINDOWS_APP
        private dynamic GetTitleBar()
        {
            var window = CoreApplication.GetCurrentView();

            var titleBar = window.GetType()
                                 .GetRuntimeProperties()
                                 .FirstOrDefault(x => x.Name == "TitleBar")
                                 .GetMethod
                                 .Invoke(window, null);

            return titleBar;
        }
#endif
    }
}
