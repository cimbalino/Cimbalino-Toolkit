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
using System.Threading.Tasks;
using Microsoft.Phone.Tasks;
#elif WINDOWS_PHONE_APP
using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Email;
#else
using System;
using System.Threading.Tasks;
using Cimbalino.Toolkit.Extensions;
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
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowAsync(string subject, string body)
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
        public Task ShowAsync(string to, string subject, string body)
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
#if WINDOWS_PHONE
        public Task ShowAsync(string to, string cc, string bcc, string subject, string body)
        {
            new EmailComposeTask()
            {
                To = to,
                Cc = cc,
                Bcc = bcc,
                Subject = subject,
                Body = body
            }.Show();

            return Task.FromResult(0);
        }
#elif WINDOWS_PHONE_APP
        public async Task ShowAsync(string to, string cc, string bcc, string subject, string body)
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

            await EmailManager.ShowComposeNewEmailAsync(emailMessage);
        }
#else
        public async Task ShowAsync(string to, string cc, string bcc, string subject, string body)
        {
            var emailUri = new UriBuilder("mailto:")
                .SetPath(to)
                .AppendQueryParameterIfValueNotEmpty("cc", cc)
                .AppendQueryParameterIfValueNotEmpty("bcc", bcc)
                .AppendQueryParameterIfValueNotEmpty("subject", subject)
                .AppendQueryParameterIfValueNotEmpty("body", body)
                .Uri;

            await Launcher.LaunchUriAsync(emailUri);
        }
#endif
    }
}