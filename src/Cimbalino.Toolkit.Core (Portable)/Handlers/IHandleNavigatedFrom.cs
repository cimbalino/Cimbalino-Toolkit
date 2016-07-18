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

namespace Cimbalino.Toolkit.Handlers
{
    /// <summary>
    /// Interface for when a page has been navigated from
    /// </summary>
    public interface IHandleNavigatedFrom
    {
        /// <summary>Called when a page becomes the active page in a frame.</summary>
        /// <param name="navigationMode">A value that indicates whether the navigation is forward, back, or a new navigation.</param>
        /// <param name="parameter">Any Parameter object passed to the target page for the navigation.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task OnNavigatedFromAsync(HandledNavigationMode navigationMode, object parameter);
    }
}