// ****************************************************************************
// <copyright file="WeakAction.cs" company="Pedro Lamas">
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
    /// Stores an <see cref="Action" /> without causing a hard reference to be created to the action's owner. The owner can be garbage collected at any time.
    /// </summary>
    public class WeakAction : IDisposable
    {
        /// <summary>
        /// Gets or sets a <see cref="WeakReference"/> to the target <see cref="Action"/>.
        /// </summary>
        /// <value>A <see cref="WeakReference"/> to the target <see cref="Action"/>.</value>
        protected WeakReference ActionReference { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="WeakReference"/> to the target of this <see cref="WeakAction"/>.
        /// </summary>
        /// <value>A <see cref="WeakReference"/> to the target of this <see cref="WeakAction"/>.</value>
        protected WeakReference Reference { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="MethodInfo" /> corresponding to this <see cref="WeakAction"/>.
        /// </summary>
        /// <value>The <see cref="MethodInfo" /> corresponding to this <see cref="WeakAction"/>.</value>
        protected MethodInfo Method { get; set; }

        /// <summary>
        /// Gets a value indicating whether the action's owner is still alive (not yet collected by the Garbage Collector).
        /// </summary>
        /// <value>true if action's owner is still alive; otherwise, false.</value>
        public virtual bool IsAlive
        {
            get
            {
                return Reference != null && Reference.IsAlive;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WeakAction"/> class.
        /// </summary>
        protected WeakAction()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WeakAction"/> class.
        /// </summary>
        /// <param name="action">The action.</param>
        public WeakAction(Action action)
            : this(action.Target, action)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WeakAction"/> class.
        /// </summary>
        /// <param name="target">The action's owner.</param>
        /// <param name="action">The action.</param>
        public WeakAction(object target, Action action)
        {
            Method = action.GetMethodInfo();
            ActionReference = new WeakReference(action.Target);
            Reference = new WeakReference(target);
        }

        /// <summary>
        /// Executes the action if action's owner is still alive.
        /// </summary>
        public virtual void Execute()
        {
            if (IsAlive)
            {
                var actionTarget = ActionReference.Target;

                if (Method != null && actionTarget != null)
                {
                    Method.Invoke(actionTarget, null);
                }
            }
            else
            {
                Dispose();
            }
        }

        #region IDisposable Interface

        /// <summary>
        /// Disposes this instance and releases all references.
        /// </summary>
        public void Dispose()
        {
            Reference = null;
            ActionReference = null;
            Method = null;

            GC.SuppressFinalize(this);
        }

        #endregion
    }
}