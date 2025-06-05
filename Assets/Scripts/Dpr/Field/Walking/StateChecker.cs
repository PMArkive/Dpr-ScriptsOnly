using System;

namespace Dpr.Field.Walking
{
    public class StateChecker
    {
        private Condition condition;
        private Type NextState;

        public StateChecker(Condition condition, Type type)
        {
            this.condition = condition;
            NextState = type;
        }

        public Type Check(AIModel model)
        {
            return condition.Invoke(model) ? NextState : null;
        }

        public void Destroy()
        {
            condition = null;
            NextState = null;
        }

        public delegate bool Condition(AIModel model);
    }
}