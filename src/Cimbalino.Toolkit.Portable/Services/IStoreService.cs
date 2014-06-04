// ****************************************************************************
// <copyright file="IStoreService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2014
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <project>Cimbalino.Toolkit.Portable</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System.Threading.Tasks;

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of launching the Store application.
    /// </summary>
    public interface IStoreService
    {
        /// <summary>
        /// Shows the Store application.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowAsync();

        /// <summary>
        /// Shows the Store application.
        /// </summary>
        /// <param name="publisherName">The publisher display name.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowPublisherAsync(string publisherName);

        /// <summary>
        /// Shows the Store application, optionally filtering results by keyword, publisher, and content type.
        /// </summary>
        /// <param name="keywords">The keywords to search for.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task SearchAsync(string keywords);

        /// <summary>
        /// Shows the Store application.
        /// </summary>
        /// <param name="applicationId">The application id.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ReviewAsync(string applicationId);
    }
}