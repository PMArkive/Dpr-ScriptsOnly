using nn.hid;
using System.Collections;
using UnityEngine;

namespace Dpr.SecretBase
{
	public class StatueVibration : MonoBehaviour
	{
		private const int vibrationDeviceCountMax = 2;

		private int vibrationDeviceCount;
		private VibrationDeviceHandle[] vibrationDeviceHandles = new VibrationDeviceHandle[vibrationDeviceCountMax];
		private VibrationDeviceInfo[] vibrationDeviceInfos = new VibrationDeviceInfo[vibrationDeviceCountMax];
		private VibrationValue vibrationHighValue = VibrationValue.Make();
		private VibrationValue vibrationLowValue = VibrationValue.Make();
        private VibrationValue vibrationStopValue = VibrationValue.Make();
        private NpadId npadId = NpadId.Invalid;
		private NpadStyle npadStyle = NpadStyle.Invalid;
		private NpadState npadState;
		private Coroutine vibHandler;
		private VibrationValue vibrationValue = VibrationValue.Make();

        // TODO
        private void Start() { }
		
		// TODO
		public void Execute(float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh, float period) { }
		
		// TODO
		private void SendValue(VibrationValue value, float period) { }
		
		// TODO
		private IEnumerator StartVibration(VibrationValue value, float period) { return default; }
		
		// TODO
		private void UpdateState() { }
		
		// TODO
		private void GetVibrationDevice(NpadId id, NpadStyle style) { }
	}
}