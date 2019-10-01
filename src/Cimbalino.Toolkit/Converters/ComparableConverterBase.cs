// ****************************************************************************
// <copyright file="ComparableConverterBase.cs" company="Pedro Lamas">
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
using Cimbalino.Toolkit.Extensions;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Cimbalino.Toolkit.Converters
{
    /// <summary>
    /// An <see cref="IValueConverter"/> abstract implementation which converts an <see cref="IComparable"/> value.
    /// </summary>
    /// <typeparam name="T">The <see cref="IComparable"/> type.</typeparam>
    public abstract class ComparableConverterBase<T> : ValueConverterBase
        where T : IComparable
    {
        /// <summary>
        /// Gets or sets the ternary condition.
        /// </summary>
        /// <value>The ternary condition.</value>
        public ComparableOperator CompareMode
        {
            get { return (ComparableOperator)GetValue(CompareModeProperty); }
            set { SetValue(CompareModeProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="CompareMode" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty CompareModeProperty =
            DependencyProperty.Register(nameof(CompareMode), typeof(ComparableOperator), typeof(ComparableConverterBase<T>), new PropertyMetadata(ComparableOperator.Equal));

        /// <summary>
        /// Gets or sets the value to compary with.
        /// </summary>
        public T CompareWith
        {
            get { return (T)GetValue(CompareWithProperty); }
            set { SetValue(CompareWithProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="CompareWith" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty CompareWithProperty =
            DependencyProperty.Register(nameof(CompareWith), typeof(T), typeof(ComparableConverterBase<T>), new PropertyMetadata(default(T)));

        /// <summary>
        /// Perform the ternary operation with the indicated value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The bolean result of the ternary operation.</returns>
        protected bool CompareTo(T value)
        {
            return CompareWith.CompareTo(CompareMode, value);
        }
    }
}