using Dpr.SubContents;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dpr.Field.Walking
{
    public static class ListExtension
    {
        public static T GetRandomofMaxpriority<T>(this List<T> list) where T : ActionModel
        {
            if (list.Count != 0)
            {
                var MaxPriority = list.Max(x => x.priority);
                return RandomWithWeight.Lotto(list.FindAll(x => x.priority == MaxPriority)) as T;
            }

            return null;
        }

        public static T GetRandom<T>(this List<T> list)
        {
            if (list.Count != 0)
                return list[UnityEngine.Random.Range(0, list.Count)];

            return default;
        }

        public static void FindDoAll<T>(this List<T> list, FindDelegate<T> find, Action<T> act)
        {
            for (int i=0; i<list.Count; i++)
            {
                if (find.Invoke(list[i]))
                    act(list[i]);
            }
        }

        public static TSource FindMin<TSource, TResult>(this IEnumerable<TSource> self, Func<TSource, TResult> selector)
        {
            return self.First(c => selector.Invoke(c).Equals(self.Min(selector)));
        }

        public static TSource FindMax<TSource, TResult>(this IEnumerable<TSource> self, Func<TSource, TResult> selector)
        {
            return self.First(c => selector.Invoke(c).Equals(self.Max(selector)));
        }

        public delegate bool FindDelegate<T>(T model);
    }
}