using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dpr.Battle.View.UI
{
	public class BUIResult : BattleViewUICanvasBase
	{
		[SerializeField]
		private List<PokeStatus> _pokeStatusList;
		
		// TODO
		public void Initialize() { }
		
		// TODO
		public override void OnUpdate(float deltaTime) { }

		[Serializable]
		private class PokeStatus { }

		[Serializable]
		private class LevelupInfo { }
	}
}