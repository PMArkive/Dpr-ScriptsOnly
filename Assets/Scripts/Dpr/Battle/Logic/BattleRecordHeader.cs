namespace Dpr.Battle.Logic
{
    public class BattleRecordHeader
    {
        public ushort turnNum;
        public BtlRecordResult1 result1;
        public BtlRecordResult2 result2;

        public void Clear()
        {
            turnNum = 0;
            result1 = BtlRecordResult1.BTL_RECORD_RESULT_1_WIN;
            result2 = BtlRecordResult2.BTL_RECORD_RESULT_2_DEAD;
        }
    }
}