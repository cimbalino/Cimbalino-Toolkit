// ****************************************************************************
// <copyright file="EmptyCollectionToObjectConverter.cs" company="Pedro Lamas">
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
using System.Collections;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
#else
using System;
using System.Collections;
using System.Globalization;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
#endif

namespace Cimbalino.Toolkit.Converters
{
    /// <summary>
    /// An <see cref="IValueConverter"/> that evaluates if a collection is empty or not and returns an <see cref="object"/> accordingly.
    /// </summary>
    public class EmptyCollectionToObjectConverter : ValueConverterBase
    {
        /// <summary>
        /// Gets or sets the value to return if the collection is empty.
        /// </summary>
        /// <value>The value to return if the collection is empty.</value>
        public object EmptyValue
        {
            get { return (object)GetValue(EmptyValueProperty); }
            set { SetValue(EmptyValueProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="EmptyValue" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty EmptyValueProperty =
            DependencyProperty.Register(nameof(EmptyValue), typeof(object), typeof(EmptyCollectionToObjectConverter), null);

        /// <summary>
        /// Gets or sets the value to return if the collection is not empty.
        /// </summary>
        /// <value>The value to return if the collection is not empty.</value>
        public object NotEmptyValue
        {
            get { return (object)GetValue(NotEmptyValueProperty); }
            set { SetValue(NotEmptyValueProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="NotEmptyValue" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty NotEmptyValueProperty =
            DependencyProperty.Register(nameof(NotEmptyValue), typeof(object), typeof(EmptyCollectionToObjectConverter), null);

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
            bool hasItems;

            var collection = value as ICollection;

            if (collection != null)
            {
                hasItems = collection.Count > 0;
            }
            else
            {
                var enumerable = value as IEnumerable;

                hasItems = enumerable != null && enumerable.GetEnumerator().MoveNext();
            }

            return hasItems ? NotEmptyValue : EmptyValue;
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