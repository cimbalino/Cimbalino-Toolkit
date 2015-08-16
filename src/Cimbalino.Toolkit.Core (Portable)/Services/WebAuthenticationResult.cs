// ****************************************************************************
// <copyright file="WebAuthenticationResult.cs" company="Pedro Lamas">
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
    /// Result of a web authentication call
    /// </summary>
    public class WebAuthenticationResult
    {
        /// <summary>
        /// Gets or sets the response data.
        /// </summary>
        /// <value>
        /// The response data.
        /// </value>
        public string ResponseData { get; set; }

        /// <summary>
        /// Gets or sets the response error data.
        /// </summary>
        /// <value>
        /// The response error data.
        /// </value>
        public uint ResponseErrorData { get; set; }

        /// <summary>
        /// Gets or sets the response status.
        /// </summary>
        /// <value>
        /// The response status.
        /// </value>
        public WebAuthenticationStatus ResponseStatus { get; set; }
    }
}