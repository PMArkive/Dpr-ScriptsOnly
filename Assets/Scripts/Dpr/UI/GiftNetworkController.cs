using Dpr.NetworkUtils;
using INL1;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dpr.UI
{
	public class GiftNetworkController : MonoBehaviour
	{
		private const ushort FailedDataNoValue = 65535;

		private List<ushort> checkDataNoList;
		private byte[] fileDataBytes;
		private List<byte[]> giftDataByteList;
		private Action<int, ushort> onCompleteCheckSerial;
		private Action<byte[][]> onCompleteGetGiftListItemInfos;
		private Action<bool> onCompleteUpdateSerialCodeUsed;
		private bool isCheckSerialCodeRequested;
		
		public int ProgressCount { get; set; }
		
		// TODO
		public void CallInternetGo(Action<bool, SessionErrorType> onFinishedInternetGo) { }
		
		// TODO
		public bool IsConnect() { return default; }
		
		// TODO
		public void CheckSerialRequest(string serialCode, Action<int, ushort> onComplete) { }
		
		// TODO
		private void SerialServerCallback(bool isSuccess, IlcaNetServerCallbackEventType eve, IlcaNetServerCallbackResult serverResult, long responseCode, string responseStr) { }
		
		// TODO
		public void UpdateSerialCodeUsed(Action<bool> onComplete) { }
		
		// TODO
		private void UpdateSerialCodeUsedCallback(bool isSuccess, IlcaNetServerCallbackEventType eve, IlcaNetServerCallbackResult serverResult, long responseCode, string responseStr) { }
		
		// TODO
		public void GetGiftListItemInfos(ushort[] dataNos, Action<byte[][]> onComplete) { }
		
		// TODO
		private void GetGiftListItemInfosCallback(bool isSuccess, IlcaNetServerCallbackEventType eve, IlcaNetServerCallbackResult serverResult, long responseCode, string responseStr) { }
		
		// TODO
		private void NextReadFile() { }
	}
}