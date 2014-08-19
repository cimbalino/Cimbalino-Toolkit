// ****************************************************************************
// <copyright file="RuntimeInformationService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2014
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <project>Cimbalino.Toolkit.Core</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

#if WINDOWS_PHONE
using System;
using System.Windows;
#else
using System;
#endif

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IRuntimeInformationService"/>.
    /// </summary>
    public class RuntimeInformationService : IRuntimeInformationService
    {
        /// <summary>
        /// Gets the device runtime profile.
        /// </summary>
        /// <value>The device runtime profile.</value>
        public RuntimeInformationServiceProfile Profile
        {
            get
            {
#if WINDOWS_PHONE
                return RuntimeInformationServiceProfile.WindowsPhoneSilverlight;
#elif WINDOWS_PHONE_APP
                return RuntimeInformationServiceProfile.WindowsPhoneApp;
#else
                return RuntimeInformationServiceProfile.WindowsApp;
#endif
            }
        }

        /// <summary>
        /// Gets the device runtime version.
        /// </summary>
        /// <value>The device runtime version.</value>
        public Version Version
        {
            get
            {
#if WINDOWS_PHONE
                return Version.Parse(Deployment.Current.RuntimeVersion);
#else
                return null;
#endif
            }
        }
    }
}