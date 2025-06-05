using Effect;
using Pml;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dpr.SecretBase
{
    public class SecretBaseCrystalEffectManager : MonoBehaviour
    {
        [SerializeField]
        private Transform crystalRoot;

        private const int EffectLevelMax = 3;

        private List<EffectFieldID> effectIds = new List<EffectFieldID>()
        {
            EffectFieldID.EF_F_CRYSTAL_NORMAL_03,
            EffectFieldID.EF_F_CRYSTAL_NORMAL_02,
            EffectFieldID.EF_F_CRYSTAL_NORMAL_01,
            EffectFieldID.EF_F_CRYSTAL_FIGHTING_03,
            EffectFieldID.EF_F_CRYSTAL_FIGHTING_02,
            EffectFieldID.EF_F_CRYSTAL_FIGHTING_01,
            EffectFieldID.EF_F_CRYSTAL_FLYING_03,
            EffectFieldID.EF_F_CRYSTAL_FLYING_02,
            EffectFieldID.EF_F_CRYSTAL_FLYING_01,
            EffectFieldID.EF_F_CRYSTAL_POISON_03,
            EffectFieldID.EF_F_CRYSTAL_POISON_02,
            EffectFieldID.EF_F_CRYSTAL_POISON_01,
            EffectFieldID.EF_F_CRYSTAL_GROUND_03,
            EffectFieldID.EF_F_CRYSTAL_GROUND_02,
            EffectFieldID.EF_F_CRYSTAL_GROUND_01,
            EffectFieldID.EF_F_CRYSTAL_ROCK_03,
            EffectFieldID.EF_F_CRYSTAL_ROCK_02,
            EffectFieldID.EF_F_CRYSTAL_ROCK_01,
            EffectFieldID.EF_F_CRYSTAL_BUG_03,
            EffectFieldID.EF_F_CRYSTAL_BUG_02,
            EffectFieldID.EF_F_CRYSTAL_BUG_01,
            EffectFieldID.EF_F_CRYSTAL_GHOST_03,
            EffectFieldID.EF_F_CRYSTAL_GHOST_02,
            EffectFieldID.EF_F_CRYSTAL_GHOST_01,
            EffectFieldID.EF_F_CRYSTAL_STEEL_03,
            EffectFieldID.EF_F_CRYSTAL_STEEL_02,
            EffectFieldID.EF_F_CRYSTAL_STEEL_01,
            EffectFieldID.EF_F_CRYSTAL_FIRE_03,
            EffectFieldID.EF_F_CRYSTAL_FIRE_02,
            EffectFieldID.EF_F_CRYSTAL_FIRE_01,
            EffectFieldID.EF_F_CRYSTAL_WATER_03,
            EffectFieldID.EF_F_CRYSTAL_WATER_02,
            EffectFieldID.EF_F_CRYSTAL_WATER_01,
            EffectFieldID.EF_F_CRYSTAL_GRASS_03,
            EffectFieldID.EF_F_CRYSTAL_GRASS_02,
            EffectFieldID.EF_F_CRYSTAL_GRASS_01,
            EffectFieldID.EF_F_CRYSTAL_ELECTRIC_03,
            EffectFieldID.EF_F_CRYSTAL_ELECTRIC_02,
            EffectFieldID.EF_F_CRYSTAL_ELECTRIC_01,
            EffectFieldID.EF_F_CRYSTAL_PSYCHIC_03,
            EffectFieldID.EF_F_CRYSTAL_PSYCHIC_02,
            EffectFieldID.EF_F_CRYSTAL_PSYCHIC_01,
            EffectFieldID.EF_F_CRYSTAL_ICE_03,
            EffectFieldID.EF_F_CRYSTAL_ICE_02,
            EffectFieldID.EF_F_CRYSTAL_ICE_01,
            EffectFieldID.EF_F_CRYSTAL_DRAGON_03,
            EffectFieldID.EF_F_CRYSTAL_DRAGON_02,
            EffectFieldID.EF_F_CRYSTAL_DRAGON_01,
            EffectFieldID.EF_F_CRYSTAL_DARK_03,
            EffectFieldID.EF_F_CRYSTAL_DARK_02,
            EffectFieldID.EF_F_CRYSTAL_DARK_01,
            EffectFieldID.EF_F_CRYSTAL_FARIY_03,
            EffectFieldID.EF_F_CRYSTAL_FAIRY_02,
            EffectFieldID.EF_F_CRYSTAL_FAIRY_01,
        };
        private readonly Dictionary<int, EffectData> effectData = new Dictionary<int, EffectData>();
        private EffectInstance effecttInstance;

        public bool IsLoadCompleted { get; set; }

        // TODO
        public void PlayCrystalEffect(PokeType type, int level) { }

        // TODO
        public void StopyCrystalEffect() { }

        // TODO
        private void Play(int index) { }

        // TODO
        public IEnumerator Load() { return default; }

        // TODO
        private void OnDestroy() { }

        // TODO
        private void Clear() { }
    }
}