using Pml.PokePara;
using Pml;
using SmartPoint.AssetAssistant;
using UnityEngine;
using XLSXContent;
using Dpr;
using Effect;

public class FieldWazaCutIn
{
    public bool IsInitialized { get; set; }
    public bool IsBusy { get; }
    public bool IsLoaded { get; }
    public bool IsPlayedEffect { get; }
    public bool IsOverrideEnvironmentSettings { get; set; }

    public float PokemonVisibleTimeOffset;
    private GameObject LoadedPokemonObject;
    private AssetRequestOperation PokemonObjectLoad;
    private GameObject PokemonObject;
    private EffectInstance Effect;
    private FieldFloatMove Time = new FieldFloatMove();
    private FieldFloatMove CaptureAlpha = new FieldFloatMove();
    private int PokemonUniqueId;
    private MonsNo MonsNo;
    private int FormNo;
    private Vector3 PokemonPosition;
    private FieldWazaCutInComponents Components;
    private bool IsForceCaptureInvisible;
    private bool CaptureAlphaUpdateSkip;
    private CutInPhase Phase;
    private CameraParamBackup CameraBackup = new CameraParamBackup();

    // TODO
    public void Initialize() { }

    // TODO
    public void Load(MonsNo monsNo) { }

    // TODO
    public void Load(PokemonParam param) { }

    // TODO
    public void Load(MonsNo monsNo, ushort formNo, Sex sex, bool isRare) { }

    // TODO
    public void Release() { }

    // TODO
    public void Play() { }

    // TODO
    private void PlayCutIn()
    {
        // TODO
        void ChangeDefaultLayer(GameObject self, int layer) { }
    }

    // TODO
    private static int GetAnimationIndex(BaseEntity entity, string clipName) { return 0; }

    // TODO
    private void End() { }

    // TODO
    public void Update(float deltaTime)
    {
        // TODO
        void SetPokemonPosX(float x) { }
    }

    // TODO
    public void ForceCaptureInvisible() { }

    // TODO
    private float GetParam(ParamIndex paramIndex) { return 0.0f; }

    // TODO
    private FieldWazaCutInParam.SheetPokemonParam GetPokemonParam(int uniqueId) { return null; }

    // TODO
    private void CalcPokemonPosRot(FieldWazaCutInParam.SheetPokemonParam param, out Vector3 pos, out Vector3 rot, out Vector3 scale)
    {
        pos = Vector3.zero;
        rot = Vector3.zero;
        scale = Vector3.zero;
    }

    // TODO
    private void SetEnviroment() { }

    // TODO
    private void ResetEnviroment() { }

    // TODO
    public EnvironmentSettings GetEnvironmentSettings() { return null; }

    // TODO
    private void SetupLightParam() { }

    // TODO
    private void SetupCamera() { }

    // TODO
    private void ResetCamera() { }

    private enum ParamIndex : int
    {
        CameraFov = 0,
        EffectZ = 1,
        EffectScale = 2,
        PokemonX = 3,
        PokemonY = 4,
        PokemonZ = 5,
        PokemonScale = 6,
        PokemonRotY = 7,
        PokemonAppearOfsX = 8,
        PokemonDisappearOfsX = 9,
        PokemonPreAppearTime = 10,
        PokemonAppearTime = 11,
        PokemonStopTime = 12,
        PokemonDisappearTime = 13,
        EffectPreKillTime = 14,
    }

    private enum CutInPhase : int
    {
        None = 0,
        Capture = 1,
        CaptureFadeIn = 2,
        WaitPlayEffect = 3,
        SetupLight = 4,
        PreAppear = 5,
        Appear = 6,
        Stop = 7,
        Disappear = 8,
        PreKill = 9,
    }

    private class CameraParamBackup
    {
	    private bool orthographic;
        private float farClipPlane;
        private float nearClipPlane;
        private float fieldOfView;
        private bool valid;

        public void Set(Camera camera)
        {
            orthographic = camera.orthographic;
            farClipPlane = camera.farClipPlane;
            nearClipPlane = camera.nearClipPlane;
            fieldOfView = camera.fieldOfView;
            valid = true;
        }

        public void Restore(Camera camera)
        {
            if (valid)
            {
                camera.orthographic = orthographic;
                camera.farClipPlane = farClipPlane;
                camera.nearClipPlane = nearClipPlane;
                camera.fieldOfView = fieldOfView;
            }
        }
    }
}