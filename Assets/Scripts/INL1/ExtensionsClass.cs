using System;
using System.Collections.Generic;

namespace INL1
{
	internal static class ExtensionsClass
	{
		private static Random rng = new Random();
		
		public static void Shuffle<T>(this IList<T> list)
		{
			for (int i=list.Count; i>=2; i--)
			{
                var next = rng.Next(i);
                var nextItem = list[next];
				var oldItem = list[i-1];
				list[next] = oldItem;
				list[i-1] = nextItem;
            }
		}
	}
}