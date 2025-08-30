using Effect;
using UnityEngine;

namespace Dpr.SubContents
{
	public class TimeLineEffect : MonoBehaviour
	{
		private EffectData _effectData;
		private EffectInstance _effectInstance;
		
		public void SetEffect(EffectData effectData, BindModelEffect bindModel)
		{
			_effectData = effectData;
			_effectInstance = null;

			if (bindModel.StartActive)
				OnEnable();
		}
		
		// TODO
		private void LateUpdate() { }
		
		// TODO
		private void OnEnable() { }
		
		// TODO
		private void OnDisable() { }
		
		// TODO
		private void EffectStop() { }
		
		// TODO
		private void OnDestroy() { }
	}
}