using SmartPoint.AssetAssistant;
using System.Collections;
using UnityEngine;

public class FieldAnimeCamera : MonoBehaviour
{
    public static FieldAnimeCamera instance;

    private Camera _camera;
    private Animator _animator;
    private bool _isPlay;
    private Transform transform;
    private string assetbundleName;

    private void Awake()
    {
        instance = this;
        _camera = GetComponent<Camera>();
        _animator = GetComponent<Animator>();
        transform = gameObject.transform;
    }

    private void OnDestroy()
    {
        instance = null;
        _camera = null;
        _animator.runtimeAnimatorController = null;
        _animator = null;
    }

    public float GetFov()
    {
        return _camera.fieldOfView;
    }

    public float GetFocalLength()
    {
        return _camera.focalLength;
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
        if (!_isPlay)
            return false;

        var stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName(statename))
            return stateInfo.normalizedTime < 1.0f;
        else
            return _isPlay;
    }

    public bool Ready()
    {
        return _animator.runtimeAnimatorController != null;
    }

    public void LoadRuntimeAnimatorController(string assetname)
    {
        Sequencer.Start(Load(assetname));
    }

    public void ReleaseSetRuntimeAnimatorController()
    {
        if (_isPlay)
            return;

        _animator.runtimeAnimatorController = null;
        UnloadAsset();
    }

    private IEnumerator Load(string assetname)
    {
        AssetManager.AppendAssetBundleRequest(assetname, true, null, null);
        yield return AssetManager.DispatchRequests((eventType, name, asset) =>
        {
            var controller = asset as RuntimeAnimatorController;
            if (controller == null)
                return;

            _animator.runtimeAnimatorController = controller;
        });

        assetbundleName = assetname;
    }

    public bool IsNull()
    {
        if (_animator == null)
            return true;

        return !Ready();
    }

    private void UnloadAsset()
    {
        if (assetbundleName != "")
        {
            AssetManager.UnloadAssetBundle(assetbundleName);
            assetbundleName = "";
        }
    }
}