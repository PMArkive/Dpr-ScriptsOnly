using Pml;
using System;
using UnityEngine;
using XLSXContent;

namespace Dpr.SubContents
{
    [Serializable]
    public class BindModelSound
    {
        public Transform parent;
        public SoundType soundType;
        public string SoundName;
        public MonsNo Debug_Voice;
        [NonSerialized]
        public PokemonInfo.SheetCatalog catalog;
        public bool WaitFinish;

        // TODO
        public uint GetID() { return 0; }

        // TODO
        public void Destroy() { }

        public enum SoundType : int
        {
            BGM = 0,
            VOICE = 1,
            SE = 2,
        }
    }
}