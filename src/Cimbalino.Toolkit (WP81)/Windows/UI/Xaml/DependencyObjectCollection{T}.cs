// ****************************************************************************
// <copyright file="DependencyObjectCollection{T}.cs" company="Pedro Lamas">
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
using System.Collections.Generic;
using System.Collections.Specialized;
using Windows.Foundation.Collections;

namespace Windows.UI.Xaml
{
    /// <summary>
    /// Represents a collection of <see cref="DependencyObject"/> instances of a specified type.
    /// </summary>
    /// <typeparam name="T">The type of items in the collection.</typeparam>
    public class DependencyObjectCollection<T> : DependencyObjectCollection, INotifyCollectionChanged
        where T : DependencyObject
    {
        /// <summary>
        /// Occurs when items in the collection are added, removed, or replaced.
        /// </summary>
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        private readonly List<T> _oldItems = new List<T>();

        /// <summary>
        /// Initializes a new instance of the <see cref="DependencyObjectCollection{T}" /> class.
        /// </summary>
        public DependencyObjectCollection()
        {
            VectorChanged += DependencyObjectCollectionVectorChanged;
        }

        private void DependencyObjectCollectionVectorChanged(IObservableVector<DependencyObject> sender, IVectorChangedEventArgs e)
        {
            var index = (int)e.Index;

            switch (e.CollectionChange)
            {
                case CollectionChange.Reset:
                    OnNotifyPropertyChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));

                    _oldItems.Clear();

                    break;

                case CollectionChange.ItemInserted:
                    OnNotifyPropertyChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, this[index], index));

                    _oldItems.Insert(index, (T)this[index]);

                    break;

                case CollectionChange.ItemRemoved:
                    OnNotifyPropertyChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, _oldItems[index], index));

                    _oldItems.RemoveAt(index);

                    break;

                case CollectionChange.ItemChanged:
                    OnNotifyPropertyChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, this[index], _oldItems[index]));

                    _oldItems[index] = (T)this[index];

                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void OnNotifyPropertyChanged(NotifyCollectionChangedEventArgs e)
        {
            var eventHandler = CollectionChanged;

            if (eventHandler != null)
            {
                eventHandler(this, e);
            }
        }
    }
}