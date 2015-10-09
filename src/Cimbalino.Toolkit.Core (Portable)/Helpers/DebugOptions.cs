// ****************************************************************************
// <copyright file="DebugOptions.cs" company="Pedro Lamas">
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

namespace Cimbalino.Toolkit.Helpers
{
    /// <summary>
    /// Helper class to set debugging options used in Cimbalino Toolkit.
    /// </summary>
    public static class DebugOptions
    {
        /// <summary>
        /// Gets or sets a value indicating whether exceptions should be raised when code tries to access to unsupported features.
        /// </summary>
        /// <value>true if exceptions should be raised when code tries to access to unsupported features; otherwise, false.</value>
        public static bool ThrowNotSupportedExceptions { get; set; }
    }
}