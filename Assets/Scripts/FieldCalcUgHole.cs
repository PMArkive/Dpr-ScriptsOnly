using UnityEngine;

public static class FieldCalcUgHole
{
	private const float RayOfsY = 0.6f;
	private const float RayOfsXZ = 0.5f;
	private const float OfsMinValue = 0.2f;
	private const float OfsMaxValue = 0.6f;
	private const float SlopeOfsY = 0.1f;
	
	// TODO
	public static void CalcHoleTransform(out Vector3 eulerAngles, out Vector3 positionOffset)
	{
		eulerAngles = Vector3.zero;
		positionOffset = Vector3.zero;
	}
	
	// TODO
	private static void CalcSlope(Vector3 direction, out float deg, out float ofsY)
	{
		deg = 0.0f;
		ofsY = 0.0f;
	}
	
	// TODO
	private static float RayCast(Vector3 offsetDirection) { return default; }
}