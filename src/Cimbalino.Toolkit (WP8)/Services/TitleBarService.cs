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
using Cimbalino.Toolkit.Helpers;

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="ITitleBarService"/>.
    /// </summary>
    public class TitleBarService : ITitleBarService
    {
        /// <summary>
        /// Gets or sets a value indicating whether this title bar should replace the default window title bar.
        /// </summary>
        /// <value>true if this title bar should replace the default window title bar; otherwise, false.</value>
        public virtual bool ExtendViewIntoTitleBar
        {
            get
            {
                return ExceptionHelper.ThrowNotSupported<bool>();
            }
            set
            {
                ExceptionHelper.ThrowNotSupported();
            }
        }

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

        /// <summary>
        /// Gets the title bar height.
        /// </summary>
        /// <value>The title bar height.</value>
        public virtual double Height
        {
            get
            {
                return ExceptionHelper.ThrowNotSupported<double>();
            }
        }
    }
}