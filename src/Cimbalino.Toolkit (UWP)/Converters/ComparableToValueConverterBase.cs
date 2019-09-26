// ****************************************************************************
// <copyright file="ComparableToValueConverterBase.cs" company="Pedro Lamas">
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
using System.Globalization;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Cimbalino.Toolkit.Converters
{
    /// <summary>
    /// An <see cref="IValueConverter"/> abstract implementation which converts an <see cref="IComparable"/> value.
    /// </summary>
    /// <typeparam name="TInput">The input <see cref="IComparable"/> type.</typeparam>
    /// <typeparam name="TOutput">The output type.</typeparam>
    public class ComparableToValueConverterBase<TInput, TOutput> : ComparableConverterBase<TInput>
        where TInput : IComparable
    {
        /// <summary>
        /// Gets or sets the value to return if true.
        /// </summary>
        /// <value>The value to return if true.</value>
        public TOutput TrueValue
        {
            get { return (TOutput)GetValue(TrueValueProperty); }
            set { SetValue(TrueValueProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="TrueValue" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty TrueValueProperty =
            DependencyProperty.Register(nameof(TrueValue), typeof(TOutput), typeof(ComparableToValueConverterBase<TInput, TOutput>), new PropertyMetadata(default(TOutput)));

        /// <summary>
        /// Gets or sets the value to return if false.
        /// </summary>
        /// <value>The value to return if false.</value>
        public TOutput FalseValue
        {
            get { return (TOutput)GetValue(FalseValueProperty); }
            set { SetValue(FalseValueProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="FalseValue" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty FalseValueProperty =
            DependencyProperty.Register(nameof(FalseValue), typeof(TOutput), typeof(ComparableToValueConverterBase<TInput, TOutput>), new PropertyMetadata(default(TOutput)));

        /// <summary>
        /// Modifies the source data before passing it to the target for display in the UI.
        /// </summary>
        /// <param name="value">The source data being passed to the target.</param>
        /// <param name="targetType">The <see cref="T:System.Type"/> of data expected by the target dependency property.</param>
        /// <param name="parameter">An optional parameter to be used in the converter logic.</param>
        /// <param name="culture">The culture of the conversion.</param>
        /// <returns>The value to be passed to the target dependency property.</returns>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var comparable = (TInput)value;

            return CompareTo(comparable) ? TrueValue : FalseValue;
        }

        /// <summary>
        /// Modifies the target data before passing it to the source object.  This method is called only in <see cref="F:System.Windows.Data.BindingMode.TwoWay"/> bindings.
        /// </summary>
        /// <param name="value">The target data being passed to the source.</param>
        /// <param name="targetType">The <see cref="T:System.Type"/> of data expected by the source object.</param>
        /// <param name="parameter">An optional parameter to be used in the converter logic.</param>
        /// <param name="culture">The culture of the conversion.</param>
        /// <returns>The value to be passed to the source object.</returns>
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}