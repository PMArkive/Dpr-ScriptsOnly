using Dpr.EvScript;
using Dpr.FureaiHiroba;
using Dpr.SubContents;
using GameData;
using Pml;
using System;
using System.Collections.Generic;
using UnityEngine;
using XLSXContent;

namespace Dpr.Field.Walking
{
    public class WalkingCharacterController : MonoBehaviour
    {
        public WalkingCharacterModel model;
        public WalkingCharacterView view;
        public AI AI;
        protected PokeEffect effectManager;
        public Emoticon emoticon;
        public event Action<int> NeedEffect;
        public bool isChousei = true;
        public Func<List<FureaiPokeModel>> getWalkingCharacters;
        public VoicePlayerAmbient voicePlayer;
        public bool isFureai;
        public bool isFieldWalking;
        public bool isSubWalking;
        public float bodySize;
        public float walkDistance;
        public float runDistance;
        public float walkSpeed;
        public float runSpeed;
        public float nowSpeed;
        public float nowDistance;
        public bool nowRunMode;
        public float targetDistance;
        public float targetDistanceOffset;
        public GameObject DebugBodySizeView;
        [Button("ChangePositionNPC", "ChangePositionNPC", new object[0])]
        public int Button05;
        public int DebugAnimIndex = 1;
        [Button("TestAnim", "TestAnim", new object[0])]
        public int Button06;
        [Button("InitAnimationPlayer", "InitAnimationPlayer", new object[0])]
        public int Button07;
        public ActionState actionState;
        public ActionState nextActionState;
        public ActionState nextTalkState;
        public Action<float> talkAction;
        public AnimeState animeState;
        public AnimeState nextAnimeState;
        public AnimeState talkAnimeState;
        public AnimeState prevAnimeState;
        public PokemonInfo.SheetTrearuki trearukiAnimeInfo;
        private const float MotionWait = 0.033333335f;

        public WalkData walkModel { get => model.walkData; }

        protected void Awake()
        {
            emoticon = gameObject.AddComponentIfNecessary<Emoticon>();
            voicePlayer = gameObject.AddComponentIfNecessary<VoicePlayerAmbient>();
        }

        private void OnDestroy()
        {
            Destroy(emoticon);
            effectManager.Destroy();
            model.Destroy();

            effectManager = null;
            emoticon = null;
            NeedEffect = null;
            getWalkingCharacters = null;
            voicePlayer = null;
            model = null;
            view = null;

            AI.Destroy();

            if (!isSubWalking && FieldManager.fwMng != null && FlagWork.GetSysFlag(EvScript.EvWork.SYSFLAG_INDEX.SYS_FLAG_PAIR))
            {
                FieldManager.fwMng.PartnerNPC_ObjectName = "";
                FieldManager.fwMng.NPCToPartner();
            }
        }

        public void PlayVoice(MonsNo monsNo, int formNo, int voiceNo)
        {
            voicePlayer.PlayVoice(monsNo, formNo, voiceNo);
        }

        public virtual void SetModel(WalkingCharacterModel model)
        {
            this.model = model;
            AI = new AI(this);
            effectManager = new PokeEffect(transform);

            AISetting();
        }

        public virtual AIModel CreateAIModel()
        {
            return new AIModel(this);
        }

        public virtual void AISetting()
        {
            // Empty
        }

        public void SetView(WalkingCharacterView view)
        {
            this.view = view;
        }

        protected virtual void OnNeedEffect(int EffectID)
        {
            NeedEffect?.Invoke(EffectID);
        }

        protected virtual void ModelUpdate(float deltaTime)
        {
            model.Update(null, 1.0f, 1.0f);
            walkModel.Update(deltaTime);
        }

        public virtual void MyUpdate(float deltaTime)
        {
            if (model.isDestroyed)
                return;

            if (gameObject == null)
                return;

            if (!gameObject.activeInHierarchy)
                return;

            model.collisionModel.isCollidedAdd = false;
            if (isChousei)
                Chousei();

            if (model.walkData.isStopUpdate)
                return;

            if (model.entity.EventParams.IsEventRunning)
            {
                walkModel.moveVec = Vector3.zero; // BUG: Supposed to be setting prevMoveVec to zero most likely
                walkModel.moveVec = Vector3.zero;

                if (IsTurearukiData())
                {
                    walkModel.isNeedWalk = false;
                    walkModel.isNeedRun = false;
                    UpdateState(deltaTime);
                }
                else
                {
                    view.AutoSelectAnimation(model);
                }
            }
            else
            {
                if (!isFureai)
                {
                    bool stopUpdate = EvDataManager.Instanse.isUpdateDelegate();
                    if (!isFieldWalking)
                        stopUpdate |= !PlayerWork.isPlayerInputActive;

                    if (view.GetAnimPlayer().IsValidCurrentPlayable)
                        view.GetAnimPlayer().SetAnimSpeed(EvDataManager.Instanse.isUpdateDelegate() ? 0.0f : 1.0f);

                    if (stopUpdate)
                        return;
                }

                ModelUpdate(deltaTime);
                AI.Update();

                walkModel.prevMoveVec = walkModel.moveVec;

                if (IsTurearukiData())
                {
                    if (view.isNeedWait())
                    {
                        walkModel.prevMoveVec = Vector3.zero;
                        walkModel.moveVec = Vector3.zero;
                    }

                    UpdateState(deltaTime);
                }
                else if (view.isNeedWait())
                {
                    walkModel.prevMoveVec = Vector3.zero;
                    walkModel.moveVec = Vector3.zero;
                }

                CheckAttribute();
                model.collisionModel.CollisionUpdate(deltaTime);
                model.collisionModel.ObjectCollisionUpdate(deltaTime, model.isIgnoreJump);

                CheckAttribute();
                model.collisionModel.UpdateCollisionCount();
            }
        }

        public virtual void CheckAttribute()
        {
            if (Utils.isEnterbleAttribute(walkModel.entity.transform.position + walkModel.moveVec, MoveType.FLY, isFureai) != Utils.MoveTypeResult.OK)
            {
                model.collisionModel.isCollidedAdd = true;
                walkModel.moveVec = Vector3.zero;
            }
        }

        protected virtual List<FureaiPokeModel> GetWalkingCharacters()
        {
            return null;
        }

        public virtual void MyLateUpdate(float deltaTime)
        {
            model.collisionModel.LateUpdate(deltaTime);
        }

        protected void Chousei()
        {
            walkModel.targetDistanceOffset = 0.5f;
            walkModel.awayDistanceOffset = walkDistance;
            walkModel.farDistanceOffset = runDistance;
            model.bodySize = bodySize;
            walkModel.walkSpeed = walkSpeed;
            walkModel.runSpeed = runSpeed;

            if (EntityManager.activeFieldPlayer.IsRideBicycle() && runSpeed > 2.0f)
                walkModel.runSpeed *= 1.5f;

            nowSpeed = walkModel.nowSpeed;
            nowDistance = walkModel.distance;
            nowRunMode = walkModel.isNeedRun;
            targetDistance = walkModel.targetDistance;
            targetDistanceOffset = walkModel.targetDistanceOffset;

            if (!isFureai)
                walkModel.Offset = Vector3.zero;

            if (FieldWalkingManager.DebugMode)
            {
                if (DebugBodySizeView == null)
                {
                    DebugBodySizeView = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    DebugBodySizeView.name = "BodySizeView";
                    DebugBodySizeView.transform.parent = transform;
                    DebugBodySizeView.transform.localPosition = Vector3.zero;
                }

                DebugBodySizeView.transform.localScale = new Vector3(bodySize, 0.1f, bodySize);
            }
            else
            {
                if (DebugBodySizeView != null)
                    Destroy(DebugBodySizeView);
            }
        }

        public void ChangePositionNPC()
        {
            FieldManager.fwMng.ChangePositionNPC();
        }

        public void TestAnim()
        {
            AI.GetNowState().Play(new PlayAnim(DebugAnimIndex), null);
        }

        public void InitAnimationPlayer()
        {
            model.entity.enabled = false;
            model.entity.enabled = true;

            view.GetAnimPlayer().Play(view.GetAnimPlayer().currentIndex, 0.0f, view.GetAnimPlayer().currentPlayingTime);
        }

        private void InitializeTrearukiData()
        {
            trearukiAnimeInfo = DataManager.GetPokemonCatalogTrearuki(model.pokePara.GetMonsNo(), model.pokePara.GetFormNo(), model.pokePara.GetSex(), model.pokePara.IsRare());
            InitState();
        }

        public void InitState()
        {
            if (!IsTurearukiData())
                return;

            actionState = ActionState.Disable;
            nextActionState = ActionState.Disable;
            animeState = AnimeState.Disable;
            nextAnimeState = AnimeState.Disable;

            view.State_PlayAnime(trearukiAnimeInfo.AnimeIndex[0], trearukiAnimeInfo.AnimeDuration[0]);
        }

        private void ChangeAnimeState(AnimeState state)
        {
            nextAnimeState = state;
        }

        public void ChangeTalkAnimeState(AnimeState state)
        {
            ChangeAnimeState(AnimeState.TalkStart);
            talkAnimeState = state;
        }

        public void ChangeActionState(ActionState state)
        {
            nextActionState = state;
        }

        public void ChangeTalkState(ActionState state)
        {
            nextTalkState = state;
        }

        public bool IsTurearukiData()
        {
            return trearukiAnimeInfo != null && trearukiAnimeInfo.Enable;
        }

        private bool UpdateState(float deltatime)
        {
            if (!IsTurearukiData())
                return false;

            view.DebugAnimeState();

            if (actionState != nextActionState)
            {
                switch (nextActionState)
                {
                    case ActionState.Stay:
                        switch (actionState)
                        {
                            case ActionState.MoveWalk:
                                ChangeAnimeState(AnimeState.WalkEndWait);
                                break;

                            case ActionState.MoveRun:
                                ChangeAnimeState(AnimeState.RunEndWait);
                                break;
                        }
                        break;

                    case ActionState.MoveWalk:
                        switch (animeState)
                        {
                            case AnimeState.Run:
                                ChangeAnimeState(AnimeState.Walk);
                                break;

                            default:
                                ChangeAnimeState(AnimeState.WalkStart);
                                break;
                        }
                        break;

                    case ActionState.MoveRun:
                        switch (animeState)
                        {
                            case AnimeState.Walk:
                                ChangeAnimeState(AnimeState.Run);
                                break;

                            default:
                                ChangeAnimeState(AnimeState.RunStart);
                                break;
                        }
                        break;

                    case ActionState.TalkStayWait:
                        switch (actionState)
                        {
                            case ActionState.MoveWalk:
                                ChangeAnimeState(AnimeState.WalkEndWait);
                                break;

                            case ActionState.MoveRun:
                                ChangeAnimeState(AnimeState.RunEndWait);
                                break;
                        }
                        ChangeTalkState(ActionState.TalkStayWait);
                        break;

                    case ActionState.Happy:
                        ChangeAnimeState(AnimeState.Happy);
                        break;

                    case ActionState.Hate:
                        ChangeAnimeState(AnimeState.Hate);
                        break;

                    case ActionState.DrowSe:
                        ChangeAnimeState(AnimeState.DrowSeA01);
                        break;

                    case ActionState.Roar:
                        ChangeAnimeState(AnimeState.Roar);
                        break;

                    case ActionState.Tokusyu:
                        ChangeAnimeState(AnimeState.Tokusyu);
                        break;

                    case ActionState.Buturi:
                        ChangeAnimeState(AnimeState.Buturi);
                        break;
                }

                actionState = nextActionState;
            }

            NextAnimeState();
            UpdateActionState(deltatime);
            UpdateAnimeState(deltatime);

            return true;
        }

        private void UpdateAnimeState(float deltatime)
        {
            if (animeState > AnimeState.TalkEnd)
                return;

            var checkState = GetAnimeIndex(animeState);

            switch (animeState)
            {
                case AnimeState.WaitStart:
                    if (view.PlayAnimeTime(checkState) >= MotionWait)
                        ChangeAnimeState(AnimeState.Wait);
                    break;

                case AnimeState.Wait:
                case AnimeState.Walk:
                case AnimeState.Run:
                case AnimeState.TalkStartWait:
                    break;

                case AnimeState.WalkStart:
                    if (view.IsPlayAnimeEnd(checkState))
                        ChangeAnimeState(AnimeState.WalkStartWait);
                    break;

                case AnimeState.WalkEnd:
                case AnimeState.RunEnd:
                case AnimeState.TalkEnd:
                    if (view.IsPlayAnimeEnd(checkState))
                        ChangeAnimeState(AnimeState.WaitStart);
                    break;

                case AnimeState.Disable:
                    ChangeAnimeState(AnimeState.WaitStart);
                    break;

                case AnimeState.RunStart:
                    if (view.IsPlayAnimeEnd(checkState))
                        ChangeAnimeState(AnimeState.RunStartWait);
                    break;

                case AnimeState.DrowSeA01:
                    if (view.IsPlayAnimeEnd(checkState))
                        ChangeAnimeState(AnimeState.DrowSeB01);
                    break;

                case AnimeState.DrowSeB01:
                    if (view.IsPlayAnimeEnd(checkState))
                        ChangeAnimeState(AnimeState.DrowSeC01);
                    break;

                case AnimeState.WalkStartWait:
                    if (view.PlayAnimeTime(checkState) >= MotionWait)
                        ChangeAnimeState(AnimeState.Walk);
                    break;

                case AnimeState.WalkEndWait:
                    if (view.PlayAnimeTime(checkState) >= MotionWait)
                        ChangeAnimeState(AnimeState.WalkEnd);
                    break;

                case AnimeState.RunStartWait:
                    if (view.PlayAnimeTime(checkState) >= MotionWait)
                        ChangeAnimeState(AnimeState.Run);
                    break;

                case AnimeState.RunEndWait:
                    if (view.PlayAnimeTime(checkState) >= MotionWait)
                        ChangeAnimeState(AnimeState.RunEnd);
                    break;

                case AnimeState.TalkStart:
                    if (view.PlayAnimeTime(checkState) >= MotionWait)
                        ChangeAnimeState(AnimeState.TalkStartWait);
                    break;

                case AnimeState.TalkEndWait:
                    if (view.PlayAnimeTime(checkState) >= MotionWait)
                        ChangeAnimeState(AnimeState.TalkEnd);
                    break;

                default:
                    if (view.IsPlayAnimeEnd(checkState))
                        ChangeAnimeState(AnimeState.TalkEndWait);
                    break;
            }
        }

        private int GetAnimeIndex(AnimeState state)
        {
            return trearukiAnimeInfo.AnimeIndex[(int)state];
        }

        private void NextAnimeState()
        {
            if (nextAnimeState == animeState)
                return;

            while (!view.State_PlayAnime(GetAnimeIndex(nextAnimeState), trearukiAnimeInfo.AnimeDuration[(int)nextAnimeState]))
            {
                bool unknownState = false;
                switch (nextAnimeState)
                {
                    case AnimeState.Disable: ChangeAnimeState(AnimeState.WaitStart); break;
                    case AnimeState.WaitStart: ChangeAnimeState(AnimeState.Wait); break;
                    case AnimeState.WalkStart: ChangeAnimeState(AnimeState.WalkStartWait); break;
                    case AnimeState.WalkEnd: ChangeAnimeState(AnimeState.WaitStart); break;
                    case AnimeState.RunStart: ChangeAnimeState(AnimeState.RunStartWait); break;
                    case AnimeState.RunEnd: ChangeAnimeState(AnimeState.WaitStart); break;
                    case AnimeState.Happy: ChangeAnimeState(AnimeState.TalkEndWait); break;
                    case AnimeState.Hate: ChangeAnimeState(AnimeState.TalkEndWait); break;
                    case AnimeState.Roar: ChangeAnimeState(AnimeState.TalkEndWait); break;
                    case AnimeState.Tokusyu: ChangeAnimeState(AnimeState.TalkEndWait); break;
                    case AnimeState.Buturi: ChangeAnimeState(AnimeState.TalkEndWait); break;
                    case AnimeState.DrowSeA01: ChangeAnimeState(AnimeState.DrowSeB01); break;
                    case AnimeState.DrowSeB01: ChangeAnimeState(AnimeState.DrowSeC01); break;
                    case AnimeState.DrowSeC01: ChangeAnimeState(AnimeState.TalkEndWait); break;
                    case AnimeState.WalkStartWait: ChangeAnimeState(AnimeState.Walk); break;
                    case AnimeState.WalkEndWait: ChangeAnimeState(AnimeState.WalkEnd); break;
                    case AnimeState.RunStartWait: ChangeAnimeState(AnimeState.Run); break;
                    case AnimeState.RunEndWait: ChangeAnimeState(AnimeState.RunEnd); break;
                    case AnimeState.TalkStart: ChangeAnimeState(AnimeState.TalkStartWait); break;
                    case AnimeState.TalkEndWait: ChangeAnimeState(AnimeState.TalkEnd); break;
                    case AnimeState.TalkEnd: ChangeAnimeState(AnimeState.WaitStart); break;

                    default:
                        unknownState = true;
                        break;
                }

                prevAnimeState = animeState;
                animeState = nextAnimeState;

                if (unknownState)
                    break;
            }
        }

        private void UpdateActionState(float deltatime)
        {
            switch (actionState)
            {
                case ActionState.Disable:
                    if (animeState == AnimeState.Wait)
                        ChangeActionState(ActionState.Stay);
                    break;

                case ActionState.Stay:
                    if (animeState == AnimeState.Wait)
                    {
                        if (walkModel.isNeedRun)
                            ChangeActionState(ActionState.MoveRun);
                        else if (walkModel.isNeedWalk)
                            ChangeActionState(ActionState.MoveWalk);
                    }
                    break;

                case ActionState.MoveWalk:
                    if (animeState == AnimeState.Run || animeState == AnimeState.Walk)
                    {
                        if (walkModel.isNeedRun)
                        {
                            ChangeActionState(ActionState.MoveRun);
                            return;
                        }
                        else if (!walkModel.isNeedWalk)
                        {
                            ChangeActionState(ActionState.Stay);
                            break;
                        }
                        else
                        {
                            return;
                        }
                    }
                    break;

                case ActionState.MoveRun:
                    if (animeState == AnimeState.Run || animeState == AnimeState.Walk)
                    {
                        if (walkModel.isNeedRun)
                        {
                            return;
                        }
                        else if (walkModel.isNeedWalk)
                        {
                            ChangeActionState(ActionState.MoveWalk);
                            return;
                        }
                        else
                        {
                            ChangeActionState(ActionState.Stay);
                            return;
                        }
                    }
                    break;

                case ActionState.TalkStayWait:
                    switch (animeState)
                    {
                        case AnimeState.Wait:
                            ChangeAnimeState(AnimeState.TalkStart);
                            return;

                        case AnimeState.TalkStartWait:
                            talkAction?.Invoke(deltatime);
                            if (nextTalkState != ActionState.TalkStayWait)
                                ChangeActionState(nextTalkState);
                            return;

                        default:
                            return;
                    }

                case ActionState.Happy:
                case ActionState.Hate:
                case ActionState.DrowSe:
                case ActionState.Roar:
                case ActionState.Tokusyu:
                case ActionState.Buturi:
                    switch (animeState)
                    {
                        case AnimeState.Wait:
                        case AnimeState.TalkEndWait:
                        case AnimeState.TalkEnd:
                            if (FieldManager.fwMng.pokeTalkModel != null)
                            {
                                FieldManager.fwMng.pokeTalkModel.isMotionEnd = true;
                                if (FieldManager.fwMng.pokeTalkModel.isTalkEnd)
                                {
                                    if (FieldWalkingManager.talkState == FieldWalkingManager.TalkState.Talking)
                                        FieldWalkingManager.talkState = FieldWalkingManager.TalkState.TalkEnd;

                                    model.isForceAnimation = false;
                                }
                            }
                            ChangeActionState(ActionState.TalkEndWait);
                            break;
                    }
                    break;

                case ActionState.TalkEndWait:
                    switch (animeState)
                    {
                        case AnimeState.Wait:
                            if (FieldManager.fwMng.pokeTalkModel != null)
                            {
                                FieldManager.fwMng.pokeTalkModel.isMotionEnd = true;
                                if (FieldManager.fwMng.pokeTalkModel.isTalkEnd)
                                {
                                    if (FieldWalkingManager.talkState == FieldWalkingManager.TalkState.Talking)
                                        FieldWalkingManager.talkState = FieldWalkingManager.TalkState.TalkEnd;

                                    model.isForceAnimation = false;
                                }
                            }
                            ChangeActionState(ActionState.Stay);
                            break;

                        case AnimeState.TalkStartWait:
                            if (view.IsNullStateAnime(GetAnimeIndex(AnimeState.TalkStartWait)))
                            {
                                if (FieldManager.fwMng.pokeTalkModel != null)
                                {
                                    FieldManager.fwMng.pokeTalkModel.isMotionEnd = true;
                                    if (FieldManager.fwMng.pokeTalkModel.isTalkEnd)
                                    {
                                        if (FieldWalkingManager.talkState == FieldWalkingManager.TalkState.Talking)
                                            FieldWalkingManager.talkState = FieldWalkingManager.TalkState.TalkEnd;

                                        model.isForceAnimation = false;
                                    }
                                }
                                ChangeActionState(ActionState.Stay);
                                ChangeAnimeState(AnimeState.WaitStart);
                            }
                            else
                            {
                                ChangeAnimeState(AnimeState.TalkEndWait);
                            }
                            break;

                        case AnimeState.TalkEndWait:
                            if (view.IsNullStateAnime(GetAnimeIndex(AnimeState.TalkEndWait)))
                            {
                                if (FieldManager.fwMng.pokeTalkModel != null)
                                {
                                    FieldManager.fwMng.pokeTalkModel.isMotionEnd = true;
                                    if (FieldManager.fwMng.pokeTalkModel.isTalkEnd)
                                    {
                                        if (FieldWalkingManager.talkState == FieldWalkingManager.TalkState.Talking)
                                            FieldWalkingManager.talkState = FieldWalkingManager.TalkState.TalkEnd;

                                        model.isForceAnimation = false;
                                    }
                                }
                                ChangeActionState(ActionState.Stay);
                            }
                            break;
                    }
                    break;

                case ActionState.TalkNormal:
                    switch (animeState)
                    {
                        case AnimeState.TalkStartWait:
                        case AnimeState.TalkEndWait:
                            if (view.PlayAnimeTime(GetAnimeIndex(animeState)) >= 3.0f)
                            {
                                FieldManager.fwMng.pokeTalkModel.isMotionEnd = true;
                                model.isForceAnimation = false;
                                ChangeActionState(ActionState.TalkEndWait);
                            }
                            else
                            {
                                if (FieldManager.fwMng.pokeTalkModel != null)
                                {
                                    FieldManager.fwMng.pokeTalkModel.isMotionEnd = true;
                                    if (FieldManager.fwMng.pokeTalkModel.isTalkEnd)
                                    {
                                        if (FieldWalkingManager.talkState == FieldWalkingManager.TalkState.Talking)
                                            FieldWalkingManager.talkState = FieldWalkingManager.TalkState.TalkEnd;

                                        model.isForceAnimation = false;
                                        ChangeActionState(ActionState.TalkEndWait);
                                    }
                                }
                            }
                            break;
                    }
                    break;

                default:
                    return;
            }

            walkModel.prevMoveVec = Vector3.zero;
            walkModel.moveVec = Vector3.zero;
        }

        private void NextActionState()
        {
            if (nextActionState == actionState)
                return;

            switch (nextActionState)
            {
                case ActionState.Stay:
                    switch (actionState)
                    {
                        case ActionState.MoveWalk: ChangeAnimeState(AnimeState.WalkEndWait); break;
                        case ActionState.MoveRun: ChangeAnimeState(AnimeState.RunEndWait); break;
                    }
                    break;

                case ActionState.MoveWalk:
                    if (animeState == AnimeState.Run) ChangeAnimeState(AnimeState.Walk);
                    else ChangeAnimeState(AnimeState.WalkStart);
                    break;

                case ActionState.MoveRun:
                    if (animeState == AnimeState.Walk) ChangeAnimeState(AnimeState.Run);
                    else ChangeAnimeState(AnimeState.RunStart);
                    break;

                case ActionState.TalkStayWait:
                    switch (actionState)
                    {
                        case ActionState.MoveWalk: ChangeAnimeState(AnimeState.WalkEndWait); break;
                        case ActionState.MoveRun: ChangeAnimeState(AnimeState.RunEndWait); break;
                    }
                    ChangeTalkState(ActionState.TalkStayWait);
                    break;

                case ActionState.Happy:
                    ChangeAnimeState(AnimeState.Happy);
                    break;

                case ActionState.Hate:
                    ChangeAnimeState(AnimeState.Hate);
                    break;

                case ActionState.DrowSe:
                    ChangeAnimeState(AnimeState.DrowSeA01);
                    break;

                case ActionState.Roar:
                    ChangeAnimeState(AnimeState.Roar);
                    break;

                case ActionState.Tokusyu:
                    ChangeAnimeState(AnimeState.Tokusyu);
                    break;

                case ActionState.Buturi:
                    ChangeAnimeState(AnimeState.Buturi);
                    break;
            }

            actionState = nextActionState;
        }

        public bool IsEventTalkOK(FieldObjectEntity entity)
        {
            if (IsTurearukiData())
            {
                if (model?.entity != null && model.entity == entity)
                {
                    switch (actionState)
                    {
                        case ActionState.Stay:
                        case ActionState.MoveWalk:
                        case ActionState.MoveRun:
                            return true;

                        default:
                            return false;
                    }
                }
            }

            return true;
        }

        public enum ActionState : int
        {
            Disable = 0,
            Stay = 1,
            MoveWalk = 2,
            MoveRun = 3,
            TalkStayWait = 4,
            Happy = 5,
            Hate = 6,
            DrowSe = 7,
            Roar = 8,
            Tokusyu = 9,
            Buturi = 10,
            TalkEndWait = 11,
            TalkNormal = 12,
        }

        public enum AnimeState : int
        {
            Disable = 0,
            WaitStart = 1,
            Wait = 2,
            WalkStart = 3,
            Walk = 4,
            WalkEnd = 5,
            RunStart = 6,
            Run = 7,
            RunEnd = 8,
            Happy = 9,
            Hate = 10,
            DrowSeA01 = 11,
            DrowSeB01 = 12,
            DrowSeC01 = 13,
            Roar = 14,
            Tokusyu = 15,
            Buturi = 16,
            WalkStartWait = 17,
            WalkEndWait = 18,
            RunStartWait = 19,
            RunEndWait = 20,
            TalkStart = 21,
            TalkStartWait = 22,
            TalkEndWait = 23,
            TalkEnd = 24,
        }
    }
}