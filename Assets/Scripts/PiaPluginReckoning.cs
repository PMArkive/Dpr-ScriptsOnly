public class PiaPluginReckoning
{
	public class Value3d
	{
		// TODO
		private static extern PiaPlugin.Result SetValue3dNative(ushort port, ulong destConstantId, float posX, float posY, float posZ, bool isStop);
		
		// TODO
		public static PiaPlugin.Result SetValue(ushort port, ulong destConstantId, float posX, float posY, float posZ, bool isStop) { return default; }

		// TODO
		private static extern PiaPlugin.Result SetValueToAll3dNative(ushort port, float posX, float posY, float posZ, bool isStop);
		
		// TODO
		public static PiaPlugin.Result SetValueToAll(ushort port, float posX, float posY, float posZ, bool isStop) { return default; }

		// TODO
		private static extern PiaPlugin.Result GetValue3dNative(ushort port, out ulong destConstantId, out float posX, out float posY, out float posZ);
		
		// TODO
		public static PiaPlugin.Result GetValue(ushort port, out ulong destConstantId, out float pPosX, out float pPosY, out float pPosZ)
		{
			destConstantId = default;
			pPosX = default;
			pPosY = default;
			pPosZ = default;
			return default;
		}

		// TODO
		private static extern void SetSamplingDistance3dNative(ushort port, float distance);
		
		// TODO
		public static void SetSamplingDistance(ushort port, float distance) { }

		// TODO
		private static extern float GetSamplingDistance3dNative(ushort port);
		
		// TODO
		public static float GetSamplingDistance(ushort port) { return default; }

		// TODO
		private static extern bool IsInCommunication3dNative(ushort port);
		
		// TODO
		public static bool IsInCommunication(ushort port) { return default; }

		// TODO
		private static extern bool Reset3dNative(ushort port);
		
		// TODO
		public static void Reset(ushort port) { }

		// TODO
		private static extern void SetClock3dNative(ushort port, ulong clock);
		
		// TODO
		public static void SetClock(ushort port, ulong clock) { }

		// TODO
		private static extern void SetReckoningTimeout3dNative(ushort port, ulong clock);
		
		// TODO
		public static void SetReckoningTimeout(ushort port, ulong clock) { }
	}

	public class Value1d
	{
		// TODO
		private static extern PiaPlugin.Result SetValue1dNative(ushort port, ulong destConstantId, float value, bool isStop);
		
		// TODO
		public static PiaPlugin.Result SetValue(ushort port, ulong destConstantId, float value, bool isStop) { return default; }

		// TODO
		private static extern PiaPlugin.Result SetValueToAll1dNative(ushort port, float value, bool isStop);
		
		// TODO
		public static PiaPlugin.Result SetValueToAll(ushort port, float value, bool isStop) { return default; }

		// TODO
		private static extern PiaPlugin.Result GetValue1dNative(ushort port, out ulong destConstantId, out float pValue);
		
		// TODO
		public static PiaPlugin.Result GetValue(ushort port, out ulong destConstantId, out float pValue)
		{
			destConstantId = default;
			pValue = default;
			return default;
		}

		// TODO
		private static extern void SetSamplingDistance1dNative(ushort port, float value);
		
		// TODO
		public static void SetSamplingDistance(ushort port, float value) { }

		// TODO
		private static extern float GetSamplingDistance1dNative(ushort port);
		
		// TODO
		public static float GetSamplingDistance(ushort port) { return default; }

		// TODO
		private static extern bool IsInCommunication1dNative(ushort port);
		
		// TODO
		public static bool IsInCommunication(ushort port) { return default; }

		// TODO
		private static extern bool Reset1dNative(ushort port);
		
		// TODO
		public static void Reset(ushort port) { }

		// TODO
		private static extern void SetClock1dNative(ushort port, ulong clock);
		
		// TODO
		public static void SetClock(ushort port, ulong clock) { }

		// TODO
		private static extern void SetReckoningTimeout1dNative(ushort port, ulong clock);
		
		// TODO
		public static void SetReckoningTimeout(ushort port, ulong clock) { }
	}
}