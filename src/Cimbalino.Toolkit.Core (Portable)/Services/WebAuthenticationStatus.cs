// ****************************************************************************
// <copyright file="WebAuthenticationStatus.cs" company="Pedro Lamas">
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
namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Status of a web authentication call
    /// </summary>
    public enum WebAuthenticationStatus
    {
        /// <summary>
        /// The operation succeeded, and the response data is available.
        /// </summary>
        Success = 0,
          
        /// <summary>
        /// The operation was canceled by the user.
        /// </summary>
        UserCancel = 1,
          
        /// <summary>
        /// The operation failed because a specific HTTP error was returned, for example 404.
        /// </summary>
        ErrorHttp = 2
    }
}