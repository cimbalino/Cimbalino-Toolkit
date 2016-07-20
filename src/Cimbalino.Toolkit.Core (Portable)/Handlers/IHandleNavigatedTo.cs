// ****************************************************************************
// <copyright file="IHandleNavigatedTo.cs" company="Pedro Lamas">
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
    /// Interface for when a page has been navigated to
    /// </summary>
    public interface IHandleNavigatedTo
    {
        /// <summary>Called when a page is no longer the active page in a frame.</summary>
        /// <param name="eventArgs">An object that contains the event data.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task OnNavigatedToAsync(NavigationServiceNavigationEventArgs eventArgs);
    }
}