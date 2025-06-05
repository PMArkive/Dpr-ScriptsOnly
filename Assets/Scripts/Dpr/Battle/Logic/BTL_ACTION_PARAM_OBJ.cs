namespace Dpr.Battle.Logic
{
    public class BTL_ACTION_PARAM_OBJ
    {
        public BTL_ACTION_PARAM value;

        public BTL_ACTION_PARAM_OBJ()
        {
            value = new BTL_ACTION_PARAM();
        }

        public BTL_ACTION_PARAM_OBJ(BTL_ACTION_PARAM value)
        {
            this.value = value;
        }
    }
}