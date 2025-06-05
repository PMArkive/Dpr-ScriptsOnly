using Dpr.Field.Walking;
using Pml.PokePara;
using Pml;
using System.Collections.Generic;
using UnityEngine;
using Dpr.Message;

namespace Dpr.FureaiHiroba
{
    public sealed class FureaiPokeModel : WalkingCharacterModel
    {
        public bool isSelectPoke;
        public float stateTime;
        public bool isCollided;
        public List<int> CanAnimationList = new List<int>();
        public int CollisionHitCount;
        public int MonohiroiItemNo = -1;
        public int MonohiroiSealNo = -1;
        private FureaiDataManager dataManager;
        public GetFureaiPokes GetHirobaPokes;
        private PokemonParam pokeParam;

        public FureaiPokeController controller { get => base.controller as FureaiPokeController; }
        public PokeSanpoModel sanpoModel { get; set; }
        public uint TemotiNo { get => PlayerWork.playerParty.GetMemberIndex(pokeParam); }
        public uint nakayoshi { get => pokeParam.GetFriendship(); }
        public uint pokeID { get => pokePara.GetID(); }
        public MonsNo monsNo { get => pokeParam.GetMonsNo(); }
        public Seikaku seikaku { get => pokeParam.GetSeikaku(); }
        public string NickName { get => pokeParam.GetNickName(); }

        public FureaiPokeModel(WalkData walkData, PokemonParam pokeParam, FureaiDataManager dataMng) : base(walkData)
        {
            this.pokeParam = pokeParam;
            this.dataManager = dataMng;

            var kuse = dataMng.ActionKuseList.Find(x => x.PokeID == (int)monsNo);

            if (kuse.kw32_happyA01)
                CanAnimationList.Add(FieldPokemonEntity.Animation.Happy01);

            if (kuse.kw32_happyB01)
                CanAnimationList.Add(FieldPokemonEntity.Animation.Happy02);

            if (kuse.kw32_happyC01)
                CanAnimationList.Add(FieldPokemonEntity.Animation.Happy03);


            if (kuse.kw33_moveA01)
                CanAnimationList.Add(FieldPokemonEntity.Animation.MoveA);

            if (kuse.kw33_moveB01)
                CanAnimationList.Add(FieldPokemonEntity.Animation.MoveB);

            if (kuse.kw33_moveC01)
                CanAnimationList.Add(FieldPokemonEntity.Animation.MoveC);

            if (kuse.kw33_moveD01)
                CanAnimationList.Add(FieldPokemonEntity.Animation.MoveD);
        }

        public PokemonParam GetPokeParam()
        {
            return pokeParam;
        }

        public FieldPokemonEntity GetEntity()
        {
            return entity as FieldPokemonEntity;
        }

        public override void Destroy()
        {
            sanpoModel?.Destroy();
            sanpoModel = null;

            CanAnimationList.Clear();

            dataManager = null;
            GetHirobaPokes = null;
            pokeParam = null;

            base.Destroy();
        }

        public void PokeCollisionUpdate()
        {
            var entities = EntityManager.GetEntities<FieldCharacterEntity>();

            for (int i=0; i<entities.Length; i++)
            {
                var entity = entities[i];

                if (entity.transform != transform && entity.GetComponent<FureaiPokeController>() != null)
                {
                    var model = entity.GetComponent<FureaiPokeController>().model;
                    if (model.walkData.order < walkData.order)
                        collisionModel.CheckCollision(entity, bodySize + model.bodySize, 1.0f, true);
                }
            }
        }

        public void Debug_SetNakayoshi(uint nakayoshi)
        {
            pokeParam.SetFriendship(nakayoshi);
        }

        private void SetNakayoshiRandom()
        {
            var values = new uint[3] { 0, 128, 255 };
            pokeParam.SetFriendship(values[Random.Range(0, 3)]);
        }

        public void SetSanpoModel(PokeSanpoModel sanpoModel)
        {
            this.sanpoModel = sanpoModel;
        }

        public void Log()
        {
            // Result is ignored and not actually logged
            _ = MessageManager.Instance.GetNameMessage(MessageDataConstants.MONSNAME_FILE_NAME, (int)monsNo) +
                "\n立ち止まり確率:" +
                walkData.actionModel.StopThreshold +
                "\nキョロ確率:" +
                (walkData.actionModel.KyoroThreshold - walkData.actionModel.StopThreshold);
        }

        public int GetAnimRandom()
        {
            return CanAnimationList[Random.Range(0, CanAnimationList.Count)];
        }

        public bool LottMonohiroiItemID()
        {
            if (MonohiroiItemNo != -1 || MonohiroiSealNo != -1)
                return true;

            var lott = new MonohiroiLottery(dataManager, (int)monsNo);
            var item = lott.GetItem();
            if (item == -1)
                return false;

            if (lott.itemType == MonohiroiLottery.ItemType.Item)
                MonohiroiItemNo = item;
            else if (lott.itemType == MonohiroiLottery.ItemType.Seal && !lott.isSeal)
                MonohiroiItemNo = item;
            else
                MonohiroiSealNo = item;

            return true;
        }

        public delegate List<FureaiPokeModel> GetFureaiPokes();
    }
}