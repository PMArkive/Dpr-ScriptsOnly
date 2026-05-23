using SmartPoint.Mathematics;
using System.Collections.Generic;
using UnityEngine;

namespace SmartPoint.Components
{
    [RequireComponent(typeof(Camera))]
    [DisallowMultipleComponent]
    public class RenderPriorityController : MonoBehaviour
    {
        private Camera _camera;
        private static Dictionary<Transform, List<(Transform, SkinnedMeshRenderer[])>> _clusterAndTransforms = new Dictionary<Transform, List<(Transform, SkinnedMeshRenderer[])>>();

        private void Awake()
        {
            _camera = GetComponent<Camera>();
        }

        public static void Register(Transform root, SkinnedMeshRendererCluster[] clusters)
        {
            for (int i=0; i<clusters.Length; i++)
                Register(root, clusters[i].node, clusters[i].renderers);
        }

        public static void Register(Transform root, Transform group, SkinnedMeshRenderer[] prioritySortedRenderers)
        {
            if (prioritySortedRenderers == null)
                return;

            if (prioritySortedRenderers.Length == 0)
                return;

            // Result ignored
            _ = prioritySortedRenderers[0].rootBone;

            if (group == null)
                group = prioritySortedRenderers[0].transform.parent;

            if (!_clusterAndTransforms.TryGetValue(root, out List<(Transform, SkinnedMeshRenderer[])> value))
            {
                value = new List<(Transform, SkinnedMeshRenderer[])>();
                _clusterAndTransforms.Add(root, value);
            }

            value.Add((group, prioritySortedRenderers));
        }

        public static void Unregister(Transform root)
        {
            _clusterAndTransforms.Remove(root);
        }

        // TODO: There are some weird assignments in the foreach, double-check those
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
                    for (int i=0; i<list.Count-1; i++)
                    {
                        var pos = list[i].Item1.position;
                        var nextPos = list[i+1].Item1.position;

                        if (pos.FastDistanceSq(cameraPos) < nextPos.FastDistanceSq(cameraPos))
                        {
                            var nextTf = list[i+1].Item1;
                            var nextRenderers = list[i+1].Item2;

                            list[i+1] = (list[i].Item1, list[i].Item2);
                            list[i] = (nextTf, nextRenderers);
                        }
                    }
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