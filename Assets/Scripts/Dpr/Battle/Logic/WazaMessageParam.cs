using Pml;

namespace Dpr.Battle.Logic
{
    public sealed class WazaMessageParam
    {
        public bool isDone;
        public ushort reservedQueuePos;
        public ushort commandQueuePos;
        public WazaNo wazano;
        public byte attackerID;
        public BtlPokePos targetPos;
        public bool needMsgDisplay;

        public WazaMessageParam()
        {
            Clear();
        }

        public void Clear()
        {
            reservedQueuePos = ushort.MaxValue;
            commandQueuePos = ushort.MaxValue;
            isDone = false;
            wazano = WazaNo.NULL;
            attackerID = PokeID.INVALID;
            targetPos = BtlPokePos.POS_NULL;
            needMsgDisplay = false;
        }

        public bool IsDone()
        {
            return isDone;
        }

        public bool IsReserved()
        {
            return reservedQueuePos != ushort.MaxValue;
        }
    }
}