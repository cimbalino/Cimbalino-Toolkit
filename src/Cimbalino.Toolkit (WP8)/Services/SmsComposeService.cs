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
using Microsoft.Phone.Tasks;
#elif WINDOWS_PHONE_APP
using Windows.ApplicationModel.Chat;
#else
using System;
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
        public void Show(string recipient)
        {
            Show(recipient, null);
        }

        /// <summary>
        /// Shows the Messaging application, using the specified recipient list and message body.
        /// </summary>
        /// <param name="recipient">The recipient list for the new SMS message.</param>
        /// <param name="body">The body text of the new SMS message.</param>
        public void Show(string recipient, string body)
        {
#if WINDOWS_PHONE
            new SmsComposeTask()
            {
                To = recipient,
                Body = body
            }.Show();
#elif WINDOWS_PHONE_APP
            var chatMessage = new ChatMessage
            {
                Body = body
            };

            chatMessage.Recipients.Add(recipient);

            ChatMessageManager.ShowComposeSmsMessageAsync(chatMessage);
#else
            throw new NotSupportedException("This method is not supported in Windows Store Apps");
#endif
        }
    }
}