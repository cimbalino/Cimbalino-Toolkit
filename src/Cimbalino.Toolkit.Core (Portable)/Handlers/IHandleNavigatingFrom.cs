// ****************************************************************************
// <copyright file="IHandleNavigatingFrom.cs" company="Pedro Lamas">
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
using Cimbalino.Toolkit.Services;

namespace Cimbalino.Toolkit.Handlers
{
    /// <summary>
    /// Interface for when a page is about to be unloaded and no longer the current source of a parent frame.
    /// </summary>
    public interface IHandleNavigatingFrom
    {
        /// <summary>
        /// Invoked immediately before the page is unloaded and is no longer the current source of a parent frame.
        /// </summary>
        /// <param name="eventArgs">An object that contains the event data.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task OnNavigatingFromAsync(NavigationServiceNavigatingCancelEventArgs eventArgs);
    }
}