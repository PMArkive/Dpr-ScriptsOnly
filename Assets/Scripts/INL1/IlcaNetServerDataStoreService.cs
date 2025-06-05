using System.Collections;
using UnityEngine;

namespace INL1
{
	public class IlcaNetServerDataStoreService
	{
		private const int PokeCoreSize = 328;

		private static bool GMStationTrading = false;
		private static bool GMStationErrorSimulateFlag = false;
		private static byte[] downCoreBinary = new byte[332]; // TODO: Find constants for these?
		private static byte[] downSignatureBinary = new byte[0x100];
		private static ushort recvPoint = 0;
		
		// TODO
		public static bool GMStationTrade(MonoBehaviour callobj, int targetPoint, IlcaNetServerValidate.CheckRequest cReq, byte[] upSignatureBinary, IlcaNetServerDataStoreServiceGMStationTradeCallback userCallback, bool errorOn = false) { return default; }
		
		// TODO
		private static IEnumerator GMStationTradeCore(int targetPoint, IlcaNetServerValidate.CheckRequest cReq, byte[] upSignatureBinary, IlcaNetServerDataStoreServiceGMStationTradeCallback userCallback) { return default; }
		
		// TODO
		public static bool GMStationTradeCoreDataInstanceGet(byte[] downloadCoreData) { return default; }
		
		// TODO
		public static bool GMStationTradeCoreDataInstanceGet(byte[] downloadCoreData, ref ushort point) { return default; }

		public delegate void IlcaNetServerDataStoreServiceGMStationTradeCallback(bool isSuccess, GMstationTradeStatusEnum result, bool playerCoreDataDelete);

		public enum GMstationTradeStatusEnum : int
		{
			SUCCESS = 0,
			ERROR = 10,
			ERROR_CALL = 11,
			ERROR_SERVER = 12,
			ERROR_SIGNATURE = 13,
			ERROR_EMPTY = 14,
		}
	}
}