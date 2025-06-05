using Effect;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Dpr.Battle.View.Objects
{
	public sealed class BattleModelParticleEntity : EffectActivator
	{
		[SerializeField]
		[SearchableEnum]
		private EffectBattleID _effectBattleId = EffectBattleID.NONE;
		[SerializeField]
		private EffectInstance _effectInstance;
		private static Dictionary<int, EffectData> _effectDataDic = new Dictionary<int, EffectData>();
		private EffectData _effectData;
		
		public bool IsLoaded { get; set; }
		public EffectBattleID EffectBattleId { get => _effectBattleId; }
		private bool isManualEffectDataRelease { get => PlayerWork.isSealPreview; }
		
		// TODO
		protected override IEnumerator OnActivateOperation() { return default; }
		
		// TODO
		private void OnDestroy() { }
		
		// TODO
		public void Play([Optional] Action onComplete) { }
		
		// TODO
		public void Stop(float fadeTime = 0.0f) { }
		
		// TODO
		public static void ReleaseEffectData() { }
	}
}