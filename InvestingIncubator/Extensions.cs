﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestingIncubator
{
    public static class Extensions
    {
        /// <summary>
        /// Finds the index of 'find' in the string
        /// Will return -1 if find is not in the string
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
    }
}
