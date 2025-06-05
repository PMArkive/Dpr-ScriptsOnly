using SmartPoint.AssetAssistant;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class TheaterTrackPlayer : SingletonMonoBehaviour<TheaterTrackPlayer>
{
	public AnimationPlayer animationPlayer = new AnimationPlayer();
	public string trackName;
	public bool takeover;
	public int colorIndex;
	public bool shadowDistanceAdjust;
	public GameObject bgInstance;
	public float sensorScale;
	private Camera mainCamera;
	private string cameraName;
	private Transform cameraParent;
	private float fieldOfView;
	private Vector3 cameraPosition;
	private Vector3 cameraAngles;
	private int siblingIndex;
	private Transform aimTarget;
	private bool usePhysicalProperties;
	private bool isPlay;
	private bool isLoading;
	private float shadowNearPlaneOffset;
	private float shadowDistance;
	private Transform dofTarget;
	private Camera dofCamera;
	private float dofSensorScale;
	private Dictionary<string, FieldEventEntity> eventEntityMap = new Dictionary<string, FieldEventEntity>();
	public OnStartPlaying onStart;
	private List<Transform> actors = new List<Transform>();
	private Dictionary<string, GameObject> objectTable = new Dictionary<string, GameObject>();
	private List<Renderer> shadowRenderers = new List<Renderer>();
	private List<SaveGameObject> saveGameObjects = new List<SaveGameObject>();
	
	// TODO
	public static TheaterTrackPlayer Instance { get; }
	
	// TODO
	public void Load(TheaterTrack track) { }
	
	// TODO
	private void PlayEffect(string key) { }
	
	// TODO
	private void PlayAnimation(string key) { }
	
	// TODO
	public void OnDestroy() { }
	
	// TODO
	private IEnumerator OnLoad(TheaterTrack track) { return default; }
	
	// TODO
	private void Update() { }

	private class SaveGameObject
	{
		public Behaviour behaviour;
		public Transform target;
		public Transform parent;
		public Vector3 position;
		public Vector3 angles;
		public Vector3 scale;
		
		public SaveGameObject(Transform target, Transform parent)
		{
			behaviour = null;
			this.target = target;
			this.parent = target.parent;

            position = target.localPosition;
            angles = target.localEulerAngles;
            scale = target.localScale;

			target.SetParent(parent, false);
        }
		
		public SaveGameObject(Behaviour behaviour, Transform parent)
		{
			this.behaviour = behaviour;
			target = behaviour.transform;
			this.parent = target.parent;

			position = target.localPosition;
			angles = target.localEulerAngles;
			scale = target.localScale;

			behaviour.enabled = false;
			target.SetParent(parent, false);
		}
		
		// TODO
		public void Resume() { }
	}

	public delegate void OnStartPlaying();
}