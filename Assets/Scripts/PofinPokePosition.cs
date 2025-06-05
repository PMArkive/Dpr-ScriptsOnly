using System.Collections.Generic;
using UnityEngine;

public class PofinPokePosition : MonoBehaviour
{
	[SerializeField]
	private Transform PoffinMachine;
	[SerializeField]
	private List<GameObject> Positions;
	[SerializeField]
	private List<float> Angles;
	[SerializeField]
	private float Radius;
	[SerializeField]
	private bool isCubeVisible;
	
	// TODO
	private void OnValidate() { }
	
	// TODO
	private static Vector3 RotateAroundY(Vector3 original_position, float angle, float radius) { return default; }
	
	// TODO
	public Vector3 GetTargetRadiusPos(int index, float RadiusOffset) { return default; }
}