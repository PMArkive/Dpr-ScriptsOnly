using System;
using System.Collections.Generic;
using UnityEngine;

namespace SmartPoint.Components
{
    [RequireComponent(typeof(Camera))]
    [DisallowMultipleComponent]
    public class RenderPriorityController : MonoBehaviour
    {
        private Camera _camera;
        private static Dictionary<Transform, List<ValueTuple<Transform, SkinnedMeshRenderer[]>>> _clusterAndTransforms = new Dictionary<Transform, List<(Transform, SkinnedMeshRenderer[])>>();

        // TODO
        private void Awake() { }

        // TODO
        public static void Register(Transform root, SkinnedMeshRendererCluster[] clusters) { }

        // TODO
        public static void Register(Transform root, Transform group, SkinnedMeshRenderer[] prioritySortedRenderers) { }

        // TODO
        public static void Unregister(Transform root) { }

        // TODO
        private void OnPreCull() { }
    }
}