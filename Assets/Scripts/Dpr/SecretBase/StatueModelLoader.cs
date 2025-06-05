using SmartPoint.AssetAssistant;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dpr.SecretBase
{
	public class StatueModelLoader : MonoBehaviour
	{
		[SerializeField]
		private PetrifyData petrifyData;
		private Shader petrifyShader;
		private Shader petrifyFireShader;
		private List<string> histories = new List<string>();
		
		// TODO
		private void OnEnable() { }
		
		// TODO
		public void AppendRequest(StatueEffectData statue, Action<GameObject> onLoadCompleted) { }
		
		// TODO
		public AssetRequestOperation DispatchRequests() { return default; }
		
		// TODO
		public void UnloadHistories() { }
		
		// TODO
		public void Load(StatueEffectData statue, Transform parent, Action<GameObject> onLoadCompleted) { }
	}
}