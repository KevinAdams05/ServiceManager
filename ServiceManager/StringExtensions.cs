using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceManager
{
    /// <summary>
    /// Various String extensions to make life easier.
    /// Some are mine and some are from 3rd parties, credit cited.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Escapes special characters that would blow up a CSV file
        /// </summary>
        public static string Clean(this string s)
        {
            if (s.Contains("\""))
            {
                s = s.Replace("\"", "\"\"");
            }

            if (s.Contains(","))
            {
                s = string.Format("\"{0}\"", s);
            }

            return s;
        }

        /// <summary>
        /// Appends a backslash to a string, if the last character is not already a backslash. 
        /// Used when validating a user inputed string that is supposed to be a file path.
        /// </summary>
        public static string AppendBackslash(this string s)
        {
            if (s.Substring(s.Length - 1, 1) != @"\")
            {
                s = s + @"\";
            }

            return s;
        }

        /// <summary>
        /// Append and add a HTML newline between the original text and the appended text
        /// Useful when building error messages or other things that get sent via email
        /// </summary>
        public static string AppendWithNewLineHtml(this string originalText, string textToAppend)
        {
            string newLine = "<br>";

            if (string.IsNullOrEmpty(originalText))
            {
                newLine = string.Empty;
            }

            return string.Concat(originalText, newLine, textToAppend);
        }

        /// <summary>
        /// Append and add a newline between the original text and the appended text
        /// </summary>
        public static string AppendWithNewLine(this string originalText, string textToAppend)
        {
            string newLine = Environment.NewLine;

            if (string.IsNullOrEmpty(originalText))
            {
                newLine = string.Empty;
            }

            return string.Concat(originalText, newLine, textToAppend);
        }

        public static bool CaseInsensitiveContains(this string text, string value, StringComparison stringComparison = StringComparison.CurrentCultureIgnoreCase)
        {
            return text.IndexOf(value, stringComparison) >= 0;
        }

        /// <summary>
        /// A brain dead pluralizer. 1.Pluralize("time") => "1 time"
        /// </summary>
        /// Credit: Stack Exchange Inc.
        /// <param name="count">The amount to pluralize</param>
        /// <param name="name">The singular form to pluralize (based on the <paramref name="count"/>)</param>
        /// <param name="includeNumber">Whether to include the number before the text</param>
        public static string Pluralize(this int count, string name, bool includeNumber = true) => Pluralize((long)count, name, includeNumber);

        /// <summary>
        /// A brain dead pluralizer. 1.Pluralize("time") => "1 time"
        /// </summary>
        /// Credit: Stack Exchange Inc.
        /// <param name="count">The amount to pluralize</param>
        /// <param name="name">The singular form to pluralize (based on the <paramref name="count"/>)</param>
        /// <param name="includeNumber">Whether to include the number before the text</param>
        public static string Pluralize(this long count, string name, bool includeNumber = true)
        {
            var numString = includeNumber ? count.ToComma() + " " : null;
            if (count == 1) return numString + name;
            if (name.EndsWith("y")) return numString + name.Remove(name.Length - 1) + "ies";
            if (name.EndsWith("s")) return numString + name.Remove(name.Length - 1) + "es";
            if (name.EndsWith("ex")) return numString + name + "es";
            return numString + name + "s";
        }

        /// <summary>
        /// A plurailizer that accepts the count, single and plural variants of the text
        /// </summary>
        /// Credit: Stack Exchange Inc.
        /// <param name="count">The amount to pluralize</param>
        /// <param name="single">The singular form to pluralize (based on the <paramref name="count"/>)</param>
        /// <param name="plural">The plural form to pluralize (based on the <paramref name="count"/>)</param>
        /// <param name="includeNumber">Whether to include the number before the text</param>
        public static string Pluralize(this int count, string single, string plural, bool includeNumber = true) =>
            includeNumber
                ? count.ToComma() + " " + (count == 1 ? single : plural)
                : count == 1 ? single : plural;

        /// <summary>
        /// A plurailizer that accepts the count, single and plural variants of the text
        /// </summary>
        /// Credit: Stack Exchange Inc.
        /// <param name="count">The amount to pluralize</param>
        /// <param name="single">The singular form to pluralize (based on the <paramref name="count"/>)</param>
        /// <param name="plural">The plural form to pluralize (based on the <paramref name="count"/>)</param>
        /// <param name="includeNumber">Whether to include the number before the text</param>
        public static string Pluralize(this long count, string single, string plural, bool includeNumber = true) =>
            includeNumber
                ? count.ToComma() + " " + (count == 1 ? single : plural)
                : count == 1 ? single : plural;

        /// <summary>
        /// Converts an int to a comma formatted string, example 1234 to "1,234"
        /// </summary>
        /// Credit: Stack Exchange Inc.
        public static string ToComma(this int? number, string valueIfZero = null) => number.HasValue ? ToComma(number.Value, valueIfZero) : string.Empty;

        /// <summary>
        /// Converts an int to a comma formatted string, example 1234 to "1,234"
        /// </summary>
        /// Credit: Stack Exchange Inc.
        public static string ToComma(this int number, string valueIfZero = null) => number == 0 && valueIfZero != null ? valueIfZero : number.ToString("n0");

        /// <summary>
        /// Converts a long to a comma formatted string, example 1234 to "1,234"
        /// </summary>
        /// Credit: Stack Exchange Inc.
        public static string ToComma(this long? number, string valueIfZero = null) => number.HasValue ? ToComma(number.Value, valueIfZero) : string.Empty;

        /// <summary>
        /// Converts a long to a comma formatted string, example 1234 to "1,234"
        /// </summary>
        /// Credit: Stack Exchange Inc.
        public static string ToComma(this long number, string valueIfZero = null) => number == 0 && valueIfZero != null ? valueIfZero : number.ToString("n0");

        /// <summary>
        /// Answers true if this String is either null or empty.
        /// </summary>
        /// Credit: Stack Exchange Inc.
        /// <param name="s">The string to check</param>
        /// <remarks>I'm so tired of typing String.IsNullOrEmpty(s)</remarks>
        public static bool IsNullOrEmpty(this string s) => string.IsNullOrEmpty(s);

        /// <summary>
        /// Truncates a string to <paramref name="maxLength"/>.
        /// </summary>
        /// Credit: Stack Exchange Inc.
        /// <param name="s">The string to truncate</param>
        /// <param name="maxLength">The length to truncate to</param>
        public static string Truncate(this string s, int maxLength) =>
            s.IsNullOrEmpty() ? s : (s.Length > maxLength ? s.Remove(maxLength) : s);

        /// <summary>
        /// Truncates a string to <paramref name="maxLength"/>, addinge an ellipsis on the end in truncated.
        /// </summary>
        /// Credit: Stack Exchange Inc.
        /// <param name="s">The string to truncate</param>
        /// <param name="maxLength">The length to truncate to</param>
        /// <returns></returns>
        public static string TruncateWithEllipsis(this string s, int maxLength) =>
            s.IsNullOrEmpty() || s.Length <= maxLength ? s : Truncate(s, Math.Max(maxLength, 3) - 3) + "…";
    }
}
