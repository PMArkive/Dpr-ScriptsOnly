using UnityEngine;
using UnityEngine.UI;

namespace Effect
{
	[RequireComponent(typeof(ParticleSystem))]
	public class ParticleToCanvas : MaskableGraphic
	{
		private static readonly Matrix4x4 s_scaleZ;

		[HideInInspector]
		[SerializeField]
		private Material _material;
		[HideInInspector]
		[SerializeField]
		private Material _trailMaterial;

		private ParticleSystem _particleSystem;
		private ParticleSystemRenderer _particleSystemRenderer;
		private ParticleSystem.MainModule _mainModule;
		private ParticleSystem.TrailModule _trailsModule;
		private MeshCombiner _meshCombiner;
		private Material[] _maskMaterials;
		private Canvas _parentCanvas;
		
		// TODO
		protected override void Awake() { }
		
		// TODO
		protected override void OnEnable() { }
		
		// TODO
		protected override void OnDisable() { }
		
		// TODO
		private void OnWillRenderCanvases() { }
		
		// TODO
		private Canvas GetParentCanvas() { return default; }
		
		// TODO
		protected override void UpdateMaterial() { }
		
		// TODO
		private Material GetModifiedMaterial(Material baseMaterial, int index) { return default; }
	}
}