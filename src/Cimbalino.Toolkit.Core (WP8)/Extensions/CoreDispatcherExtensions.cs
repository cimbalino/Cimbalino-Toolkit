// ****************************************************************************
// <copyright file="CoreDispatcherExtensions.cs" company="Pedro Lamas">
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
using Windows.UI.Core;

namespace Cimbalino.Toolkit.Extensions
{
    /// <summary>
    /// Provides a set of static (Shared in Visual Basic) methods for <see cref="CoreDispatcher"/> instances.
    /// </summary>
#if !NETFX_CORE
    [CLSCompliant(false)]
#endif
    public static class CoreDispatcherExtensions
    {
        /// <summary>
        /// Runs the event dispatcher and awaits for it to complete before returning the results for dispatched events asynchronously.
        /// </summary>
        /// <param name="dispatcher">The dispatcher.</param>
        /// <param name="function">The async function to call.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public static Task RunAndAwaitAsync(this CoreDispatcher dispatcher, Func<Task> function)
        {
            return dispatcher.RunAndAwaitAsync(async () =>
            {
                await function().ConfigureAwait(false);

                return true;
            });
        }

        /// <summary>
        /// Runs the event dispatcher and awaits for it to complete before returning the results for dispatched events asynchronously.
        /// </summary>
        /// <typeparam name="T">The return type.</typeparam>
        /// <param name="dispatcher">The dispatcher.</param>
        /// <param name="function">The async function to call.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public static async Task<T> RunAndAwaitAsync<T>(this CoreDispatcher dispatcher, Func<Task<T>> function)
        {
            var taskCompletionSource = new TaskCompletionSource<T>();

            await dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
            {
                try
                {
                    var result = await function().ConfigureAwait(false);

                    taskCompletionSource.TrySetResult(result);
                }
                catch (Exception ex)
                {
                    taskCompletionSource.TrySetException(ex);
                }
            });

            return await taskCompletionSource.Task.ConfigureAwait(false);
        }
    }
}