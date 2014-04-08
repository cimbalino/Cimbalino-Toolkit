// ****************************************************************************
// <copyright file="XmlReaderExtensions.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2014
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <project>Cimbalino.Toolkit.Portable</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.Collections.Generic;
using System.Xml;

namespace Cimbalino.Toolkit.Extensions
{
    /// <summary>
    /// Provides a set of static (Shared in Visual Basic) methods for <see cref="XmlReader"/> instances.
    /// </summary>
    public static class XmlReaderExtensions
    {
        /// <summary>
        /// Reads the current element as a urn and returns the contents as a string.
        /// </summary>
        /// <param name="reader">The current reader.</param>
        /// <returns>The element content as a string.</returns>
        public static string ReadElementContentAsUrn(this XmlReader reader)
        {
            var id = reader.ReadElementContentAsString();

            return id != null && id.StartsWith("urn:uuid:") ? id.Substring(9) : id;
        }

        /// <summary>
        /// Reads the current element as the requested nullable type.
        /// </summary>
        /// <param name="reader">The current reader.</param>
        /// <typeparam name="T">The return type.</typeparam>
        /// <returns>The element content converted to the requested nullable typed object.</returns>
        public static T? ReadElementContentAsNullable<T>(this XmlReader reader) where T : struct
        {
            if (reader.HasValue)
            {
                return (T)reader.ReadElementContentAs(typeof(T), null);
            }

            reader.Skip();

            return null;
        }

        /// <summary>
        /// Reads the current element as an array and returns the contents using the specified function.
        /// </summary>
        /// <param name="reader">The current reader.</param>
        /// <param name="deserialize">The deserialization function.</param>
        /// <typeparam name="T">The array return type.</typeparam>
        /// <returns>An array containing the deserialized items.</returns>
        public static T[] ReadElementContentAsArray<T>(this XmlReader reader, Func<XmlReader, T> deserialize)
        {
            var items = new List<T>();

            reader.ReadStartElement();

            while (reader.NodeType != XmlNodeType.EndElement)
            {
                items.Add(deserialize(reader));
            }

            reader.ReadEndElement();

            return items.ToArray();
        }

        /// <summary>
        /// Gets the value of the attribute with the specified name, as a boolean value.
        /// </summary>
        /// <param name="reader">The current reader.</param>
        /// <param name="name">The name of the attribute.</param>
        /// <returns>The value of the attribute with the specified name, as a boolean value.</returns>
        public static bool GetAttributeAsBool(this XmlReader reader, string name)
        {
            bool value;

            return bool.TryParse(reader.GetAttribute(name), out value) && value;
        }

        /// <summary>
        /// Gets the value of the attribute with the specified name, as an <see cref="int"/> value.
        /// </summary>
        /// <param name="reader">The current reader.</param>
        /// <param name="name">The name of the attribute.</param>
        /// <returns>The value of the attribute with the specified name, as an <see cref="int"/> value.</returns>
        public static int GetAttributeAsInt(this XmlReader reader, string name)
        {
            int value;

            return int.TryParse(reader.GetAttribute(name), out value) ? value : 0;
        }

        /// <summary>
        /// Executes the specified function, skips the current node, and returns the value.
        /// </summary>
        /// <param name="reader">The current reader.</param>
        /// <param name="readerFunction">The function to execute.</param>
        /// <typeparam name="T">The return type.</typeparam>
        /// <returns>The result value from the executed function, just after skipping to the next node.</returns>
        public static T GetAndSkip<T>(this XmlReader reader, Func<XmlReader, T> readerFunction)
        {
            var value = readerFunction(reader);

            reader.Skip();

            return value;
        }
    }
}