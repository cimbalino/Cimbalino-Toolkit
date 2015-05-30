using System;

namespace Cimbalino.Toolkit.Helpers
{
    public class ExceptionHelper
    {
        public static void ThrowNotSupported(string message = "")
        {
            if (DebugOptions.ThrowNotSupportedExceptions)
            {
                throw new NotSupportedException(message);
            }
        }

        public static T ThrowNotSupported<T>(string message = "")
        {
            if (DebugOptions.ThrowNotSupportedExceptions)
            {
                throw new NotSupportedException(message);
            }

            return default(T);
        }
    }
}
