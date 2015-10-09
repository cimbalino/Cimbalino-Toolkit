// ****************************************************************************
// <copyright file="MultiBindingItemCollection.cs" company="Pedro Lamas">
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
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
#else
using System.Collections.Specialized;
using System.Linq;
using Cimbalino.Toolkit.Helpers;
using Windows.UI.Xaml;
#endif

namespace Cimbalino.Toolkit.Behaviors
{
    /// <summary>
    /// Represents a collection of <see cref="MultiBindingBehavior" />.
    /// </summary>
    public class MultiBindingItemCollection : DependencyObjectCollection<MultiBindingItem>
    {
        private bool _updating;

        /// <summary>
        /// Gets or sets the multiple binding value.
        /// </summary>
        /// <value>The multiple binding value.</value>
        public object[] Value
        {
            get { return (object[])GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="Value" /> dependency property.
        /// </summary>
        internal static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(object[]), typeof(MultiBindingItemCollection), new PropertyMetadata(null, OnValueChanged));

        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var multiBindingItemCollection = (MultiBindingItemCollection)d;

            multiBindingItemCollection.UpdateSource();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultiBindingItemCollection"/> class.
        /// </summary>
        public MultiBindingItemCollection()
        {
            CollectionChanged += OnCollectionChanged;
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
            {
                foreach (MultiBindingItem item in e.OldItems)
                {
                    item.Parent = null;
                }
            }

            if (e.NewItems != null)
            {
                foreach (MultiBindingItem item in e.NewItems)
                {
                    item.Parent = this;
                }
            }

            Update();
        }

        internal void Update()
        {
            if (_updating)
            {
                return;
            }

            try
            {
                _updating = true;

                Value = this
                    .OfType<MultiBindingItem>()
                    .Select(x => x.Value)
                    .ToArray();
            }
            finally
            {
                _updating = false;
            }
        }

        private void UpdateSource()
        {
            if (_updating)
            {
                return;
            }

            try
            {
                _updating = true;

                for (var index = 0; index < this.Count; index++)
                {
                    var multiBindingItem = this[index] as MultiBindingItem;

                    if (multiBindingItem != null)
                    {
                        multiBindingItem.Value = Value[index];
                    }
                }
            }
            finally
            {
                _updating = false;
            }
        }
    }
}