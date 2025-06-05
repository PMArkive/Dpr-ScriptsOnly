using Effect;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldEffect : EffectActivator
{
    [SerializeField]
    private EffectFieldID _effectId;
    private EffectInstance _effectInstance;
    private EffectData _effectData;
    private static List<FieldEffect> requests = new List<FieldEffect>();

    public EffectManager.FieldLoadParam param { get => EffectManager.Instance.dbEffects.FieldEffectData[(int)_effectId]; }
    public EffectInstance effectInstance { get => _effectInstance; set => _effectInstance = value; }

    public static void AppendRequest(FieldEffect fieldEffect)
    {
        requests.Add(fieldEffect);
    }

    // TODO
    public static IEnumerator DispathRequests() { return null; }

    // TODO
    protected override IEnumerator OnActivateOperation() { return null; }

    // TODO
    private void OnDestroy() { }
}