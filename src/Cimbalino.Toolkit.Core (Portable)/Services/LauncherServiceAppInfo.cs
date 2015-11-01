// ****************************************************************************
// <copyright file="LauncherServiceAppInfo.cs" company="Pedro Lamas">
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
    /// Provides information about an application such as it name, package information, ID.
    /// </summary>
    public class LauncherServiceAppInfo
    {
        /// <summary>
        /// Gets the app identifier.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets the app user model identifier.
        /// </summary>
        public string AppUserModelId { get; private set; }

        /// <summary>
        /// Gets an identifier that uniquely identifies the app's package.
        /// </summary>
        public string PackageFamilyName { get; private set; }

        /// <summary>
        /// Gets the application's display name.
        /// </summary>
        public string DisplayName { get; private set; }

        /// <summary>
        /// Gets the application's description.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LauncherServiceAppInfo"/> class.
        /// </summary>
        /// <param name="id">The app identifier.</param>
        /// <param name="appUserModelId">The app user model identifier.</param>
        /// <param name="packageFamilyName">An identifier that uniquely identifies the app's package.</param>
        public LauncherServiceAppInfo(string id, string appUserModelId, string packageFamilyName)
        {
            Id = id;
            AppUserModelId = appUserModelId;
            PackageFamilyName = packageFamilyName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LauncherServiceAppInfo"/> class.
        /// </summary>
        /// <param name="id">The app identifier.</param>
        /// <param name="appUserModelId">The app user model identifier.</param>
        /// <param name="packageFamilyName">An identifier that uniquely identifies the app's package.</param>
        /// <param name="displayName">The application's display name.</param>
        /// <param name="description">The application's description.</param>
        public LauncherServiceAppInfo(string id, string appUserModelId, string packageFamilyName, string displayName, string description)
        {
            Id = id;
            AppUserModelId = appUserModelId;
            PackageFamilyName = packageFamilyName;
            Description = description;
            DisplayName = displayName;
        }
    }
}