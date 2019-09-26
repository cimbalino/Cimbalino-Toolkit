// ****************************************************************************
// <copyright file="ApplicationBarItemCollectionBase.cs" company="Pedro Lamas">
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

using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using Microsoft.Phone.Shell;

namespace Cimbalino.Toolkit.Behaviors
{
    /// <summary>
    /// Represents a collection of <see cref="ApplicationBarItemBase{T}" />.
    /// </summary>
    /// <typeparam name="T">The type of items in the collection.</typeparam>
    public abstract class ApplicationBarItemCollectionBase<T> : DependencyObjectCollection<ApplicationBarItemBase<T>>
        where T : IApplicationBarMenuItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes",
            Justification = "Necessary")]
        private readonly System.Collections.IList _itemsList;
        private readonly int _maxVisibleItems;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationBarItemCollectionBase{T}" /> class.
        /// </summary>
        /// <param name="itemsList">The items list.</param>
        /// <param name="maxVisibleItems">The maximum visible items.</param>
        protected ApplicationBarItemCollectionBase(System.Collections.IList itemsList, int maxVisibleItems)
        {
            _itemsList = itemsList;
            _maxVisibleItems = maxVisibleItems;

            CollectionChanged += OnCollectionChanged;
        }

        internal void UpdateApplicationBar()
        {
            if (DesignerProperties.IsInDesignTool)
            {
                return;
            }

            _itemsList.Clear();

            foreach (var item in GetVisibleItems())
            {
                _itemsList.Add(item.InternalItem);
            }
        }

        private void OnCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
            {
                foreach (ApplicationBarItemBase<T> item in e.OldItems)
                {
                    item.Parent = null;
                }
            }

            if (e.NewItems != null)
            {
                foreach (ApplicationBarItemBase<T> item in e.NewItems)
                {
                    item.Parent = this;
                }
            }

            UpdateApplicationBar();
        }

        private IEnumerable<ApplicationBarItemBase<T>> GetVisibleItems()
        {
            var itemCount = 0;

            foreach (var item in this)
            {
                if (item.IsVisible)
                {
                    yield return item;

                    if (++itemCount == _maxVisibleItems)
                    {
                        yield break;
                    }
                }
            }
        }
    }
}