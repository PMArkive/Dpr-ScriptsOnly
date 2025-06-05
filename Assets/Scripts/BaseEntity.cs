using SmartPoint.AssetAssistant;
using System;
using UnityEngine;

[DisallowMultipleComponent]
public class BaseEntity : MonoBehaviour
{
    [SerializeField]
    private string _enityName = string.Empty;
    private bool _alreadyRegistered;
    [NonSerialized]
    public float yawAngle;
    [NonSerialized]
    public Vector3 worldPosition = Vector3.zero;
    private float savedYawAngle;
    private Vector3 savedPosition = Vector3.zero;

    public virtual string entityType { get => "Base"; }

    public virtual AnimationPlayer GetAnimationPlayer()
    {
        return null;
    }

    public Vector3 beforePosition { set; get; }

    private Transform _cacheTransform;

    public void Register()
    {
        if (_alreadyRegistered)
            return;

        EntityManager.Add(this);
        _alreadyRegistered = true;
    }

    public void Unregister()
    {
        if (!_alreadyRegistered)
            return;

        EntityManager.Remove(this);
        _alreadyRegistered = false;
    }

    public int currentSequence { get; set; }
    public int nextSequence { get; set; }
    public float sequenceTime { get; set; }
    public string entityEname { get => _enityName == string.Empty ? name : _enityName; set => _enityName = value; }
    public BaseEntity target { get; set; }
    public Transform transform
    {
        get
        {
            if (_cacheTransform == null)
                _cacheTransform = GetComponent<Transform>();

            return _cacheTransform;
        }
    }

    protected virtual void Awake()
    {
        _cacheTransform = GetComponent<Transform>();
        savedYawAngle = _cacheTransform.eulerAngles.y;
        savedPosition = _cacheTransform.position;
        worldPosition = _cacheTransform.position;
        yawAngle = savedYawAngle;
        Register();
    }

    protected virtual void OnEnable()
    {
        OnDisable();
        OnPostLateUpdate(0.0f);

        Sequencer.earlyUpdate += OnEarlyUpdate;
        Sequencer.update += OnUpdate;
        Sequencer.lateUpdate += OnLateUpdate;
        Sequencer.postLateUpdate += OnPostLateUpdate;
    }

    protected virtual void OnDisable()
    {
        Sequencer.earlyUpdate -= OnEarlyUpdate;
        Sequencer.update -= OnUpdate;
        Sequencer.lateUpdate -= OnLateUpdate;
        Sequencer.postLateUpdate -= OnPostLateUpdate;
    }

    protected virtual void OnDestroy()
    {
        Unregister();
    }

    private void OnEarlyUpdate(float deltaTime)
    {
        savedYawAngle = _cacheTransform.eulerAngles.y;
        savedYawAngle = _cacheTransform.eulerAngles.y;
        savedPosition = _cacheTransform.position;
        worldPosition = _cacheTransform.position;
        yawAngle = savedYawAngle;
    }

    protected virtual void OnUpdate(float deltaTime)
    {
        if (currentSequence != nextSequence && SwitchToNext())
        {
            currentSequence = nextSequence;
            sequenceTime = 0.0f;
        }

        ProcessSequence(deltaTime);
        sequenceTime += deltaTime;
    }

    protected virtual void OnLateUpdate(float deltaTime)
    {
        // Empty
    }

    private void OnPostLateUpdate(float deltaTime)
    {
        beforePosition = _cacheTransform.position;
        var euler = _cacheTransform.eulerAngles;
        _cacheTransform.eulerAngles = new Vector3(euler.x, euler.y + (yawAngle - savedYawAngle), euler.z);
        _cacheTransform.position = _cacheTransform.position + worldPosition - savedPosition;
    }

    protected virtual bool SwitchToNext()
    {
        return true;
    }

    protected virtual void ProcessSequence(float deltaTime)
    {
        // Empty
    }

    public void SetPositionDirect(Vector3 pos)
    {
        _cacheTransform.position = pos;
        savedPosition = _cacheTransform.position;
        worldPosition = _cacheTransform.position;
    }

    public void SetYawAngleDirect(float angle)
    {
        var euler = _cacheTransform.eulerAngles;
        _cacheTransform.eulerAngles = new Vector3(euler.x, angle, euler.z);
        savedYawAngle = angle;
        yawAngle = angle;
    }

    public class SequenceID
    {
	    public const int Initialize = 0;
        protected const int User = 4096;
    }
}