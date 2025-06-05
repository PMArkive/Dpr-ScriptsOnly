using Dpr.Battle.Logic;
using Pml;
using Pml.Battle;
using Pml.WazaData;
using System;

namespace Dpr.Battle.View.Systems
{
	public struct BTLV_WAZA_EFF_PARAM
	{
		public BtlPokePos m_atkPos;
		public BtlPokePos m_defPos;
		public WazaNo m_id;
		public WazaTarget m_range;
		public BtlvWazaEffect_TurnType m_turnType;
		public int m_continueCount;
		public bool m_syncDamageEffect;
		public TypeAffinity.AboutAffinityID m_damageAbout;
        [Obsolete]
        public bool m_isGShockOccur;
        [Obsolete]
        public bool m_isGShortWaza;
		[Obsolete]
		public bool m_isDefGPoke;
		public bool m_setData;
		public int m_frame;
		public float m_elaspedTime;
		public bool m_enableKeyAdjust;
		public bool m_isPlayMotion;
		public int m_keyDiffFrame;
		public BattlePokemonEntity.AnimationState m_attackMotion;
		public int m_startFrame;
		
		// TODO
		public static BTLV_WAZA_EFF_PARAM Factory() { return default; }
	}
}