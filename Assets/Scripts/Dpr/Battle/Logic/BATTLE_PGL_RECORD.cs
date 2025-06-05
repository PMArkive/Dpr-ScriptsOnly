namespace Dpr.Battle.Logic
{
    public class BATTLE_PGL_RECORD
    {
        public ushort deadPokeNumber;
        public ushort deadPokeForm;
        public ushort finishWazaNumber;
        public ushort attackPokeNumber;
        public ushort attackPokeForm;
        public ushort[] wazaUseCount = new ushort[BattleDefConst.PTL_WAZA_MAX];
        public ushort[] wazaKillCount = new ushort[BattleDefConst.PTL_WAZA_MAX];

        public void Clear()
        {
            deadPokeNumber = 0;
            deadPokeForm = 0;
            finishWazaNumber = 0;
            attackPokeNumber = 0;
            attackPokeForm = 0;

            for (int i=0; i<wazaUseCount.Length; i++)
                wazaUseCount[i] = 0;
            
            for (int i=0; i<wazaKillCount.Length; i++)
                wazaKillCount[i] = 0;
        }
    }
}