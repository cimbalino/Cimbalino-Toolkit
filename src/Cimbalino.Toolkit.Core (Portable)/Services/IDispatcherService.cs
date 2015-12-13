// ****************************************************************************
// <copyright file="IDispatcherService.cs" company="Pedro Lamas">
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

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of handling the UI thread dispatcher.
    /// </summary>
    public interface IDispatcherService
    {
        /// <summary>
        /// Runs the event dispatcher and awaits for it to complete before returning the results for dispatched events asynchronously.
        /// </summary>
        /// <param name="action">The action to call.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task InvokeOnUiThreadAsync(Action action);

        /// <summary>
        /// Runs the event dispatcher and awaits for it to complete before returning the results for dispatched events asynchronously.
        /// </summary>
        /// <param name="action">The action to call.</param>
        /// <param name="force">Force dispatcher invokation even if already on UI thread.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task InvokeOnUiThreadAsync(Action action, bool force);

        /// <summary>
        /// Runs the event dispatcher and awaits for it to complete before returning the results for dispatched events asynchronously.
        /// </summary>
        /// <typeparam name="T">The return type.</typeparam>
        /// <param name="function">The function to call.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task<T> InvokeOnUiThreadAsync<T>(Func<T> function);

        /// <summary>
        /// Runs the event dispatcher and awaits for it to complete before returning the results for dispatched events asynchronously.
        /// </summary>
        /// <typeparam name="T">The return type.</typeparam>
        /// <param name="function">The function to call.</param>
        /// <param name="force">Force dispatcher invokation even if already on UI thread.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task<T> InvokeOnUiThreadAsync<T>(Func<T> function, bool force);

        /// <summary>
        /// Runs the event dispatcher and awaits for it to complete before returning the results for dispatched events asynchronously.
        /// </summary>
        /// <param name="asyncAction">The async action to call.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task InvokeOnUiThreadAsync(Func<Task> asyncAction);

        /// <summary>
        /// Runs the event dispatcher and awaits for it to complete before returning the results for dispatched events asynchronously.
        /// </summary>
        /// <param name="asyncAction">The async action to call.</param>
        /// <param name="force">Force dispatcher invokation even if already on UI thread.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task InvokeOnUiThreadAsync(Func<Task> asyncAction, bool force);

        /// <summary>
        /// Runs the event dispatcher and awaits for it to complete before returning the results for dispatched events asynchronously.
        /// </summary>
        /// <typeparam name="T">The return type.</typeparam>
        /// <param name="asyncFunction">The async function to call.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task<T> InvokeOnUiThreadAsync<T>(Func<Task<T>> asyncFunction);

        /// <summary>
        /// Runs the event dispatcher and awaits for it to complete before returning the results for dispatched events asynchronously.
        /// </summary>
        /// <typeparam name="T">The return type.</typeparam>
        /// <param name="asyncFunction">The async function to call.</param>
        /// <param name="force">Force dispatcher invokation even if already on UI thread.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task<T> InvokeOnUiThreadAsync<T>(Func<Task<T>> asyncFunction, bool force);
    }
}