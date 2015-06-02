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
