using Effect;
using SmartPoint.AssetAssistant;
using System.Collections;
using UnityEngine;

public class EncEffectSequenceController
{
    private EncEffectSequenceData _sequence;
    private float _updateTime;
    private EffectInstance _effectInstance;
    private FieldManager _field;
    private Vector3 _cameraPositionOffset = Vector3.zero;
    private Vector3 _cameraRotationOffset = Vector3.zero;

    public ePlayState PlayState { set; get; }

    public EncEffectSequenceController(string assetname, FieldManager field)
    {
        _sequence = null;
        _updateTime = 0.0f;
        _effectInstance = null;
        _field = field;
        PlayState = ePlayState.Loading;
        Sequencer.Start(EffectLoad(assetname));
    }

    // TODO
    private IEnumerator EffectLoad(string assetname) { return null; }

    // TODO
    private IEnumerator LoadGymEffect() { return null; }

    // TODO
    private IEnumerator LoadLeagueEffect() { return null; }

    // TODO
    private IEnumerator LoadTowerEffect() { return null; }

    // TODO
    public void Release() { }

    // TODO
    public void Play() { }

    // TODO
    public void ForceFinish() { }

    // TODO
    private void update(float deltatime) { }

    // TODO
    private void CommandRunning(EncEffectSequenceData.KeyData data) { }

    // TODO
    private void ProcCommandStart(EncEffectSequenceData.KeyData data) { }

    // TODO
    private void ProcCommandUpdate(EncEffectSequenceData.KeyData data) { }

    // TODO
    private void ProcCommandEnd(EncEffectSequenceData.KeyData data) { }

    // TODO
    public void LegendCamera() { }

    // TODO
    private void SetLegendCamera(int index, ref Vector3 pos, ref Vector3 rot) { }

    public enum ePlayState : int
    {
        Loading = 0,
        PlayStandBy = 1,
        Play = 2,
        Finish = 3,
        Release = 4,
    }
}