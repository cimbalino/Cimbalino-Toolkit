using System;
using System.Collections.Generic;
using System.Reflection;

namespace Cimbalino.Toolkit.Services
{
    internal static class WebAuthenticationHelper
    {
        private const string WebAuthenticationBrokerFullName = "Windows.Security.Authentication.Web.WebAuthenticationBroker, Windows, ContentType=WindowsRuntime";
        private const string ValueSetFullName = "Windows.Foundation.Collections.ValueSet, Windows, ContentType=WindowsRuntime";
        private const string WebAuthenticationBrokerOptionsFullName = "Windows.Security.Authentication.Web.WebAuthenticationOptions, Windows, ContentType=WindowsRuntime";

        internal static bool IsSupported()
        {
            return GetBrokerType() != null;
        }

        internal static TypeInfo CreateBroker()
        {
            var type = GetBrokerType();
            return type.GetTypeInfo();
        }

        internal static object CreateValueSet(Dictionary<string, object> values)
        {
            var type = GetValueSetType();
            dynamic instance = Activator.CreateInstance(type);

            if (values == null)
            {
                return instance;
            }

            foreach (var value in values)
            {
                instance.Add(value);
            }

            return instance;
        }

        internal static Type GetValueSetType()
        {
            return Type.GetType(ValueSetFullName);
        }

        internal static Type GetBrokerType()
        {
            return Type.GetType(WebAuthenticationBrokerFullName);
        }

        internal static Type GetOptionsType()
        {
            return Type.GetType(WebAuthenticationBrokerOptionsFullName);
        }
    }
}