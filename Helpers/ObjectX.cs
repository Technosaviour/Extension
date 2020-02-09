using System;
using System.Collections.Generic;
using System.Text;

namespace Extensions.Helpers
{
    public static class ObjectX
    {
        /// <summary>
        /// Check if an object is null or not
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsNull(this object obj)
        {
            return obj == null;
        }

        /// <summary>
        /// Checks if an object is not null
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsNotNull(this object obj)
        {
            return !IsNull(obj);
        }

        /// <summary>
        /// Checks if the list is not null or empty 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsListNullOrEmpty<T>(this List<T> obj)
        {
            return obj.IsNull() || (obj.IsNotNull() && obj.Count == 0);
        }

        /// <summary>
        /// Checks if the list is null or empty
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsListNotNullOrEmpty<T>(this List<T> obj)
        {
            return !IsListNullOrEmpty<T>(obj);
        }

    }
}
