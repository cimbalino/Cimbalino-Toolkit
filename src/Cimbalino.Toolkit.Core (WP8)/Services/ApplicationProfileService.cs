// ****************************************************************************
// <copyright file="ApplicationProfileService.cs" company="Pedro Lamas">
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

#if WINDOWS_PHONE || WINDOWS_PHONE_APP || WINDOWS_UAP
using Windows.Phone.ApplicationModel;
#else
using System;
using Cimbalino.Toolkit.Helpers;
#endif

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IApplicationProfileService"/>.
    /// </summary>
    public class ApplicationProfileService : IApplicationProfileService
    {
        /// <summary>
        /// Gets a value that indicates the mode that an app is running in.
        /// </summary>
        /// <value>A value that indicates the mode that an app is running in.</value>
        public virtual ApplicationProfileServiceMode Mode
        {
            get
            {
#if WINDOWS_PHONE || WINDOWS_PHONE_APP || WINDOWS_UAP
                switch (ApplicationProfile.Modes)
                {
                    case ApplicationProfileModes.Default:
                        return ApplicationProfileServiceMode.Default;
                    
                    case ApplicationProfileModes.Alternate:
                        return ApplicationProfileServiceMode.KidsCorner;
                    
                    default:
                        return ApplicationProfileServiceMode.Unknown;
                }
#else
                return ExceptionHelper.ThrowNotSupported<ApplicationProfileServiceMode>();
#endif
            }
        }
    }
}