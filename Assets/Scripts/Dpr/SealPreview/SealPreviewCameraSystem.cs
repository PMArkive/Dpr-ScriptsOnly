using Audio;
using Dpr.Battle.Logic;
using Dpr.Battle.View;
using Dpr.Battle.View.Objects;
using Dpr.SequenceEditor;
using SmartPoint.Rendering;
using System;
using UnityEngine;

namespace Dpr.SealPreview
{
	public sealed class SealPreviewCameraSystem : SequenceCameraSystem
	{
		public SealPreviewCameraSystem(ISequenceViewSystem viewSystem, BOCamera camera) : base(viewSystem)
		{
            var cameraPlacementData = BattleDataTableManager.Instance.BattleDefaultPlacementData.GetDefaultCameraPlacementData(BtlRule.BTL_RULE_SINGLE, Pml.PokePara.Size.S, Pml.PokePara.Size.S);
            var camStateTypes = Enum.GetValues(typeof(CameraStateType));
            Cameras = new BOCamera[camStateTypes.Length];

            foreach (CameraStateType camStateType in camStateTypes)
            {
                if (camStateType != CameraStateType.Sub)
                {
                    var boCam = camera.AddComponentIfNecessary<BOCamera>();
                    boCam.Initialize(camStateType);
                    boCam.IsAudioListener = true;
                    DepthOfField.instance.target = boCam.GetTargetTransform();

                    if (cameraPlacementData == null)
                    {
                        boCam.transform.SetOrigin(null);
                        boCam.Camera.nearClipPlane = DEFAULT_NEAR;
                        boCam.Camera.farClipPlane = DEFAULT_FAR;
                        boCam.Camera.fieldOfView = DEFAULT_FOV;
                    }
                    else
                    {
                        boCam.transform.position = camStateType == CameraStateType.Main ? cameraPlacementData.MainCamPos : cameraPlacementData.SubCamPos;
                        boCam.transform.rotation = Quaternion.Euler(camStateType == CameraStateType.Main ? cameraPlacementData.MainCamRot : cameraPlacementData.SubCamRot);
                        var cam = boCam.Camera;
                        cam.nearClipPlane = camStateType == CameraStateType.Main ? cameraPlacementData.MainCamNear : cameraPlacementData.SubCamNear;
                        cam.farClipPlane = camStateType == CameraStateType.Main ? cameraPlacementData.MainCamFar : cameraPlacementData.SubCamFar;
                        cam.fieldOfView = camStateType == CameraStateType.Main ? cameraPlacementData.MainCamFov : cameraPlacementData.SubCamFov;
                    }

                    Cameras[(int)camStateType] = boCam;
                }
            }

            CameraState = CameraStateType.Main;
        }
	}
}