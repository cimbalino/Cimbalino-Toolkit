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

#if WINDOWS_PHONE
using System;
using System.Windows;
using Microsoft.Phone.Info;
using Windows.Graphics.Display;
using Rect = Cimbalino.Toolkit.Foundation.Rect;
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
        public float LogicalDpi
        {
            get
            {
#if WINDOWS_PHONE
                return DisplayProperties.LogicalDpi;
#else
                return DisplayInformation.GetForCurrentView().LogicalDpi;
#endif
            }
        }

        /// <summary>
        /// Gets the height and width of the application window, as a Rect value.
        /// </summary>
        /// <value>A value that reports the height and width of the application window.</value>
        public Rect Bounds
        {
            get
            {
#if WINDOWS_PHONE
                return new Rect(0, 0, Application.Current.Host.Content.ActualWidth, Application.Current.Host.Content.ActualHeight);
#else
                var bounds = Window.Current.Bounds;

                return new Rect(bounds.X, bounds.Y, bounds.Width, bounds.Height);
#endif
            }
        }

        /// <summary>
        /// Gets the scale factor of the immersive environment.
        /// </summary>
        /// <value>The scale factor of the immersive environment.</value>
        public DisplayPropertiesServiceResolutionScale ResolutionScale
        {
            get
            {
#if WINDOWS_PHONE
                var resolutionScale = Application.Current.Host.Content.ScaleFactor;

                object physicalScreenResolutionObject;

                if (DeviceExtendedProperties.TryGetValue("PhysicalScreenResolution", out physicalScreenResolutionObject))
                {
                    var physicalScreenResolution = (Size)physicalScreenResolutionObject;

                    resolutionScale = (int)(physicalScreenResolution.Width / 4.8);
                }
#elif WINDOWS_PHONE_APP
                var resolutionScale = (int)DisplayInformation.GetForCurrentView().ResolutionScale;
#else
                var resolutionScale = (int)DisplayInformation.GetForCurrentView().ResolutionScale;
#endif

                if (Enum.IsDefined(typeof(DisplayPropertiesServiceResolutionScale), resolutionScale))
                {
                    return (DisplayPropertiesServiceResolutionScale)resolutionScale;
                }

                return DisplayPropertiesServiceResolutionScale.Invalid;
            }
        }
    }
}