using System.Collections.Generic;
using UnityEngine;

namespace Effect
{
	internal class MeshCombiner
	{
		private Mesh _mainMesh;
		private List<Mesh> _workMeshes;
		private int _workMeshIndex;
		private CombineInstance[] _combineInstances;
		
		public Mesh mainMesh { get => _mainMesh; }
		
		// TODO
		public static MeshCombiner Create() { return default; }
		
		// TODO
		public void Destroy() { }
		
		// TODO
		public void Clear() { }
		
		// TODO
		public Mesh FetchMesh() { return default; }
		
		// TODO
		public void CombineMeshes(Matrix4x4 m) { }
		
		// TODO
		private static Mesh CreateMesh() { return default; }
		
		// TODO
		private static void DestroyMesh(Mesh mesh) { }
	}
}