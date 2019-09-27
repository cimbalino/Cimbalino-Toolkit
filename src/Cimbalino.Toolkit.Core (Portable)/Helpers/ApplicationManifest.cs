// ****************************************************************************
// <copyright file="ApplicationManifest.cs" company="Pedro Lamas">
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

namespace Cimbalino.Toolkit.Helpers
{
    /// <summary>
    /// Represents the contents of the application manifest.
    /// </summary>
    public class ApplicationManifest
    {
        #region Properties

        /// <summary>
        /// Gets the current <see cref="ApplicationManifest"/> instance.
        /// </summary>
        /// <value>The current <see cref="ApplicationManifest"/> instance.</value>
        public static ApplicationManifest Current
        {
            get
            {
                return ExceptionHelper.ThrowNotSupported<ApplicationManifest>();
            }
        }

        /// <summary>
        /// Gets or sets the version of the Windows Phone SDK or the runtime binaries of the platform. The default value is 8.0 for Windows Phone 8 and 7.1 for Windows Phone OS 7.1.
        /// </summary>
        /// <value>The version of the Windows Phone SDK or the runtime binaries of the platform.</value>
        public string AppPlatformVersion { get; set; }

        /// <summary>
        /// Gets or sets the application default language.
        /// </summary>
        /// <value>The application default language.</value>
        public ApplicationManifestLanguageNode DefaultLanguage { get; set; }

        /// <summary>
        /// Gets or sets the application extra elements.
        /// </summary>
        /// <value>The application extra elements.</value>
        public ApplicationManifestNamedNode[] AppExtras { get; set; }

        /// <summary>
        /// Gets or sets the application supported languages.
        /// </summary>
        /// <value>The application supported languages.</value>
        public ApplicationManifestLanguageNode[] Languages { get; set; }

        /// <summary>
        /// Gets or sets the app detailed information.
        /// </summary>
        /// <value>The app detailed information.</value>
        public ApplicationManifestAppNode App { get; set; }

        #endregion
    }
}