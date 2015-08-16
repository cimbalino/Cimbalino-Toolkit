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
        //
        // Summary:
        //     The operation succeeded, and the response data is available.
        Success = 0,
        //
        // Summary:
        //     The operation was canceled by the user.
        UserCancel = 1,
        //
        // Summary:
        //     The operation failed because a specific HTTP error was returned, for example
        //     404.
        ErrorHttp = 2
    }
}