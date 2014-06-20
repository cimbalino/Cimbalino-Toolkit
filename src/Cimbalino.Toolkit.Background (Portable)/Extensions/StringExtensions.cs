// ****************************************************************************
// <copyright file="StringExtensions.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2014
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <project>Cimbalino.Toolkit.Background</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Cimbalino.Toolkit.Extensions
{
    /// <summary>
    /// Provides a set of static (Shared in Visual Basic) methods for <see cref="string"/> instances.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Encodes all the characters in the string into a sequence of UTF8 bytes.
        /// </summary>
        /// <param name="input">The current string.</param>
        /// <returns>A byte array containing the results of encoding the set of characters.</returns>
        public static byte[] GetBytes(this string input)
        {
            return input.GetBytes(Encoding.UTF8);
        }

        /// <summary>
        /// Encodes all the characters in the string into a sequence of bytes, using the specified <see cref="Encoding"/>.
        /// </summary>
        /// <param name="input">The current string.</param>
        /// <param name="encoding">The <see cref="Encoding"/> to use for encoding the characters.</param>
        /// <returns>A byte array containing the results of encoding the set of characters.</returns>
        public static byte[] GetBytes(this string input, Encoding encoding)
        {
            return encoding.GetBytes(input);
        }

        /// <summary>
        /// Converts the string, which encodes binary data as base-64 digits, to an equivalent 8-bit unsigned integer array.
        /// </summary>
        /// <param name="input">The current string.</param>
        /// <returns>An array of 8-bit unsigned integers that is equivalent to the string.</returns>
        public static byte[] FromBase64String(this string input)
        {
            return Convert.FromBase64String(input);
        }

        /// <summary>
        /// Replaces one or more format items in the string with the string representation of a specified object.
        /// </summary>
        /// <param name="format">The composite format string.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <returns>A copy of the string in which the format items have been replaced by the string representation of the corresponding objects in args.</returns>
        public static string FormatWith(this string format, params object[] args)
        {
            return string.Format(format, args);
        }

        /// <summary>
        /// Replaces one or more format items in the string with the string representation of a specified object.
        /// </summary>
        /// <param name="format">The composite format string.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <returns>A copy of the string in which the format items have been replaced by the string representation of the corresponding objects in args.</returns>
        public static string FormatWith(this string format, IFormatProvider provider, params object[] args)
        {
            return string.Format(provider, format, args);
        }

        /// <summary>
        /// Replaces one or more format items in the string with the string representation of a specified object, using an <see cref="CultureInfo.InvariantCulture"/>.
        /// </summary>
        /// <param name="format">The composite format string.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <returns>A copy of the string in which the format items have been replaced by the string representation of the corresponding objects in args.</returns>
        public static string FormatWithInvariantCulture(this string format, params object[] args)
        {
            return format.FormatWith(CultureInfo.InvariantCulture, args);
        }

        /// <summary>
        /// Returns a new string containing the specified number of characters from the left side of the current string.
        /// </summary>
        /// <param name="input">The current string.</param>
        /// <param name="length">The number of characters to return. If 0, a zero-length string ("") is returned. If greater than or equal to the number of characters in the string, the entire string is returned.</param>
        /// <returns>Returns a string containing a specified number of characters from the left side of the string.</returns>
        public static string Left(this string input, int length)
        {
            if (input.Length <= length)
            {
                return input;
            }

            return input.Substring(0, length);
        }

        /// <summary>
        /// Returns a new string containing the specified number of characters from the right side of the current string.
        /// </summary>
        /// <param name="input">The current string.</param>
        /// <param name="length">The number of characters to return. If 0, a zero-length string ("") is returned. If greater than or equal to the number of characters in the string, the entire string is returned.</param>
        /// <returns>Returns a string containing a specified number of characters from the right side of the string.</returns>
        public static string Right(this string input, int length)
        {
            if (input.Length <= length)
            {
                return input;
            }

            return input.Substring(input.Length - length, length);
        }

        /// <summary>
        /// Returns a new string in which a specified number of characters from the left side of the current string are deleted.
        /// </summary>
        /// <param name="input">The current string.</param>
        /// <param name="length">The number of characters to remove. If greater than or equal to the number of characters in the string, an empty string is returned.</param>
        /// <returns>Returns a string in which a specified number of characters from the left side of the current string where deleted.</returns>
        public static string RemoveLeft(this string input, int length)
        {
            if (input.Length <= length)
            {
                return string.Empty;
            }

            return input.Substring(length);
        }

        /// <summary>
        /// Returns a new string in which a specified number of characters from the right side of the current string are deleted.
        /// </summary>
        /// <param name="input">The current string.</param>
        /// <param name="length">The number of characters to remove. If greater than or equal to the number of characters in the string, an empty string is returned.</param>
        /// <returns>Returns a string in which a specified number of characters from the right side of the current string where deleted.</returns>
        public static string RemoveRight(this string input, int length)
        {
            if (input.Length <= length)
            {
                return string.Empty;
            }

            return input.Substring(0, input.Length - length);
        }

        /// <summary>
        /// Returns a new string by repeating the current string the specified number of times.
        /// </summary>
        /// <param name="input">The current string.</param>
        /// <param name="count">The number of times the current string occurs.</param>
        /// <returns>A new string by repeating the current string the specified number of times.</returns>
        public static string Times(this string input, int count)
        {
            var stringBuilder = new StringBuilder();

            while (count-- > 0)
            {
                stringBuilder.Append(input);
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Indicates whether the regular expression finds a match in the input string using the regular expression specified in the pattern parameter.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <returns>true if the regular expression finds a match; otherwise, false.</returns>
        public static bool RegexIsMatch(this string input, string pattern)
        {
            return Regex.IsMatch(input, pattern);
        }

        /// <summary>
        /// Indicates whether the regular expression finds a match in the input string, using the regular expression specified in the pattern parameter and the matching options supplied in the options parameter.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="options">A bitwise combination of the enumeration values.</param>
        /// <returns>true if the regular expression finds a match; otherwise, false.</returns>
        public static bool RegexIsMatch(this string input, string pattern, RegexOptions options)
        {
            return Regex.IsMatch(input, pattern, options);
        }

        /// <summary>
        /// Searches the specified input string for the first occurrence of the regular expression supplied in the pattern parameter.
        /// </summary>
        /// <param name="input">The string to be tested for a match.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <returns>An object that contains information about the match.</returns>
        public static Match RegexMatch(this string input, string pattern)
        {
            return Regex.Match(input, pattern);
        }

        /// <summary>
        /// Searches the input string for the first occurrence of the regular expression supplied in a pattern parameter with matching options supplied in an options parameter.
        /// </summary>
        /// <param name="input">The string to be tested for a match.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="options">A bitwise combination of the enumeration values.</param>
        /// <returns>An object that contains information about the match.</returns>
        public static Match RegexMatch(this string input, string pattern, RegexOptions options)
        {
            return Regex.Match(input, pattern, options);
        }

        /// <summary>
        /// Searches the specified input string for all occurrences of the regular expression specified in the pattern parameter.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <returns>A collection of the <see cref="Match"/> objects found by the search. If no matches are found, the method returns an empty collection object.</returns>
        public static MatchCollection RegexMatches(this string input, string pattern)
        {
            return Regex.Matches(input, pattern);
        }

        /// <summary>
        /// Searches the specified input string for all occurrences of the regular expression supplied in a pattern parameter with matching options supplied in an options parameter.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="options">A bitwise combination of the enumeration values.</param>
        /// <returns>A collection of the <see cref="Match"/> objects found by the search. If no matches are found, the method returns an empty collection object.</returns>
        public static MatchCollection RegexMatches(this string input, string pattern, RegexOptions options)
        {
            return Regex.Matches(input, pattern, options);
        }

        /// <summary>
        /// Within a specified input string, replaces all strings that match a specified regular expression with a specified replacement string.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="replacement">The replacement string.</param>
        /// <returns>A new string that is identical to the input string, except that a replacement string takes the place of each matched string.</returns>
        public static string RegexReplace(this string input, string pattern, string replacement)
        {
            return Regex.Replace(input, pattern, replacement);
        }

        /// <summary>
        /// Within a specified input string, replaces all strings that match a specified regular expression with a specified replacement string. Specified options modify the matching operation.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="replacement">The replacement string.</param>
        /// <param name="options">A bitwise combination of the enumeration values.</param>
        /// <returns>A new string that is identical to the input string, except that a replacement string takes the place of each matched string.</returns>
        public static string RegexReplace(this string input, string pattern, string replacement, RegexOptions options)
        {
            return Regex.Replace(input, pattern, replacement, options);
        }

        /// <summary>
        /// Within a specified input string, replaces all strings that match a specified regular expression with a string returned by a <see cref="MatchEvaluator"/> delegate.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="evaluator">A custom method that examines each match and returns either the original matched string or a replacement string.</param>
        /// <returns>A new string that is identical to the input string, except that a replacement string takes the place of each matched string.</returns>
        public static string RegexReplace(this string input, string pattern, MatchEvaluator evaluator)
        {
            return Regex.Replace(input, pattern, evaluator);
        }

        /// <summary>
        /// Within a specified input string, replaces all strings that match a specified regular expression with a string returned by a <see cref="MatchEvaluator"/> delegate. Specified options modify the matching operation.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="evaluator">A custom method that examines each match and returns either the original matched string or a replacement string.</param>
        /// <param name="options">A bitwise combination of the enumeration values.</param>
        /// <returns>A new string that is identical to the input string, except that a replacement string takes the place of each matched string.</returns>
        public static string RegexReplace(this string input, string pattern, MatchEvaluator evaluator, RegexOptions options)
        {
            return Regex.Replace(input, pattern, evaluator, options);
        }
    }
}