using System.Runtime.InteropServices;

namespace nn.hid
{
	public static class Npad
	{
		public const int StateCountMax = 16;

		public static extern void Initialize();
		public static extern void SetSupportedStyleSet(NpadStyle npadStyle);
		public static extern NpadStyle GetSupportedStyleSet();
		public static extern void SetSupportedIdType(NpadId[] npadIds, long count);
		
		// TODO
		public static void SetSupportedIdType(NpadId[] npadIds) { }

		public static extern void BindStyleSetUpdateEvent(NpadId npadId);
		public static extern bool IsStyleSetUpdated(NpadId npadId);
		public static extern void DestroyStyleSetUpdateEvent(NpadId npadId);
		public static extern NpadStyle GetStyleSet(NpadId npadId);
		public static extern void Disconnect(NpadId npadId);
		public static extern byte GetPlayerLedPattern(NpadId npadId);
		public static extern Result GetControllerColor(ref NpadControllerColor pOutValue, NpadId npadId);
		public static extern Result GetControllerColor(ref NpadControllerColor pOutLeftColor, ref NpadControllerColor pOutRightColor, NpadId npadId);
		
		// TODO
		public static void GetState(ref NpadState pOutValue, NpadId npadId, NpadStyle npadStyle) { }
		
		// TODO
		public static int GetStates([Out] NpadStateArrayItem[] pOutValues, int count, NpadId npadId, NpadStyle npadStyle) { return default; }
		
		// TODO
		public static ErrorRange ResultColorNotAvailable { get; }
		
		// TODO
		public static ErrorRange ResultControllerNotConnected { get; }
	}
}