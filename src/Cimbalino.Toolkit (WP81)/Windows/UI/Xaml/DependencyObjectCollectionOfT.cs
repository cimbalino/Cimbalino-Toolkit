// ****************************************************************************
// <copyright file="DependencyObjectCollectionOfT.cs" company="Pedro Lamas">
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
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Windows.Foundation.Collections;

namespace Windows.UI.Xaml
{
    public class DependencyObjectCollection<T> : DependencyObjectCollection, INotifyCollectionChanged
        where T : DependencyObject
    {
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        private readonly List<T> _oldItems = new List<T>();

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


    public class DependencyObjectCollection3<T> : DependencyObject, IObservableVector<T>, INotifyCollectionChanged
       where T : DependencyObject
    {
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public event VectorChangedEventHandler<T> VectorChanged;

        private readonly DependencyObjectCollection _items = new DependencyObjectCollection();
        private readonly List<T> _oldItems = new List<T>();

        public DependencyObjectCollection3()
        {
            _items.VectorChanged += DependencyObjectCollectionVectorChanged;
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

        public int IndexOf(T item)
        {
            return _items.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            _items.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _items.RemoveAt(index);
        }

        public T this[int index]
        {
            get
            {
                return (T)_items[index];
            }
            set
            {
                _items[index] = value;
            }
        }

        public void Add(T item)
        {
            _items.Add(item);
        }

        public void Clear()
        {
            _items.Clear();
        }

        public bool Contains(T item)
        {
            return _items.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _items.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get
            {
                return _items.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return _items.IsReadOnly;
            }
        }

        public bool Remove(T item)
        {
            return _items.Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _items
                .Cast<T>()
                .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}