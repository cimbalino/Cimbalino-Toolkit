// ****************************************************************************
// <copyright file="Size.cs" company="Pedro Lamas">
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
    /// Implements a structure that is used to describe the <see cref="Size" /> of an object.
    /// </summary>
    public struct Size
    {
        private static readonly Size EmptySize = new Size()
        {
            _width = double.NegativeInfinity,
            _height = double.NegativeInfinity
        };

        private double _width, _height;

        #region Properties

        /// <summary>
        /// Gets or sets the width of this <see cref="Size" /> structure.
        /// </summary>
        /// <value>The width of this <see cref="Size" /> structure. The default is 0.</value>
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
        /// Gets or sets the height of this <see cref="Size" /> structure.
        /// </summary>
        /// <value>The height of this <see cref="Size" /> structure. The default is 0.</value>
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
        /// Gets a value indicating whether this instance of <see cref="Size" /> is <see cref="Size.Empty" />.
        /// </summary>
        /// <value>true if this instance of <see cref="Size" /> is <see cref="Size.Empty" />; otherwise, false.</value>
        public bool IsEmpty
        {
            get
            {
                return _width < 0;
            }
        }

        /// <summary>
        /// Gets a value that represents a static empty <see cref="Size" />.
        /// </summary>
        /// <value>The static empty <see cref="Size" />.</value>
        public static Size Empty
        {
            get
            {
                return EmptySize;
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Size"/> structure and assigns it an initial <paramref name="width" /> and <paramref name="height" />.
        /// </summary>
        /// <param name="width">The initial width of the instance of <see cref="Size" />.</param>
        /// <param name="height">The initial height of the instance of <see cref="Size" />.</param>
        public Size(double width, double height)
        {
            if (width < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(width), width, null);
            }

            if (height < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(height), width, null);
            }

            _width = width;
            _height = height;
        }
    }
}