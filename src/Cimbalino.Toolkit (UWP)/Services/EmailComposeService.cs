// ****************************************************************************
// <copyright file="EmailComposeService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2014
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <project>Cimbalino.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Email;

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IEmailComposeService"/>.
    /// </summary>
    public class EmailComposeService : IEmailComposeService
    {
        /// <summary>
        /// Shows the e-mail compose screen with the specified subject and message body.
        /// </summary>
        /// <param name="subject">The e-mail subject.</param>
        /// <param name="body">The e-mail message body.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task ShowAsync(string subject, string body)
        {
            return ShowAsync(string.Empty, string.Empty, string.Empty, subject, body);
        }

        /// <summary>
        /// Shows the e-mail compose screen with the specified recipients, subject and message body.
        /// </summary>
        /// <param name="to">The e-mail recipients.</param>
        /// <param name="subject">The e-mail subject.</param>
        /// <param name="body">The e-mail message body.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task ShowAsync(string to, string subject, string body)
        {
            return ShowAsync(to, string.Empty, string.Empty, subject, body);
        }

        /// <summary>
        /// Shows the e-mail compose screen with the specified recipients, CC recipients, BCC recipients, subject and message body.
        /// </summary>
        /// <param name="to">The e-mail recipients.</param>
        /// <param name="cc">The e-mail CC recipients.</param>
        /// <param name="bcc">The e-mail BCC recipients.</param>
        /// <param name="subject">The e-mail subject.</param>
        /// <param name="body">The e-mail message body.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task ShowAsync(string to, string cc, string bcc, string subject, string body)
        {
            var emailMessage = new EmailMessage
            {
                Body = body,
                Subject = subject
            };

            if (!string.IsNullOrEmpty(to))
            {
                emailMessage.To.Add(new EmailRecipient(to));
            }

            if (!string.IsNullOrEmpty(cc))
            {
                emailMessage.CC.Add(new EmailRecipient(cc));
            }

            if (!string.IsNullOrEmpty(bcc))
            {
                emailMessage.Bcc.Add(new EmailRecipient(bcc));
            }

            return EmailManager.ShowComposeNewEmailAsync(emailMessage).AsTask();
        }
    }
}