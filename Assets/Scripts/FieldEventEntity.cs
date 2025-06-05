using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

public class FieldEventEntity : FieldObjectEntity
{
    public ShapeType shapeType;
    public float radius = 0.5f;
    public Vector2 offset = Vector2.zero;
    public Vector2 size = Vector2.one;
    [SearchableEnum]
    public ZoneID transitionZone = ZoneID.UNKNOWN;
    public int locatorIndex;
    public bool playOnAwake;
    public int clipIndex;
    public List<TweenClip> clips = new List<TweenClip>();
    protected bool checkHeight;
    private Animator _animator;
    private PlayableGraph _graph;
    private PlayableOutput _output;
    public CorrectionDir correctionDir;
    [SerializeField]
    private bool isLandingEntity = true;
    private bool _hit;

    public override string entityType { get => "FieldCollision"; }
    public bool isCompleted
    {
        get
        {
            if (clipIndex < clips.Count)
                return true;

            if (clips[clipIndex].isComplete)
                return true;

            if (clips[clipIndex].animationClip == null)
                return false;

            if (!_output.IsOutputValid())
                return true;

            return clips[clipIndex].animationClip.length < _output.GetSourcePlayable().GetTime();
        }
    }

    protected override void Awake()
    {
        isLanding = isLandingEntity;
        base.Awake();
        clips.ForEach(__ => __.Build(transform));

        if (playOnAwake)
            Play(0);
    }

    protected override void OnUpdate(float deltaTime)
    {
        base.OnUpdate(deltaTime);
    }

    protected override void OnLateUpdate(float deltaTime)
    {
        base.OnLateUpdate(deltaTime);
    }

    public void Play(int index)
    {
        // Very weird condition, not sure how this was done originally
        if (index != int.MaxValue && index < -1)
            return;

        if (index >= clips.Count)
            return;

        if (clips[index].animationClip != null)
        {
            if (_animator == null)
                _animator = GetComponent<Animator>();

            if (_animator != null)
            {
                if (!_graph.IsValid())
                    _graph = PlayableGraph.Create();

                if (!_output.IsOutputValid())
                    _output = AnimationPlayableOutput.Create(_graph, "FieldEventEntity", _animator);
            }

            if (_output.IsOutputValid())
            {
                var playable = AnimationClipPlayable.Create(_graph, clips[index].animationClip);
                if (playable.IsValid())
                {
                    _output.SetSourcePlayable(playable);
                    _graph.Play();
                }
            }
        }

        clips[index].Play();
        clipIndex = index;
    }

    public void ForceAnimeEnd(int index)
    {
        // Very weird condition, not sure how this was done originally
        if (index != int.MaxValue && index < -1)
            return;

        if (index >= clips.Count)
            return;

        clipIndex = index;

        foreach (var elem in clips[index].elements)
        {
            switch (elem.animationType)
            {
                case AnimationType.Move:
                    elem.target.position = elem.value;
                    break;

                case AnimationType.LocalMove:
                    elem.target.localPosition = elem.value;
                    break;

                case AnimationType.Rotate:
                    elem.target.eulerAngles = elem.value;
                    break;

                case AnimationType.LocalRotate:
                    elem.target.localEulerAngles = elem.value;
                    break;

                case AnimationType.Scale:
                    elem.target.localScale = elem.value;
                    break;
            }
        }
    }

    public void RewindAll()
    {
        clips.ForEach(__ => __.Rewind());
    }

    public void Rewind(int index)
    {
        // Very weird condition, not sure how this was done originally
        if (index != int.MaxValue && index < -1)
            return;

        if (index >= clips.Count)
            return;

        clips[index].Rewind();
    }

    protected override void OnDestroy()
    {
        clips.ForEach(__ => __.Destroy());

        if (_graph.IsValid())
            _graph.Destroy();

        base.OnDestroy();
    }

    protected override void ProcessSequence(float deltaTime)
    {
        if (currentSequence != SequenceID.Active ||
            shapeType == ShapeType.None ||
            EntityManager.activeFieldPlayer == null)
        {
            base.ProcessSequence(deltaTime);
            return;
        }

        if (checkHeight || Math.Abs(EntityManager.activeFieldPlayer.Height - Height) <= 0.3f)
        {
            Vector2 vec;
            float x;
            float z;
            switch (shapeType)
            {
                case ShapeType.Box:
                    vec = new Vector2(-(worldPosition.x - offset.x), worldPosition.z + offset.y - size.y);
                    x = -EntityManager.activeFieldPlayer.worldPosition.x - vec.x;
                    z = EntityManager.activeFieldPlayer.worldPosition.z - vec.y;
                    if (x >= 0.0f && z >= 0.0f && x <= size.x && z <= size.y)
                    {
                        if (!_hit)
                            EntityManager.activeFieldPlayer.OnEventEnter(deltaTime, this);

                        EntityManager.activeFieldPlayer.OnEventStay(deltaTime, this);
                        _hit = true;
                        base.ProcessSequence(deltaTime);
                        return;
                    }
                    break;

                case ShapeType.Circle:
                    vec = new Vector2(radius - (worldPosition.x - offset.x), worldPosition.z + offset.y - radius);
                    x = -EntityManager.activeFieldPlayer.worldPosition.x - vec.x;
                    z = EntityManager.activeFieldPlayer.worldPosition.z - vec.y;
                    if (x * x + z * z < radius * radius)
                    {
                        if (!_hit)
                            EntityManager.activeFieldPlayer.OnEventEnter(deltaTime, this);

                        EntityManager.activeFieldPlayer.OnEventStay(deltaTime, this);
                        _hit = true;
                        base.ProcessSequence(deltaTime);
                        return;
                    }
                    break;
            }
        }

        if (_hit)
        {
            EntityManager.activeFieldPlayer.OnEventLeave(deltaTime, this);
            _hit = false;
        }

        base.ProcessSequence(deltaTime);
    }

    public enum ShapeType : int
    {
        None = 0,
        Box = 1,
        Circle = 2,
    }

    public enum CorrectionDir : int
    {
        Up = 0,
        Down = 1,
        Left = 2,
        Right = 3,
    }
}