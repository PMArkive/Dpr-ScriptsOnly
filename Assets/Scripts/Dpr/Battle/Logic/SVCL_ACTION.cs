namespace Dpr.Battle.Logic
{
    public sealed class SVCL_ACTION
    {
        public BTL_ACTION_PARAM[][] param = RectangularArrays.RectangularBTL_ACTION_PARAMArray((int)BTL_CLIENT_ID.BTL_CLIENT_NUM, DefineConstants.BTL_PARTY_MEMBER_MAX);
        public byte[] count = new byte[(int)BTL_CLIENT_ID.BTL_CLIENT_NUM];

        public static byte GetNumAction(SVCL_ACTION clientAction, byte clientID)
        {
            return clientAction.count[clientID];
        }

        public static ref BTL_ACTION_PARAM Get(SVCL_ACTION clientAction, byte clientID, byte posIdx)
        {
            return ref clientAction.param[clientID][posIdx];
        }
    }
}