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
        /// <summary>
        /// Called when [navigated from].
        /// </summary>
        /// <param name="navigationMode">The navigation mode.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task OnNavigatedFromAsync(HandledNavigationMode navigationMode, object parameter = null);
    }
}