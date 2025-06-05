using DPData;
using System;
using UnityEngine.Events;

public static class ConfigWork
{
    public const int MAX_VOLUME = 10;
    public static UnityAction<ConfigID, int> onValueChanged;

    // TODO
    public static void Initialize(ref CONFIG config) { }

    // TODO
    public static void Reset(ref CONFIG config) { }

    private static void CheckAndInvokeChangedValues(ref CONFIG config, ref CONFIG prevConfig)
    {
        var configs = Enum.GetNames(typeof(ConfigID));
        for (int i=0; i<configs.Length; i++)
        {
            if (config.IsEqualValue((ConfigID)i, ref prevConfig))
                onValueChanged?.Invoke((ConfigID)i, config.GetValue((ConfigID)i));
        }
    }

    public static void InvokeChangedValues(ref CONFIG config)
    {
        var configs = Enum.GetNames(typeof(ConfigID));
        for (int i=0; i<configs.Length; i++)
            onValueChanged?.Invoke((ConfigID)i, config.GetValue((ConfigID)i));
    }
}