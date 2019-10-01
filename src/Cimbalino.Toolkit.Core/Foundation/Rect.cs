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

using System;

namespace Cimbalino.Toolkit.Foundation
{
    /// <summary>
    /// Describes the width, height, and point origin of a rectangle.
    /// </summary>
    public struct Rect
    {
        private static readonly Rect EmptyRect = new Rect()
        {
            _x = double.PositiveInfinity,
            _y = double.PositiveInfinity,
            _width = double.NegativeInfinity,
            _height = double.NegativeInfinity,
        };

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
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);
                }

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
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);
                }

                _height = value;
            }
        }

        /// <summary>
        /// Gets the x-axis value of the left side of the rectangle.
        /// </summary>
        /// <value>The x-axis value of the left side of the rectangle.</value>
        public double Left
        {
            get
            {
                return _x;
            }
        }

        /// <summary>
        /// Gets the x-axis value of the right side of the rectangle.
        /// </summary>
        /// <value>The x-axis value of the right side of the rectangle.</value>
        public double Right
        {
            get
            {
                return IsEmpty ? double.NegativeInfinity : _x;
            }
        }

        /// <summary>
        /// Gets the y-axis position of the top of the rectangle.
        /// </summary>
        /// <value>The y-axis position of the top of the rectangle.</value>
        public double Top
        {
            get
            {
                return _y;
            }
        }

        /// <summary>
        /// Gets the y-axis value of the bottom of the rectangle.
        /// </summary>
        /// <value>The y-axis value of the bottom of the rectangle.</value>
        public double Bottom
        {
            get
            {
                return IsEmpty ? double.NegativeInfinity : _y + _height;
            }
        }

        /// <summary>
        /// Gets the position of the top-left corner of the rectangle. 
        /// </summary>
        /// <value>The position of the top-left corner of the rectangle.</value>
        public Point TopLeft
        {
            get
            {
                return new Point(Left, Top);
            }
        }

        /// <summary>
        /// Gets the position of the top-right corner of the rectangle.
        /// </summary>
        /// <value>The position of the top-right corner of the rectangle.</value>
        public Point TopRight
        {
            get
            {
                return new Point(Right, Top);
            }
        }

        /// <summary>
        /// Gets the position of the bottom-left corner of the rectangle.
        /// </summary>
        /// <value>The position of the bottom-left corner of the rectangle.</value>
        public Point BottomLeft
        {
            get
            {
                return new Point(Left, Bottom);
            }
        }

        /// <summary>
        /// Gets the position of the bottom-right corner of the rectangle.
        /// </summary>
        /// <value>The position of the bottom-right corner of the rectangle.</value>
        public Point BottomRight
        {
            get
            {
                return new Point(Right, Bottom);
            }
        }

        /// <summary>
        /// Gets the width and height of the rectangle.
        /// </summary>
        /// <value>A <see cref="Size" /> structure that specifies the width and height of the rectangle.</value>
        public Size Size
        {
            get
            {
                return new Size(_width, _height);
            }
        }

        /// <summary>
        /// Gets a value indicating whether the rectangle is the <see cref="Rect.Empty"/> rectangle.
        /// </summary>
        /// <value>true if the rectangle is the <see cref="Rect.Empty"/> rectangle; otherwise, false.</value>
        public bool IsEmpty
        {
            get
            {
                return _width < 0;
            }
        }

        /// <summary>
        /// Gets a special value that represents a rectangle with no position or area.
        /// </summary>
        /// <value>A rectangle with no position or area.</value>
        public static Rect Empty
        {
            get
            {
                return EmptyRect;
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Rect" /> structure that is exactly large enough to contain the two specified points.
        /// </summary>
        /// <param name="point1">The first point that the new rectangle must contain.</param>
        /// <param name="point2">The second point that the new rectangle must contain.</param>
        public Rect(Point point1, Point point2)
        {
            _x = Math.Min(point1.X, point2.X);
            _y = Math.Min(point1.Y, point2.Y);
            _width = Math.Max(Math.Max(point1.X, point2.X) - _x, 0);
            _height = Math.Max(Math.Max(point1.Y, point2.Y) - _y, 0);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rect" /> structure that has the specified top-left corner location and the specified width and height.
        /// </summary>
        /// <param name="location">A point that specifies the location of the top-left corner of the rectangle.</param>
        /// <param name="size">A <see cref="Size" /> structure that specifies the width and height of the rectangle.</param>
        public Rect(Point location, Size size)
        {
            if (size.IsEmpty)
            {
                this = EmptyRect;
            }
            else
            {
                _x = location.X;
                _y = location.Y;
                _width = size.Width;
                _height = size.Height;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rect"/> structure that has the specified x-coordinate, y-coordinate, width, and height.
        /// </summary>
        /// <param name="x">The x-coordinate of the top-left corner of the rectangle.</param>
        /// <param name="y">The y-coordinate of the top-left corner of the rectangle.</param>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        public Rect(double x, double y, double width, double height)
        {
            if (width < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(width), width, null);
            }

            if (height < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(height), height, null);
            }

            _x = x;
            _y = y;
            _width = width;
            _height = height;
        }

        /// <summary>
        /// Indicates whether the rectangle contains the specified point.
        /// </summary>
        /// <param name="point">The point to check.</param>
        /// <returns>true if the rectangle contains the specified point; otherwise, false.</returns>
        public bool Contains(Point point)
        {
            return Contains(point.X, point.Y);
        }

        /// <summary>
        /// Indicates whether the rectangle contains the specified x-coordinate and y-coordinate.
        /// </summary>
        /// <param name="x">The x-coordinate of the point to check.</param>
        /// <param name="y">The y-coordinate of the point to check.</param>
        /// <returns>true if (<paramref name="x" />, <paramref name="y" />) is contained by the rectangle; otherwise, false.</returns>
        public bool Contains(double x, double y)
        {
            return x >= Left && x <= Right && y >= Top && y <= Bottom;
        }
    }
}