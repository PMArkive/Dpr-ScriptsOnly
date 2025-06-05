using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

public class PokemonAnimePlayable : MonoBehaviour
{
	public string[] mStates;
	private PlayableGraph graph;
	private AnimationPlayableOutput output;
	private AnimationClipPlayable clipPlayable;
	private AnimationClipPlayable clipPlayableLoop;
	[HideInInspector]
	public AnimationLayerMixerPlayable layer;
	[SerializeField]
	public AnimationClip[] clips;
	[SerializeField]
	private AnimationClip cliploop;
	[SerializeField]
	private AvatarMask avatarMask;
	private float mTime;
	private bool pauseFlag;
	private Animator animator;
	private AnimatorCallEvent callEvent;
	
	// TODO
	public void Awake() { }
	
	// TODO
	private void Start() { }
	
	// TODO
	private void Update() { }
	
	// TODO
	public void ChangeAnimation(string animName) { }
	
	// TODO
	public float GetAnimationLength(string animName) { return default; }
	
	// TODO
	public AnimationClipPlayable GetCurrentAnimationClipPlayable() { return default; }
	
	// TODO
	public bool IsLooping(string animName) { return default; }
	
	// TODO
	public void SetPauseFrame(bool pFlag, float time = 0.0f) { }
	
	// TODO
	private void OnDestroy() { }
}