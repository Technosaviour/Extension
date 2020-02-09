using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Extensions.Helpers
{
    public static class IEnumerableX
    {
        /// <summary>
        /// Checks if the enumertable list is empty or not
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns>boolean</returns>
        public static bool IsEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.ToList().Count == 0;
        }

        /// <summary>
        /// checks if the enumerable is null or empty
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns>true/false</returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable == null || enumerable.IsEmpty();
        }


        /// <summary>
        /// Merge one list of enumerable with another list of same type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="moreItems"></param>
        /// <returns></returns>
        public static IEnumerable<T> Merge<T>(this IEnumerable<T> enumerable, IEnumerable<T> moreItems)
        {
            List<T> mergedItems = new List<T>();
            mergedItems.AddRange(enumerable);
            mergedItems.AddRange(moreItems);
            return mergedItems;
        }

        /// <summary>
        /// Merge multiple enemurable togeather in a single enumerable 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="additionalItems"></param>
        /// <returns></returns>
        public static IEnumerable<T> Merge<T>(this IEnumerable<T> source, params IEnumerable<T>[] additionalItems)
        {
            var mergedItems = new List<T>();
            mergedItems.AddRange(source);
            foreach (var eachItem in additionalItems)
            {
                mergedItems.AddRange(eachItem);
            }
            return mergedItems;
        }


        /// <summary>
        /// Add the element of type T to the enumerable object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="item"></param>
        /// <returns>new enumerable with the "T item" added to it</returns>
        public static IEnumerable<T> Add<T>(this IEnumerable<T> enumerable, T item)
        {
            foreach (var e in enumerable)
            {
                yield return e;
            }

            if (item != null)
                yield return item;
        }

        /// <summary>
        /// Add mutiple enemurable to the enumerable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="moreItems"></param>
        /// <returns></returns>
        public static IEnumerable<T> Add<T>(this IEnumerable<T> source, params T[] moreItems)
        {
            foreach (var item in source)
            {
                yield return item;
            }
            foreach (var item in moreItems)
            {
                yield return item;
            }
        }

        /// <summary>
        /// Get the distinct items in list based on a single property
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static IEnumerable<T> Distinct<T, V>(this IEnumerable<T> source, Func<T, V> selector) where V : IComparable<V>
        {
            List<T> distinctList = new List<T>();

            foreach (var element in source)
            {
                if (!distinctList.Exists(item => selector(item).CompareTo(selector(element)) == 0))
                {
                    distinctList.Add(element);
                }
            }

            return distinctList;
        }

        /// <summary>
        /// Fetches Distinct items in list based on one or more properies of item
        /// For Ex: ListOfItems.DistinctBy(x => new { x.FirstName, x.LastName })
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="source">ListOfItems</param>
        /// <param name="keySelector">Property names</param>
        /// <returns></returns>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }

        
    }
}
