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

#if WINDOWS_PHONE
using Microsoft.Phone.Tasks;
#elif WINDOWS_PHONE_APP
using System;
using Windows.ApplicationModel.Email;
#else
using System;
using System.Net;
using Windows.System;
#endif

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
        public void Show(string subject, string body)
        {
            Show(string.Empty, string.Empty, string.Empty, subject, body);
        }

        /// <summary>
        /// Shows the e-mail compose screen with the specified recipients, subject and message body.
        /// </summary>
        /// <param name="to">The e-mail recipients.</param>
        /// <param name="subject">The e-mail subject.</param>
        /// <param name="body">The e-mail message body.</param>
        public void Show(string to, string subject, string body)
        {
            Show(to, string.Empty, string.Empty, subject, body);
        }

        /// <summary>
        /// Shows the e-mail compose screen with the specified recipients, CC recipients, BCC recipients, subject and message body.
        /// </summary>
        /// <param name="to">The e-mail recipients.</param>
        /// <param name="cc">The e-mail CC recipients.</param>
        /// <param name="bcc">The e-mail BCC recipients.</param>
        /// <param name="subject">The e-mail subject.</param>
        /// <param name="body">The e-mail message body.</param>
        public void Show(string to, string cc, string bcc, string subject, string body)
        {
#if WINDOWS_PHONE
            new EmailComposeTask()
            {
                To = to,
                Cc = cc,
                Bcc = bcc,
                Subject = subject,
                Body = body
            }.Show();
#elif WINDOWS_PHONE_APP
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
                emailMessage.To.Add(new EmailRecipient(cc));
            }

            if (!string.IsNullOrEmpty(bcc))
            {
                emailMessage.To.Add(new EmailRecipient(bcc));
            }

            EmailManager.ShowComposeNewEmailAsync(emailMessage);
#else
            var emailUri = "mailto:?";

            if (!string.IsNullOrEmpty(to))
            {
                emailUri += "&to=" + WebUtility.UrlEncode(to);
            }

            if (!string.IsNullOrEmpty(cc))
            {
                emailUri += "&cc=" + WebUtility.UrlEncode(cc);
            }

            if (!string.IsNullOrEmpty(bcc))
            {
                emailUri += "&bcc=" + WebUtility.UrlEncode(bcc);
            }

            if (!string.IsNullOrEmpty(subject))
            {
                emailUri += "&subject=" + WebUtility.UrlEncode(subject);
            }

            if (!string.IsNullOrEmpty(body))
            {
                emailUri += "&body=" + WebUtility.UrlEncode(body);
            }

            Launcher.LaunchUriAsync(new Uri(emailUri));
#endif
        }
    }
}