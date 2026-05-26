using Dpr.FureaiHiroba;
using Dpr.SubContents;

namespace Dpr.Field.Walking
{
    public abstract class SanpoStateBase : AIStateBase
    {
        private static readonly int[] RankToEmoticonNo = new int[6] { 0, 0, 0, 3, 3, 2 };

        protected AIFureaiModel model { get => base.model as AIFureaiModel; }
        protected PokeSanpoModel sanpoModel { get => model.sanpoModel; }
        protected WalkData walkModel { get => model.walkData; }

        public SanpoStateBase(AIFureaiModel model) : base(model)
        {
            // Empty
        }

        protected bool CheckAddWalking()
        {
            if (!sanpoModel.isAddWalking)
                return false;

            model.emoticon.Enter(RankToEmoticonNo[Utils.GetNakayoshiRank(model.fureaiModel.nakayoshi)]);

            var pokeParam = model.fureaiModel.GetPokeParam();
            var monsno = pokeParam.GetMonsNo();

            if (Utils.IsPikaV(monsno))
                Utils.PlayVoicePikaBui_Notice(monsno, Utils.GetNakayoshiRank(pokeParam.GetFriendship()), model.charaModel.controller.voicePlayer);
            else
                Utils.PlayVoice(pokeParam.GetMonsNo(), pokeParam.GetFormNo(), 0, model.charaModel.controller.voicePlayer);

            corSys.Cancel();
            model.AI.ChangeState(typeof(ReturnState));

            return true;
        }

        protected bool LookPlayer()
        {
            var playerTf = EntityManager.activeFieldPlayer.transform;

            if (!sanpoModel.isLookPlayer)
                return false;

            if (model.charaModel.isForceAnimation)
                return true;

            corSys.Cancel();

            model.walkData.nowSpeed = 0.0f;
            model.walkData.LookAtTarget(playerTf.position, deltaTime, 3.0f);

            return true;
        }

        protected override void StateUpdate()
        {
            // Empty
        }
    }
}