using SmartPoint.AssetAssistant;
using System.Collections;
using UnityEngine;

[DisallowMultipleComponent]
public class EffectActivator : MonoBehaviour
{
    // TODO
    [SceneBeforeActivateOperationMethod]
    public IEnumerator ActivateOperation(Transform cluster) { return null; }

    // TODO
    protected virtual IEnumerator OnActivateOperation() { return null; }
}