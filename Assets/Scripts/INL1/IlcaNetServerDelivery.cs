using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace INL1
{
	public class IlcaNetServerDelivery : IlcaNetServer
	{
		private static Stopwatch sp = new Stopwatch();
		private static TimeSpan span;

        // TODO: There seems to be something weird here using DataMemoryBarriers in ARM64 which affects this one
        private static bool isMount = false;

		public const int OkurimonoIdFlagArray256size = 256;
		public const int FileFlagArraySize = 13;
		public const int MaxFileNameArraySize = 100;

        // TODO: There seems to be something weird here using DataMemoryBarriers in ARM64 which affects this one
        private static bool isReading = false;

		private static uint s_directoryNum;
		private static uint s_fileNum;
		private static byte[] s_data;
		private static bool s_finish;
		private static int s_ret;
		
		// TODO
		public static void Init() { }
		
		// TODO
		public static bool MountStorageAsync(MonoBehaviour callobj, IlcaNetServerAsyncCallback callback) { return default; }
		
		// TODO
		private static IEnumerator MountStorageAsyncCore(IlcaNetServerAsyncCallback callback) { return default; }
		
		// TODO
		private static IEnumerator MountStorageAsyncCoreSub2() { return default; }
		
		// TODO
		public static bool UnMountStorage() { return default; }
		
		// TODO
		public static bool ImmediateSyncRequestAsync(MonoBehaviour callobj, IlcaNetServerAsyncCallback callback) { return default; }
		
		// TODO
		public static bool ImmediateSyncRequestAsync(MonoBehaviour callobj, IlcaNetServerAsyncCallback callback, bool mount) { return default; }
		
		// TODO
		private static IEnumerator ImmediateSyncRequestAsyncCore(IlcaNetServerAsyncCallback callback, bool mount) { return default; }
		
		// TODO
		public static int FileCountGet(uint directoryNum) { return default; }
		
		// TODO
		public static bool OkurimonoIdFlagCheck(int OkurimonoID, byte[] OkurimonoIdFlagArray256) { return default; }
		
		// TODO
		public static bool OkurimonoIdFlagSet(int OkurimonoID, ref byte[] OkurimonoIdFlagArray256) { return default; }
		
		// TODO
		public static bool OkurimonoIdFlagInit(ref byte[] OkurimonoIdFlagArray256) { return default; }
		
		// TODO
		public static bool FileFlagCheck(byte fileName, byte[] fileFlagArray) { return default; }
		
		// TODO
		public static bool FileFlagSet(byte fileName, ref byte[] fileFlagArray) { return default; }
		
		// TODO
		public static List<byte> FileListGetWithFlag(uint directoryNum, byte[] fileFlagArray) { return default; }
		
		// TODO
		public static int FileCountNameArrayGet(uint directoryNum, byte[] fileNameArray) { return default; }
		
		// TODO
		public static long FileSizeGet(uint directoryNum, uint fileNum) { return default; }
		
		// TODO
		public static int FileRead(uint directoryNum, uint fileNum, byte[] data) { return default; }
		
		// TODO
		public static bool FileReadAsync(MonoBehaviour callobj, uint directoryNum, uint fileNum, byte[] data, IlcaNetServerAsyncCallback callback) { return default; }
		
		// TODO
		private static IEnumerator FileReadAsyncCore(uint directoryNum, uint fileNum, byte[] data, IlcaNetServerAsyncCallback callback) { return default; }
		
		// TODO
		private static void FileReadWorkerThread() { }
	}
}