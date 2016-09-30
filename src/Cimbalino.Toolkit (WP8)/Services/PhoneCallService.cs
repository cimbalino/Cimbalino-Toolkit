// ****************************************************************************
// <copyright file="PhoneCallService.cs" company="Pedro Lamas">
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

#if WINDOWS_PHONE || WINDOWS_PHONE_81
using System.Threading.Tasks;
using Microsoft.Phone.Tasks;
#elif WINDOWS_PHONE_APP
using System.Threading.Tasks;
using Windows.ApplicationModel.Calls;
#elif WINDOWS_UWP
using System;
using System.Threading.Tasks;
using Cimbalino.Toolkit.Extensions;
using Windows.ApplicationModel.Calls;
using Windows.System;
#else
using System;
using System.Threading.Tasks;
using Cimbalino.Toolkit.Extensions;
using Windows.System;
#endif

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IPhoneCallService"/>.
    /// </summary>
    public class PhoneCallService : IPhoneCallService
    {
        /// <summary>
        /// Shows the Phone application, using the specified phone number.
        /// </summary>
        /// <param name="phoneNumber">The phone number.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task ShowAsync(string phoneNumber)
        {
            return ShowAsync(phoneNumber, null);
        }

        /// <summary>
        /// Shows the Phone application, using the specified phone number and display name.
        /// </summary>
        /// <param name="phoneNumber">The phone number.</param>
        /// <param name="displayName">The display name.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
#if WINDOWS_PHONE || WINDOWS_PHONE_81
        public virtual Task ShowAsync(string phoneNumber, string displayName)
        {
            new PhoneCallTask()
            {
                PhoneNumber = phoneNumber,
                DisplayName = displayName
            }.Show();

            return Task.FromResult(0);
        }
#elif WINDOWS_PHONE_APP
        public virtual Task ShowAsync(string phoneNumber, string displayName)
        {
            PhoneCallManager.ShowPhoneCallUI(phoneNumber, displayName);
            
            return Task.FromResult(0);
        }
#elif WINDOWS_UWP
        public virtual Task ShowAsync(string phoneNumber, string displayName)
        {
            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.ApplicationModel.Calls.PhoneCallManager"))
            {
                PhoneCallManager.ShowPhoneCallUI(phoneNumber, displayName);

                return Task.CompletedTask;
            }

            return CallByUri(phoneNumber, displayName);
        }
#else
        public virtual Task ShowAsync(string phoneNumber, string displayName)
        {
            return CallByUri(phoneNumber, displayName);
        }
#endif

#if WINDOWS_APP || WINDOWS_UWP
        private Task CallByUri(string phoneNumber, string displayName)
        {
            var phoneCallUri = new UriBuilder("tel:")
                .SetPath(phoneNumber)
                .Uri;

            return Launcher.LaunchUriAsync(phoneCallUri).AsTask();
        }
#endif
    }
}