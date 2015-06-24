// ****************************************************************************
// <copyright file="ExceptionHelper.cs" company="Pedro Lamas">
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

namespace Cimbalino.Toolkit.Helpers
{
    internal class ExceptionHelper
    {
        internal static void ThrowNotSupported(string message = "")
        {
            if (DebugOptions.ThrowNotSupportedExceptions)
            {
                throw new NotSupportedException(message);
            }
        }

        internal static T ThrowNotSupported<T>(string message = "")
        {
            if (DebugOptions.ThrowNotSupportedExceptions)
            {
                throw new NotSupportedException(message);
            }

            return default(T);
        }
    }
}
