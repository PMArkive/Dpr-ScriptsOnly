using System.Diagnostics;

namespace Dpr.Battle.Logic
{
    public sealed class GameTimer
    {
        private Stopwatch[] m_timeCount = Arrays.InitializeWithDefaultInstances<Stopwatch>((int)TimerType.NUM);
        private ushort[] m_limitTime = new ushort[(int)TimerType.NUM];
        private bool[][] m_isPause = RectangularArrays.RectangularDefaultArray<bool>((int)TimerType.NUM, (int)TimerControlLevel.NUM);

        public void Initialize()
        {
            // Empty
        }

        // TODO
        public uint GetTime(TimerType type) { return 0; }

        // TODO
        public void SetTime(TimerType type, uint time) { }

        // TODO
        public void StartCountDown(TimerType type, TimerControlLevel level) { }

        // TODO
        public void Pause(TimerType type, TimerControlLevel level) { }

        public bool IsFinish(TimerType type)
        {
        	if (2 < (int)type) {
        	  return true;
        	}
        	if (type < this.m_timeCount.Length) {
        	  var iVar1 = GetTime();
        	  return iVar1 == 0;
        	}
        }

        private void setPauseFlag(TimerType type, TimerControlLevel level, bool flag)
        {
        	if (type < this[0].Length) {
        	  if ((uint)level < this[0] + (int)type * 8[0].Length) {
        	    this[0] + (int)type * 8[0] + (ulong)level[0] = flag & 1;
        	  }
        	}
        }

        // TODO
        private bool isPause(TimerType type) { return false; }

        private void clearPauseFlag(TimerType type)
        {
        	if (type < this[0].Length) {
        	  var uVar3 = 0;
        	  do {
        	    this[0] = this[0] + (int)type * 8[0];
        	    var uVar1 = this[0].Length;
        	    if ((int)uVar1 <= (long)uVar3) {
        	    }
        	    if (uVar1 <= uVar3) break;
        	    this[0] = this[0] + uVar3;
        	    uVar3 = uVar3 + 1;
        	    this[0][0] = 0;
        	  } while (type < this[0].Length);
        	}
        }

        public enum TimerType : int
        {
            GAME = 0,
            CLIENT = 1,
            COMMAND = 2,
            NUM = 3,
        }
    }
}