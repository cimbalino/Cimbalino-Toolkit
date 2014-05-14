// ****************************************************************************
// <copyright file="BehaviorOfT.cs" company="Pedro Lamas">
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
    public abstract class Behavior<T> : Behavior
        where T : DependencyObject
    {
        protected new T AssociatedObject
        {
            get
            {
                return (T)base.AssociatedObject;
            }
        }
    }
}