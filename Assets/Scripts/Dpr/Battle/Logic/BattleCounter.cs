using System.Runtime.InteropServices;

namespace Dpr.Battle.Logic
{
    public sealed class BattleCounter
    {
        // BUG: The Client and Side counter arrays are initialized with a size of 5 instead of 1, it's likely they used UniqueCounter.NUM instead of their respective maximums
        private ulong[] m_uniqueCount = Arrays.InitializeWithDefaultInstances<ulong>((int)UniqueCounter.NUM);
        private ulong[][] m_clientCount = RectangularArrays.RectangularDefaultArray<ulong>((int)UniqueCounter.NUM, (int)BTL_CLIENT_ID.BTL_CLIENT_NUM);
        private ulong[][] m_sideCount = RectangularArrays.RectangularDefaultArray<ulong>((int)UniqueCounter.NUM, (int)BtlSide.BTL_SIDE_NUM);

        // TODO: Find good constants to replace the numbers with
        private static readonly CounterDesc[] COUNTER_DESC_UNIQUE = new CounterDesc[(int)UniqueCounter.NUM]
        {
            new CounterDesc(DefineConstants.BTL_TURNCOUNT_MAX),
            new CounterDesc(30),
            new CounterDesc(Safari.SAFARI_COUNT_MAX),
            new CounterDesc(12),
            new CounterDesc(Safari.SAFARI_BALL_MAX),
        };
        private static readonly CounterDesc[] COUNTER_DESC_CLIENT = new CounterDesc[(int)ClientCounter.NUM] { new CounterDesc(0xFF) };
        private static readonly CounterDesc[] COUNTER_DESC_SIDE = new CounterDesc[(int)SideCounter.NUM] { new CounterDesc(0xFF) };

        private static ref CounterDesc GetCounterDesc(UniqueCounter counterID)
        {
            return ref COUNTER_DESC_UNIQUE[(int)counterID];
        }

        private static ref CounterDesc GetCounterDesc(ClientCounter counterID)
        {
            return ref COUNTER_DESC_CLIENT[(int)counterID];
        }

        private static ref CounterDesc GetCounterDesc(SideCounter counterID)
        {
            return ref COUNTER_DESC_SIDE[(int)counterID];
        }

        public BattleCounter()
        {
            Initialize(null);
        }

        // TODO
        public void Initialize([Optional] MainModule mainModule) { }

        // TODO
        public void CopyFrom(BattleCounter src) { }

        // TODO
        public ulong Get(UniqueCounter counterID) { return 0; }

        // TODO
        public void Inc(UniqueCounter counterID) { }

        // TODO
        public void Dec(UniqueCounter counterID) { }

        // TODO
        public ulong Get(ClientCounter counterID, BTL_CLIENT_ID clientID) { return 0; }

        // TODO
        public void Inc(ClientCounter counterID, BTL_CLIENT_ID clientID) { }

        // TODO
        public ulong Get(SideCounter counterID, BtlSide side) { return 0; }

        // TODO
        public void Inc(SideCounter counterID, BtlSide side) { }

        // TODO
        private bool isValidCounter(UniqueCounter counterID) { return false; }

        // TODO
        private bool isValidCounter(ClientCounter counterID, BTL_CLIENT_ID clientID) { return false; }

        // TODO
        private bool isValidCounter(SideCounter counterID, BtlSide side) { return false; }

        public enum UniqueCounter : byte
        {
            BATTLE_TURN_COUNT = 0,
            ESCAPE_TRIED_COUNT = 1,
            SAFARI_GET_COUNT = 2,
            SAFARI_ESCAPE_COUNT = 3,
            SAFARI_BALL_COUNT = 4,
            NUM = 5,
        }

        public enum ClientCounter : byte
        {
            MEMBER_CHANGE_COUNT = 0,
            NUM = 1,
        }

        public enum SideCounter : byte
        {
            G_USE_COUNT = 0,
            NUM = 1,
        }

        private struct CounterDesc
        {
            public ulong max;

            public CounterDesc(ulong max)
            {
                this.max = max;
            }
        }
    }
}