using System;
using System.Runtime.InteropServices;

public class PiaPluginSync
{
	public const uint FrameDelayMax = 32;

	// TODO
	private static extern PiaPlugin.Result StepNative();
	
	// TODO
	public static PiaPlugin.Result Step() { return default; }

	// TODO
	private static extern PiaPlugin.Result StartNative([In] SyncStartArgument syncStartArg);
	
	// TODO
	public static PiaPlugin.Result Start(SyncStartArgument syncStartArg) { return default; }

	// TODO
	private static extern PiaPlugin.Result EndNative();
	
	// TODO
	public static PiaPlugin.Result End() { return default; }

	// TODO
	private static extern PiaPlugin.Result EndAllNative();
	
	// TODO
	public static PiaPlugin.Result EndAll() { return default; }

	// TODO
	private static extern PiaPlugin.Result SetDataNative([In] SetDataArgument arg);
	
	// TODO
	public static PiaPlugin.Result SetData(SetDataArgument arg) { return default; }

	// TODO
	private static extern PiaPlugin.Result GetDataNative([In] GetDataArgument arg);
	
	// TODO
	public static PiaPlugin.Result GetData(GetDataArgument arg) { return default; }

	// TODO
	private static extern PiaPlugin.Result ReadySetDataNative();
	
	// TODO
	public static PiaPlugin.Result ReadySetData() { return default; }

	// TODO
	private static extern PiaPlugin.Result ReadySetDataNative2(byte dataId);
	
	// TODO
	public static PiaPlugin.Result ReadySetData(byte dataId) { return default; }

	// TODO
	private static extern PiaPlugin.Result ReadyGetDataNative(ulong constantId);
	
	// TODO
	public static PiaPlugin.Result ReadyGetData(ulong constantId) { return default; }

	// TODO
	private static extern State GetSyncStateNative();
	
	// TODO
	public static State GetSyncState() { return default; }

	// TODO
	private static extern bool CheckEntryNative(ulong constantId);
	
	// TODO
	public static bool CheckEntry(ulong constantId) { return default; }

	// TODO
	private static extern uint GetFrameNoNative();
	
	// TODO
	public static uint GetFrameNo() { return default; }

	// TODO
	private static extern byte GetDelayNative();
	
	// TODO
	public static byte GetDelay() { return default; }

	// TODO
	private static extern byte GetDelayMaxNative();
	
	// TODO
	public static byte GetDelayMax() { return default; }

	// TODO
	private static extern PiaPlugin.Result RequestToChangeDelayNative(byte newDelay);
	
	// TODO
	public static PiaPlugin.Result RequestToChangeDelay(byte newDelay) { return default; }

	public enum State : int
	{
		NotSynchronized = 0,
		Starting = 1,
		Synchronizing = 2,
		Ending = 3,
	}

	[Serializable]
	public class SyncStartArgument
	{
		public int usingDataIdBitmap;
		public byte delay;
		public byte sendPeriod;
	}

	public struct SetDataArgument
	{
		public byte dataId;
		public uint dataSize;
		public IntPtr pData;
	}

	public struct GetDataArgument
	{
		public ulong constantId;
		public byte dataId;
		public uint dataSize;
		public IntPtr pData;
	}
}