using Effect;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Dpr.Battle.View.Objects
{
	public class BattleFieldEffect : EffectActivator
	{
		private static List<BattleFieldEffect> _registedEffects = new List<BattleFieldEffect>();

		[SerializeField]
		[SearchableEnum]
		private EffectBattleID _effectBattleId;
		[SerializeField]
		private float _delayTime;
		private EffectInstance _effectInstance;
		private EffectData _effectData;
		
		private bool IsPlaying { get; set; }
		
		// TODO
		protected override IEnumerator OnActivateOperation() { return default; }
		
		// TODO
		private void OnDestroy() { }
		
		// TODO
		public void Play([Optional] Action onComplete) { }
		
		// TODO
		public void Stop() { }
		
		// TODO
		public static void SetAllActivate(bool isActive) { }
	}
}