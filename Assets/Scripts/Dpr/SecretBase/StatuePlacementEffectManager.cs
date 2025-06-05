using Effect;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dpr.SecretBase
{
	public class StatuePlacementEffectManager : MonoBehaviour
	{
		private List<EffectFieldID> effectIds = new List<EffectFieldID>()
		{
			EffectFieldID.EF_SU_FUSSIL_DAIZA_GROUND,
			EffectFieldID.EF_SU_FUSSIL_DAIZA_GROUND_M,
			EffectFieldID.EF_SU_FUSSIL_DAIZA_GROUND_L,
		};
		private readonly Dictionary<int, EffectData> effectData = new Dictionary<int, EffectData>();
		private EffectInstance effecttInstance;
		
		public bool IsLoadCompleted { get; set; }
		
		// TODO
		public void Play(EffectID id, Vector3 pos) { }
		
		// TODO
		public IEnumerator Load() { return default; }
		
		// TODO
		private void OnDestroy() { }
		
		// TODO
		private void Clear() { }

		public enum EffectID : int
		{
			PlacementStatueS = 0,
			PlacementStatueM = 1,
			PlacementStatueL = 2,
		}
	}
}