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

#if WINDOWS_PHONE
using System.Threading.Tasks;
using Microsoft.Phone.Tasks;
#elif WINDOWS_PHONE_APP
using System.Threading.Tasks;
using Windows.ApplicationModel.Calls;
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
        public Task ShowAsync(string phoneNumber)
        {
            return ShowAsync(phoneNumber, null);
        }

        /// <summary>
        /// Shows the Phone application, using the specified phone number and display name.
        /// </summary>
        /// <param name="phoneNumber">The phone number.</param>
        /// <param name="displayName">The display name.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public async Task ShowAsync(string phoneNumber, string displayName)
        {
#if WINDOWS_PHONE
            new PhoneCallTask()
            {
                PhoneNumber = phoneNumber,
                DisplayName = displayName
            }.Show();

            await Task.FromResult(0);
#elif WINDOWS_PHONE_APP
            PhoneCallManager.ShowPhoneCallUI(phoneNumber, displayName);

            await Task.FromResult(0);
#else
            var phoneCallUri = new UriBuilder("tel:")
                .SetPath(phoneNumber)
                .Uri;

            await Launcher.LaunchUriAsync(phoneCallUri);
#endif
        }
    }
}