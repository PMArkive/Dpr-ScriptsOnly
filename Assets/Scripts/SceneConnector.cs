using Dpr.EvScript;
using SmartPoint.AssetAssistant;
using SmartPoint.Components;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneConnector : MonoBehaviour
{
    [SerializeField]
    public SceneID sceneID = SceneID.Title;
    [SerializeField]
    public string scenePath = string.Empty;
    [SerializeField]
    public Camera mainCamera;
    [SerializeField]
    public Camera reflectionCamera;
    [SerializeField]
    protected Transform _bgCacheObjects;
    [SerializeField]
    protected Transform _characterCacheObjects;

    private PeriodOfDay _fixedPeriodOfDay;
    public bool IsEnableUpdate = true;
    private bool IsRenderSettingsDirty;

    public virtual IEnumerator PrepareOperation()
    {
        yield return null;
    }

    public virtual IEnumerator SetupOperation()
    {
        ClearBGCache();
        ClearCharacterCache();
        yield return null;
    }

    public virtual bool SwitchingOperation(SceneID target)
    {
        return sceneID != target;
    }

    public Scene scene { get; set; }

    public EnvironmentSettings renderSettings;
    public EnvironmentController environmentController;

    public Transform bgCacheObjects { get => _bgCacheObjects; }
    public Transform characterCacheObjects { get => _characterCacheObjects; }

    [SceneBeforeActivateOperationMethod]
    private IEnumerator ActivateOperation(Transform cluster)
    {
        scene = cluster.gameObject.scene;
        environmentController = cluster.GetComponentInChildren<EnvironmentController>(true);
        GameManager.connector = this;
        Fader.valid = false;
        yield return null;
    }

    public virtual void OnEnable()
    {
        Sequencer.update -= OnUpdate;

        _fixedPeriodOfDay = GameManager.currentPeriodOfDay;
        if (renderSettings != null && sceneID == SceneID.Battle)
            EnvironmentController.global.SetLight(renderSettings, GameManager.currentPeriodOfDay, 0.0f, 0.0f);

        Sequencer.update += OnUpdate;
    }

    public void ResetLight(bool isForceCurrentPeriodOfDay = true)
    {
        if (renderSettings == null)
            return;

        if (sceneID == SceneID.Battle)
        {
            if (isForceCurrentPeriodOfDay)
            {
                EnvironmentController.global.SetLight(renderSettings, GameManager.currentPeriodOfDay, 0.0f, 0.0f);
                _fixedPeriodOfDay = GameManager.currentPeriodOfDay;
            }
            else
            {
                EnvironmentController.global.SetLight(renderSettings, _fixedPeriodOfDay, 0.0f, 0.0f);
            }
        }
        else
        {
            EnvironmentController.global.SetLight(renderSettings, GameManager.currentPeriodOfDay, 0.0f, 0.0f);
        }
    }

    public virtual void OnDisable()
    {
        Sequencer.update -= OnUpdate;
    }

    public virtual void OnUpdate(float deltaTime)
    {
        if (!IsEnableUpdate)
            return;

        if (renderSettings == null)
            return;

        if (sceneID != SceneID.Field && sceneID != SceneID.Battle)
            return;

        if (sceneID == SceneID.Battle || PlayerWork.zoneID == ZoneID.UNKNOWN)
        {
            ResetLight(false);
            return;
        }

        (PeriodOfDay, float, float) podEx = GameManager.currentPeriodOfDayEx;

        if (FieldManager.Instance != null)
        {
            if (EvDataManager.Instanse.FieldWazaCutIn.IsBusy && EvDataManager.Instanse.FieldWazaCutIn.IsOverrideEnvironmentSettings)
            {
                renderSettings = EvDataManager.Instanse.FieldWazaCutIn.GetEnvironmentSettings();
                IsRenderSettingsDirty = true;
                podEx.Item1 = PeriodOfDay.Daytime;
            }
            else if (FieldManager.Instance.MistWork.IsEnable)
            {
                FieldManager.Instance.MistWork.Update(deltaTime);
                renderSettings = FieldManager.Instance.MistWork.GetCurrentSetting();
                IsRenderSettingsDirty = true;
            }
            else
            {
                if (IsRenderSettingsDirty)
                {
                    renderSettings = GameManager.mapInfo[(int)PlayerWork.zoneID].RenderSettings;
                    IsRenderSettingsDirty = false;
                }
            }
        }

        if (GameManager.mapInfo[(int)PlayerWork.zoneID].FixedTime)
        {
            EnvironmentController.global.SetLight(renderSettings, PeriodOfDay.Daytime, 0.0f, 0.0f);
            EnvironmentController.global._EmissionThreshold = (podEx.Item2 + (int)podEx.Item1) * 0.2f;
            return;
        }

        EnvironmentController.global.SetLight(renderSettings, podEx.Item1, podEx.Item2, podEx.Item3);
    }

    // TODO: Unsure on if this is what this method does
    public void ClearBGCache()
    {
        if (_bgCacheObjects == null)
            return;

        foreach (Transform t in _bgCacheObjects)
            Object.Destroy(t.gameObject);
    }

    // TODO: Unsure on if this is what this method does
    public void ClearCharacterCache()
    {
        if (_characterCacheObjects == null)
            return;

        foreach (Transform t in _characterCacheObjects)
            Object.Destroy(t.gameObject);
    }
}