// ****************************************************************************
// <copyright file="DisplayPropertiesService.cs" company="Pedro Lamas">
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

using System;
using Cimbalino.Toolkit.Foundation;
using Windows.Foundation.Metadata;
using Windows.Graphics.Display;
using Windows.UI.Xaml;

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IDisplayPropertiesService"/>.
    /// </summary>
    public class DisplayPropertiesService : IDisplayPropertiesService
    {
        /// <summary>
        /// Gets the pixels per logical inch of the current environment.
        /// </summary>
        /// <value>The pixels per logical inch of the current environment.</value>
        public virtual float LogicalDpi => DisplayInformation.GetForCurrentView().LogicalDpi;

        /// <summary>
        /// Gets the raw dots per inch (DPI) along the x axis of the display monitor.
        /// </summary>
        /// <value>The raw dots per inch (DPI) along the x axis of the display monitor.</value>
        public virtual float RawDpiX => DisplayInformation.GetForCurrentView().RawDpiX;

        /// <summary>
        /// Gets the raw dots per inch (DPI) along the y axis of the display monitor.
        /// </summary>
        /// <value>The raw dots per inch (DPI) along the y axis of the display monitor.</value>
        public virtual float RawDpiY => DisplayInformation.GetForCurrentView().RawDpiY;

        /// <summary>
        /// Gets the height and width of the application window, as a Rect value.
        /// </summary>
        /// <value>A value that reports the height and width of the application window.</value>
        public virtual Rect Bounds
        {
            get
            {
                var bounds = Window.Current.Bounds;

                return new Rect(bounds.X, bounds.Y, bounds.Width, bounds.Height);
            }
        }

        /// <summary>
        /// Gets the height and width of the physical screen, as a Rect value.
        /// </summary>
        /// <value>A value that reports the height and width of the physical screen window.</value>
        public virtual Rect PhysicalBounds
        {
            get
            {
                var bounds = Bounds;
                var rawPixelsPerViewPixel = RawPixelsPerViewPixel;

                return new Rect(0, 0, bounds.Width * rawPixelsPerViewPixel, bounds.Height * rawPixelsPerViewPixel);
            }
        }

        /// <summary>
        /// Gets the physical screen diagonal size.
        /// </summary>
        /// <value>The physical screen diagonal size.</value>
        public virtual double ScreenDiagonal
        {
            get
            {
                if (ApiInformation.IsPropertyPresent("Windows.Graphics.Display.DisplayInformation", "DiagonalSizeInInches"))
                {
                    var diagonalSizeInInches = DisplayInformation.GetForCurrentView().DiagonalSizeInInches;

                    if (diagonalSizeInInches.HasValue)
                    {
                        return diagonalSizeInInches.Value;
                    }
                }

                var physicalBounds = PhysicalBounds;

                return Math.Sqrt(Math.Pow(physicalBounds.Width / RawDpiX, 2) + Math.Pow(physicalBounds.Height / RawDpiY, 2));
            }
        }

        /// <summary>
        /// Gets the number of raw (physical) pixels for each view (layout) pixel.
        /// </summary>
        /// <value>The number of raw (physical) pixels for each view (layout) pixel.</value>
        public virtual double RawPixelsPerViewPixel => DisplayInformation.GetForCurrentView().RawPixelsPerViewPixel;
    }
}