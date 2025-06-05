using Audio;
using System.Collections.Generic;
using UnityEngine;

public class AudioAmbient : MonoBehaviour
{
	[SerializeField]
	private uint _playEventId;
	[SerializeField]
	private List<Vector3> _positions = new List<Vector3>() { Vector3.zero };
	protected AudioInstance _audioInstance;
	
	// TODO
	protected virtual void Start() { }
	
	// TODO
	protected virtual void Play() { }
	
	// TODO
	protected virtual void OnDestroy() { }
	
	// TODO
	protected virtual void Update() { }
	
	// TODO
	protected float DistanceSqLinePoint(Vector3 l0, Vector3 l1, Vector3 p, out Vector3 crossPos)
	{
		crossPos = default;
		return default;
	}
	
	// TODO
	public void SetSwitch(uint groupId, uint state) { }
}