using Dpr;

public class FieldMistWork
{
    private EnvironmentSettings currentSetting;
    private EnvironmentSettings mistSetting;
    private FieldFloatMove mistWeight = new FieldFloatMove();

    // TODO
    public static bool CheckMistWeather() { return false; }

    // TODO
    public static bool AvailableKiribarai() { return false; }

    // TODO
    public EnvironmentSettings GetCurrentSetting() { return null; }

    public bool IsEnable { get => mistWeight.IsBusy || mistWeight.CurrentValue > 0.0f; }

    // TODO
    public void Setup() { }

    // TODO
    private EnvironmentSettings GetBaseSetting(ZoneID zoneId) { return null; }

    // TODO
    public void Update(float deltaTime) { }

    // TODO
    public void ChangeMist(float target, float time = 0.0f) { }

    // TODO
    private void CalcCurrentSetting() { }

    // TODO
    private void BlendSetting(EnvironmentSettings.Parameters paramA, EnvironmentSettings.Parameters paramB, float weight, EnvironmentSettings.Parameters refOutParam) { }

    // TODO
    private void CreateMistEffectSetting() { }

    // TODO
    private void OverrideParameter(EnvironmentSettings.Parameters param, int paramHeadIndex)
    {
        // TODO
        float Get() { return default; }
    }
}