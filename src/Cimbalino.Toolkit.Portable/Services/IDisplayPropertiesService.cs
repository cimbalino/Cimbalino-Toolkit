// ****************************************************************************
// <copyright file="IDisplayPropertiesService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2014
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <project>Cimbalino.Toolkit.Portable</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using Cimbalino.Toolkit.Foundation;

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of launching a Settings dialog that allows the user to change the device's settings.
    /// </summary>
    public interface IDisplayPropertiesService
    {
        /// <summary>
        /// Gets the pixels per logical inch of the current environment.
        /// </summary>
        /// <value>The pixels per logical inch of the current environment.</value>
        float LogicalDpi { get; }

        /// <summary>
        /// Gets the height and width of the application window, as a Rect value.
        /// </summary>
        /// <value>A value that reports the height and width of the application window.</value>
        Rect Bounds { get; }

        /// <summary>
        /// Gets the scale factor of the immersive environment.
        /// </summary>
        /// <value>The scale factor of the immersive environment.</value>
        DisplayPropertiesServiceResolutionScale ResolutionScale { get; }
    }
}