using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace Effect
{
	[RequireComponent(typeof(ParticleSystem))]
	public class ParticleToCanvas : MaskableGraphic
	{
		private static readonly Matrix4x4 s_scaleZ = Matrix4x4.Scale(new Vector3(1.0f, 1.0f, 0.00001f));

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
		
		protected override void Awake()
		{
			base.Awake();

			_particleSystem = GetComponent<ParticleSystem>();
			_particleSystemRenderer = GetComponent<ParticleSystemRenderer>();
			_material = _particleSystemRenderer.sharedMaterial;
			_trailMaterial = _particleSystemRenderer.trailMaterial;
			_mainModule = _particleSystem.main;
			_trailsModule = _particleSystem.trails;
		}
		
		protected override void OnEnable()
		{
			base.OnEnable();

			_meshCombiner = MeshCombiner.Create();
			_maskMaterials = new Material[2];
			_parentCanvas = null;

			Canvas.willRenderCanvases += OnWillRenderCanvases;
		}
		
		protected override void OnDisable()
        {
            Canvas.willRenderCanvases -= OnWillRenderCanvases;

			_meshCombiner.Destroy();
			_meshCombiner = null;

			for (int i=0; i<_maskMaterials.Length; i++)
				StencilMaterial.Remove(_maskMaterials[i]);

			_maskMaterials = null;
        }
		
		private void OnWillRenderCanvases()
		{
			if (GetParentCanvas() == null)
				return;

			_meshCombiner.Clear();

			if (_particleSystem.particleCount > 0)
			{
				_particleSystemRenderer.BakeMesh(_meshCombiner.FetchMesh());

				var trailsOn = _trailsModule.enabled;

                if (trailsOn)
                    _particleSystemRenderer.BakeTrailsMesh(_meshCombiner.FetchMesh());

				if (canvasRenderer.materialCount != (trailsOn ? 2 : 1))
					SetMaterialDirty();

				var matrix = _mainModule.simulationSpace == ParticleSystemSimulationSpace.World ? transform.worldToLocalMatrix : Matrix4x4.identity;

				_meshCombiner.CombineMeshes(s_scaleZ * matrix);
            }

			canvasRenderer.SetMesh(_meshCombiner.mainMesh);
		}
		
		private Canvas GetParentCanvas()
		{
			if (_parentCanvas == null)
				_parentCanvas = GetComponentInParent<Canvas>();

			return _parentCanvas;
		}
		
		protected override void UpdateMaterial()
		{
			canvasRenderer.materialCount = _trailsModule.enabled ? 2 : 1;
			canvasRenderer.SetMaterial(GetModifiedMaterial(material, 0), 0);

			if (_trailsModule.enabled)
                canvasRenderer.SetMaterial(GetModifiedMaterial(material, 1), 1);
        }
		
		private Material GetModifiedMaterial(Material baseMaterial, int index)
		{
			if (m_ShouldRecalculateStencil)
			{
				m_ShouldRecalculateStencil = false;
				if (maskable)
				{
					var root = MaskUtilities.FindRootSortOverrideCanvas(transform);
					m_StencilValue = MaskUtilities.GetStencilDepth(transform, root) + index;
				}
				else
				{
					m_StencilValue = 0;
                }
			}

			var mask = GetComponent<Mask>();

			if (m_StencilValue < 1)
				return baseMaterial;

			if (mask != null && mask.IsActive())
				return baseMaterial;

			var stencilMask = (1 << m_StencilValue) - 1;
			var mat = StencilMaterial.Add(baseMaterial, stencilMask, StencilOp.Keep, CompareFunction.Equal, ColorWriteMask.All, stencilMask, 0);

			StencilMaterial.Remove(_maskMaterials[index]);
			_maskMaterials[index] = mat;
			return _maskMaterials[index];
        }
	}
}