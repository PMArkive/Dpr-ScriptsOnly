using nn.hid;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.DigFossil
{
	public class DigVibration : MonoBehaviour
	{
		[SerializeField]
		private Text timeText;
		[SerializeField]
		private Text lowAmpText;
		[SerializeField]
		private Text highAmpText;
		[SerializeField]
		private Text lowFreqText;
		[SerializeField]
		private Text highFreqText;

		private const int vibrationDeviceCountMax = 2;

		private int vibrationDeviceCount;
		private Coroutine vibHandler;
		private readonly VibrationDeviceHandle[] vibrationDeviceHandles = new VibrationDeviceHandle[vibrationDeviceCountMax];
		private readonly VibrationDeviceInfo[] vibrationDeviceInfos = new VibrationDeviceInfo[vibrationDeviceCountMax];
        private VibrationValue vibrationHighValue = VibrationValue.Make();
		private VibrationValue vibrationLowValue = VibrationValue.Make();
        private VibrationValue vibrationStopValue = VibrationValue.Make();
        private NpadId currentNpadId = NpadId.Invalid;
		private NpadStyle currentNpadStyle = NpadStyle.Invalid;
		private VibrationValue vibrationValue = VibrationValue.Make();

        // TODO
        private void Start() { }
		
		// TODO
		public void Picaxe() { }
		
		// TODO
		public void Hummer() { }
		
		// TODO
		public void HardStone() { }
		
		// TODO
		public void CollapsePhase1(float time) { }
		
		// TODO
		public void CollapsePhase2(float time) { }
		
		// TODO
		private void SendValue(VibrationValue value, float period) { }
		
		// TODO
		private IEnumerator StartVibration(VibrationValue value, float period) { return default; }
		
		// TODO
		private void GetVibrationDevice(NpadId id, NpadStyle style) { }
	}
}