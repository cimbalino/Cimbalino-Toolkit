// ****************************************************************************
// <copyright file="LegacySettingsServiceHandler.cs" company="Pedro Lamas">
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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Windows.Storage;

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="ISettingsServiceHandler"/>.
    /// </summary>
    public class LegacySettingsServiceHandler : ISettingsServiceHandler
    {
        /// <summary>
        /// Gets the value associated with the specified key.
        /// </summary>
        /// <param name="key">The key whose value to get.</param>
        /// <returns>The value associated with the specified key, if the key is found; otherwise, the default value for the type of the value parameter.</returns>
        /// <typeparam name="T">The type of value to get.</typeparam>
        public T Get<T>(string key)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sets the value for the specified key. If the entry does not exist, a new one will be added.
        /// </summary>
        /// <param name="key">The key whose value to set.</param>
        /// <param name="value">The value for the specified key.</param>
        /// <typeparam name="T">The type of value to set.</typeparam>
        public void Set<T>(string key, T value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes the specified key and associated value.
        /// </summary>
        /// <param name="key">The key whose value to clear.</param>
        public void Clear(string key)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets an object that represents all the settings in this <see cref="ISettingsServiceHandler"/> instance.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public async Task<IEnumerable<KeyValuePair<string, object>>> GetValuesAsync()
        {
            try
            {
                using (var fileStream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync("__ApplicationSettings"))
                {
                    using (var streamReader = new StreamReader(fileStream))
                    {
                        var line = streamReader.ReadLine() ?? string.Empty;

                        var knownTypes = line.Split('\0')
                            .Where(x => !string.IsNullOrEmpty(x))
                            .Select(Type.GetType)
                            .ToArray();

                        fileStream.Position = line.Length + Environment.NewLine.Length;

                        var serializer = new DataContractSerializer(typeof(Dictionary<string, object>), knownTypes);

                        return (Dictionary<string, object>)serializer.ReadObject(fileStream);
                    }
                }
            }
            catch
            {
                return new Dictionary<string, object>();
            }
        }
    }
}