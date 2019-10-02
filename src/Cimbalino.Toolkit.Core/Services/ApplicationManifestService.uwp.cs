// ****************************************************************************
// <copyright file="ApplicationManifestService.uwp.cs" company="Pedro Lamas">
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

using Cimbalino.Toolkit.Helpers;

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IApplicationManifestService"/>.
    /// </summary>
    public class ApplicationManifestService : IApplicationManifestService
    {
        /// <summary>
        /// Gets the application manifest for the active app.
        /// </summary>
        /// <returns>The application manifest for the active app.</returns>
        public virtual ApplicationManifest GetApplicationManifest()
        {
            return ApplicationManifest.Current;
        }
    }
}