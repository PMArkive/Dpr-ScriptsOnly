using System;
using System.Collections.Generic;
using UnityEngine;

public class MeshNormalSmoother
{
	private static List<Mesh> _meshes = new List<Mesh>();
	private static Dictionary<VectorKey, SharedVertex> _vertexLookup = new Dictionary<VectorKey, SharedVertex>();
	
	// TODO
	public static void Clear() { }
	
	// TODO
	public static void Add(Mesh mesh) { }
	
	// TODO
	public static void Bake() { }

	public class SharedVertex
	{
		public Dictionary<Mesh, List<int>> indexLookup;
		public Vector3 compositeNormal;
		
		public SharedVertex(Mesh mesh, int index, Vector3 normal)
		{
			indexLookup = new Dictionary<Mesh, List<int>>()
			{
				{ mesh, new List<int>() { index } }
			};

			compositeNormal = normal;
		}
		
		// TODO
		public List<int> GetIndicesByMesh(Mesh mesh) { return default; }
		
		// TODO
		public void Add(Mesh mesh, int index, Vector3 normal) { }
	}

	public struct VectorKey
	{
		private readonly long x;
		private readonly long y;
		private readonly long z;
		private const int _tolerance = 100000;
		
		public VectorKey(in Vector3 V)
		{
            x = (long)Math.Round(V.x * _tolerance);
            y = (long)Math.Round(V.y * _tolerance);
            z = (long)Math.Round(V.z * _tolerance);
        }
		
		public override bool Equals(object rhs)
		{
			var obj = (VectorKey)rhs;

			if (x == obj.x && y == obj.y && z == obj.z)
				return true;

			return false;
		}
		
		// TODO
		public override int GetHashCode() { return default; }
	}
}