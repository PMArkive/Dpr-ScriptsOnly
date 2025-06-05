using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dpr.SecretBase
{
	public class SecretBaseAudioManager : MonoBehaviour
	{
		private readonly List<string> seNames = new List<string>()
		{
            "s_und003",             "UI_common_decide", "UI_common_menu_open",
            "UI_common_menu_close", "UI_common_select", "s_und_beep",
            "UI_common_beep",       "UI_common_cancel",
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
			PlacementStatue = 0,
			Decide = 1,
			MenuOpen = 2,
			MenuClose = 3,
			Select = 4,
			PlacementNG = 5,
			SelectNG = 6,
			Cancel = 7,
		}
	}
}