using System;
using System.Collections.Generic;

namespace Dpr.Field.Walking
{
    public class AI
    {
        public AIModel aiModel { get; set; }

        private List<AIStateBase> AIStates = new List<AIStateBase>();
        private AIStateBase nowState;
        private List<StateChecker> stateCheckers = new List<StateChecker>();
        public int abs;

        public AI(WalkingCharacterController controller)
        {
            aiModel = controller.CreateAIModel();
        }

        public AI()
        {
            // Empty
        }

        public void Update()
        {
            for (int i=0; i<stateCheckers.Count; i++)
            {
                var check = stateCheckers[i].Check(aiModel);
                if (check != null && check != nowState.GetType())
                    ChangeState(check);
            }

            nowState.CommonUpdate();
        }

        public void Destroy()
        {
            for (int i=0; i<AIStates.Count; i++)
                AIStates[i].Destroy();

            AIStates.Clear();
            AIStates = null;

            for (int i=0; i<stateCheckers.Count; i++)
                stateCheckers[i].Destroy();

            stateCheckers.Clear();
            stateCheckers = null;

            nowState = null;
            aiModel = null;
        }

        public T AddState<T>() where T : AIStateBase
        {
            var state = Activator.CreateInstance(typeof(T), new object[1] { aiModel }) as AIStateBase;
            AIStates.Add(state);

            if (nowState == null)
                nowState = state;

            return state as T;
        }

        public void AddStateChecker<T>(StateChecker.Condition Condition) where T : AIStateBase
        {
            stateCheckers.Add(new StateChecker(Condition, typeof(T)));
        }

        public AIStateBase ChangeState(Type type)
        {
            var foundState = AIStates.Find(x => x.GetType() == type);
            foundState.Cancel();

            nowState?.Exit();
            nowState = foundState;
            nowState.Enter();

            aiModel.walkData.nowSpeed = 0.0f;
            aiModel.view.AnimPlay(0);

            return nowState;
        }

        public Type GetNowStateType()
        {
            return nowState.GetType();
        }

        public AIStateBase GetNowState()
        {
            return nowState;
        }

        public AIStateBase GetState<T>() where T : AIStateBase
        {
            return AIStates.Find(x => x.GetType() == typeof(T));
        }
    }
}