using SmartPoint.AssetAssistant;
using System;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;

namespace SmartPoint.Rendering
{
    [CreateAssetMenu(fileName = "DepthOfField", menuName = "ScriptableObjects/ImageEffect/DepthOfField")]
    public class DepthOfField : ImageEffectObject
    {
        private static readonly int BLUROFFSET_X = Shader.PropertyToID("_BlurOffsetX");
        private static readonly int BLUROFFSET_Y = Shader.PropertyToID("_BlurOffsetY");
        private static readonly int TEMPORARY_RT = Shader.PropertyToID("_DownscaleRT_T");
        private static readonly int DEPTH_RT = Shader.PropertyToID("_DownscaleDepthRT_T");
        private static readonly int BLUR_TEX = Shader.PropertyToID("_BlurTex");
        private static readonly int STRONGER_BLUR_TEX = Shader.PropertyToID("_StrongerBlurTex");
        private static readonly int FOCUS_TEX = Shader.PropertyToID("_FocusTex");
        private static readonly int FOCAL_COEFF = Shader.PropertyToID("_FocalCoefficient");
        public static OnBuildCallback onBuild;
        public static OnRelaseCallback onRelease;

        public float farDepth { get; set; }
        public float focalLength { get; set; }
        public float distance { get; set; }
        public float sensorScale { get; set; } = 1.0f;
        public Vector3 targetOffset { get; set; } = Vector3.zero;
        public Camera shootingCamera { get; set; }
        public static float blurry { get; set; } = 1.0f;

        public static DepthOfField instance = null;
        private RenderTexture downscaledRT;
        private RenderTexture blurredRT;

        public RenderTexture renderTexture { get => downscaledRT; }
        public RenderTexture strongerBlurTexture { get => blurredRT; }
        public Material downsampleMaterial { get => materialInstances[0]; }
        public Material blurMaterial { get => materialInstances[1]; }
        public Vector4 blurOffset { get => new Vector4(-2.218315f, 2.218315f, -0.607793f, 0.607793f); }

        // TODO: Put back GraphicsFormat.None on the calls to GetTemporaryRT eventually, they output a lot of errors with it currently tho
        public override CommandBuffer Build(RenderTargetIdentifier sourceRT, out RenderTargetIdentifier resultRT, bool feedbackCameraTarget = true)
        {
            Destroy();
            InstantiateMaterials();

            var buffer = new CommandBuffer();
            buffer.name = "DepthOfField";

            int shaderID;
            RenderTargetIdentifier tempTarget;
            if (temporaryRT != null)
            {
                tempTarget = new RenderTargetIdentifier(temporaryRT);
                shaderID = -1;
            }
            else
            {
                shaderID = Shader.PropertyToID("_TemporaryRT");
                buffer.GetTemporaryRT(shaderID, -1, -1, 0, FilterMode.Bilinear); // GraphicsFormat.None
                tempTarget = shaderID;
                buffer.Blit(BuiltinRenderTextureType.CameraTarget, shaderID);
            }

            int width = Sequencer.screenWidth;
            if (width < 0)
                width++;

            int height = Sequencer.screenHeight;
            if (height < 0)
                height++;

            downscaledRT = new RenderTexture(width / 2, height / 2, 0, DefaultFormat.LDR);
            downscaledRT.wrapMode = TextureWrapMode.Clamp;
            downscaledRT.autoGenerateMips = false;
            downscaledRT.Create();

            blurredRT = new RenderTexture(width / 4, height / 4, 0, DefaultFormat.LDR);
            blurredRT.wrapMode = TextureWrapMode.Clamp;
            blurredRT.autoGenerateMips = false;
            blurredRT.Create();

            buffer.GetTemporaryRT(DEPTH_RT, width / 2, height / 2, 0, FilterMode.Point, GraphicsFormat.R16G16B16A16_SNorm);
            buffer.GetTemporaryRT(TEMPORARY_RT, width / 2, height / 2, 0, FilterMode.Point, GraphicsFormat.R16G16B16A16_SNorm);

            buffer.Blit(sourceRT, DEPTH_RT, downsampleMaterial);
            buffer.Blit(DEPTH_RT, TEMPORARY_RT, blurMaterial);
            buffer.Blit(TEMPORARY_RT, DEPTH_RT, materialInstances[4]);

            buffer.ReleaseTemporaryRT(TEMPORARY_RT);
            materialInstances[2].SetTexture(BLUR_TEX, downscaledRT);
            materialInstances[2].SetTexture(STRONGER_BLUR_TEX, blurredRT);

            buffer.GetTemporaryRT(TEMPORARY_RT, width / 2, height / 2, 0, FilterMode.Bilinear); // GraphicsFormat.None
            buffer.SetGlobalTexture(FOCUS_TEX, DEPTH_RT);
            buffer.Blit(sourceRT, downscaledRT, materialInstances[5]);

            buffer.SetGlobalVector(BLUROFFSET_X, blurOffset);
            buffer.SetGlobalVector(BLUROFFSET_Y, Vector4.zero);
            buffer.Blit(downscaledRT, TEMPORARY_RT, materialInstances[3]);

            buffer.SetGlobalVector(BLUROFFSET_X, Vector4.zero);
            buffer.SetGlobalVector(BLUROFFSET_Y, blurOffset);
            buffer.Blit(TEMPORARY_RT, downscaledRT, materialInstances[3]);

            buffer.ReleaseTemporaryRT(TEMPORARY_RT);
            buffer.GetTemporaryRT(TEMPORARY_RT, width / 4, height / 4, 0, FilterMode.Bilinear); // GraphicsFormat.None
            buffer.Blit(downscaledRT, blurredRT);

            buffer.SetGlobalVector(BLUROFFSET_X, blurOffset);
            buffer.SetGlobalVector(BLUROFFSET_Y, Vector4.zero);
            buffer.Blit(blurredRT, TEMPORARY_RT, materialInstances[3]);

            buffer.SetGlobalVector(BLUROFFSET_X, Vector4.zero);
            buffer.SetGlobalVector(BLUROFFSET_Y, blurOffset);
            buffer.Blit(TEMPORARY_RT, blurredRT, materialInstances[3]);

            if (shaderID == -1)
            {
                if (feedbackCameraTarget)
                {
                    resultRT = BuiltinRenderTextureType.CameraTarget;

                    if (sourceRT == BuiltinRenderTextureType.CameraTarget)
                    {
                        buffer.Blit(sourceRT, temporaryRT);
                        buffer.Blit(temporaryRT, resultRT, materialInstances[2]);
                    }
                    else
                    {
                        buffer.Blit(sourceRT, resultRT, materialInstances[2]);
                    }
                }
                else
                {
                    if (sourceRT == BuiltinRenderTextureType.CameraTarget)
                        resultRT = new RenderTargetIdentifier(temporaryRT);
                    else
                        resultRT = BuiltinRenderTextureType.CameraTarget;

                    buffer.Blit(sourceRT, resultRT, materialInstances[2]);
                }
            }
            else
            {
                if (feedbackCameraTarget)
                {
                    resultRT = BuiltinRenderTextureType.CameraTarget;
                }
                else
                {
                    if (temporaryRT == null)
                        resultRT = BuiltinRenderTextureType.CameraTarget;
                    else
                        resultRT = new RenderTargetIdentifier(temporaryRT);
                }

                if (sourceRT == resultRT)
                    Debug.LogError(name + ": The source and destination are the same render target.");

                buffer.Blit(tempTarget, resultRT, materialInstances[2]);
                buffer.ReleaseTemporaryRT(shaderID);
            }

            buffer.ReleaseTemporaryRT(DEPTH_RT);
            instance = this;
            onBuild?.Invoke();

            return buffer;
        }

        public override void Update()
        {
            if (camera == null)
                return;

            if (target != null)
                distance = Vector3.Distance(target.position + targetOffset, camera.transform.position);

            if (shootingCamera != null)
            {
                if (shootingCamera.usePhysicalProperties)
                {
                    farDepth = (sensorScale * shootingCamera.sensorSize.y * 0.001f * distance * 0.5f) / (shootingCamera.focalLength * 0.001f * shootingCamera.focalLength * 0.001f);
                }
                else
                {
                    float focalLength = Camera.FieldOfViewToFocalLength(shootingCamera.fieldOfView, sensorScale * 24.0f);
                    farDepth = (sensorScale * 0.024f * distance * 0.5f) / (focalLength * 0.001f * focalLength * 0.001f);
                }
            }

            float focalCoeff = Math.Max(distance + farDepth, 0.001f);
            Shader.SetGlobalVector(FOCAL_COEFF, new Vector4(distance, farDepth, 1.0f / farDepth, 1.0f / focalCoeff));
        }

        public override void Destroy()
        {
            instance = null;
            base.Destroy();

            if (downscaledRT != null)
                DestroyImmediate(downscaledRT);

            if (blurredRT != null)
                DestroyImmediate(blurredRT);

            downscaledRT = null;
            blurredRT = null;

            onRelease?.Invoke();
        }

        public delegate void OnBuildCallback();
        public delegate void OnRelaseCallback();
    }
}