using System.Collections.Generic;
using System;

namespace Extensions
{
    public static class ListExtensions
    {
        public static T GetRandomElement<T>(this List<T> list)
        {
            return list[new Random().Next(list.Count)];
        }
    }
}