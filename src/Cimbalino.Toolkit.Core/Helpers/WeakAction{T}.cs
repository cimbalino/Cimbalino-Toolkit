// ****************************************************************************
// <copyright file="WeakAction{T}.cs" company="Pedro Lamas">
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
    /// Stores an <see cref="Action{T}" /> without causing a hard reference to be created to the action's owner. The owner can be garbage collected at any time.
    /// </summary>
    /// <typeparam name="T">The type of the parameter of the method that this delegate encapsulates.</typeparam>
    public class WeakAction<T> : WeakAction
    {
        /// <summary>
        /// Gets a value indicating whether the action's owner is still alive (not yet collected by the Garbage Collector).
        /// </summary>
        /// <value>true if action's owner is still alive; otherwise, false.</value>
        public override bool IsAlive
        {
            get
            {
                return Reference != null && Reference.IsAlive;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WeakAction{T}"/> class.
        /// </summary>
        /// <param name="action">The action.</param>
        public WeakAction(Action<T> action)
            : this(action.Target, action)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WeakAction{T}"/> class.
        /// </summary>
        /// <param name="target">The action's owner.</param>
        /// <param name="action">The action.</param>
        public WeakAction(object target, Action<T> action)
        {
            Method = action.GetMethodInfo();
            ActionReference = new WeakReference(action.Target);
            Reference = new WeakReference(target);
        }

        /// <summary>
        /// Executes the action if action's owner is still alive.
        /// </summary>
        public override void Execute()
        {
            Execute(default(T));
        }

        /// <summary>
        /// Executes the action if action's owner is still alive.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        public virtual void Execute(T parameter)
        {
            if (IsAlive)
            {
                var actionTarget = ActionReference.Target;

                if (Method != null && actionTarget != null)
                {
                    Method.Invoke(actionTarget, new object[] { parameter });
                }
            }
            else
            {
                Dispose();
            }
        }
    }
}