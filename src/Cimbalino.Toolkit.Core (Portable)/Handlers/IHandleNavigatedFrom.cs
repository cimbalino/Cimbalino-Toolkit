// ****************************************************************************
// <copyright file="IHandleNavigatedFrom.cs" company="Pedro Lamas">
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
    /// Interface for when a page has been navigated from
    /// </summary>
    public interface IHandleNavigatedFrom
    {
        /// <summary>Called when a page becomes the active page in a frame.</summary>
        /// <param name="eventArgs">An object that contains the event data.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task OnNavigatedFromAsync(NavigationServiceNavigationEventArgs eventArgs);
    }
}