using UnityEngine;

namespace Dpr.UI
{
    public class ModelViewReflectionCamera : MonoBehaviour
    {
        [SerializeField]
        private Material _material;
        [SerializeField]
        private Camera _camera;
        private readonly int _propBgTexture = Shader.PropertyToID("_BgTex");
        private readonly int _propAlpha = Shader.PropertyToID("_Alpha");

        public Camera camera { get => _camera; }

        private void Awake()
        {
            _camera = GetComponent<Camera>();
        }

        private void OnPreRender()
        {
            GL.invertCulling = true;
        }

        private void OnPostRender()
        {
            GL.invertCulling = false;
        }

        public void SetBgTexture(Texture bgTexture)
        {
            _material.SetTexture(_propBgTexture, bgTexture);
        }

        public void SetAlpha(float alpha)
        {
            _material.SetFloat(_propAlpha, alpha);
        }

        private void OnRenderImage(RenderTexture src, RenderTexture dest)
        {
            Graphics.Blit(src, dest, _material);
        }
    }
}