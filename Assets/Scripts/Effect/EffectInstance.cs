using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;

namespace Effect
{
    public class EffectInstance : IObjectPoolInstance
    {
        private EffectData _effectData;
        private ParticleSystem _particleSystem;
        private ParticleSystemController _particleSystemController;
        private UnityAction<object> _onFinished;
        private UnityAction<EffectInstance> _onPlayFinished;
        private Transform _attachedTransform;
        private Vector3 _localPosition = Vector3.zero;
        private Quaternion _localRotation = Quaternion.identity;
        private Color _mulColor = Color.white;
        private float _stopFadeLifeTime;
        private float _stopFadeTime;

        public EffectData effectData { get => _effectData; set => _effectData = value; }
        public ParticleSystem particleSystem { get => _particleSystem; set => _particleSystem = value; }
        public GameObject gameObject
        {
            get
            {
                if (_particleSystem != null)
                    return _particleSystem.gameObject;

                return null;
            }
        }
        public string name
        {
            get
            {
                if (_particleSystem != null)
                    return _particleSystem.gameObject.name;

                return null;
            }
        }
        public Transform attachedTransform { get => _attachedTransform; }
        public Vector3 localPosition { get => _localPosition; }
        public Quaternion localRotation { get => _localRotation; }

        void IObjectPoolInstance.SetGameObject(GameObject obj)
        {
            _particleSystem = obj.GetComponent<ParticleSystem>();
        }

        GameObject IObjectPoolInstance.GetGameObject()
        {
            if (_particleSystem == null)
                return null;

            return _particleSystem.gameObject;
        }

        void IObjectPoolInstance.OnCreate()
        {
            // Empty
        }

        void IObjectPoolInstance.OnRelease()
        {
            // Empty
        }

        internal void _Setup(EffectData effectData, Vector3 position, Quaternion rotation, Transform attachedTransform, UnityAction<object> onFinished)
        {
            _effectData = effectData;

            SetupParticleSystemController(onFinished);

            if (attachedTransform != null)
            {
                _attachedTransform = attachedTransform;
                _localPosition = position;
                _localRotation = rotation;
            }
            else
            {
                _attachedTransform = null;
                ((IObjectPoolInstance)this).GetGameObject().transform.localRotation = rotation;
                ((IObjectPoolInstance)this).GetGameObject().transform.localPosition = position;
            }

            SetMultiplyColor(Color.white);

            _stopFadeLifeTime = 0.0f;
            _stopFadeTime = 0.0f;

            _UpdateTransform();
            UpdateFader(0.0f);
            _particleSystemController.OnUpdate(0.0f);
        }

        private void SetupParticleSystemController(UnityAction<object> onFinished)
        {
            _onFinished = onFinished;

            var controller = _particleSystem.gameObject.GetComponent<ParticleSystemController>();
            if (controller == null)
                controller = _particleSystem.gameObject.AddComponent<ParticleSystemController>();

            controller.Setup(_particleSystem, OnFinished, this);
            var main = _particleSystem.main;
            main.stopAction = ParticleSystemStopAction.Callback;

            _particleSystemController = controller;
        }

        private void OnFinished(object reference)
        {
            var onFinished = _onFinished;
            var onPlayFinished = _onPlayFinished;

            _onFinished = null;
            _onPlayFinished = null;
            _particleSystemController = null;
            _attachedTransform = null;

            onFinished?.Invoke(reference);
            onPlayFinished?.Invoke(this);
        }

        // TODO
        public EffectInstance Play([Optional] UnityAction<EffectInstance> onFinished)
        {
            return null;
        }

        public void Stop(float fadeTime = 0.0f, bool isForce = false)
        {
            if (fadeTime == 0.0f)
            {
                StopInternal(isForce);
            }
            else if (_stopFadeLifeTime <= 0.0f)
            {
                _stopFadeLifeTime = fadeTime;
                _stopFadeTime = 0.0f;
            }
        }

        // TODO
        private void StopInternal(bool isForce) { }

        internal bool _Update(float deltaTime)
        {
            UpdateFader(deltaTime);
            return _particleSystemController.OnUpdate(deltaTime);
        }

        // TODO
        private void UpdateFader(float deltaTime) { }

        // TODO
        internal void _UpdateTransform() { }

        public static void MatrixMultiply4x3(out Matrix4x4 mT, ref Matrix4x4 lhs, ref Matrix4x4 rhs)
        {
            mT.m00 = lhs.m00 * rhs.m00 + lhs.m10 * rhs.m01 + lhs.m20 * rhs.m02;
            mT.m10 = lhs.m00 * rhs.m10 + lhs.m10 * rhs.m11 + lhs.m20 * rhs.m12;
            mT.m20 = lhs.m00 * rhs.m20 + lhs.m10 * rhs.m21 + lhs.m20 * rhs.m22;
            mT.m30 = 0.0f;

            mT.m01 = lhs.m01 * rhs.m00 + lhs.m11 * rhs.m01 + lhs.m21 * rhs.m02;
            mT.m11 = lhs.m01 * rhs.m10 + lhs.m11 * rhs.m11 + lhs.m21 * rhs.m12;
            mT.m21 = lhs.m01 * rhs.m20 + lhs.m11 * rhs.m21 + lhs.m21 * rhs.m22;
            mT.m31 = 0.0f;

            mT.m02 = lhs.m02 * rhs.m00 + lhs.m12 * rhs.m01 + lhs.m22 * rhs.m02;
            mT.m12 = lhs.m02 * rhs.m10 + lhs.m12 * rhs.m11 + lhs.m22 * rhs.m12;
            mT.m22 = lhs.m02 * rhs.m20 + lhs.m12 * rhs.m21 + lhs.m22 * rhs.m22;
            mT.m32 = 0.0f;

            mT.m03 = lhs.m03 * rhs.m00 + lhs.m13 * rhs.m01 + lhs.m23 * rhs.m02 + rhs.m03;
            mT.m13 = lhs.m03 * rhs.m10 + lhs.m13 * rhs.m11 + lhs.m23 * rhs.m12 + rhs.m13;
            mT.m23 = lhs.m03 * rhs.m20 + lhs.m13 * rhs.m21 + lhs.m23 * rhs.m22 + rhs.m23;
            mT.m33 = 1.0f;
        }

        public void SetMultiplyColor(Color mulColor)
        {
            if (_particleSystemController != null)
            {
                _mulColor = mulColor;
                _particleSystemController.SetMultiplyColor(_mulColor);
            }
        }

        public Color GetMulColor()
        {
            return _mulColor;
        }

        public void SetTransformParent(Transform parent, bool worldPositionStays)
        {
            if (((IObjectPoolInstance)this).GetGameObject() != null)
                ((IObjectPoolInstance)this).GetGameObject().transform.SetParent(parent, worldPositionStays);
        }

        public void RestoreTransformParent()
        {
            SetTransformParent(EffectManager.Instance.transform, false);
        }
    }
}