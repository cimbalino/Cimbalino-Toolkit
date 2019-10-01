// ****************************************************************************
// <copyright file="ObservableTaskBase.cs" company="Pedro Lamas">
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
using System.ComponentModel;
using System.Threading.Tasks;

namespace Cimbalino.Toolkit.Helpers
{
    /// <summary>
    /// A basic implementation of <see cref="INotifyPropertyChanged"/>.
    /// </summary>
    /// <typeparam name="T">The associated task instance type.</typeparam>
    public abstract class ObservableTaskBase<T> : ObservableBase
        where T : Task
    {
        /// <summary>
        /// Gets the associated task instance.
        /// </summary>
        /// <value>The associated task instance.</value>
        public T Task { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the associated task instance has completed.
        /// </summary>
        /// <value>true if the associated task instance has completed; otherwise, false.</value>
        public bool IsCompleted
        {
            get
            {
                return Task.IsCompleted;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the associated task instance has completed execution due to being canceled.
        /// </summary>
        /// <value>true if the associated task instance has completed execution due to being canceled; otherwise, false.</value>
        public bool IsCancelled
        {
            get
            {
                return Task.IsCanceled;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the associated task instance has completed execution due to an unhandled exception.
        /// </summary>
        /// <value>true if the associated task instance has completed execution due to an unhandled exception; otherwise, false.</value>
        public bool IsFaulted
        {
            get
            {
                return Task.IsFaulted;
            }
        }

        /// <summary>
        /// Gets the <see cref="AggregateException"/> that caused the associated task instance to end prematurely.
        /// </summary>
        /// <value>The <see cref="AggregateException"/> that caused the associated task instance to end prematurely.</value>
        public AggregateException Exception
        {
            get
            {
                return Task.Exception;
            }
        }

        /// <summary>
        /// Gets the <see cref="TaskStatus"/> of the associated task instance.
        /// </summary>
        /// <value>The <see cref="TaskStatus"/> of the associated task instance.</value>
        public TaskStatus Status
        {
            get
            {
                return Task.Status;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObservableTaskBase{T}"/> class.
        /// </summary>
        /// <param name="task">The associated task instance.</param>
        protected ObservableTaskBase(T task)
        {
            Task = task;

            AwaitTask();
        }

        private async void AwaitTask()
        {
            try
            {
                await Task;
            }
            catch
            {
            }

            RaisePropertyChanged(string.Empty);
        }
    }
}