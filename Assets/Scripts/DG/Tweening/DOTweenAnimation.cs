using DG.Tweening.Core;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace DG.Tweening
{
    [AddComponentMenu(menuName: "DOTween/DOTween Animation")]
    public class DOTweenAnimation : ABSAnimationComponent
    {
        public static event Action<DOTweenAnimation> OnReset;
        public bool targetIsSelf = true;
        public GameObject targetGO;
        public bool tweenTargetIsTargetGO = true;
        public float delay;
        public float duration = 1.0f;
        public Ease easeType = Ease.OutQuad;
        public AnimationCurve easeCurve = new AnimationCurve(new Keyframe[2]
        {
            new Keyframe(0.0f, 0.0f),
            new Keyframe(1.0f, 1.0f),
        });
        public LoopType loopType;
        public int loops = 1;
        public string id = "";
        public bool isRelative;
        public bool isFrom;
        public bool isIndependentUpdate;
        public bool autoKill = true;
        public bool isActive = true;
        public bool isValid;
        public Component target;
        public AnimationType animationType;
        public TargetType targetType;
        public TargetType forcedTargetType;
        public bool autoPlay = true;
        public bool useTargetAsV3;
        public float endValueFloat;
        public Vector3 endValueV3;
        public Vector2 endValueV2;
        public Color endValueColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        public string endValueString = "";
        public Rect endValueRect = new Rect(0.0f, 0.0f, 0.0f, 0.0f);
        public Transform endValueTransform;
        public bool optionalBool0;
        public float optionalFloat0;
        public int optionalInt0;
        public RotateMode optionalRotationMode;
        public ScrambleMode optionalScrambleMode;
        public string optionalString;
        private bool _tweenCreated;
        private int _playCount = -1;

        private static void Dispatch_OnReset(DOTweenAnimation anim)
        {
            OnReset?.Invoke(anim);
        }

        private void Awake()
        {
            if (isActive && isValid && (animationType != AnimationType.Move || !useTargetAsV3))
            {
                CreateTween();
                _tweenCreated = true;
            }
        }

        private void Start()
        {
            if (!_tweenCreated && isActive && isValid)
            {
                CreateTween();
                _tweenCreated = true;
            }
        }

        private void Reset()
        {
            Dispatch_OnReset(this);
        }

        private void OnDestroy()
        {
            if (tween != null && tween.IsActive())
                tween.Kill(false);

            tween = null;
        }

        public void CreateTween()
        {
            var go = GetTweenGO();

            if (target == null || go == null)
            {
                if (targetIsSelf)
                {
                    // Result seems ignored (commented log?)
                    _ = target == null;
                }
                return;
            }

            if (forcedTargetType == TargetType.Unset)
            {
                if (targetType == TargetType.Unset)
                    targetType = TypeToDOTargetType(target.GetType());
            }
            else
            {
                targetType = forcedTargetType;
            }

            if (animationType != AnimationType.None && animationType - 1 < AnimationType.UIWidthHeight)
            {
                switch (animationType)
                {
                    case AnimationType.Move:
                        if (useTargetAsV3)
                        {
                            isRelative = false;

                            if (endValueTransform == null)
                                endValueV3 = Vector3.zero;
                            else if (targetType != TargetType.RectTransform)
                                endValueV3 = endValueTransform.position;
                            else if (endValueTransform as RectTransform == null)
                                endValueV3 = Vector3.zero;
                            else if (target as RectTransform != null)
                                endValueV3 = DOTweenModuleUI.Utils.SwitchToRectTransform(endValueTransform as RectTransform, target as RectTransform);
                        }
                        switch (targetType)
                        {
                            case TargetType.RectTransform:
                                tween = (target as RectTransform).DOAnchorPos3D(endValueV3, duration, optionalBool0);
                                break;

                            case TargetType.Rigidbody:
                                tween = (target as Rigidbody).DOMove(endValueV3, duration, optionalBool0);
                                break;

                            case TargetType.Rigidbody2D:
                                tween = (target as Rigidbody2D).DOMove(endValueV3, duration, false);
                                break;

                            case TargetType.Transform:
                                tween = (target as Transform).DOMove(endValueV3, duration, optionalBool0);
                                break;
                        }
                        break;

                    case AnimationType.LocalMove:
                        tween = go.transform.DOLocalMove(endValueV3, duration, optionalBool0);
                        break;

                    case AnimationType.Rotate:
                        switch (targetType)
                        {
                            case TargetType.Rigidbody:
                                tween = (target as Rigidbody).DORotate(endValueV3, duration, optionalRotationMode);
                                break;

                            case TargetType.Rigidbody2D:
                                tween = (target as Rigidbody2D).DORotate(endValueFloat, duration);
                                break;

                            case TargetType.Transform:
                                tween = (target as Transform).DORotate(endValueV3, duration, optionalRotationMode);
                                break;
                        }
                        break;

                    case AnimationType.LocalRotate:
                        tween = go.transform.DOLocalRotate(endValueV3, duration, optionalRotationMode);
                        break;

                    case AnimationType.Scale:
                        if (optionalBool0)
                            tween = go.transform.DOScale(new Vector3(endValueFloat, endValueFloat, endValueFloat), duration);
                        else
                            tween = go.transform.DOScale(endValueV3, duration);
                        break;

                    case AnimationType.Color:
                        isRelative = false;
                        switch (targetType)
                        {
                            case TargetType.Image:
                                tween = (target as Graphic).DOColor(endValueColor, duration);
                                break;

                            case TargetType.Light:
                                tween = (target as Light).DOColor(endValueColor, duration);
                                break;

                            case TargetType.Renderer:
                                tween = (target as Renderer).material.DOColor(endValueColor, duration);
                                break;

                            case TargetType.SpriteRenderer:
                                tween = (target as SpriteRenderer).DOColor(endValueColor, duration);
                                break;

                            case TargetType.Text:
                                tween = (target as Text).DOColor(endValueColor, duration);
                                break;
                        }
                        break;

                    case AnimationType.Fade:
                        isRelative = false;
                        switch (targetType)
                        {
                            case TargetType.CanvasGroup:
                                tween = (target as CanvasGroup).DOFade(endValueFloat, duration);
                                break;

                            case TargetType.Image:
                                tween = (target as Graphic).DOFade(endValueFloat, duration);
                                break;

                            case TargetType.Light:
                                tween = (target as Light).DOIntensity(endValueFloat, duration);
                                break;

                            case TargetType.Renderer:
                                tween = (target as Renderer).material.DOFade(endValueFloat, duration);
                                break;

                            case TargetType.SpriteRenderer:
                                tween = (target as SpriteRenderer).DOFade(endValueFloat, duration);
                                break;

                            case TargetType.Text:
                                tween = (target as Text).DOFade(endValueFloat, duration);
                                break;
                        }
                        break;

                    case AnimationType.Text:
                        if (targetType == TargetType.Text)
                            tween = (target as Text).DOText(endValueString, duration, optionalBool0, optionalScrambleMode, optionalString);
                        break;

                    case AnimationType.PunchPosition:
                        switch (targetType)
                        {
                            case TargetType.RectTransform:
                                tween = (target as RectTransform).DOPunchAnchorPos(endValueV3, duration, optionalInt0, optionalFloat0, optionalBool0);
                                break;

                            case TargetType.Transform:
                                tween = (target as Transform).DOPunchPosition(endValueV3, duration, optionalInt0, optionalFloat0, optionalBool0);
                                break;
                        }
                        break;

                    case AnimationType.PunchRotation:
                        tween = go.transform.DOPunchRotation(endValueV3, duration, optionalInt0, optionalFloat0);
                        break;

                    case AnimationType.PunchScale:
                        tween = go.transform.DOPunchScale(endValueV3, duration, optionalInt0, optionalFloat0);
                        break;

                    // TODO: More cases
                }
            }

            if (tween == null)
                return;

            if (isFrom)
                (tween as Tweener).From(isRelative);
            else
                tween.SetRelative(isRelative);

            var goTarget = (!targetIsSelf && tweenTargetIsTargetGO) ? targetGO : gameObject;
            tween.SetTarget(goTarget).SetDelay(delay).SetLoops(loops, loopType).SetAutoKill(autoKill).OnKill(() => tween = null);

            if (isSpeedBased)
                tween.SetSpeedBased();

            if (easeType == Ease.INTERNAL_Custom)
                tween.SetEase(easeCurve);
            else
                tween.SetEase(easeType);

            if (!string.IsNullOrEmpty(id))
                tween.SetId(id);

            tween.SetUpdate(isIndependentUpdate);

            if (hasOnStart && onStart != null)
                tween.OnStart(onStart.Invoke);
            else
                onStart = null;

            if (hasOnPlay && onPlay != null)
                tween.OnPlay(onPlay.Invoke);
            else
                onPlay = null;

            if (hasOnUpdate && onUpdate != null)
                tween.OnUpdate(onUpdate.Invoke);
            else
                onUpdate = null;

            if (hasOnStepComplete && onStepComplete != null)
                tween.OnStepComplete(onStepComplete.Invoke);
            else
                onStepComplete = null;

            if (hasOnComplete && onComplete != null)
                tween.OnComplete(onComplete.Invoke);
            else
                onComplete = null;

            if (hasOnRewind && onRewind != null)
                tween.OnRewind(onRewind.Invoke);
            else
                onRewind = null;

            if (autoPlay)
                tween.Play();
            else
                tween.Pause();

            if (hasOnTweenCreated)
                onTweenCreated?.Invoke();
        }

        public override void DOPlay()
        {
            DOTween.Play(gameObject);
        }

        public override void DOPlayBackwards()
        {
            DOTween.PlayBackwards(gameObject);
        }

        public override void DOPlayForward()
        {
            DOTween.PlayForward(gameObject);
        }

        public override void DOPause()
        {
            DOTween.Pause(gameObject);
        }

        public override void DOTogglePause()
        {
            DOTween.TogglePause(gameObject);
        }

        public override void DORewind()
        {
            _playCount = -1;

            var anims = gameObject.GetComponents<DOTweenAnimation>();
            for (int i=anims.Length-1; i>=0; i--)
            {
                if (anims[i].tween != null && anims[i].tween.IsInitialized())
                    anims[i].tween.Rewind(true);
            }
        }

        public override void DORestart()
        {
            DORestart(false);
        }

        public override void DORestart(bool fromHere)
        {
            _playCount = -1;

            if (tween == null)
            {
                if (Debugger.logPriority > 1)
                    Debugger.LogNullTween(tween);
            }
            else
            {
                if (fromHere && isRelative)
                    ReEvaluateRelativeTween();

                DOTween.Restart(gameObject, true, -1.0f);
            }
        }

        public override void DOComplete()
        {
            DOTween.Complete(gameObject);
        }

        public override void DOKill()
        {
            DOTween.Kill(gameObject);
            tween = null;
        }

        public void DOPlayById(string id)
        {
            DOTween.Play(gameObject, id);
        }

        public void DOPlayAllById(string id)
        {
            DOTween.Play(id);
        }

        public void DOPauseAllById(string id)
        {
            DOTween.Pause(id);
        }

        public void DOPlayBackwardsById(string id)
        {
            DOTween.PlayBackwards(gameObject, id);
        }

        public void DOPlayBackwardsAllById(string id)
        {
            DOTween.PlayBackwards(id);
        }

        public void DOPlayForwardById(string id)
        {
            DOTween.PlayForward(gameObject, id);
        }

        public void DOPlayForwardAllById(string id)
        {
            DOTween.PlayForward(id);
        }

        public void DOPlayNext()
        {
            var anims = gameObject.GetComponents<DOTweenAnimation>();
            for (int i=0; i<anims.Length; i++)
            {
                _playCount++;
                if (anims[i] != null && anims[i].tween != null && !anims[i].tween.IsPlaying() && !anims[i].tween.IsComplete())
                {
                    anims[i].tween.Play();
                    break;
                } 
            }
        }

        public void DORewindAndPlayNext()
        {
            _playCount = -1;
            DOTween.Rewind(gameObject, true);
            DOPlayNext();
        }

        public void DORewindAllById(string id)
        {
            _playCount = -1;
            DOTween.Rewind(id, true);
        }

        public void DORestartById(string id)
        {
            _playCount = -1;
            DOTween.Restart(gameObject, id, true, -1.0f);
        }

        public void DORestartAllById(string id)
        {
            _playCount = -1;
            DOTween.Restart(id, true, -1.0f);
        }

        public List<Tween> GetTweens()
        {
            var tweens = new List<Tween>();

            var anims = gameObject.GetComponents<DOTweenAnimation>();
            for (int i=0; i<anims.Length; i++)
                tweens.Add(anims[i].tween);

            return tweens;
        }

        public static TargetType TypeToDOTargetType(Type t)
        {
            var typeName = t.ToString();

            int dotIndex = typeName.LastIndexOf(".");
            if (dotIndex != -1)
                typeName = typeName.Substring(dotIndex + 1);

            int rendererIndex = typeName.IndexOf("Renderer");
            if (rendererIndex != -1)
                typeName = typeName != "SpriteRenderer" ? "Renderer" : typeName;

            typeName = typeName != "RawImage" ? typeName : "Image";

            return (TargetType)Enum.Parse(typeof(TargetType), typeName);
        }

        public Tween CreateEditorPreview()
        {
            if (Application.isPlaying)
                return null;

            CreateTween();
            return tween;
        }

        private GameObject GetTweenGO()
        {
            if (targetIsSelf)
                return gameObject;

            return targetGO;
        }

        private void ReEvaluateRelativeTween()
        {
            var go = GetTweenGO();

            if (go == null)
                return;

            if (animationType == AnimationType.Move)
            {
                (tween as Tweener).ChangeEndValue(go.transform.position + endValueV3, true);
            }
            else if (animationType == AnimationType.LocalMove)
            {
                (tween as Tweener).ChangeEndValue(go.transform.localPosition + endValueV3, true);
            }
        }

        public enum AnimationType : int
        {
            None = 0,
            Move = 1,
            LocalMove = 2,
            Rotate = 3,
            LocalRotate = 4,
            Scale = 5,
            Color = 6,
            Fade = 7,
            Text = 8,
            PunchPosition = 9,
            PunchRotation = 10,
            PunchScale = 11,
            ShakePosition = 12,
            ShakeRotation = 13,
            ShakeScale = 14,
            CameraAspect = 15,
            CameraBackgroundColor = 16,
            CameraFieldOfView = 17,
            CameraOrthoSize = 18,
            CameraPixelRect = 19,
            CameraRect = 20,
            UIWidthHeight = 21,
        }

        public enum TargetType : int
        {
            Unset = 0,
            Camera = 1,
            CanvasGroup = 2,
            Image = 3,
            Light = 4,
            RectTransform = 5,
            Renderer = 6,
            SpriteRenderer = 7,
            Rigidbody = 8,
            Rigidbody2D = 9,
            Text = 10,
            Transform = 11,
            tk2dBaseSprite = 12,
            tk2dTextMesh = 13,
            TextMeshPro = 14,
            TextMeshProUGUI = 15,
        }
    }
}