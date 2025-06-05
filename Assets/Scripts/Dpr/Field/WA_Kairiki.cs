using AK;
using Pml;
using UnityEngine;

namespace Dpr.Field
{
	public class WA_Kairiki
	{
		private static WA_Kairiki instance;

		private const MonsNo monsNo = MonsNo.BIIDARU;
		private const uint voiceEventId = EVENTS.PLAY_PV_BTL_400_00_00;

		private bool isVoiceEnd;
		private int seqNo;
		
		// TODO
		public static bool Action(float deltatime) { return default; }
		
		// TODO
		public static bool PushEntity(FieldPlayerEntity player, DIR dir, FieldObjectEntity target, out Vector2Int outgrid, out bool hit)
		{
			outgrid = default;
			hit = default;
			return default;
		}
	}
}