using Dpr.Battle.View.Systems;
using SmartPoint.AssetAssistant;
using System.Collections;
using UnityEngine;

namespace Dpr.Battle.View
{
    public sealed class BattleViewCore : SingletonMonoBehaviour<BattleViewCore>
    {
        [SerializeField]
        private Material _shadowCastMaterial;
        private Transform _cluster;

        public BattleViewSystem ViewSystem { get; set; }
        public BattleViewUISystem UISystem { get; set; }
        public Transform Cluster { get => _cluster; }
        public Material ShadowCastMaterial { get => _shadowCastMaterial; }

        // TODO
        private void OnDestroy() { }

        // TODO
        private void OnEnable() { }

        // TODO
        private void OnDisable() { }

        // TODO
        private void OnUpdate(float deltaTime) { }

        // TODO
        private void OnLateUpdate(float deltaTime) { }

        // TODO
        private void OnResume(int value) { }

        // TODO
        public IEnumerator InitializeSystem(BattleViewSystem pViewSystem) { return null; }
    }
}