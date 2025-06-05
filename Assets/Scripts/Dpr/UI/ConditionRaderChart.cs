using Effect;
using Pml.PokePara;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class ConditionRaderChart : MonoBehaviour
	{
		[SerializeField]
		private ChartItem[] _chartItems;
		[SerializeField]
		private RaderChart _rader;

		private List<EffectInstance> _effects = new List<EffectInstance>();

		public const int conditionRaderParamNum = 5;
		
		// TODO
		private void Awake() { }
		
		// TODO
		public void Setup(PokemonParam pokemonParam) { }
		
		// TODO
		public void SetupByBytes(byte[] conditions, bool isHideArrows = true) { }
		
		// TODO
		private void OnEnable() { }
		
		// TODO
		private void OnDisable() { }
		
		// TODO
		private void StopEffects() { }
		
		// TODO
		private void PlayEffects(byte[] conditions) { }
		
		// TODO
		private float GetRaderValue(byte value) { return default; }
		
		// TODO
		public void EnableStatusUpIcon(bool enabled, Condition condition) { }

		[Serializable]
		private class ChartItem
		{
			public Image icon;
			public RectTransform effectRoot;
		}
	}
}