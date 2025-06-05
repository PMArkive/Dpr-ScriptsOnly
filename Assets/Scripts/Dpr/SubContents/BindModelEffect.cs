using Effect;
using System;
using UnityEngine;

namespace Dpr.SubContents
{
    [Serializable]
    public class BindModelEffect
    {
        public bool StartActive;
        public Transform parent;
        public string EffectName;
        [NonSerialized]
        public EffectData EffData;

        // TODO
        public EffectFieldID GetEffectID() { return EffectFieldID.NONE; }

        // TODO
        public void Destroy() { }
    }
}