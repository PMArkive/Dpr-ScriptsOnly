using System.Collections.Generic;
using UnityEngine;

namespace Dpr.FureaiHiroba
{
    public class PokeEffect
    {
        private Dictionary<string, GameObject> Effects = new Dictionary<string, GameObject>();
        private Transform transform;

        public PokeEffect(Transform tra)
        {
            transform = tra;
        }

        public void Destroy()
        {
            Effects.Clear();
            transform = null;
        }

        // TODO
        public void PlayEffect(GameObject go, string name, float bodySize) { }

        // TODO
        private void PlayEffLoop(ParticleSystem eff, float LoopInterval) { }

        public void CancelEff(string name)
        {
            if (Effects.ContainsKey(name))
            {
                Object.Destroy(Effects[name].gameObject);
                Effects.Remove(name);
            }
        }
    }
}