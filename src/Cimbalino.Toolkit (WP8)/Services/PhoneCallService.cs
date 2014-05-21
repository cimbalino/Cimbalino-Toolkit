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
using Microsoft.Phone.Tasks;
#elif WINDOWS_PHONE_APP
using Windows.ApplicationModel.Calls;
#else
using System;
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
        public void Show(string phoneNumber)
        {
            Show(phoneNumber, null);
        }

        /// <summary>
        /// Shows the Phone application, using the specified phone number and display name.
        /// </summary>
        /// <param name="phoneNumber">The phone number.</param>
        /// <param name="displayName">The display name.</param>
        public void Show(string phoneNumber, string displayName)
        {
#if WINDOWS_PHONE
            new PhoneCallTask()
            {
                PhoneNumber = phoneNumber,
                DisplayName = displayName
            }.Show();
#elif WINDOWS_PHONE_APP
            PhoneCallManager.ShowPhoneCallUI(phoneNumber, displayName);
#else
            throw new NotSupportedException("This method is not supported in Windows Store Apps");
#endif
        }
    }
}