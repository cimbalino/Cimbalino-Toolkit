// ****************************************************************************
// <copyright file="SmsComposeService.cs" company="Pedro Lamas">
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
using Windows.ApplicationModel.Chat;
#else
using System;
using System.Threading.Tasks;
using Windows.System;
#endif

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="ISmsComposeService"/>.
    /// </summary>
    public class SmsComposeService : ISmsComposeService
    {
        /// <summary>
        /// Shows the Messaging application, using the specified recipient list.
        /// </summary>
        /// <param name="recipient">The recipient.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task ShowAsync(string recipient)
        {
            return ShowAsync(recipient, null);
        }

        /// <summary>
        /// Shows the Messaging application, using the specified recipient list and message body.
        /// </summary>
        /// <param name="recipient">The recipient list for the new SMS message.</param>
        /// <param name="body">The body text of the new SMS message.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public async Task ShowAsync(string recipient, string body)
        {
#if WINDOWS_PHONE
            new SmsComposeTask()
            {
                To = recipient,
                Body = body
            }.Show();

            await Task.FromResult(0);
#elif WINDOWS_PHONE_APP
            var chatMessage = new ChatMessage
            {
                Body = body
            };

            chatMessage.Recipients.Add(recipient);

            await ChatMessageManager.ShowComposeSmsMessageAsync(chatMessage);
#else
            var smsUrl = "sms:" + Uri.EscapeDataString(recipient);

            if (!string.IsNullOrEmpty(body))
            {
                smsUrl += "?body=" + Uri.EscapeDataString(body);
            }

            await Launcher.LaunchUriAsync(new Uri(smsUrl, UriKind.Absolute));
#endif
        }
    }
}