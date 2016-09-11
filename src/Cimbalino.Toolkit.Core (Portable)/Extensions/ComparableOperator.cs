// ****************************************************************************
// <copyright file="ComparableOperator.cs" company="Pedro Lamas">
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

namespace Cimbalino.Toolkit.Extensions
{
    /// <summary>
    /// Represents an <see cref="IComparable"/> operator.
    /// </summary>
    public enum ComparableOperator
    {
        /// <summary>
        /// Specifies an equal operator.
        /// </summary>
        Equal,

        /// <summary>
        /// Specifies a not equal operator.
        /// </summary>
        NotEqual,

        /// <summary>
        /// Specifies a less than operator.
        /// </summary>
        LessThan,

        /// <summary>
        /// Specifies a less than or equal operator.
        /// </summary>
        LessThanOrEqual,

        /// <summary>
        /// Specifies a greater than operator.
        /// </summary>
        GreaterThan,

        /// <summary>
        /// Specifies a greater than or equal operator.
        /// </summary>
        GreaterThanOrEqual
    }
}