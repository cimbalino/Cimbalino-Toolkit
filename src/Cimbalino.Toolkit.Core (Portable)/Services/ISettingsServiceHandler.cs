// ****************************************************************************
// <copyright file="ISettingsServiceHandler.cs" company="Pedro Lamas">
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
using System.Threading.Tasks;

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of handling the application settings.
    /// </summary>
    public interface ISettingsServiceHandler
    {
        /// <summary>
        /// Determines if the application settings contains the specified key.
        /// </summary>
        /// <param name="key">The key for the entry to be located.</param>
        /// <returns>true if the settings contains the specified key; otherwise, false.</returns>
        bool Contains(string key);

        /// <summary>
        /// Gets the value associated with the specified key.
        /// </summary>
        /// <param name="key">The key whose value to get.</param>
        /// <returns>The value associated with the specified key, if the key is found; otherwise, the default value for the type of the value parameter.</returns>
        /// <typeparam name="T">The type of value to get.</typeparam>
        T Get<T>(string key);

        /// <summary>
        /// Gets the value associated with the specified key.
        /// </summary>
        /// <param name="key">The key whose value to get.</param>
        /// <param name="defaultValue">The default value to return if the key does not exist.</param>
        /// <returns>The value associated with the specified key, if the key is found; otherwise, the specified default value.</returns>
        /// <typeparam name="T">The type of value to get.</typeparam>
        T Get<T>(string key, T defaultValue);

        /// <summary>
        /// Sets the value for the specified key. If the entry does not exist, a new one will be added.
        /// </summary>
        /// <param name="key">The key whose value to set.</param>
        /// <param name="value">The value for the specified key.</param>
        /// <typeparam name="T">The type of value to set.</typeparam>
        void Set<T>(string key, T value);

        /// <summary>
        /// Removes the specified key and associated value.
        /// </summary>
        /// <param name="key">The key whose value to clear.</param>
        void Remove(string key);

        /// <summary>
        /// Gets an object that represents all the settings in this <see cref="ISettingsServiceHandler"/> instance.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task<IEnumerable<KeyValuePair<string, object>>> GetValuesAsync();
    }
}