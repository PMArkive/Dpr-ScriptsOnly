using UnityEngine;

public static class SwitchNativeUtils
{
	public const float VolumeValueMin = 0;
	public const float VolumeValueMax = 1;

	// TODO
	private static extern void Native_SetExpectedVolumeBalance(float applicationVolume, float sdkVolume);
	
	// TODO
	public static void SetExpectedVolumeBalance(float applicationVolume, float sdkVolume) { }

	// TODO
	private unsafe static extern void Native_GetExpectedVolumeBalance(float* pApplicationVolume, float* pSdkVolume);
	
	// TODO
	public static Vector2 GetExpectedVolumeBalance() { return default; }
}