// ****************************************************************************
// <copyright file="IWindowsPhoneStoreService.cs" company="Pedro Lamas">
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

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of retrieving Windows Phone Store information about an application.
    /// </summary>
    public interface IWindowsPhoneStoreService
    {
        /// <summary>
        /// Retrieves store information about the running application.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task<WindowsPhoneStoreServiceAppNode> GetAppInformationAsync();

        /// <summary>
        /// Retrieves store information about the running application.
        /// </summary>
        /// <param name="productId">The application Product ID.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task<WindowsPhoneStoreServiceAppNode> GetAppInformationAsync(string productId);
    }
}