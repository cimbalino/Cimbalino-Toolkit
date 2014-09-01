// ****************************************************************************
// <copyright file="IDisplayPropertiesService.cs" company="Pedro Lamas">
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
        /// Gets the raw dots per inch (DPI) along the x axis of the display monitor.
        /// </summary>
        /// <value>The raw dots per inch (DPI) along the x axis of the display monitor.</value>
        float RawDpiX { get; }

        /// <summary>
        /// Gets the raw dots per inch (DPI) along the y axis of the display monitor.
        /// </summary>
        /// <value>The raw dots per inch (DPI) along the y axis of the display monitor.</value>
        float RawDpiY { get; }

        /// <summary>
        /// Gets the height and width of the application window, as a Rect value.
        /// </summary>
        /// <value>A value that reports the height and width of the application window.</value>
        Rect Bounds { get; }

        /// <summary>
        /// Gets the height and width of the physical screen, as a Rect value.
        /// </summary>
        /// <value>A value that reports the height and width of the physical screen window.</value>
        Rect PhysicalBounds { get; }

        /// <summary>
        /// Gets the physical screen diagonal size.
        /// </summary>
        /// <value>The physical screen diagonal size.</value>
        float ScreenDiagonal { get; }

        /// <summary>
        /// Gets the number of raw (physical) pixels for each view (layout) pixel.
        /// </summary>
        /// <value>The number of raw (physical) pixels for each view (layout) pixel.</value>
        double RawPixelsPerViewPixel { get; }
    }
}