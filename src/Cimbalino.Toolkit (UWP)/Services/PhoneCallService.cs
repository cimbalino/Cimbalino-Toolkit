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

using System;
using System.Threading.Tasks;
using Cimbalino.Toolkit.Extensions;
using Windows.ApplicationModel.Calls;
using Windows.System;

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
        public virtual Task ShowAsync(string phoneNumber, string displayName)
        {
            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.ApplicationModel.Calls.PhoneCallManager"))
            {
                PhoneCallManager.ShowPhoneCallUI(phoneNumber, displayName);

                return Task.CompletedTask;
            }

            return CallByUri(phoneNumber, displayName);
        }

        private Task CallByUri(string phoneNumber, string displayName)
        {
            var phoneCallUri = new UriBuilder("tel:")
                .SetPath(phoneNumber)
                .Uri;

            return Launcher.LaunchUriAsync(phoneCallUri).AsTask();
        }
    }
}