using System.Collections.Generic;
using System;

namespace Extentions
{
    public static class ListExtentions
    {
        public static T GetRandomElement<T>(this List<T> list)
        {
            return list[new Random().Next(list.Count)];
        }
    }
}