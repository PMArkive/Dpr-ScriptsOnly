using Effect;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dpr.SecretBase
{
	public class SecretBaseEffectManager : MonoBehaviour
	{
		private List<EffectFieldID> effectIds = new List<EffectFieldID>()
		{
			EffectFieldID.EF_SU_FUSSIL_DAIZA_GROUND,
			EffectFieldID.EF_SU_FUSSIL_DAIZA_GROUND,
			EffectFieldID.EF_SU_FUSSIL_DAIZA_GROUND,
		};
		private readonly Dictionary<int, EffectData> effectData = new Dictionary<int, EffectData>();
		private EffectInstance effecttInstance;
		
		// TODO
		private void Play(int index, Vector3 pos) { }
		
		// TODO
		public IEnumerator Load() { return default; }
		
		// TODO
		private void OnDestroy() { }
		
		// TODO
		private void Clear() { }
	}
}