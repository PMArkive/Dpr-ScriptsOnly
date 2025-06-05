using SmartPoint.Components;
using UnityEngine;

public class FieldFader : MonoBehaviour
{
    [SerializeField]
    private GameObject _dungeonFade;
    [SerializeField]
    private GameObject _buildingFade;
    [SerializeField]
    private GameObject _areaFade;
    private bool _isFadeOut;
    private bool _isPlaying;
    private float _time;
    private float _progressTime;
    private Animator _animator;

    public bool IsBusy { get => _isPlaying; }

    public void OnUpdate(float deltaTime)
    {
        if (!_isPlaying)
            return;

        _progressTime += deltaTime;

        if (_isFadeOut)
        {
            Fader.fillColor = Color.black;
            Fader.FadeOut(0.0f);
        }

        _isPlaying = false;
        SetActiveFade(FieldFadeType.NONE);
        gameObject.SetActive(false);
    }

    public void FadeOut(FieldFadeType type, float time = 0.5f)
    {
        _isFadeOut = true;
        gameObject.SetActive(true);

        SetActiveFade(type);
        PlayAnimation(type, time);
    }

    public void FadeIn(FieldFadeType type, float time = 0.5f)
    {
        _isFadeOut = false;
        Fader.fillColor = Color.black;
        Fader.FadeIn(0.0f);
        gameObject.SetActive(true);

        SetActiveFade(type);
        PlayAnimation(type, time);
    }

    private void PlayAnimation(FieldFadeType type, float time)
    {
        if (_animator == null)
            _animator = GetComponent<Animator>();

        if (_animator == null)
            return;

        string stateName = "";
        switch (type)
        {
            case FieldFadeType.DUNGEON:
                stateName = "fieldfader_hole";
                break;

            case FieldFadeType.BUILDING:
                stateName = "fieldfader_updown";
                break;

            case FieldFadeType.AREA_UP:
                stateName = "fieldfader_up";
                break;

            case FieldFadeType.AREA_DOWN:
                stateName = "fieldfader_down";
                break;

            case FieldFadeType.AREA_LEFT:
                stateName = "fieldfader_left";
                break;

            case FieldFadeType.AREA_RIGHT:
                stateName = "fieldfader_right";
                break;
        }

        if (_isFadeOut)
            stateName += "_out";
        else
            stateName += "_in";

        _isPlaying = true;
        _time = time;
        _progressTime = 0.0f;
        _animator.Play(stateName, 0);
        _animator.speed = 1.0f / time;
    }

    private void SetActiveFade(FieldFadeType type)
    {
        _dungeonFade.SetActive(type == FieldFadeType.DUNGEON);
        _buildingFade.SetActive(type == FieldFadeType.BUILDING);
        _areaFade.SetActive(type == FieldFadeType.AREA_UP || type == FieldFadeType.AREA_DOWN || type == FieldFadeType.AREA_LEFT || type == FieldFadeType.AREA_RIGHT);
    }

    public enum FieldFadeType : int
    {
        NONE = 0,
        DUNGEON = 1,
        BUILDING = 2,
        AREA_UP = 3,
        AREA_DOWN = 4,
        AREA_LEFT = 5,
        AREA_RIGHT = 6,
    }
}