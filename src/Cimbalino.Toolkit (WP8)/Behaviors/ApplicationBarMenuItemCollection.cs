// ****************************************************************************
// <copyright file="ApplicationBarMenuItemCollection.cs" company="Pedro Lamas">
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

using Microsoft.Phone.Shell;

namespace Cimbalino.Toolkit.Behaviors
{
    /// <summary>
    /// Represents a collection of <see cref="IApplicationBarMenuItem" />
    /// </summary>
    public class ApplicationBarMenuItemCollection : ApplicationBarItemCollectionBase<IApplicationBarMenuItem>
    {
        private const int MaxVisibleMenuitems = 50;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationBarMenuItemCollection" /> class.
        /// </summary>
        /// <param name="itemsList">The items list.</param>
        public ApplicationBarMenuItemCollection(System.Collections.IList itemsList)
            : base(itemsList, MaxVisibleMenuitems)
        {
        }
    }
}