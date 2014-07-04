// ****************************************************************************
// <copyright file="WeakFunc{TResult}.cs" company="Pedro Lamas">
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
    /// Stores an <see cref="Func{TResult}" /> without causing a hard reference to be created to the function's owner. The owner can be garbage collected at any time.
    /// </summary>
    /// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates.</typeparam>
    public class WeakFunc<TResult> : IDisposable
    {
        /// <summary>
        /// Gets or sets a <see cref="WeakReference"/> to the target <see cref="Func{TResult}"/>.
        /// </summary>
        /// <value>A <see cref="WeakReference"/> to the target <see cref="Func{TResult}"/>.</value>
        protected WeakReference FuncReference { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="WeakReference"/> to the target of this <see cref="WeakFunc{TResult}"/>.
        /// </summary>
        /// <value>A <see cref="WeakReference"/> to the target of this <see cref="WeakFunc{TResult}"/>.</value>
        protected WeakReference Reference { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="MethodInfo" /> corresponding to this <see cref="WeakFunc{TResult}"/>.
        /// </summary>
        /// <value>The <see cref="MethodInfo" /> corresponding to this <see cref="WeakFunc{TResult}"/>.</value>
        protected MethodInfo Method { get; set; }

        /// <summary>
        /// Gets a value indicating whether the function's owner is still alive (not yet collected by the Garbage Collector).
        /// </summary>
        /// <value>true if function's owner is still alive; otherwise, false.</value>
        public virtual bool IsAlive
        {
            get
            {
                return Reference != null && Reference.IsAlive;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WeakFunc{TResult}"/> class.
        /// </summary>
        protected WeakFunc()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WeakFunc{TResult}"/> class.
        /// </summary>
        /// <param name="func">The function.</param>
        public WeakFunc(Func<TResult> func)
            : this(func.Target, func)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WeakFunc{TResult}"/> class.
        /// </summary>
        /// <param name="target">The function's owner.</param>
        /// <param name="func">The function.</param>
        public WeakFunc(object target, Func<TResult> func)
        {
            Method = func.GetMethodInfo();
            FuncReference = new WeakReference(func.Target);
            Reference = new WeakReference(target);
        }

        /// <summary>
        /// Executes the function if function's owner is still alive.
        /// </summary>
        /// <returns>The return value from executing the function if the function's owner is still alive.</returns>
        public virtual TResult Execute()
        {
            if (IsAlive)
            {
                var funcTarget = FuncReference.Target;

                if (Method != null && funcTarget != null)
                {
                    return (TResult)Method.Invoke(funcTarget, null);
                }
            }
            else
            {
                Dispose();
            }

            return default(TResult);
        }

        #region IDisposable Interface

        /// <summary>
        /// Disposes this instance and releases all references.
        /// </summary>
        public void Dispose()
        {
            Reference = null;
            FuncReference = null;
            Method = null;

            GC.SuppressFinalize(this);
        }

        #endregion
    }
}