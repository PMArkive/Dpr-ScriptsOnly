using Dpr.Field.Walking;
using Dpr.SubContents;
using Effect;
using System.Collections.Generic;
using UnityEngine;

namespace Dpr.FureaiHiroba
{
    public sealed class FureaiPokeController : WalkingCharacterController
    {
        public FureaiPokeModel model { get => base.model as FureaiPokeModel; }
        public WalkData walkModel { get => model.walkData; }
        public FureaiPokeView view { get => base.view as FureaiPokeView; }

        public event EventHandler<FureaiPokeModel> OnPlayerNear;
        public event EventHandler<FureaiPokeModel> OnWalkingKaizyo;
        public event EventHandler<FureaiPokeModel> OnGotoSanpo;
        public event EventHandler<FureaiPokeModel> OnReturn;

        [SerializeField]
        private PokeWalkerDebug pokeWalkerDebug;
        public List<string> Animations = new List<string>();
        [SerializeField]
        private string _DebugNowState;
        private bool isStep01;
        private bool isStep02;
        private EffectInstance Eff_Step01;
        private EffectInstance Eff_Step02;
        [Button("Tes", "Tes", new object[0])]
        public int Button011;
        [Button("Tes2", "Tes2", new object[0])]
        public int Button012;

        public override void SetModel(WalkingCharacterModel model)
        {
            base.SetModel(model);
            pokeWalkerDebug = new PokeWalkerDebug(model);
            pokeWalkerDebug.CreateTrackPoint();
            isFureai = true;
        }

        public override AIModel CreateAIModel()
        {
            return new AIFureaiModel(this);
        }

        public override void AISetting()
        {
            AI.AddState<WaitState>();
            AI.AddState<SanpoState>();
            AI.AddState<PokeWalkingState>();
            AI.AddState<ReturnState>();
            AI.AddState<GotoSanpoState>();
            AI.AddState<SanpoPairState>();
            AI.AddState<FureaiExitState>();

            OnPlayerNear += model => AI.ChangeState(typeof(PokeWalkingState));
        }

        public void SetDebugDrawActive(bool isActive)
        {
            pokeWalkerDebug.SetActive(isActive);
        }

        protected override void ModelUpdate(float deltaTime)
        {
            walkModel.Update(deltaTime);
        }

        public override void MyUpdate(float deltaTime)
        {
            base.MyUpdate(deltaTime);

            var walkData = walkModel;
            walkData.totalMoveDistance += walkData.moveVec.magnitude;

            if (walkModel.totalMoveDistance >= 400.0f)
                model.LottMonohiroiItemID();
        }

        public void PlayerNear()
        {
            OnPlayerNear.Invoke(model);
        }

        protected override List<FureaiPokeModel> GetWalkingCharacters()
        {
            return FureaiManager.Instance.GetWalkingPokes();
        }

        public void Amity()
        {
            if (!model.CheckState<ReturnState>() && !model.CheckState<SanpoState>())
            {
                if (isStep01)
                {
                    Eff_Step01.Stop();
                    isStep01 = false;
                }

                if (isStep02)
                {
                    Eff_Step02.Stop();
                    isStep02 = false;
                }
            }
            else
            {
                if (walkModel.moveVec.magnitude <= 0.1f)
                {
                    if (!isStep01)
                    {
                        Eff_Step02.Play(null);
                        isStep02 = true;
                    }

                    if (isStep02)
                    {
                        Eff_Step01.Stop();
                        isStep01 = false;
                    }
                }
                else
                {
                    if (isStep02)
                    {
                        Eff_Step02.Stop();
                        isStep02 = false;
                    }

                    if (!isStep01)
                    {
                        Eff_Step01.Play(null);
                        isStep01 = true;
                    }
                }
            }
        }

        private void Tes()
        {
            FieldManager.Instance.CallEffect(EffectFieldID.EF_F_AMITY_STEP_01, transform, null, null);
        }

        private void Tes2()
        {
            FieldManager.Instance.CallEffect(EffectFieldID.EF_F_AMITY_STEP_02, transform, null, null);
        }
    }
}