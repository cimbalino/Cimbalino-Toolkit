// ****************************************************************************
// <copyright file="NullToVisibilityConverter.cs" company="Pedro Lamas">
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
using System.Globalization;
using System.Windows;
using System.Windows.Data;
#else
using System;
using System.Globalization;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
#endif

namespace Cimbalino.Toolkit.Converters
{
    /// <summary>
    /// An <see cref="IValueConverter"/> which converts a <see cref="object"/> value to a <see cref="Visibility"/> value.
    /// </summary>
    public class NullToVisibilityConverter : ValueConverterBase
    {
        /// <summary>
        /// Gets or sets a value indicating whether the return value should be inverted.
        /// </summary>
        /// <value>true if the return value should be inverted; otherwise, false.</value>
        public bool InvertValue
        {
            get { return (bool)GetValue(InvertValueProperty); }
            set { SetValue(InvertValueProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="InvertValue" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty InvertValueProperty =
            DependencyProperty.Register(nameof(InvertValue), typeof(bool), typeof(NullToVisibilityConverter), new PropertyMetadata(false));

        /// <summary>
        /// Converts a <see cref="bool"/> value to a <see cref="Visibility"/> value.
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var boolValue = value != null;

            if (InvertValue)
            {
                boolValue = !boolValue;
            }

            return boolValue ? Visibility.Visible : Visibility.Collapsed;
        }

        /// <summary>
        /// Converts a <see cref="Visibility"/> value to a <see cref="bool"/> value.
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
} 