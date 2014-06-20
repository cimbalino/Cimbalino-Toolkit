// ****************************************************************************
// <copyright file="IEmailComposeService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2014
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <project>Cimbalino.Toolkit.Background</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System.Threading.Tasks;

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of sending e-mail messages.
    /// </summary>
    public interface IEmailComposeService
    {
        /// <summary>
        /// Shows the e-mail compose screen with the specified subject and message body.
        /// </summary>
        /// <param name="subject">The e-mail subject.</param>
        /// <param name="body">The e-mail message body.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowAsync(string subject, string body);

        /// <summary>
        /// Shows the e-mail compose screen with the specified recipients, subject and message body.
        /// </summary>
        /// <param name="to">The e-mail recipients.</param>
        /// <param name="subject">The e-mail subject.</param>
        /// <param name="body">The e-mail message body.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowAsync(string to, string subject, string body);

        /// <summary>
        /// Shows the e-mail compose screen with the specified recipients, CC recipients, BCC recipients, subject and message body.
        /// </summary>
        /// <param name="to">The e-mail recipients.</param>
        /// <param name="cc">The e-mail CC recipients.</param>
        /// <param name="bcc">The e-mail BCC recipients.</param>
        /// <param name="subject">The e-mail subject.</param>
        /// <param name="body">The e-mail message body.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task ShowAsync(string to, string cc, string bcc, string subject, string body);
    }
}