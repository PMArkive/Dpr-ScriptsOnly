using UnityEngine;

namespace SmartPoint.AssetAssistant
{
    public abstract class SequenceMonoBehaviour : MonoBehaviour
    {
        protected virtual void OnEnable()
        {
            Sequencer.update += OnUpdate;
        }

        protected virtual void OnDisable()
        {
            Sequencer.update -= OnUpdate;
        }

        protected abstract void OnUpdate(float deltaTime);
    }
}