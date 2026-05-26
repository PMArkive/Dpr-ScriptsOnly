using Dpr.EvScript;
using Dpr.FureaiHiroba;
using Dpr.SubContents;
using SmartPoint.AssetAssistant;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Dpr.Field.Walking
{
    public class WalkingAIManager
    {
        private List<WalkingCharacterController> walkingCharacters = new List<WalkingCharacterController>();
        public bool isAllStop;

        [SerializeField]
        private FieldObjectEntity testEntity;

        [Button("TestAdd", "TestAdd", new object[0])]
        public int Button01;
        [Button("TestSub", "TestSub", new object[0])]
        public int Button02;

        public WalkingCharacterController ToWalkingCharacter(FieldObjectEntity entity)
        {
            var controller = CommonSetUp(entity);
            EvDataManager.Instanse.FieldObjectEntityAdd(entity);

            entity.EventParams.Type = EvDataManager.EntityType.Npc;
            entity.EventParams.VanishFlagIndex = 1;

            Sequencer.earlyLateUpdate += controller.MyUpdate;
            Sequencer.lateUpdate += controller.MyLateUpdate;

            walkingCharacters.Add(controller);

            return controller;
        }

        public virtual void Destroy(bool isDestroyGameObject = false)
        {
            for (int i=walkingCharacters.Count; i>0; i--)
            {
                if (walkingCharacters[0] != null && walkingCharacters[0].model.entity.GetType() == typeof(FieldPokemonEntity))
                    SubWalkingCharacter(walkingCharacters[0].model.entity, isDestroyGameObject);
            }

            if (isDestroyGameObject)
                EntityManager.BuildFieldEntities();

            walkingCharacters.Clear();
        }

        public void StopAll(bool isStop)
        {
            if (isAllStop != isStop)
            {
                isAllStop = isStop;

                var speed = isStop ? 0.0f : 1.0f;

                for (int i=0; i<walkingCharacters.Count; i++)
                {
                    var chara = walkingCharacters[i];
                    if (chara.view.GetAnimPlayer().IsValidCurrentPlayable)
                        chara.view.GetAnimPlayer().SetAnimSpeed(speed);

                    chara.model.isStopUpdate = isStop;
                }
            }
        }

        private WalkingCharacterModel CreateFieldWalkModel(FieldObjectEntity entity)
        {
            return new WalkingCharacterModel(new WalkData(entity));
        }

        private WalkingCharacterController CommonSetUp(FieldObjectEntity entity)
        {
            var go = entity.gameObject;
            var scale = go.transform.localScale;

            var controller = AddController(go);
            var model = CreateFieldWalkModel(entity);
            model.controller = controller;

            var view = go.AddComponent<WalkingCharacterView>();
            view.SetAnimPlayer(model.animPlayer);
            view.PokeScale = scale.x;

            if (entity.GetType() == typeof(FieldPokemonEntity))
                view.ChangeUpdateWhenOffScreen(entity as FieldPokemonEntity);

            controller.view = view;
            controller.SetModel(model);

            model.transform.Find("Origin")?.gameObject.AddComponent<MoveHosei>();

            EntityManager.BuildFieldEntities();

            return controller;
        }

        protected virtual WalkingCharacterController AddController(GameObject go)
        {
            return go.AddComponent<WalkingCharacterController>();
        }

        public void SubWalkingCharacter(FieldObjectEntity entity, bool isDestroy = false)
        {
            var go = entity.gameObject;
            var controller = go.GetComponent<WalkingCharacterController>();

            if (controller == null)
                return;

            var model = controller.model;

            controller.view.AnimPlay(FieldPokemonEntity.Animation.Idle);
            controller.emoticon.Delete();

            if (go.transform.Find("Origin") != null)
                UnityEngine.Object.Destroy(go.transform.Find("Origin").gameObject.GetComponent<MoveHosei>());

            Sequencer.earlyLateUpdate -= controller.MyUpdate;
            Sequencer.lateUpdate -= controller.MyLateUpdate;

            walkingCharacters.Remove(controller);
            controller.isSubWalking = true;
            UnityEngine.Object.Destroy(controller);

            model.Destroy();

            testEntity = null;

            if (isDestroy)
            {
                EntityManager.Remove(entity);
                UnityEngine.Object.Destroy(go);
            }
        }

        public void TestAdd()
        {
            if (testEntity != null)
                TestSub();

            ToWalkingCharacter(testEntity);
        }

        public void TestSub()
        {
            if (testEntity != null)
                SubWalkingCharacter(testEntity);
        }

        public static List<Vector2Int> GetNearEmptyPosition(Vector2Int grid, bool ignoreNaname = false, bool isFureai = false)
        {
            // Result ignored
            _ = EntityManager.activeFieldPlayer.Height;

            var matrix = GameManager.GetMapAttributeMattrix();
            var result = new List<Vector2Int>();

            var positions = EntityManager.fieldObjects.Select(x => x.gridPosition).ToList();

            for (int x=-1; x!=2; x++)
            {
                for (int y=-1; y!=2; y++)
                {
                    var CheckGrid = grid + new Vector2Int(x, y);
                    GameManager.GetAttribute(CheckGrid, out int code, out int stop, true);

                    var enterable = Utils.isEnterbleAttribute(code, stop, MoveType.FLY);
                    if (isFureai && Array.Exists(FureaiDataManager.DontEnterPoints, a => a == grid))
                        enterable = Utils.MoveTypeResult.CantEnter;

                    var objectInPosition = positions.Exists(pos => pos == CheckGrid);

                    if (enterable == Utils.MoveTypeResult.OK && (x != 0 || y != 0) && !objectInPosition)
                        result.Add(new Vector2Int(x, y));
                }
            }

            return result;
        }
    }
}