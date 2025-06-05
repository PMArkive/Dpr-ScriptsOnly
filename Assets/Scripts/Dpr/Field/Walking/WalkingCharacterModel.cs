using Audio;
using DG.Tweening;
using Dpr.RouteSearch;
using Dpr.SubContents;
using Pml.Personal;
using Pml.PokePara;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Dpr.Field.Walking
{
    public class WalkingCharacterModel
    {
        public WalkingCharacterController controller;
        public WalkData walkData;
        public WalkingCollisionModelBase collisionModel;

        public float bodySize { get => walkData.bodySize; set => walkData.bodySize = value; }
        public int CollidedCount { get => walkData.CollidedCount; set => walkData.CollidedCount = value; }
        public bool isStopUpdate { get => walkData.isStopUpdate; set => walkData.isStopUpdate = value; }
        public Type nowState { get => controller.AI.GetNowStateType(); }
        public AI AI
        {
            get
            {
                if (controller == null)
                    return null;

                return controller.AI;
            }
        }

        public event Action OnChangeState;
        public Func<FieldObjectEntity[]> GetWalkers;
        public PokemonParam pokePara;
        public Action<WalkingCharacterModel> OnWarp;
        public AnimationPlayer animPlayer;
        public Transform LookTarget;

        public FieldObjectEntity entity { get => walkData.entity; }
        public Transform transform { get => walkData.transform; }

        public bool isForceAnimation;
        public int PrevSleepLevel;
        public int SleepLevel;
        public bool isCanSleepAnimation;

        public bool isDestroyed { get; set; }

        public List<Vector3> route;
        private Vector3 PokeDefaultScale;
        public bool isWarping;
        public MoveType moveType;
        private NodeData nodeData;
        public Tween warpDelay;
        
        public bool isIgnoreJump { get => moveType == MoveType.FLY || (moveType == MoveType.RUN_FLY && walkData.isNeedRun); }

        public bool CheckState<T>()
        {
            return typeof(T) == nowState;
        }

        public void Update(WalkingCharacterModel Target, float baseOffsetScale, float baseSpeed)
        {
            if (Target != null)
            {
                walkData.TrackTarget = Target.walkData.entity.transform;
                walkData.TrackTargetBodySize = Target.walkData.bodySize;
            }
            else
            {
                walkData.TrackTarget = EntityManager.activeFieldPlayer.transform;
                walkData.TrackTargetBodySize = 0.5f;
            }

            LookTarget = walkData.TrackTarget;
            walkData.offsetScale = baseOffsetScale;
        }

        public WalkingCharacterModel(WalkData walkData)
        {
            this.walkData = walkData;
            collisionModel = new PokeCollitionModel(walkData);
            PokeDefaultScale = walkData.entity.transform.localScale;

            if (walkData.entity is FieldCharacterEntity || walkData.entity is FieldPokemonEntity)
                animPlayer = walkData.entity.GetAnimationPlayer();

            walkData.bodySize = 0.5f;
            nodeData = FieldObjectRoute.CreateNodeData(50, 50);
            isCanSleepAnimation = animPlayer.clips[FieldPokemonEntity.Animation.Kw_DrowseA] != null;
        }

        public void SetController(WalkingCharacterController controller)
        {
            this.controller = controller;
        }

        public void SetPokemonParam(PokemonParam pokePara)
        {
            var catalog = Utils.GetPokemonCatalog(pokePara);
            walkData.awayDistanceOffset = catalog.WalkStart;
            walkData.farDistanceOffset = catalog.RunStart;
            controller.walkDistance = catalog.WalkStart;
            controller.runDistance = catalog.RunStart;
            controller.walkSpeed = catalog.WalkSpeed;
            controller.runSpeed = catalog.RunSpeed;
            controller.bodySize = catalog.BodySize;

            this.pokePara = pokePara;
            PersonalSystem.LoadPersonalData(pokePara.GetMonsNo(), pokePara.GetFormNo());
            var weight = PersonalSystem.GetPersonalParam(ParamID.WEIGHT);

            if (weight < 500)
                walkData.WeightRank = 0;
            else if (weight < 1500)
                walkData.WeightRank = 1;
            else if (weight < 3000)
                walkData.WeightRank = 2;
            else
                walkData.WeightRank = 3;
        }

        public virtual void Destroy()
        {
            isDestroyed = true;

            if (AI != null)
            {
                // Result ignored
                bool _ = controller != null;

                controller.AI.GetNowState().Cancel();
            }

            controller = null;
            collisionModel = null;
            walkData = null;
            OnChangeState = null;
            GetWalkers = null;
            pokePara = null;
        }

        protected virtual void GetBodySize()
        {
            var go = transform.gameObject;
            string newName = go.name.Replace("(Clone)", "");
            var skin = go.transform.Find(newName + "_BodySkin");

            if (skin == null)
                skin = go.transform.Find(newName + "_Skin");

            if (skin == null)
                skin = go.transform.Find("VriTex00/" + newName + "_BodySkin");

            if (skin == null)
            {
                walkData.bodySize = 0.5f;
            }
            else
            {
                var extents = skin.GetComponent<SkinnedMeshRenderer>().sharedMesh.bounds.extents;
                walkData.bodySize = Mathf.Max(extents.x, extents.z);
                walkData.bodySize = walkData.bodySize > 0.2f ? walkData.bodySize : 0.2f;
            }
        }

        public List<Vector3> GetRoute(Vector3 goalPos, int SearchDistance)
        {
            var matrix = GameManager.GetMapAttributeMattrix();
            var objs = EntityManager.fieldObjects.Except(GetWalkers.Invoke()).Select(x => x.gridPosition).ToList();
            objs.Add(new Vector2Int(35, 20));

            if (nodeData == null)
                nodeData = FieldObjectRoute.CreateNodeData(SearchDistance, SearchDistance);
            else
                nodeData.SetupNodesAndSetGoal(new Vector2Int(-(int)goalPos.x, (int)goalPos.z));

            nodeData.AddCantEntryObjectsPositions = objs.ToArray();
            return FieldObjectRoute.Search(ObjectType.LAND, entity.transform.position, goalPos, matrix, nodeData)?.ToList();
        }

        public void CreateRoute(Vector3 goalPos, int SearchDistance)
        {
            route = GetRoute(goalPos, SearchDistance);
        }

        public IEnumerator WaitforAnimationFinish(CancelCheck cancelCheck)
        {
            if (!animPlayer.IsValidCurrentPlayable)
                yield break;

            var halfTime = animPlayer.currentRemaingTime * 0.5f;
            var isUnderHalf = false;

            while (animPlayer.IsValidCurrentPlayable && animPlayer.currentRemaingTime >= 0.05f && !animPlayer.IsPlayingEnd)
            {
                if (animPlayer.currentRemaingTime <= halfTime)
                    isUnderHalf = true;
                else if (!isUnderHalf || animPlayer.currentRemaingTime <= halfTime)
                    yield return null;
                else
                    yield break;

                if (!cancelCheck.Invoke())
                    yield break;
            }
        }

        public void Warp(Vector3 pos, bool immidiate = false)
        {
            var t = Exit(immidiate);

            warpDelay?.Kill();
            warpDelay = null;

            t.OnComplete(() =>
            {
                OnWarp?.Invoke(this);
                warpDelay = DOVirtual.DelayedCall(immidiate ? 0.0f : 0.8f, () =>
                {
                    warpDelay = null;
                    if (pokePara != null)
                    {
                        if (!controller.isFureai && !FieldManager.fwMng.IsCanTurearuki(pokePara))
                            return;

                        entity.SetPositionDirect(new Vector3(pos.x, 30.0f, pos.z));
                        Enter(immidiate);
                    }
                });
            });
        }

        public Tweener Enter(Vector3 pos, bool dontSE = false)
        {
            entity.SetPositionDirect(new Vector3(pos.x, 30.0f, pos.z));
            return Enter(dontSE);
        }

        public Tweener Enter(bool dontSE = false)
        {
            Utils.WaitFrame(2, () => CreateWarpEffect());

            controller.SetActive(true);

            if (!dontSE)
                AudioManager.Instance.PlaySe(AK.EVENTS.PLAY_BA_SYS_POKE_APPERANCE_FIELD, null);

            walkData.isStopUpdate = false;
            entity.transform.localScale = Vector3.zero;

            DOVirtual.DelayedCall(0.3f, () => isWarping = false);

            controller.InitState();
            return entity.transform.DOScale(PokeDefaultScale, 0.3f);
        }

        public Tween Exit(bool dontSE)
        {
            CreateWarpEffect();
            isWarping = true;

            if (!dontSE)
                AudioManager.Instance.PlaySe(AK.EVENTS.PLAY_BA_SYS_BALL_OPEN_FIELD, null);

            entity.transform.DOScale(Vector3.zero, 0.2f);
            return DOVirtual.DelayedCall(0.2f, () =>
            {
                if (controller != null)
                {
                    walkData.isStopUpdate = true;
                    controller.SetActive(false);
                }
            });
        }

        public void CreateWarpEffect()
        {
            if (isDestroyed)
                return;

            FieldManager.Instance.CallEffect(EffectFieldID.EF_F_POKEMON_APPEAR, CreateEffectPosTransform(entity.transform.position, 0.8f), null, null);
        }

        public Transform CreateEffectPosTransform(Vector3 pos, float duration)
        {
            var tra = new GameObject().transform;
            tra.position = pos;

            DOVirtual.DelayedCall(duration, () => UnityEngine.Object.Destroy(tra.gameObject));

            return tra;
        }

        public delegate bool CancelCheck();
    }
}