using UnityEngine;

public class FieldAnimatorController : MonoBehaviour
{
	private Animator _animator;
	private bool _isPlay;
	private Transform transform;
	private Transform _returnParent;
	
	public void SetChild(Transform tran)
	{
		_returnParent = tran.parent;

		tran.SetParent(transform);
		tran.localPosition = Vector3.zero;
		tran.localRotation = Quaternion.identity;
	}
	
	public Transform GetReturnParent()
	{
		return _returnParent;
	}
	
	private void Awake()
	{
		_animator = GetComponent<Animator>();
		transform = gameObject.transform;
	}
	
	private void OnDestroy()
	{
		_animator.runtimeAnimatorController = null;
		_animator = null;
	}
	
	public void Play(string statename)
    {
        _animator.Play(statename);
		_isPlay = true;
    }
	
	public void Stop()
	{
		_animator.Play("stop");
        _isPlay = false;
    }
	
	public void OnStateMachineExit()
	{
		_isPlay = false;
	}
	
	public bool IsPlay()
	{
		return _isPlay;
	}
	
	public bool IsPlay(string statename)
	{
		if (!IsPlay())
			return false;

		var stateInfo = _animator.GetCurrentAnimatorStateInfo(0);

		if (stateInfo.IsName(statename))
			return stateInfo.normalizedTime < 1.0f;

		return _isPlay;
	}
	
	public bool Ready()
	{
		return _animator.runtimeAnimatorController != null;
	}
	
	public Animator GetAnimator()
	{
		return _animator;
	}
}