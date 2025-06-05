using Dpr;
using FieldCommon;
using GameData;
using SmartPoint.AssetAssistant;
using UnityEngine;

public class FieldFlashWork
{
    private AssetRequestOperation LoadRequest;
    private GameObject LoadedDarkObject;
    private FieldFloatMove DarkRate = new FieldFloatMove();

    public static bool CheckFlashWeather()
    {
        return WeatherWork.WeatherID == SYS_WEATHER.FLASH;
    }

    public static bool AvailableFlash()
    {
        return CheckFlashWeather() && !PlayerWork.Flash;
    }

    public void Load()
    {
        DarkRate.EaseFunc = FieldFloatMove.EaseInOutSin;

        if (LoadRequest != null)
            return;

        LoadRequest = AssetManager.AppendAssetBundleRequest("gimmick/obj0013_01", true, (type, name, content) =>
        {
            if (type != RequestEventType.Activated)
                return;

            LoadedDarkObject = content as GameObject;
        }, null);
        AssetManager.DispatchRequests(null);
    }

    public void Release()
    {
        if (GameManager.fieldCamera != null)
            GameManager.fieldCamera.DestroyDarkWindow();

        if (LoadRequest != null)
        {
            AssetManager.UnloadAssetBundle(LoadRequest.assetBundleRequest.uri);
            LoadRequest = null;
        }
    }

    public bool IsValid { get => LoadedDarkObject != null; }
    public bool IsEnable { get => IsValid && (DarkRate.IsBusy || DarkRate.CurrentValue > 0.0f); }

    public void Update(float deltaTime)
    {
        if (DarkRate.IsBusy)
        {
            DarkRate.Update(deltaTime);
            UpdateDark();
        }
    }

    public void ChangeDark(float target, float time = 0.0f)
    {
        if (time > 0.0f)
        {
            DarkRate.MoveTime(target, time);
        }
        else
        {
            DarkRate.SetValue(target);
            UpdateDark();
        }
    }

    private void UpdateDark()
    {
        if (GameManager.fieldCamera.GetDarkWindow() == null)
            GameManager.fieldCamera.InstantiateDarkWindow(LoadedDarkObject);

        if (DarkRate.CurrentValue > 0.0f)
        {
            GameManager.fieldCamera.GetDarkWindow().SetActive(true);
            float flashScale = DataManager.FieldCommonParam[(int)ParamIndx.FlashDark_FlashScale].param;
            float darkScale = DataManager.FieldCommonParam[(int)ParamIndx.FlashDark_DarkScale].param;
            float size = Mathf.Lerp(flashScale, darkScale, DarkRate.CurrentValue);
            GameManager.fieldCamera.GetDarkWindow().transform.localScale = new Vector3(size, 1.0f, size);
        }
        else
        {
            GameManager.fieldCamera.GetDarkWindow().SetActive(false);
        }
    }
}