using UnityEngine;

namespace Dpr.DigFossil
{
	public static class DigInput
	{
		// TODO
		public static bool Left { get; }
		
		// TODO
		public static bool Right { get; }
		
		// TODO
		public static bool Up { get; }
		
		// TODO
		public static bool Down { get; }
		
		// TODO
		public static bool Dig { get; }
		
		// TODO
		public static bool Touch { get; }
		
		// TODO
		public static Vector2 TouchPos { get; }
		
		// TODO
		public static bool Decide { get; }
		
		// TODO
		public static bool SwitchTool { get; }
		
		// TODO
		public static Vector2 Analog { get; }
		
		// TODO
		public static bool ToggleCameraShake { get; }
		
		private static bool IsEasyInput()
		{
			return PlayerWork.config.input_mode != DPData.INPUTMODE.INPUTMODE_NORMAL;
		}
	}
}