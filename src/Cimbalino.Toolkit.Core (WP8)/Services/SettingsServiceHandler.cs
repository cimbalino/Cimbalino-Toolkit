// ****************************************************************************
// <copyright file="SettingsServiceHandler.cs" company="Pedro Lamas">
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

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="ISettingsServiceHandler"/>.
    /// </summary>
#if !NETFX_CORE
    [System.CLSCompliant(false)]
#endif
    public class SettingsServiceHandler : ISettingsServiceHandler
    {
        private readonly ApplicationDataContainer _applicationDataContainer;

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsServiceHandler"/> class.
        /// </summary>
        /// <param name="applicationDataContainer">The root <see cref="ApplicationDataContainer"/> instance.</param>
        public SettingsServiceHandler(ApplicationDataContainer applicationDataContainer)
        {
            _applicationDataContainer = applicationDataContainer;
        }

        /// <summary>
        /// Gets the value associated with the specified key.
        /// </summary>
        /// <param name="key">The key whose value to get.</param>
        /// <returns>The value associated with the specified key, if the key is found; otherwise, the default value for the type of the value parameter.</returns>
        /// <typeparam name="T">The type of value to get.</typeparam>
        public T Get<T>(string key)
        {
            return Get(key, default(T));
        }

        /// <summary>
        /// Gets the value associated with the specified key.
        /// </summary>
        /// <param name="key">The key whose value to get.</param>
        /// <param name="defaultValue">The default value to return if the key does not exist.</param>
        /// <returns>The value associated with the specified key, if the key is found; otherwise, the specified default value.</returns>
        /// <typeparam name="T">The type of value to get.</typeparam>
        public T Get<T>(string key, T defaultValue)
        {
            var container = GetContainer(key, out key);

            if (container != null && container.Values.ContainsKey(key))
            {
                return (T)container.Values[key];
            }

            return defaultValue;
        }

        /// <summary>
        /// Sets the value for the specified key. If the entry does not exist, a new one will be added.
        /// </summary>
        /// <param name="key">The key whose value to set.</param>
        /// <param name="value">The value for the specified key.</param>
        /// <typeparam name="T">The type of value to set.</typeparam>
        public void Set<T>(string key, T value)
        {
            var container = GetContainer(key, out key, true);

            if (container.Values.ContainsKey(key))
            {
                container.Values[key] = value;
            }
            else
            {
                container.Values.Add(key, value);
            }
        }

        /// <summary>
        /// Removes the specified key and associated value.
        /// </summary>
        /// <param name="key">The key whose value to clear.</param>
        public void Clear(string key)
        {
            var container = GetContainer(key, out key);

            if (container != null && container.Values.ContainsKey(key))
            {
                container.Values.Remove(key);
            }
        }

        /// <summary>
        /// Gets an object that represents all the settings in this <see cref="ISettingsServiceHandler"/> instance.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task<IEnumerable<KeyValuePair<string, object>>> GetValuesAsync()
        {
            return Task.FromResult(GetValues(_applicationDataContainer));
        }

        private IEnumerable<KeyValuePair<string, object>> GetValues(ApplicationDataContainer container, string parentKey = null)
        {
            return container.Containers
                .SelectMany(x => GetValues(x.Value, parentKey + x.Key + "."))
                .Concat(container.Values
                    .Select(x => new KeyValuePair<string, object>(parentKey + x.Key, x.Value)));
        }

        private ApplicationDataContainer GetContainer(string fullPath, out string key, bool create = false)
        {
            var containerNames = fullPath.Split(new[] { '.', '\\', '/' });

            key = containerNames[containerNames.Length - 1];

            var container = _applicationDataContainer;

            for (var containerIndex = 0; containerIndex < containerNames.Length - 1; containerIndex++)
            {
                var containerName = containerNames[containerIndex];

                if (container.Containers.ContainsKey(containerName))
                {
                    container = container.Containers[containerName];
                }
                else if (create)
                {
                    container = container.CreateContainer(containerName, ApplicationDataCreateDisposition.Always);
                }
                else
                {
                    return null;
                }
            }

            return container;
        }
    }
}