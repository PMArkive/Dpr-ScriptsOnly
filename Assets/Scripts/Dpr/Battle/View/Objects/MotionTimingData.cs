using System;
using XLSXContent;

namespace Dpr.Battle.View.Objects
{
	[Serializable]
	public struct MotionTimingData
	{
		public int Buturi01;
		public int Buturi02;
		public int Buturi03;
		public int Tokusyu01;
		public int Tokusyu02;
		public int Tokusyu03;
		public int BodyBlow;
		public int Punch;
		public int Kick;
		public int Tail;
		public int Bite;
		public int Peck;
		public int Radial;
		public int Cry;
		public int Dust;
		public int Shot;
		public int Guard;
		public int LandingFall;
		public int LandingFallEase;
		
		public MotionTimingData(BattleDataTable.SheetMotionTimingData data)
		{
			Buturi01 = data.Buturi01;
			Buturi02 = data.Buturi02;
			Buturi03 = data.Buturi03;
			Tokusyu01 = data.Tokusyu01;
			Tokusyu02 = data.Tokusyu02;
			Tokusyu03 = data.Tokusyu03;
			BodyBlow = data.BodyBlow;
			Punch = data.Punch;
			Kick = data.Kick;
			Tail = data.Tail;
			Bite = data.Bite;
			Peck = data.Peck;
			Radial = data.Radial;
			Cry = data.Cry;
			Dust = data.Dust;
			Shot = data.Shot;
			Guard = data.Guard;
			LandingFall = data.LandingFall;
			LandingFallEase = data.LandingFallEase;
		}
		
		public static MotionTimingData Factory()
		{
			return new MotionTimingData()
			{
				Dust = 0,
				Shot = 0,
				Guard = 0,
				LandingFall = 0,
				Buturi01 = 0,
				Buturi02 = 0,
				LandingFallEase = 1,
				Bite = 0,
				Peck = 0,
				Radial = 0,
				Cry = 0,
				BodyBlow = 0,
				Punch = 0,
				Kick = 0,
				Tail = 0,
				Buturi03 = 0,
				Tokusyu01 = 0,
				Tokusyu02 = 0,
				Tokusyu03 = 0,
			};
		}
		
		public int GetTiming(BattlePokemonEntity.AnimationState state)
		{
			switch (state)
			{
				case BattlePokemonEntity.AnimationState.Buturi01: return Buturi01;
				case BattlePokemonEntity.AnimationState.Buturi02: return Buturi02;
				case BattlePokemonEntity.AnimationState.Buturi03: return Buturi03;
				case BattlePokemonEntity.AnimationState.Tokusyu01: return Tokusyu01;
				case BattlePokemonEntity.AnimationState.Tokusyu02: return Tokusyu02;
				case BattlePokemonEntity.AnimationState.Tokusyu03: return Tokusyu03;
				case BattlePokemonEntity.AnimationState.BodyBlow: return BodyBlow;
				case BattlePokemonEntity.AnimationState.Punch: return Punch;
				case BattlePokemonEntity.AnimationState.Kick: return Kick;
				case BattlePokemonEntity.AnimationState.Tail: return Tail;
				case BattlePokemonEntity.AnimationState.Bite: return Bite;
				case BattlePokemonEntity.AnimationState.Peck: return Peck;
				case BattlePokemonEntity.AnimationState.Radial: return Radial;
				case BattlePokemonEntity.AnimationState.Cry: return Cry;
				case BattlePokemonEntity.AnimationState.Dust: return Dust;
				case BattlePokemonEntity.AnimationState.Shot: return Shot;
				case BattlePokemonEntity.AnimationState.Guard: return Guard;
				default: return 0;
			}
		}
	}
}