// ****************************************************************************
// <copyright file="MultiBindingItem.cs" company="Pedro Lamas">
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
using System.Windows;
#else
using Windows.UI.Xaml;
#endif

namespace Cimbalino.Toolkit.Behaviors
{
    /// <summary>
    /// A multiple binding item.
    /// </summary>
    public class MultiBindingItem : DependencyObject
    {
        /// <summary>
        /// Gets or sets the binding value.
        /// </summary>
        /// <value>The binding value.</value>
        public object Value
        {
            get { return GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="Value" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(nameof(Value), typeof(object), typeof(MultiBindingItem), new PropertyMetadata(null, OnValueChanged));

        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var multiBindingItem = (MultiBindingItem)d;

            multiBindingItem.Update();
        }

        internal MultiBindingItemCollection Parent { get; set; }

        private void Update()
        {
            var parent = Parent;

            if (parent != null)
            {
                parent.Update();
            }
        }
    }
}