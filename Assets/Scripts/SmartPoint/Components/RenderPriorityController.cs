using SmartPoint.Mathematics;
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

        private void Awake()
        {
            _camera = GetComponent<Camera>();
        }

        // TODO
        public static void Register(Transform root, SkinnedMeshRendererCluster[] clusters) { }

        // TODO
        public static void Register(Transform root, Transform group, SkinnedMeshRenderer[] prioritySortedRenderers) { }

        // TODO
        public static void Unregister(Transform root) { }

        // TODO
        private void OnPreCull()
        {
            var bounds = new Bounds();
            bounds.extents = new Vector3(1000.0f, 1000.0f, 1000.0f);

            var cameraPos = _camera.transform.position;

            foreach (var kvp in _clusterAndTransforms)
            {
                var list = kvp.Value;

                if (0 < list.Count - 1)
                {

                }

                var targetPos = list[0].Item1.transform.position;
                var dist = new Vector3(cameraPos.x - targetPos.x, cameraPos.y - targetPos.y, cameraPos.z - targetPos.z);
                dist.FastNormalize();

                var totalRenderers = 0;
                foreach (var tuple in list)
                {
                    var renderers = tuple.Item2;
                    for (int i=0; i<renderers.Length; i++)
                    {
                        var currentOffset = (totalRenderers + i) * 0.001f;
                        var tfPos = new Vector3(targetPos.x + currentOffset * dist.x, targetPos.y + currentOffset * dist.y, targetPos.z + currentOffset * dist.z);
                        bounds.center = renderers[i].rootBone.InverseTransformPoint(tfPos);
                        renderers[i].localBounds = bounds;
                    }

                    totalRenderers += renderers.Length;
                }
            }
        }
    }
}