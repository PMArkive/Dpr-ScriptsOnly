namespace Dpr.Battle.Logic
{
    public class BTL_SICKCONTOBJ
    {
        public BTL_SICKCONT value;

        public BTL_SICKCONTOBJ()
        {
            value = SICKCONT.MakeNull();
        }

        public BTL_SICKCONTOBJ(BTL_SICKCONT value)
        {
            this.value = value;
        }
    }
}