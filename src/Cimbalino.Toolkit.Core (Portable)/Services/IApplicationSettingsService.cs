// ****************************************************************************
// <copyright file="IApplicationSettingsService.cs" company="Pedro Lamas">
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
    /// Represents a service capable of handling the application settings.
    /// </summary>
    public interface IApplicationSettingsService
    {
        /// <summary>
        /// Gets the local settings handler instance for the app.
        /// </summary>
        /// <value>The local settings handler instance for the app.</value>
        IApplicationSettingsServiceHandler Local { get; }

        /// <summary>
        /// Gets the roaming settings handler instance for the app.
        /// </summary>
        /// <value>The roaming settings handler instance for the app.</value>
        IApplicationSettingsServiceHandler Roaming { get; }

        /// <summary>
        /// Gets the legacy settings handler instance for the app.
        /// </summary>
        /// <value>The legacy settings handler instance for the app.</value>
        IApplicationSettingsServiceHandler Legacy { get; }
    }
}