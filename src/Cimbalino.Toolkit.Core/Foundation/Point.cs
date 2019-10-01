// ****************************************************************************
// <copyright file="Point.cs" company="Pedro Lamas">
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

namespace Cimbalino.Toolkit.Foundation
{
    /// <summary>
    /// Represents an x- and y-coordinate pair in two-dimensional space.
    /// </summary>
    public struct Point
    {
        private double _x, _y;

        #region Properties

        /// <summary>
        /// Gets or sets the X-coordinate value of this <see cref="Point"/> structure.
        /// </summary>
        /// <value>The X-coordinate value of this <see cref="Point"/> structure.</value>
        public double X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        /// <summary>
        /// Gets or sets the Y-coordinate value of this <see cref="Point"/> structure.
        /// </summary>
        /// <value>The Y-coordinate value of this <see cref="Point"/> structure.</value>
        public double Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> structure that has the specified x-coordinate and y-coordinate.
        /// </summary>
        /// <param name="x">The x-coordinate of the new <see cref="Point" /> structure.</param>
        /// <param name="y">The y-coordinate of the new <see cref="Point" /> structure.</param>
        public Point(double x, double y)
        {
            _x = x;
            _y = y;
        }
    }
}