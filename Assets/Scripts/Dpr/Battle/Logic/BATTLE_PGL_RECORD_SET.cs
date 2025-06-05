namespace Dpr.Battle.Logic
{
    public class BATTLE_PGL_RECORD_SET
    {
        public BATTLE_PGL_RECORD[] myParty = Arrays.InitializeWithDefaultInstances<BATTLE_PGL_RECORD>(DefineConstants.BTL_PARTY_MEMBER_MAX);
        public BATTLE_PGL_RECORD[] enemysParty = Arrays.InitializeWithDefaultInstances<BATTLE_PGL_RECORD>(DefineConstants.BTL_PARTY_MEMBER_MAX);

        public void Clear()
        {
            for (int i=0; i<myParty.Length; i++)
                myParty[i].Clear();

            for (int i=0; i<enemysParty.Length; i++)
                enemysParty[i].Clear();
        }
    }
}