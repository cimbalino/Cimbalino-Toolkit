// ****************************************************************************
// <copyright file="Behavior.cs" company="Pedro Lamas">
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

using Windows.UI.Xaml;

namespace Microsoft.Xaml.Interactivity
{
    public class Behavior : DependencyObject, IBehavior
    {
        private DependencyObject _associatedObject;

        protected DependencyObject AssociatedObject
        {
            get
            {
                return _associatedObject;
            }
        }

        public void Attach(DependencyObject associatedObject)
        {
            _associatedObject = associatedObject;

            OnAttached();
        }

        public void Detach()
        {
            OnDetaching();

            _associatedObject = null;
        }

        protected virtual void OnAttached()
        {
        }

        protected virtual void OnDetaching()
        {
        }

        #region IBehavior Interface

        DependencyObject IBehavior.AssociatedObject
        {
            get
            {
                return AssociatedObject;
            }
        }

        #endregion
    }
}