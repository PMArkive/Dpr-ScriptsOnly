using System;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/PokemonWalkingDatas", fileName = "PokemonWalkingDatas")]
[Serializable]
public class PokemonWalkingDatas : ScriptableObject
{
    [SerializeField]
    public Preset presetS;
    [SerializeField]
    public Preset presetM;
    [SerializeField]
    public Preset presetL;
    [SerializeField]
    public Preset presetLL;
    [SerializeField]
    public Parameters[] list;
    [NonSerialized]
    public int currentIndex;
    [NonSerialized]
    public bool debugBoundsEnable;

    public Parameters currentData { get => list[currentIndex]; }

    public Preset GetPreset(int size)
    {
        switch (size)
        {
            case 0:
                return presetS;
            case 1:
                return presetM;
            case 2:
                return presetL;
            case 3:
                return presetLL;
            default:
                return presetS;
        }
    }

    [Serializable]
    public class Preset
    {
        public float scale = 1.0f;
        public float radius = 1.0f;
        public float falloffNear = 1.25f;
        public float falloffFar = 1.75f;
        public float walkSpeed = 0.4f;
        public float runSpeed = 0.6f;
        public float walkThreshold = 2.5f;
        public float runThreshold = 3.75f;
        public float eraseThreshold = 8.5f;
    }

    [Serializable]
    public class Parameters
    {
        public int index;
        public int size = 1;
        public float scale = 1.0f;
        public float radius = 1.0f;
        public float falloffNear = 1.25f;
        public float falloffFar = 1.75f;
        public float walkSpeed = 0.4f;
        public float runSpeed = 0.6f;
        public float walkThreshold = 2.5f;
        public float runThreshold = 3.75f;
        public float eraseThreshold = 8.5f;
        public bool footEffectEnable;
    }
}