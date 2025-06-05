using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

public class PokemonPlayable : MonoBehaviour
{
	public PlayableGraph _graph;
	public Playable _mixer;
	public AnimationPlayableOutput _output;
	private Animator _animator;
	public AvatarMask _avatarMask;
	public List<AnimationClip> _clips = new List<AnimationClip>();
	private List<AnimationClipPlayable> _playables = new List<AnimationClipPlayable>();

    public int animationIndex { get; set; }

    // TODO
    public List<AnimationClip> clips { get; }

    // TODO
    public bool isValid { get; }

    private float _increase;
	private float _weight;
	private int _activePort;

    public bool forceLoop { get; set; }

    private RuntimeAnimatorController _savedAnimatorController;
	
	// TODO
	public AnimationClipPlayable GetPlayable() { return default; }
	
	// TODO
	public void SetAnimationSpeed(int index, double speed) { }
	
	// TODO
	private void Awake() { }
	
	// TODO
	private void OnEnable() { }
	
	// TODO
	private void OnDisable() { }
	
	// TODO
	public void PlayAnimation(int index, float startTime = 0.0f) { }
	
	// TODO
	public void ChangeAnimation(int index, float duration = 0.0f, float startTime = 0.0f) { }
	
	// TODO
	private void OnUpdate(float deltaTime) { }
	
	// TODO
	public void CreatePlayables() { }
}