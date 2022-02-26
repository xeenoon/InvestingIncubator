using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestingIncubator
{
    public static class Extensions
    {
        /// <summary>
        /// Finds the index of 'find' in the string. Will return -1 if 'find' is not in the string
        /// </summary>
        /// <param name="find"></param>
        /// The string to look for
        /// <returns></returns>
        public static int PositionOf(this string str, string find)
        {
            string buffer = "";
            for (int i = 0; i < str.Length; i++)
            {
                buffer += str[i];
                if (buffer.Contains(find))
                {
                    return i-find.Length;
                }
            }
            return -1;
        }
        /// <summary>
        /// Determines if all of the elements in find are in the list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// The type of list
        /// <param name="find"></param>
        /// List of items to look for in the string
        /// <returns></returns>
        public static bool Contains<T>(this List<T> list, List<T> find)
        {
            foreach (var obj in find)
            {
                if (!list.Contains(obj))
                {
                    return false;
                }
            }
            return true;
        }

        public static List<string> ToStringList<T>(this List<T> list)
        {
            List<string> result = new List<string>();
            foreach (var obj in list)
            {
                result.Add(obj.ToString());
            }
            return result;
        }
        public static List<T> Copy<T>(this List<T> list)
        {
            List<T> result = new List<T>();
            foreach (var item in list)
            {
                result.Add(item);
            }
            return result;
        }
        public static int Area(this Rectangle rect)
        {
            return rect.Height * rect.Width;
        }
    }
}
