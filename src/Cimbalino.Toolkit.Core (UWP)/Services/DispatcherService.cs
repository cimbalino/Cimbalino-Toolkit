// ****************************************************************************
// <copyright file="DispatcherService.cs" company="Pedro Lamas">
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
using System.Threading.Tasks;
using Cimbalino.Toolkit.Extensions;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IDispatcherService"/>.
    /// </summary>
    public class DispatcherService : IDispatcherService
    {
        private readonly CoreDispatcher _dispatcher;

        /// <summary>
        /// Initializes a new instance of the <see cref="DispatcherService"/> class.
        /// </summary>
        public DispatcherService()
        {
            if (CoreApplication.Views.Count > 0)
            {
                var coreApplicationView = CoreApplication.MainView;

                if (coreApplicationView != null)
                {
                    var coreWindow = coreApplicationView.CoreWindow;

                    if (coreWindow != null)
                    {
                        _dispatcher = coreWindow.Dispatcher;
                    }
                }
            }
        }

        /// <summary>
        /// Runs the event dispatcher and awaits for it to complete before returning the results for dispatched events asynchronously.
        /// </summary>
        /// <param name="action">The action to call.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task InvokeOnUiThreadAsync(Action action)
        {
            return InvokeOnUiThreadAsync(action, false);
        }

        /// <summary>
        /// Runs the event dispatcher and awaits for it to complete before returning the results for dispatched events asynchronously.
        /// </summary>
        /// <param name="action">The action to call.</param>
        /// <param name="force">Force dispatcher invokation even if already on UI thread.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task InvokeOnUiThreadAsync(Action action, bool force)
        {
            if (_dispatcher != null && (force || !_dispatcher.HasThreadAccess))
            {
                return _dispatcher.RunAndAwaitAsync(CoreDispatcherPriority.Normal, action);
            }
            else
            {
                action();

                return Task.FromResult(0);
            }
        }

        /// <summary>
        /// Runs the event dispatcher and awaits for it to complete before returning the results for dispatched events asynchronously.
        /// </summary>
        /// <typeparam name="T">The return type.</typeparam>
        /// <param name="function">The function to call.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task<T> InvokeOnUiThreadAsync<T>(Func<T> function)
        {
            return InvokeOnUiThreadAsync(function, false);
        }

        /// <summary>
        /// Runs the event dispatcher and awaits for it to complete before returning the results for dispatched events asynchronously.
        /// </summary>
        /// <typeparam name="T">The return type.</typeparam>
        /// <param name="function">The function to call.</param>
        /// <param name="force">Force dispatcher invokation even if already on UI thread.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task<T> InvokeOnUiThreadAsync<T>(Func<T> function, bool force)
        {
            if (_dispatcher != null && (force || !_dispatcher.HasThreadAccess))
            {
                return _dispatcher.RunAndAwaitAsync(CoreDispatcherPriority.Normal, function);
            }
            else
            {
                var result = function();

                return Task.FromResult(result);
            }
        }

        /// <summary>
        /// Runs the event dispatcher and awaits for it to complete before returning the results for dispatched events asynchronously.
        /// </summary>
        /// <param name="asyncAction">The async action to call.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task InvokeOnUiThreadAsync(Func<Task> asyncAction)
        {
            return InvokeOnUiThreadAsync(asyncAction, false);
        }

        /// <summary>
        /// Runs the event dispatcher and awaits for it to complete before returning the results for dispatched events asynchronously.
        /// </summary>
        /// <param name="asyncAction">The async action to call.</param>
        /// <param name="force">Force dispatcher invokation even if already on UI thread.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task InvokeOnUiThreadAsync(Func<Task> asyncAction, bool force)
        {
            if (_dispatcher != null)
            {
                return _dispatcher.RunAndAwaitAsync(CoreDispatcherPriority.Normal, asyncAction);
            }
            else
            {
                return asyncAction();
            }
        }

        /// <summary>
        /// Runs the event dispatcher and awaits for it to complete before returning the results for dispatched events asynchronously.
        /// </summary>
        /// <typeparam name="T">The return type.</typeparam>
        /// <param name="asyncFunction">The async function to call.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task<T> InvokeOnUiThreadAsync<T>(Func<Task<T>> asyncFunction)
        {
            return InvokeOnUiThreadAsync(asyncFunction, false);
        }

        /// <summary>
        /// Runs the event dispatcher and awaits for it to complete before returning the results for dispatched events asynchronously.
        /// </summary>
        /// <typeparam name="T">The return type.</typeparam>
        /// <param name="asyncFunction">The async function to call.</param>
        /// <param name="force">Force dispatcher invokation even if already on UI thread.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task<T> InvokeOnUiThreadAsync<T>(Func<Task<T>> asyncFunction, bool force)
        {
            if (_dispatcher != null)
            {
                return _dispatcher.RunAndAwaitAsync(CoreDispatcherPriority.Normal, asyncFunction);
            }
            else
            {
                return asyncFunction();
            }
        }
    }
}