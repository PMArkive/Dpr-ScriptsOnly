using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Tools/Create PetrifyData", fileName = "PetrifyData")]
[Serializable]
public class PetrifyData : ScriptableObject
{
	public MaterialData[] materialDatas;

	[Serializable]
	public class MaterialData
	{
		[SerializeField]
		public string name;
		[SerializeField]
		public bool forceSoftEdge;
		[SerializeField]
		public float noiseFactor;
		[SerializeField]
		public float distribution;
		[Range(0.0f, 10.0f)]
		[SerializeField]
		public float triPlanarScale;
		[Range(0.0f, 64.0f)]
		[SerializeField]
		public float edgeDectectionScale;
		[SerializeField]
		public Vector2 textureOffset;
		[SerializeField]
		public Texture2D colorMap;
		[SerializeField]
		public Texture2D specularMap;
		[SerializeField]
		public Texture2D bumpMap;
		[SerializeField]
		public Texture2D ambientMap;
		[Range(0.0f, 1.0f)]
		[SerializeField]
		public float colorWeight;
		[Range(0.1f, 16.0f)]
		[SerializeField]
		public float bumpScale;
		[Range(0.1f, 256.0f)]
		[SerializeField]
		public float cosinePower;
		[Range(0.1f, 16.0f)]
		[SerializeField]
		public float specularScale;
		[SerializeField]
		public Color reflectivity;
		[Range(0.0f, 1.0f)]
		[SerializeField]
		public float glossy;
	}
}