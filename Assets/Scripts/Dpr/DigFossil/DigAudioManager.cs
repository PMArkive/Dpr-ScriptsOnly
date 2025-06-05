using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dpr.DigFossil
{
	public class DigAudioManager : MonoBehaviour, IDigAudioManager
	{
		private readonly List<string> seNames = new List<string>()
		{
            "s_und012", "s_und005", "s_und006", "s_und007",         "s_und008",
			"s_und009", "s_und010", "s_und011", "UI_common_decide", "s_und014",
        };
		private readonly List<uint> seIds = new List<uint>();
		private readonly Dictionary<SeId, Coroutine> delayBuffer = new Dictionary<SeId, Coroutine>();
		
		// TODO
		public void Initialize() { }
		
		// TODO
		public void PlaySe(SeId id, float delay = 0.0f) { }
		
		// TODO
		public void StopDelaySe(SeId id) { }
		
		// TODO
		public void StopDelaySeAll() { }
		
		// TODO
		private IEnumerator PlayDelaySe(SeId id, float delay) { return default; }

		public enum SeId : int
		{
			Beacon = 0,
			KnockHummer = 1,
			KnockPickaxe = 2,
			FoundItem = 3,
			DigOutItem = 4,
			KnockHardStone = 5,
			DigOutAllItems = 6,
			CollapseWall = 7,
			Decide = 8,
			AppearStatue = 9,
		}
	}
}