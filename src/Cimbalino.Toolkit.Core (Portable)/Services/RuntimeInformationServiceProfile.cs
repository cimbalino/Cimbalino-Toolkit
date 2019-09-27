// ****************************************************************************
// <copyright file="RuntimeInformationServiceProfile.cs" company="Pedro Lamas">
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

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Indicates the device runtime profile.
    /// </summary>
    public enum RuntimeInformationServiceProfile
    {
        /// <summary>
        /// Windows Phone Silverlight Runtime.
        /// </summary>
        WindowsPhoneSilverlight,

        /// <summary>
        /// Windows Phone Application Runtime.
        /// </summary>
        WindowsPhoneApp,

        /// <summary>
        /// Windows Application Runtime.
        /// </summary>
        WindowsApp,

        /// <summary>
        /// Universal Application Runtime.
        /// </summary>
        UniversalAppPlatform,
    }
}