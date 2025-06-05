namespace nn.audio
{
	public static class AudioDevice
	{
		public const float OutputVolumeMax = 128.0f;
		public const float OutputVolumeMin = 0.0f;

		public static extern bool SetOutputVolume(AudioDeviceName deviceName, float volume);

		public enum AudioDeviceName : int
		{
			StereoJackOutput = 0,
			BuiltInSpeakerOutput = 1,
			TvOutput = 2,
			UsbDeviceOutput = 3,
		}
	}
}