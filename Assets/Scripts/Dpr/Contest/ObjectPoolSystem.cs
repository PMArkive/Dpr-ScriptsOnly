using System.Collections.Generic;
using UnityEngine;

namespace Dpr.Contest
{
	public class ObjectPoolSystem<T> where T : class
	{
		private T prefab;
		private Transform parent;
		private List<T> prefabPool = new List<T>();
		
		~ObjectPoolSystem()
		{
			prefabPool.Clear();
			parent = null;
			prefab = null;
		}
		
		public int PoolCount { get => prefabPool.Count; }
		public List<T> PrefabPoolList { get => prefabPool; }
		
		// TODO
		public void GeneratePoolFromPrefab(T prefab, int count) { }
		
		// TODO
		public void GeneratePoolFromPrefab(T prefab, int count, Transform parent) { }
		
		// TODO
		public int SetPoolCount(int count) { return default; }
		
		// TODO
		public T AddPoolFromPrefab(T prefab) { return default; }
		
		// TODO
		public T Get() { return default; }
		
		// TODO
		public T GetCurrentlyUsed() { return default; }
		
		// TODO
		public List<T> GetAllCurrentlyUsed() { return default; }
		
		// TODO
		public List<T> GetAllDeactived() { return default; }
		
		// TODO
		public void RemoveFromPool(T prefab) { }
		
		// TODO
		public void RemoveAllNullElement() { }
		
		// TODO
		public void DeactivateAll() { }
		
		// TODO
		public void ClearPool() { }
	}
}