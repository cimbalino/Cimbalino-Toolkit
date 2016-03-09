// ****************************************************************************
// <copyright file="ObservableBase.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2014
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <project>Cimbalino.Toolkit.Core</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Cimbalino.Toolkit.Helpers
{
    /// <summary>
    /// Base helper class that will notify any listener for task completion.
    /// </summary>
    public abstract class ObservableBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Assigns a new value to a property and raises the <see cref="PropertyChanged"/> event if the value changed.
        /// </summary>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="field">The field storing the property's value.</param>
        /// <param name="value">The property's new value.</param>
        /// <param name="propertyExpression">An expression identifying the property that changed.</param>
        /// <returns>true if the property value changed; otherwise, false.</returns>
        protected virtual bool SetProperty<T>(ref T field, T value, Expression<Func<T>> propertyExpression)
        {
            return SetProperty(ref field, value, GetPropertyName(propertyExpression));
        }

        /// <summary>
        /// Assigns a new value to a property and raises the <see cref="PropertyChanged"/> event if the value changed.
        /// </summary>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="field">The field storing the property's value.</param>
        /// <param name="value">The property's new value.</param>
        /// <param name="propertyName">The property name.</param>
        /// <returns>true if the property value changed; otherwise, false.</returns>
        protected virtual bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return false;
            }

            field = value;
            RaisePropertyChanged(propertyName);
            return true;
        }

        /// <summary>
        /// Raises the <see cref="PropertyChanged"/> event.
        /// </summary>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="propertyExpression">An expression identifying the property that changed.</param>
        protected virtual void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            RaisePropertyChanged(GetPropertyName(propertyExpression));
        }

        /// <summary>
        /// Raises the <see cref="PropertyChanged"/> event.
        /// </summary>
        /// <param name="propertyName">The name of the property that changed.</param>
        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Extracts the name of a property from an expression.
        /// </summary>
        /// <typeparam name="T">The type of the property.</typeparam>
        /// <param name="propertyExpression">An expression identifying the property.</param>
        /// <returns>The name of a property from an expression.</returns>
        protected static string GetPropertyName<T>(Expression<Func<T>> propertyExpression)
        {
            if (propertyExpression == null)
            {
                throw new ArgumentNullException(nameof(propertyExpression));
            }

            var body = propertyExpression.Body as MemberExpression;

            if (body == null)
            {
                throw new ArgumentException("Invalid argument", nameof(propertyExpression));
            }

            var property = body.Member as PropertyInfo;

            if (property == null)
            {
                throw new ArgumentException("Argument is not a property", nameof(propertyExpression));
            }

            return property.Name;
        }
    }
}