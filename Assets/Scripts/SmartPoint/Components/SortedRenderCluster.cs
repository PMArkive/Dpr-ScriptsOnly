using UnityEngine;

namespace SmartPoint.Components
{
    public class SortedRenderCluster : MonoBehaviour
    {
        [SerializeField]
        public SkinnedMeshRendererCluster[] rendererClusters;

        protected void OnEnable()
        {
            RenderPriorityController.Register(transform, rendererClusters);
        }

        protected void OnDisable()
        {
            RenderPriorityController.Unregister(transform);
        }
    }
}