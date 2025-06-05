using System;

namespace Dpr.NX
{
	internal class ClockSnapshot
	{
		public const int SNAPSHOT_SIZE = 208;

		// TODO
		private static extern int GetSnapshotSize();

		// TODO
		private static extern void GetClockSnapshot(IntPtr buf);

		// TODO
		private static extern bool CompareClockSnapshot(IntPtr oldSnapshot, IntPtr newSnapshot);
		
		// TODO
		public static void GetSnapshot(ref byte[] buf) { }
		
		// TODO
		public static bool Compare(byte[] oldSnapshot, byte[] newSnapshot) { return default; }
	}
}