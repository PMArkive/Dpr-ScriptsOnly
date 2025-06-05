using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace SmartPoint.Rendering
{
    [Serializable]
    public class ImageEffectObject : ScriptableObject
    {
        [SerializeField]
        private Material[] materials;
        protected Material[] materialInstances;

        public RenderTexture temporaryRT { get; set; }
        public bool enabled { get; set; } = true;
        public Camera camera { get; set; }
        public Transform target { get; set; }

        private int initializedCount;

        public virtual CommandBuffer Build(RenderTargetIdentifier sourceRT, out RenderTargetIdentifier resultRT, bool feedbackCameraTarget = true)
        {
            resultRT = sourceRT;
            return null;
        }

        protected void InstantiateMaterials()
        {
            int beforeCount = initializedCount;
            initializedCount++;

            if (beforeCount > 0)
                return;

            materialInstances = new Material[materials.Length];

            for (int i=0; i<materials.Length; i++)
                materialInstances[i] = new Material(materials[i]);
        }

        public virtual void Update()
        {
            // Empty
        }

        public virtual void Destroy()
        {
            if (initializedCount == 0)
                return;

            initializedCount--;

            for (int i=0; i<materialInstances.Length; i++)
                DestroyImmediate(materialInstances[i]);

            materialInstances = null;
        }
    }
}