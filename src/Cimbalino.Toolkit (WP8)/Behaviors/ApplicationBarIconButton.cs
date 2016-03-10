// ****************************************************************************
// <copyright file="ApplicationBarIconButton.cs" company="Pedro Lamas">
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

using System;
using System.ComponentModel;
using System.Windows;
using Microsoft.Phone.Shell;

namespace Cimbalino.Toolkit.Behaviors
{
    /// <summary>
    /// An Application Bar button with an icon.
    /// </summary>
    public class ApplicationBarIconButton : ApplicationBarItemBase<IApplicationBarIconButton>, IApplicationBarIconButton
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationBarIconButton" /> class.
        /// </summary>
        public ApplicationBarIconButton()
            : base(new Microsoft.Phone.Shell.ApplicationBarIconButton() { IconUri = new Uri(string.Empty, UriKind.Relative) })
        {
        }

        /// <summary>
        /// Gets or sets the URI of the icon to use for the button.
        /// </summary>
        /// <value>The URI of the icon to use for the button.</value>
        [Category("Common")]
        public Uri IconUri
        {
            get
            {
                return (Uri)GetValue(IconUriProperty);
            }
            set
            {
                SetValue(IconUriProperty, value);
            }
        }

        /// <summary>
        /// Identifier for the <see cref="ApplicationBarIconButton.IconUri" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty IconUriProperty =
            DependencyProperty.Register(nameof(IconUri), typeof(Uri), typeof(ApplicationBarIconButton), new PropertyMetadata(new Uri(string.Empty, UriKind.Relative), OnIconUriChanged));

        /// <summary>
        /// Called after the URI of the icon to use for the button is changed.
        /// </summary>
        /// <param name="d">The <see cref="DependencyObject" />.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs" /> instance containing the event data.</param>
        protected static void OnIconUriChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = (ApplicationBarIconButton)d;

            element.InternalItem.IconUri = (Uri)e.NewValue;
        }
    }
}