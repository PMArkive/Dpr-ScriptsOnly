using Dpr.FureaiHiroba;
using Dpr.SubContents;
using SmartPoint.AssetAssistant;
using System;
using UnityEngine;

namespace Dpr.Field.Walking
{
    public class WalkingCharacterView : MonoBehaviour
    {
        public float PokeScale;
        private float toRunSpeed = 2.8f;
        public int anim;
        public Transform EffTransform;
        public bool isWaitMotionMove;
        protected AnimationPlayer animPlayer;
        private int PrevAnimID;
        public bool IsStopUpdate;
        public bool isKwWait;
        private float AnimDuration;
        public float defaultDuration = 0.2f;
        public static readonly int[] WaitAnimIDs = new int[4]
        {
            FieldPokemonEntity.Animation.FieldWait1, FieldPokemonEntity.Animation.FieldWait2,
            FieldPokemonEntity.Animation.Kw_Wait,    FieldPokemonEntity.Animation.Idle,
        }; 
        public static readonly int[] WaittoWalkIDs = new int[2]
        {
            FieldPokemonEntity.Animation.WaitToWalk, FieldPokemonEntity.Animation.Walk,
        };
        public static readonly int[] WaittoRunIDs = new int[2]
        {
            FieldPokemonEntity.Animation.WaitToRun, FieldPokemonEntity.Animation.Run,
        };
        public static readonly int[] WalktoRunIDs = new int[3]
        {
            FieldPokemonEntity.Animation.WalkToRun, FieldPokemonEntity.Animation.WaitToRun,
            FieldPokemonEntity.Animation.Run,
        };
        public static readonly int[] WalktoWaitIDs = new int[5]
        {
            FieldPokemonEntity.Animation.WalkToWait, FieldPokemonEntity.Animation.FieldWait1,
            FieldPokemonEntity.Animation.FieldWait2, FieldPokemonEntity.Animation.Kw_Wait,
            FieldPokemonEntity.Animation.Idle,
        };
        public static readonly int[] RuntoWalkIDs = new int[3]
        {
            FieldPokemonEntity.Animation.RunToWalk, FieldPokemonEntity.Animation.RunToWait,
            FieldPokemonEntity.Animation.Walk,
        };
        public static readonly int[] RuntoWaitIDs = new int[5]
        {
            FieldPokemonEntity.Animation.RunToWait,  FieldPokemonEntity.Animation.FieldWait1,
            FieldPokemonEntity.Animation.FieldWait2, FieldPokemonEntity.Animation.Kw_Wait,
            FieldPokemonEntity.Animation.Idle,
        };

        private void Awake()
        {
            transform.GetComponent<Animator>().cullingMode = AnimatorCullingMode.AlwaysAnimate;
        }

        public void ChangeUpdateWhenOffScreen(FieldPokemonEntity entity)
        {
            var mesh = transform.GetComponentsInChildren<SkinnedMeshRenderer>();

            if (mesh.Length <= 0)
                return;

            for (int i=0; i<entity.rendererCluster.Length; i++)
            {
                bool unset = false;
                for (int j=0; j<entity.rendererCluster.Length; j++)
                    unset |= Array.Exists(entity.rendererCluster[j].renderers, x => x == mesh[i]);

                if (unset)
                    mesh[i].updateWhenOffscreen = true;
            }
        }

        private void OnDestroy()
        {
            EffTransform = null;
            animPlayer = null;
        }

        public void SetAnimPlayer(AnimationPlayer player)
        {
            animPlayer = player;
        }

        public AnimationPlayer GetAnimPlayer()
        {
            return animPlayer;
        }

        public void CreateEffectPosition(Vector3 pos)
        {
            var go = new GameObject("EffPosition");
            go.transform.SetParent(transform);
            go.transform.localPosition = pos;
            EffTransform = go.transform;
        }

        public void AutoSelectAnimation(WalkingCharacterModel model)
        {
            float elapsedTime = Sequencer.elapsedTime == 0.0f ? 0.016666f : Sequencer.elapsedTime;
            _ = animPlayer.layerWeight;

            if (model.isForceAnimation || IsStopUpdate || CheckSleepState(model) || !animPlayer.IsValidCurrentPlayable)
                return;

            if (isHokanAnimation(PrevAnimID) && !animPlayer.IsPlayingEnd)
                return;

            var walkSpeed = model.walkData.walkSpeed * model.walkData.baseSpeed;
            var runSpeed = model.walkData.runSpeed * model.walkData.baseSpeed;

            toRunSpeed = walkSpeed + (runSpeed * defaultDuration);
            var duration = (1.0f / elapsedTime) * model.walkData.nowSpeed;

            toRunSpeed = model.controller.isChousei ? toRunSpeed : 150.0f;

            if (walkSpeed * 0.5f <= duration)
            {
                if (duration <= toRunSpeed)
                    AnimPlay(GetAnimIndex(AnimType.Walk), duration);
                else
                    AnimPlay(GetAnimIndex(AnimType.Run), duration);
            }
            else
            {
                model.walkData.moveVec = Vector3.zero;
                
                if (model.walkData.isNeedRotate)
                {
                    AnimPlay(GetAnimIndex(AnimType.Walk));
                    model.walkData.isNeedRotate = false;
                }
                else
                {
                    AnimPlay(GetAnimIndex(AnimType.Wait));
                }
            }
        }

        public bool CheckSleepState(WalkingCharacterModel model)
        {
            var prev = model.PrevSleepLevel;
            model.PrevSleepLevel = model.SleepLevel;

            if (model.SleepLevel < 1)
                return false;

            if (model.isCanSleepAnimation)
            {
                switch (model.SleepLevel)
                {
                    case 1:
                        AnimPlay(FieldPokemonEntity.Animation.Kw_DrowseA);
                        break;

                    case 2:
                        AnimPlay(FieldPokemonEntity.Animation.Kw_DrowseB);
                        break;

                    case 3:
                        AnimPlay(FieldPokemonEntity.Animation.Kw_DrowseC);
                        break;
                }
            }
            else
            {
                switch (model.SleepLevel)
                {
                    case 1:
                        AnimPlay(FieldPokemonEntity.Animation.Idle);
                        if (model.SleepLevel != prev)
                            animPlayer.SetAdditiveLayerTime(0.5f);
                        break;

                    case 2:
                        AnimPlay(FieldPokemonEntity.Animation.Idle);
                        if (model.SleepLevel != prev)
                            animPlayer.SetAdditiveLayerTime(0.8f);
                        break;

                    case 3:
                        AnimPlay(FieldPokemonEntity.Animation.Idle);
                        if (model.SleepLevel != prev)
                            animPlayer.SetAdditiveLayerTime(0.5f);
                        break;
                }
            }

            return true;
        }

        public void AnimPlay(int index, float duration = 0.0f, float startTime = 0.0f)
        {
            if (index == -1 || animPlayer == null)
                return;

            if (animPlayer.currentIndex == index)
                return;

            if (animPlayer.clips[index] != null)
            {
                animPlayer.forceLoop = index == FieldPokemonEntity.Animation.FieldWait1 || index == FieldPokemonEntity.Animation.FieldWait2;
                var animDuration = Mathf.Clamp(animPlayer.clips[index].length * defaultDuration, 0.2f, 0.4f);
                animPlayer?.Play(index, animDuration, startTime);
            }
        }

        public CorSystem AnimPlayForce(int index, CorSystem corSys, WalkingCharacterModel model, float duration = 0.0f, float startTime = 0.0f)
        {
            if (index == -1)
                index = 0;

            var sub = corSys.AddSub("");
            model.isForceAnimation = true;
            sub.onFinished += () => model.isForceAnimation = false;

            AnimPlay(index, 0.0f, startTime);

            return sub;
        }

        private float GetWaitDuration(int NextAnimID)
        {
            switch (NextAnimID)
            {
                case FieldPokemonEntity.Animation.WalkToWait:
                case FieldPokemonEntity.Animation.RunToWait:
                case FieldPokemonEntity.Animation.WaitToRun:
                case FieldPokemonEntity.Animation.WalkToRun:
                    return 0.0f;

                case FieldPokemonEntity.Animation.Idle:
                {
                    switch (animPlayer.currentIndex)
                    {
                        case FieldPokemonEntity.Animation.WalkToWait:
                        case FieldPokemonEntity.Animation.RunToWait:
                        case FieldPokemonEntity.Animation.WaitToRun:
                        case FieldPokemonEntity.Animation.WalkToRun:
                            return 0.0f;

                        default:
                            return defaultDuration;
                    }
                }

                default:
                    return defaultDuration;
            }
        }

        private int GetWaitToWait(int hokanAnim, int nextAnim)
        {
            return Utils.GetExistAnim(animPlayer, new int[2] { hokanAnim, nextAnim });
        }

        public int GetWaitAnim(int prevWait, int nextWait)
        {
            if (prevWait == nextWait)
                return prevWait;

            switch (prevWait)
            {
                case FieldPokemonEntity.Animation.FieldWait1:
                case FieldPokemonEntity.Animation.FieldWait2:
                    return nextWait == FieldPokemonEntity.Animation.Idle ?
                        GetWaitToWait(FieldPokemonEntity.Animation.FiWaitToBaWait, nextWait) :
                        GetWaitToWait(FieldPokemonEntity.Animation.FiWaitToKwWait, nextWait);

                case FieldPokemonEntity.Animation.Kw_Wait:
                    return nextWait == FieldPokemonEntity.Animation.Idle ?
                        GetWaitToWait(FieldPokemonEntity.Animation.KwWaitToBaWait, nextWait) :
                        GetWaitToWait(FieldPokemonEntity.Animation.KwWaitToFiWait, nextWait);

                case FieldPokemonEntity.Animation.Idle:
                    return nextWait == FieldPokemonEntity.Animation.FieldWait1 || nextWait == FieldPokemonEntity.Animation.FieldWait2 ?
                        GetWaitToWait(FieldPokemonEntity.Animation.BaWaitToFiWait, nextWait) :
                        GetWaitToWait(FieldPokemonEntity.Animation.BaWaitToKwWait, nextWait);

                default:
                    return nextWait;
            }
        }

        public int GetNeutralWaitAnim()
        {
            var anim = Utils.GetExistAnim(animPlayer, WaitAnimIDs);

            if (anim == FieldPokemonEntity.Animation.Kw_Wait)
                return isKwWait ? anim : FieldPokemonEntity.Animation.Idle;
            else
                return anim;
        }

        public bool isHokanAnimation(int AnimID)
        {
            switch (AnimID)
            {
                case FieldPokemonEntity.Animation.BaWaitToFiWait:
                case FieldPokemonEntity.Animation.BaWaitToKwWait:
                case FieldPokemonEntity.Animation.FiWaitToBaWait:
                case FieldPokemonEntity.Animation.FiWaitToKwWait:
                case FieldPokemonEntity.Animation.KwWaitToBaWait:
                case FieldPokemonEntity.Animation.KwWaitToFiWait:
                case FieldPokemonEntity.Animation.WaitToWalk:
                case FieldPokemonEntity.Animation.WalkToWait:
                case FieldPokemonEntity.Animation.RunToWait:
                case FieldPokemonEntity.Animation.WaitToRun:
                case FieldPokemonEntity.Animation.RunToWalk:
                case FieldPokemonEntity.Animation.WalkToRun:
                    return true;

                default:
                    return false;
            }
        }

        private bool isWaitAnim(int AnimID)
        {
            switch (AnimID)
            {
                case FieldPokemonEntity.Animation.Idle:
                case FieldPokemonEntity.Animation.FieldWait1:
                case FieldPokemonEntity.Animation.FieldWait2:
                case FieldPokemonEntity.Animation.WalkToWait:
                case FieldPokemonEntity.Animation.RunToWait:
                    return true;

                default:
                    return false;
            }
        }

        private bool isRunAnim(int AnimID)
        {
            switch (AnimID)
            {
                case FieldPokemonEntity.Animation.Run:
                case FieldPokemonEntity.Animation.WaitToRun:
                case FieldPokemonEntity.Animation.WalkToRun:
                    return true;

                default:
                    return false;
            }
        }

        private bool isWalkAnim(int AnimID)
        {
            switch (AnimID)
            {
                case FieldPokemonEntity.Animation.Walk:
                case FieldPokemonEntity.Animation.WaitToWalk:
                case FieldPokemonEntity.Animation.RunToWalk:
                    return true;

                default:
                    return false;
            }
        }

        public bool isNeedWait()
        {
            switch (PrevAnimID)
            {
                case FieldPokemonEntity.Animation.RunToWait:
                case FieldPokemonEntity.Animation.WaitToRun:
                case FieldPokemonEntity.Animation.RunToWalk:
                case FieldPokemonEntity.Animation.WalkToRun:
                    return true;

                default:
                    return false;
            }
        }

        public void CheckForceLoop(int animIndex)
        {
            animPlayer.forceLoop = animIndex == FieldPokemonEntity.Animation.FieldWait1 || animIndex == FieldPokemonEntity.Animation.FieldWait2;
        }

        public int GetAnimIndex(AnimType animType)
        {
            int anim = (int)animType;

            if (FlagWork.GetSysFlag(EvScript.EvWork.SYSFLAG_INDEX.SYS_FLAG_PAIR) && !FureaiManager.isInstantiated)
                return anim;
            
            if (isWaitMotionMove)
            {
                anim = Utils.GetExistAnim(animPlayer, WaitAnimIDs);
            }
            else if (animType == AnimType.Run)
            {
                if (isWaitAnim(PrevAnimID))
                    anim = Utils.GetExistAnim(animPlayer, WaittoRunIDs);
                else if (isWalkAnim(PrevAnimID))
                    anim = Utils.GetExistAnim(animPlayer, WalktoRunIDs);
            }
            else if (animType == AnimType.Walk)
            {
                if (isWaitAnim(PrevAnimID))
                    anim = Utils.GetExistAnim(animPlayer, WaittoWalkIDs);
                else if (isRunAnim(PrevAnimID))
                    anim = Utils.GetExistAnim(animPlayer, RuntoWalkIDs);
            }
            else if (animType == AnimType.Wait)
            {
                if (isWalkAnim(PrevAnimID))
                    anim = Utils.GetExistAnim(animPlayer, WalktoWaitIDs);
                else if (isRunAnim(PrevAnimID))
                    anim = Utils.GetExistAnim(animPlayer, RuntoWaitIDs);
                else
                    anim = Utils.GetExistAnim(animPlayer, WaitAnimIDs);
            }
            else
            {
                anim = FieldPokemonEntity.Animation.Idle;
            }

            if (anim == FieldPokemonEntity.Animation.RunToWait || anim == FieldPokemonEntity.Animation.RunToWalk)
            {
                if (EntityManager.activeFieldPlayer.moveVector != Vector3.zero)
                    anim = PrevAnimID;
            }
            else if (anim == FieldPokemonEntity.Animation.Kw_Wait)
            {
                anim = isKwWait ? FieldPokemonEntity.Animation.Kw_Wait : FieldPokemonEntity.Animation.Idle;
            }

            if (anim == PrevAnimID)
                return anim;

            PrevAnimID = anim;
            return PrevAnimID;
        }

        public void OnValidate()
        {
            // Empty
        }

        public bool State_PlayAnime(int index, float duration)
        {
            if (IsNullStateAnime(index))
                return false;

            if (animPlayer.currentIndex != index)
                animPlayer.Play(index, duration);

            return true;
        }

        public bool IsPlayAnimeEnd(int index)
        {
            if (index < 0 || animPlayer == null)
                return false;

            if (animPlayer.currentIndex != index)
                return false;

            return animPlayer.currentRemaingTime <= 0.0f;
        }

        public float PlayAnimeTime(int index)
        {
            if (index < 0 || animPlayer == null)
                return 0.0f;

            if (animPlayer.currentIndex != index)
                return 0.0f;

            return animPlayer.currentRemaingTime;
        }

        public bool IsNullStateAnime(int index)
        {
            if (index < 0 || animPlayer == null)
                return true;

            return animPlayer.clips[index] == null;
        }

        public void DebugAnimeState()
        {
            // Empty
        }

        public enum AnimType : int
        {
            Wait = 0,
            Walk = 1,
            Run = 2,
        }
    }
}