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

#if WINDOWS_PHONE || WINDOWS_PHONE_81
using System;
using System.Windows;
using Microsoft.Phone.Info;
using Windows.Graphics.Display;
using Rect = Cimbalino.Toolkit.Foundation.Rect;
#elif WINDOWS_UWP
using System;
using Cimbalino.Toolkit.Foundation;
using Windows.Foundation.Metadata;
using Windows.Graphics.Display;
using Windows.UI.Xaml;
#else
using System;
using Cimbalino.Toolkit.Foundation;
using Windows.Graphics.Display;
using Windows.UI.Xaml;
#endif

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
        public virtual float LogicalDpi
        {
            get
            {
#if WINDOWS_PHONE
                return DisplayProperties.LogicalDpi;
#elif WINDOWS_PHONE_81
#pragma warning disable 0618
                return DisplayProperties.LogicalDpi;
#pragma warning restore 0618
#else
                return DisplayInformation.GetForCurrentView().LogicalDpi;
#endif
            }
        }

        /// <summary>
        /// Gets the raw dots per inch (DPI) along the x axis of the display monitor.
        /// </summary>
        /// <value>The raw dots per inch (DPI) along the x axis of the display monitor.</value>
        public virtual float RawDpiX
        {
            get
            {
#if WINDOWS_PHONE || WINDOWS_PHONE_81
                object value;

                if (DeviceExtendedProperties.TryGetValue("RawDpiX", out value))
                {
                    return (float)(double)value;
                }

                return 1.0f;
#else
                return DisplayInformation.GetForCurrentView().RawDpiX;
#endif
            }
        }

        /// <summary>
        /// Gets the raw dots per inch (DPI) along the y axis of the display monitor.
        /// </summary>
        /// <value>The raw dots per inch (DPI) along the y axis of the display monitor.</value>
        public virtual float RawDpiY
        {
            get
            {
#if WINDOWS_PHONE || WINDOWS_PHONE_81
                object value;

                if (DeviceExtendedProperties.TryGetValue("RawDpiY", out value))
                {
                    return (float)(double)value;
                }

                return 1.0f;
#else
                return DisplayInformation.GetForCurrentView().RawDpiY;
#endif
            }
        }

        /// <summary>
        /// Gets the height and width of the application window, as a Rect value.
        /// </summary>
        /// <value>A value that reports the height and width of the application window.</value>
        public virtual Rect Bounds
        {
            get
            {
#if WINDOWS_PHONE || WINDOWS_PHONE_81
                return new Rect(0, 0, Application.Current.Host.Content.ActualWidth, Application.Current.Host.Content.ActualHeight);
#else
                var bounds = Window.Current.Bounds;

                return new Rect(bounds.X, bounds.Y, bounds.Width, bounds.Height);
#endif
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
#if WINDOWS_PHONE || WINDOWS_PHONE_81
                object value;

                if (DeviceExtendedProperties.TryGetValue("PhysicalScreenResolution", out value))
                {
                    var size = (Size)value;

                    return new Rect(0, 0, size.Width, size.Height);
                }

                return Bounds;
#else
                var bounds = Bounds;
                var rawPixelsPerViewPixel = RawPixelsPerViewPixel;

                return new Rect(0, 0, bounds.Width * rawPixelsPerViewPixel, bounds.Height * rawPixelsPerViewPixel);
#endif
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
#if WINDOWS_UWP
                if (ApiInformation.IsPropertyPresent("Windows.Graphics.Display.DisplayInformation", "DiagonalSizeInInches"))
                {
                    var diagonalSizeInInches = DisplayInformation.GetForCurrentView().DiagonalSizeInInches;

                    if (diagonalSizeInInches.HasValue)
                    {
                        return diagonalSizeInInches.Value;
                    }
                }
#endif

                var physicalBounds = PhysicalBounds;

                return Math.Sqrt(Math.Pow(physicalBounds.Width / RawDpiX, 2) + Math.Pow(physicalBounds.Height / RawDpiY, 2));
            }
        }

        /// <summary>
        /// Gets the number of raw (physical) pixels for each view (layout) pixel.
        /// </summary>
        /// <value>The number of raw (physical) pixels for each view (layout) pixel.</value>
        public virtual double RawPixelsPerViewPixel
        {
            get
            {
#if WINDOWS_PHONE || WINDOWS_PHONE_81
                return 1.0;
#elif WINDOWS_PHONE_APP || WINDOWS_UWP
                return DisplayInformation.GetForCurrentView().RawPixelsPerViewPixel;
#else
                return DisplayInformation.GetForCurrentView().LogicalDpi / 96.0;
#endif
            }
        }
    }
}