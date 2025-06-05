using SmartPoint.AssetAssistant;
using SmartPoint.Rendering;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

namespace Dpr.Battle.View
{
	[ExecuteAlways]
	[RequireComponent(typeof(Camera))]
	public sealed class BattlePostProcessFilter : MonoBehaviour, IViewportChangeHandler, IEventSystemHandler
	{
		[SerializeField]
		private EffectObjectData[] _effectObjectDatas;
		[SerializeField]
		private bool _useOnPostRender = true;

		private PfxParam _pfxParam;
		private Camera _camera;
		private RenderTexture _renderTexture;
		
		// TODO
		private void OnEnable() { }
		
		// TODO
		private void OnDisable() { }
		
		// TODO
		public void Reset() { }
		
		// TODO
		private void Update() { }
		
		// TODO
		private void OnPostRender() { }
		
		// TODO
		public T GetEffect<T>() { return default; }
		
		// TODO
		public void UpdatePfxParam(in PfxParam param) { }
		
		// TODO
		public void OnViewportChange(int screenWidth, int screenHeight) { }

		[Serializable]
		public class EffectObjectData
		{
			public ImageEffectObject effectObject;
			public CommandBuffer commandBuffer;
			public bool isFeedback;
		}
	}
}