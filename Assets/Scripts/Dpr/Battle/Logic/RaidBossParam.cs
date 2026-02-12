using Pml;
using Pml.Personal;

namespace Dpr.Battle.Logic
{
    public class RaidBossParam
    {
        private GWall m_gWall;
        private RaidBossDesc m_desc = new RaidBossDesc();
        private byte m_grade;
        private byte m_reinforceTurn;
        private byte m_angryLevel;
        private byte m_gWazaUseTurn;
        private bool m_gWazaUsed;

        public RaidBossParam()
        {
            m_gWall = null;

            m_gWazaUsed = false;
            m_grade = 0;
            m_reinforceTurn = 0;
            m_angryLevel = 0;
            m_gWazaUseTurn = 0;

            m_gWall = new GWall();
        }

        // TODO
        public void CopyFrom(in RaidBossParam src) { }

        // TODO
        public void Setup(in SetupParam param) { }

        // TODO
        public float GetHPCoef() { return 0f; }

        public GWall GetGWallConst()
        {
        	return this.m_gWall;
        }

        public GWall GetGWall()
        {
        	return this.m_gWall;
        }

        // TODO
        public byte GetGrade() { return 0; }

        public byte GetReinforceTurn()
        {
        	return this.m_reinforceTurn;
        }

        public void SetReinforceTurn(byte turn)
        {
        	this.m_reinforceTurn = turn;
        }

        public void DecReinforceTurn()
        {
        	if (this.m_reinforceTurn != 0) {
        	  this.m_reinforceTurn = this.m_reinforceTurn + -1;
        	}
        }

        // TODO
        public byte GetActionNum() { return 0; }

        // TODO
        public byte GetGWazaUseFrequency() { return 0; }

        // TODO
        public bool IsOnGWazaUseTurn() { return false; }

        public void DecGWazaUseTurn()
        {
        	if (this.m_gWazaUseTurn != 0) {
        	  this.m_gWazaUseTurn = this.m_gWazaUseTurn + -1;
        	}
        }

        public void SetGWazaUsed()
        {
        	this.m_gWazaUsed = true;
        }

        public void ResetGWazaUseSchedule(byte reUseTurn)
        {
        	this.m_gWazaUsed = false;
        	this.m_gWazaUseTurn = reUseTurn;
        }

        public byte GetAngryHPThreshold()
        {
        	if ((uint)this.m_angryLevel < this.Length[0].Length) {
        	  return this.Length[0] + (ulong)this.m_angryLevel[0];
        	}
        }

        public void IncAngryLevel()
        {
        	if (this.m_angryLevel < 2) {
        	  if (this.Length[0].Length <= (uint)this.m_angryLevel) {
        	  }
        	  if (this.Length[0] + (ulong)this.m_angryLevel[0] != 0) {
        	    this.m_angryLevel = this.m_angryLevel + 1;
        	    this.m_gWall.DecrementRepairTurnCountMax();
        	  }
        	}
        }

        public bool IsAngryLevelMax()
        {
        	if (1 < this.m_angryLevel) {
        	  return true;
        	}
        	if ((uint)this.m_angryLevel < this.Length[0].Length) {
        	  return this.Length[0] + (ulong)this.m_angryLevel[0] == 0;
        	}
        }

        public bool IsAngry()
        {
        	return this.m_angryLevel != 0;
        }

        // TODO
        public WazaNo GetAngryWaza() { return WazaNo.NULL; }

        // TODO
        public RaidBossAngryWazaTiming GetAngryWazaTiming() { return RaidBossAngryWazaTiming.NONE; }

        public class SetupParam
        {
            public byte grade;
            public RaidBossDesc pDesc;
        }
    }
}