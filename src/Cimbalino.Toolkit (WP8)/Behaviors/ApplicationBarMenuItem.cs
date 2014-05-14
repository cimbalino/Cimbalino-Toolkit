// ****************************************************************************
// <copyright file="ApplicationBarMenuItem.cs" company="Pedro Lamas">
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
    /// An item that can be added to the menu of an <see cref="Microsoft.Phone.Shell.ApplicationBar"/>.
    /// </summary>
    public class ApplicationBarMenuItem : ApplicationBarItemBase<IApplicationBarMenuItem>, IApplicationBarMenuItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationBarMenuItem" /> class.
        /// </summary>
        public ApplicationBarMenuItem()
            : base(new Microsoft.Phone.Shell.ApplicationBarMenuItem())
        {
        }
    }
}