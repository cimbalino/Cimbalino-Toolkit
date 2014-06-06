// ****************************************************************************
// <copyright file="StringRegexConverter.cs" company="Pedro Lamas">
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
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Data;
#else
using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
#endif


namespace Cimbalino.Toolkit.Converters
{
    /// <summary>
    /// An <see cref="IValueConverter"/> which formats a <see cref="string"/> value using a Regular Expression.
    /// </summary>
    public class StringRegexConverter : ValueConverterBase
    {
        /// <summary>
        /// Gets or sets the regular expression pattern to match.
        /// </summary>
        /// <value>The regular expression pattern to match.</value>
        public string Pattern
        {
            get { return (string)GetValue(PatternProperty); }
            set { SetValue(PatternProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="Pattern" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty PatternProperty =
            DependencyProperty.Register("Pattern", typeof(string), typeof(StringRegexConverter), new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the replacement pattern string.
        /// </summary>
        /// <value>The replacement pattern string.</value>
        public string ReplacementPattern
        {
            get { return (string)GetValue(ReplacementPatternProperty); }
            set { SetValue(ReplacementPatternProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="ReplacementPattern" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty ReplacementPatternProperty =
            DependencyProperty.Register("ReplacementPattern", typeof(string), typeof(StringRegexConverter), new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the options that modify the matching operation.
        /// </summary>
        /// <value>A bitwise combination of the <see cref="RegexOptions"/> values.</value>
        public RegexOptions Options
        {
            get { return (RegexOptions)GetValue(OptionsProperty); }
            set { SetValue(OptionsProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="Options" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty OptionsProperty =
            DependencyProperty.Register("Options", typeof(RegexOptions), typeof(StringRegexConverter), new PropertyMetadata(null));

        /// <summary>
        /// Formats a <see cref="string"/> value using a Regular Expression.
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

            var stringValue = (string)value;

            if (string.IsNullOrEmpty(Pattern))
            {
                return stringValue;
            }
            
            if (ReplacementPattern == null)
            {
                return Regex.Match(stringValue, Pattern).Value;
            }
            
            return Regex.Replace(stringValue, Pattern, ReplacementPattern);
        }

        /// <summary>
        /// Modifies the target data before passing it to the source object.  This
        /// method is called only in <see cref="F:System.Windows.Data.BindingMode.TwoWay" />
        /// bindings.
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
            throw new NotSupportedException();
        }
    }
}