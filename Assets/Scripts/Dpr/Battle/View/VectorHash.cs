using System;
using System.Collections.Generic;

namespace Dpr.Battle.View
{
	public class VectorHash<TKey, TElement> : IDisposable
	{
		private Dictionary<TKey, HashSet<TElement>> _elements;
		
		public Dictionary<TKey, HashSet<TElement>> RawElements { get => _elements; }
		
		public VectorHash(int capacity = 0)
		{
			_elements = new Dictionary<TKey, HashSet<TElement>>();
		}
		
		// TODO
		public void Dispose() { }
		
		// TODO
		public void CreateVector(TKey key, HashSet<TElement> elements) { }
		
		// TODO
		public bool DeleteVector(TKey key) { return default; }
		
		// TODO
		public void DeleteAllVector() { }
		
		// TODO
		public void AddVector(TKey key, HashSet<TElement> elements) { }
		
		// TODO
		public bool HasVector(TKey key) { return default; }
		
		// TODO
		public HashSet<TElement> GetVector(TKey key) { return default; }
		
		// TODO
		public bool TryGetVector(TKey key, out HashSet<TElement> value)
		{
			value = default;
			return default;
		}
	}
}