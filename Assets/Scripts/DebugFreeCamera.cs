using SmartPoint.AssetAssistant;
using UnityEngine;

public class DebugFreeCamera
{
	private static Transform _cameraTransform;
	private static Vector3 _position;
	private static Vector3 _angles;
	
	public static void BeginCapture()
	{
		Sequencer.postLateUpdate += OnUpdateCamera;
	}
	
	public static void EndCapture()
	{
        Sequencer.postLateUpdate -= OnUpdateCamera;

		_cameraTransform = null;
    }
	
	// TODO
	private static void OnUpdateCamera(float deltaTime) { }
}