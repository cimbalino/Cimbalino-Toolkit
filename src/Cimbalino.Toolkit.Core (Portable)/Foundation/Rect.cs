// ****************************************************************************
// <copyright file="Rect.cs" company="Pedro Lamas">
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
    /// Describes the width, height, and point origin of a rectangle.
    /// </summary>
    public struct Rect
    {
        private double _x, _y, _width, _height;

        #region Properties

        /// <summary>
        /// Gets or sets the x-axis value of the left side of the rectangle.
        /// </summary>
        /// <value>The x-axis value of the left side of the rectangle. This value is interpreted as pixels within the coordinate space.</value>
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
        /// Gets or sets the y-axis value of the top side of the rectangle.
        /// </summary>
        /// <value>The y-axis value of the top side of the rectangle. This value is interpreted as pixels within the coordinate space.</value>
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

        /// <summary>
        /// Gets or sets the width of the rectangle.
        /// </summary>
        /// <value>A value that represents the width of the rectangle in pixels. The default is 0.</value>
        public double Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }

        /// <summary>
        /// Gets or sets the height of the rectangle.
        /// </summary>
        /// <value>A value that represents the height of the rectangle. The default is 0.</value>
        public double Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Rect"/> structure that has the specified x-coordinate, y-coordinate, width, and height.
        /// </summary>
        /// <param name="x">The x-coordinate of the top-left corner of the rectangle.</param>
        /// <param name="y">The y-coordinate of the top-left corner of the rectangle.</param>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        public Rect(double x, double y, double width, double height)
        {
            _x = x;
            _y = y;
            _width = width;
            _height = height;
        }
    }
}