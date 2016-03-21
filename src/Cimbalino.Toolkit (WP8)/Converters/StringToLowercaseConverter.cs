// ****************************************************************************
// <copyright file="StringToLowercaseConverter.cs" company="Pedro Lamas">
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
using System.Globalization;
using System.Windows.Data;
using Cimbalino.Toolkit.Helpers;
#else
using System;
using System.Globalization;
using Cimbalino.Toolkit.Helpers;
using Windows.UI.Xaml.Data;
#endif

namespace Cimbalino.Toolkit.Converters
{
    /// <summary>
    /// An <see cref="IValueConverter"/> which formats a <see cref="string"/> value to lower case.
    /// </summary>
    public class StringToLowercaseConverter : ValueConverterBase
    {
        private static readonly StringFormatConverter _stringFormatConverter = new StringFormatConverter();

        /// <summary>
        /// Formats a <see cref="string"/> value to lower case.
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
            if (value == null)
            {
                return null;
            }

#if WINDOWS_PHONE || WINDOWS_PHONE_81
            return culture == null
                ? ((string)_stringFormatConverter.Convert(value, targetType, parameter, culture)).ToLower()
                : ((string)_stringFormatConverter.Convert(value, targetType, parameter, culture)).ToLower(culture);
#else
            return ((string)_stringFormatConverter.Convert(value, targetType, parameter, culture)).ToLower();
#endif
        }

        /// <summary>
        /// Formats a <see cref="string"/> value to lower case.
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
            return ExceptionHelper.ThrowNotSupported<object>();
        }
    }
}