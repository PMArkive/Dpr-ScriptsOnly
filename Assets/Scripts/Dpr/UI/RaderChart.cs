using Pml.PokePara;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class RaderChart : MaskableGraphic
	{
		[SerializeField]
		private float _length = 108.0f;

		private Material[] _maskMaterials;
		private Canvas _parentCanvas;
		private Mesh _mesh;
		private Param _param;
		
		// TODO
		protected override void Awake() { }
		
		// TODO
		protected override void OnEnable() { }
		
		// TODO
		protected override void OnDisable() { }
		
		// TODO
		protected override void OnDestroy() { }
		
		// TODO
		public void Setup(Param param) { }
		
		// TODO
		private void CreateMesh() { }
		
		// TODO
		private void OnWillRenderCanvases() { }
		
		// TODO
		private Canvas GetParentCanvas() { return default; }
		
		// TODO
		protected override void UpdateMaterial() { }
		
		// TODO
		private Material GetModifiedMaterial(Material baseMaterial, int index) { return default; }

		public class Param
		{
			public float[] values = new float[(int)PowerID.NUM];
			public bool isSetColor;
			public Color color;
			public float minLength = 0.15f;
		}
	}
}