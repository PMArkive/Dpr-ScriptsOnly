using SmartPoint.AssetAssistant;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dpr.Battle.View.Systems
{
    public sealed class BattleShadowCastSystem : IDisposable
    {
        private const string SHADOW_CAST_SHADER_NAME = "Dpr/Objects/ShadowCast";
        public const string SHADOW_CAST_OBJECT_LAYER_NAME = "Field";
        private List<ShadowCastObject> _castObjects;
        private Material _shadowCastMaterial;
        private bool _isDraw;

        public bool IsDraw
        {
            get
            {
                return _isDraw;
            }
            set
            {
                // TODO
            }
        }

        public BattleShadowCastSystem()
        {
            _castObjects = new List<ShadowCastObject>(4);
            _shadowCastMaterial = new Material(AssetManager.FindShader(SHADOW_CAST_SHADER_NAME));
            _isDraw = true;
        }

        // TODO
        public void Dispose() { }

        // TODO
        public void Register(ShadowCastObject shadowCastObject) { }

        // TODO
        public void OnLateUpdate(float deltaTime) { }
    }
}
