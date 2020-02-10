using System;
using System.Collections.Generic;
using System.Text;

namespace Extensions.Helpers
{
    public static class StringX
    {
        /// <summary>
        /// Extension method to check the string by ignoring case
        /// </summary>
        /// <param name="value"></param>
        /// <param name="compareWith"></param>
        /// <returns></returns>
        public static bool EqualsIgnoreCase(this string value, string compareWith)
        {
            return string.Equals(value, compareWith, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Extension method to convert int to a string
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Returns 0 if not a valid int</returns>
        public static int ToInt(this string value)
        {
            return int.TryParse(value, out int result) ? result : 0;
        }

        /// <summary>
        /// Extension method to convert string to long
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Returns 0 if not a valid long</returns>
        public static long ToLong(this string value)
        {
            return long.TryParse(value, out long result) ? result : 0;
        }

        /// <summary>
        /// Extension method to convert string to double
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Returns 0 if not a valid doubts</returns>
        public static double ToDouble(this string value)
        {
            return double.TryParse(value, out double result) ? result : 0;
        }

        /// <summary>
        /// Returns alternate value if current value is empty
        /// </summary>
        /// <param name="value"></param>
        /// <param name="alternativeValue"></param>
        /// <returns></returns>
        public static string NullOrEmptyCoalesce(this string value, string alternativeValue)
        {
            return string.IsNullOrEmpty(value) ? alternativeValue : value;
        }

        /// <summary>
        /// Checks if string is Null or Empty
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        /// <summary>
        /// Checks if string is null or whitespace
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

    }
}
