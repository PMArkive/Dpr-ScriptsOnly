using System;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/VoiceRTPC", fileName = "VoiceRTPC")]
public class VoiceRTPC : ScriptableObject
{
	public VoiceRTPCDataList[] datas;

	[Serializable]
	public class VoiceRTPCData
	{
		public byte[] equalizerValues = new byte[] { 48, 48, 48, 48, 48, 48, 48, 48, 48 };
		public byte waveValue = 0;
	}

	[Serializable]
	public class VoiceRTPCDataList
	{
		public string eventName;
		public VoiceRTPCData[] values;
		
		// TODO
		public float GetEqualizerValue(float rate, int gaugeIndex) { return default; }
		
		// TODO
		public float GetSoundWaveValue(float rate) { return default; }
	}
}