using System;
using UnityEngine;

namespace SmartPoint.Components
{
    [Serializable]
    public struct SkinnedMeshRendererCluster
    {
        [SerializeField]
        public Transform node;

        [SerializeField]
        public SkinnedMeshRenderer[] renderers;
    }
}