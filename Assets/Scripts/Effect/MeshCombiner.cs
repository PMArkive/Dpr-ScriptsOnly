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
		
		public static MeshCombiner Create()
		{
            return new MeshCombiner()
			{
				_mainMesh = CreateMesh(),
			};
		}
		
		public void Destroy()
		{
			DestroyMesh(_mainMesh);
			_mainMesh = null;

            if (_workMeshes != null)
			{
                foreach (var mesh in _workMeshes)
                    DestroyMesh(mesh);
            }
        }
		
		public void Clear()
		{
			_mainMesh.Clear();

            if (_workMeshes != null)
			{
                foreach (var mesh in _workMeshes)
                    mesh.Clear();
            }

			_combineInstances = null;
		}
		
		public Mesh FetchMesh()
		{
			if (_workMeshes == null)
				_workMeshes = new List<Mesh>();

			if (_workMeshIndex >= _workMeshes.Count)
				_workMeshes.Add(CreateMesh());

            _workMeshIndex++;

			return _workMeshes[_workMeshIndex - 1];
        }
		
		public void CombineMeshes(Matrix4x4 m)
		{
			if (_combineInstances == null || _combineInstances.Length != _workMeshIndex)
			{
				_combineInstances = new CombineInstance[_workMeshIndex];

				for (int i=0; i!=_workMeshIndex; i++)
					_combineInstances[i].mesh = _workMeshes[i];
            }

			for (int i=0; i!=_workMeshIndex; i++)
				_combineInstances[i].transform = m;

			_mainMesh.CombineMeshes(_combineInstances, false, true);

			_workMeshIndex = 0;
		}
		
		private static Mesh CreateMesh()
		{
			var mesh = new Mesh();
			mesh.MarkDynamic();
			return mesh;
		}
		
		private static void DestroyMesh(Mesh mesh)
		{
			if (Application.isPlaying)
				Object.Destroy(mesh);
            else
                Object.DestroyImmediate(mesh);
        }
	}
}