// ****************************************************************************
// <copyright file="WeakFunc{T,TResult}.cs" company="Pedro Lamas">
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
using System.Reflection;

namespace Cimbalino.Toolkit.Helpers
{
    /// <summary>
    /// Stores an <see cref="Func{T,TResult}" /> without causing a hard reference to be created to the function's owner. The owner can be garbage collected at any time.
    /// </summary>
    /// <typeparam name="T">The type of the parameter of the method that this delegate encapsulates.</typeparam>
    /// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates.</typeparam>
    public class WeakFunc<T, TResult> : WeakFunc<TResult>
    {
        /// <summary>
        /// Gets a value indicating whether the function's owner is still alive (not yet collected by the Garbage Collector).
        /// </summary>
        /// <value>true if function's owner is still alive; otherwise, false.</value>
        public override bool IsAlive
        {
            get
            {
                return Reference != null && Reference.IsAlive;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WeakFunc{T,TResult}"/> class.
        /// </summary>
        /// <param name="func">The function.</param>
        public WeakFunc(Func<T, TResult> func)
            : this(func.Target, func)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WeakFunc{T,TResult}"/> class.
        /// </summary>
        /// <param name="target">The function's owner.</param>
        /// <param name="func">The function.</param>
        public WeakFunc(object target, Func<T, TResult> func)
        {
            Method = func.GetMethodInfo();
            FuncReference = new WeakReference(func.Target);
            Reference = new WeakReference(target);
        }

        /// <summary>
        /// Executes the function if function's owner is still alive.
        /// </summary>
        /// <returns>The return value from executing the function if the function's owner is still alive.</returns>
        public override TResult Execute()
        {
            return Execute(default(T));
        }

        /// <summary>
        /// Executes the function if function's owner is still alive.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <returns>The return value from executing the function if the function's owner is still alive.</returns>
        public virtual TResult Execute(T parameter)
        {
            if (IsAlive)
            {
                var funcTarget = FuncReference.Target;

                if (Method != null && funcTarget != null)
                {
                    return (TResult)Method.Invoke(funcTarget, new object[] { parameter });
                }
            }
            else
            {
                Dispose();
            }

            return default(TResult);
        }
    }
}