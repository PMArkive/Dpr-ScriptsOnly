using Dpr.FureaiHiroba;
using System;

namespace Dpr.Field.Walking
{
    public class AIFureaiModel : AIModel
    {
        public PokeSanpoModel sanpoModel;
        public Action OnPlayerNear;
        public Emoticon emoticon;

        public FureaiPokeModel fureaiModel { get => charaModel as FureaiPokeModel; }

        public AIFureaiModel(FureaiPokeController controller) : base(controller)
        {
            sanpoModel = controller.model.sanpoModel;
            emoticon = controller.emoticon;
            OnPlayerNear = controller.PlayerNear;
        }

        public override void Destroy()
        {
            base.Destroy();
            OnPlayerNear = null;
            emoticon = null;
        }
    }
}