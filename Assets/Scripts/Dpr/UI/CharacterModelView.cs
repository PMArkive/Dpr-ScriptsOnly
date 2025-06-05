using GameData;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;
using XLSXContent;

namespace Dpr.UI
{
    public class CharacterModelView : ModelViewBase
    {
        [SerializeField]
        private Transform _transModel;
        [SerializeField]
        private float _fov = 30.0f;
        [SerializeField]
        private float _rotateSpeed;
        private int _saveModelViewCacheNum = 6;
        public const string clipName_stand_b = "stand_b";
        public const string clipName_pose_b = "pose_b";
        public const string clipName_pose_loop_b = "pose_loop_b";
        private Param _param;
        private string _clipName;

        protected override void OnEnable()
        {
            _saveModelViewCacheNum = UIManager.Instance.modelView.ResetCaches(DataManager.CharacterDressData.Data.Length * 2);
            base.OnEnable();
        }

        protected override void OnDisable()
        {
            UIManager.Instance.modelView.ResetCaches(_saveModelViewCacheNum);
            base.OnEnable(); // BUG: Typo
        }

        public void Setup(Param param, [Optional] UnityAction<Param> onSetup)
        {
            _param = param;
            PlayerWork.isPlayerInputActive = false;
            _rawImageModelView.gameObject.SetActive(true);

            if (_imageModelBg.transform.parent == _transBg)
                _imageModelBg.transform.SetParent(UIManager.Instance.modelBgRoot, false);

            var modelTf = _rawImageModelView.transform as RectTransform;
            UIManager.Instance.modelView.ModelViewSize(modelTf.rect.width, modelTf.rect.height);
            UIManager.Instance.modelView.SetModelViewType(param.type);

            var canvasTf = param.canvas.transform as RectTransform;
            UIManager.Instance.modelView.ModelCameraCenterOffset(new Vector2(-_transModel.localPosition.x / canvasTf.sizeDelta.x, -_transModel.localPosition.y / canvasTf.sizeDelta.y));
            UIManager.Instance.modelView.SetCameraRotationX(0.0f);
            UIManager.Instance.modelView.ModelCameraFov(_fov);
            UIManager.Instance.modelView.ModelReflection(float.NegativeInfinity);
            UIManager.Instance.modelView.SetModelRotation(new Vector2(_transModel.localRotation.eulerAngles.x, 0.0f));
            UIManager.Instance.modelView.SetModelScale(1.0f);
            UIManager.Instance.modelView.SetModelAttachOffset(Vector3.zero);

            StartCoroutine(UIManager.Instance.modelView.OpLoadCharacterModel(param.GetModelId(), GetAssetBundleName(param), false, modelId_ =>
            {
                UIManager.Instance.modelView.SetModelOffset(new Vector3(0.0f, 0.0f, param.offsetZ));
                onSetup?.Invoke(param);
            }));
        }

        public static string GetAssetBundleName(Param param)
        {
            return param.modelType != Param.ModelType.Field ? ("persons/battle/" + param.characterDressData.BattleGraphic) : ("persons/field/" + param.characterDressData.FieldGraphic);
        }

        public bool OnUpdate(float deltaTime, UIInputController input)
        {
            float rotationSpeed = _rotateSpeed * UIManager.Fps() * deltaTime;
            var rotation = UIManager.Instance.modelView.GetModelRotation();

            if (input.IsOnButton(GameController.ButtonMask.L))
                rotation.y += rotationSpeed;
            else if (input.IsOnButton(GameController.ButtonMask.R))
                rotation.y -= rotationSpeed;
            else
                return false;

            UIManager.Instance.modelView.SetModelRotation(rotation);
            return true;
        }

        public void PlayAnimation(string clipName, bool looped = false)
        {
            var anim = UIManager.Instance.modelView.GetAnimationIndexByClipName(clipName);
            if (anim > -1)
            {
                _clipName = clipName;
                UIManager.Instance.modelView.PlayAnimation(anim, looped);
            }
        }

        protected override void UpdateAnimation(float deltaTime)
        {
            if (UIManager.Instance.modelView.modelParam != null &&
                _clipName == clipName_pose_b &&
                UIManager.Instance.modelView.GetCurrentRemaingTime() <= 0.0f)
            {
                PlayAnimation(clipName_pose_loop_b);
            }
        }

        public class Param
        {
            public UIModelViewController.ModelViewType type = UIModelViewController.ModelViewType.Boutique;
            public CharacterDressData.SheetData characterDressData;
            public ModelType modelType = ModelType.Battle;
            public Canvas canvas;
            public float offsetZ;
            public bool isAutoUpdateTexture = true;

            public int GetModelId()
            {
                return (int)modelType + characterDressData.Index * 2;
            }

            public bool IsMaleDress()
            {
                return characterDressData.Index < 100;
            }

            public enum ModelType : int
            {
                Field = 0,
                Battle = 1,
                Num = 2,
            }
        }
    }
}