using DG.Tweening;
using Dpr.SubContents;
using SmartPoint.AssetAssistant;
using SmartPoint.Rendering;
using System.Collections.Generic;
using UnityEngine;

namespace Dpr.Demo
{
    public class DemoCamera : MonoBehaviour
    {
        [Range(0.0f, 1.0f)]
        public float LeapValue;
        public Camera cam;
        [SerializeField]
        private List<Transform> CameraPosList;
        [SerializeField]
        private int DebugLeapPosIndex1;
        [SerializeField]
        private int DebugLeapPosIndex2 = 1;
        public const int RenderSettings_Gosanke = 0;
        public const int RenderSettings_Hakase = 1;
        public const int RenderSettings_DemoCommon = 2;
        public const int RenderSettings_UI02 = 3;
        public const int RenderSettings_UI04 = 4;
        public const int RenderSettings_PoffinEat = 5;
        public List<EnvironmentSettings> environmentSettings;
        private RenderTexture tex;
        private Animator animator;
        public PostProcessFilter postProcessFilter;
        [SerializeField]
        private float DebugDuration = 1.0f;
        [SerializeField]
        private Ease DebugEase = Ease.OutSine;
        [Button("DebugMove", "DebugMove", new object[0] { })]
        public int Button01;
        private AnimationClip _nowClip;
        private int TargetFrame;
        public string DebugAnimName;
        [Button("_DebugPlay", "_DebugPlay", new object[0] { })]
        public int Button02;

        private void Awake()
        {
            postProcessFilter = GetComponent<PostProcessFilter>();
        }

        public RenderTexture CreateRenderTex(bool isUseAlpha, bool isSetCamera = true)
        {
            if (tex != null)
                tex.Release();

            tex = null;

            tex = new RenderTexture(1280, 720, 24, (RenderTextureFormat)(isUseAlpha ? 2 : 0x16));
            tex.antiAliasing = 4;
            cam.targetTexture = null;

            if (isSetCamera)
                cam.targetTexture = tex;

            return tex;
        }

        private void OnValidate()
        {
            if (cam == null)
                cam = GetComponent<Camera>();

            if (CameraPosList.Count > 1 && DebugLeapPosIndex1 < CameraPosList.Count && DebugLeapPosIndex2 < CameraPosList.Count)
                LeapMove(CameraPosList[DebugLeapPosIndex1], CameraPosList[DebugLeapPosIndex2]);
        }

        private void OnDestroy()
        {
            if (tex != null)
                tex.Release();

            tex = null;
            cam = null;
            CameraPosList.Clear();
            CameraPosList = null;
            environmentSettings.Clear();
            environmentSettings = null;
            animator = null;
            postProcessFilter = null;
            _nowClip = null;
        }

        private void LeapMove(Transform tra1, Transform tra2)
        {
            if (tra1 == null || tra2 == null)
                return;

            cam.transform.position = Vector3.Lerp(tra1.position, tra2.position, LeapValue);
            cam.transform.localEulerAngles = Vector3.Lerp(tra1.localEulerAngles, tra2.localEulerAngles, LeapValue);
        }

        public void TweenMove(int PosIndex1, int PosIndex2, float duration)
        {
            var t = DOTween.To(() => LeapValue, x => LeapValue = x, 1.0f, duration);
            t.OnUpdate(() => LeapMove(CameraPosList[PosIndex1], CameraPosList[PosIndex2]));
        }

        public void DebugMove()
        {
            TweenMove(0, 1, DebugDuration);
        }

        public void SetAnimatorController(RuntimeAnimatorController controller)
        {
            animator = gameObject.AddComponent<Animator>();
            animator.runtimeAnimatorController = controller;
        }

        private AnimationClip nowClip
        {
            get
            {
                if (_nowClip == null)
                    _nowClip = animator.GetCurrentAnimatorClipInfo(0)[0].clip;
                return _nowClip;
            }
        }

        public void PlayAnim(string animName, float time = 0.0f)
        {
            animator.Play(animName, 0, time);
            animator.speed = 1.0f;
        }

        public void PauseAnim()
        {
            animator.speed = 0.0f;
        }

        public void ResumeAnim()
        {
            animator.speed = 1.0f;
        }

        public void SetPauseTargetFrame(int i_frame)
        {
            TargetFrame = i_frame;
            Sequencer.update += TargetFramePause;
        }

        public void UnSetPause()
        {
            Sequencer.update -= TargetFramePause;
        }

        private void TargetFramePause(float deltaTime)
        {
            if ((TargetFrame / nowClip.frameRate) / nowClip.length < animator.GetCurrentAnimatorStateInfo(0).normalizedTime)
            {
                PauseAnim();
                UnSetPause();
            }
        }

        public void PlayTargetFrame(int i_frame, string animName)
        {
            PlayAnim(animName, (TargetFrame / nowClip.frameRate) / nowClip.length);
        }

        public void _DebugPlay()
        {
            animator.Play(DebugAnimName, 0, 0.0f);
            animator.speed = 1.0f;
        }

        public void ResetPostProcess()
        {
            postProcessFilter.Reset();
        }
    }
}