using Dpr.Battle.Logic;
using Dpr.Battle.View.Objects;
using Dpr.SequenceEditor;
using System.Collections.Generic;
using UnityEngine;
using XLSXContent;

namespace Dpr.Battle.View
{
	public sealed class TaskPokeLandingMotion : Task
	{
		private static readonly Dictionary<PokeEffWeight, string> LANDING_SWITCH_NAME = new Dictionary<PokeEffWeight, string>()
		{
			{ PokeEffWeight.HEAVY,       "LL" },
			{ PokeEffWeight.LIGHT_HEAVY, "L" },
			{ PokeEffWeight.MIDDLE,      "M" },
			{ PokeEffWeight.LIGHT,       "S" },
			{ PokeEffWeight.NONE,        "Flight" },
		};

		private Sequence _seq;
		private ISequenceViewSystem _iPtrBtlvSystem;
		private BtlvPos _vPos;
		private BOPokemon _iPtrPoke;
		private float _introHeight;
		private float _centerOfsY;
		private Vector3 _defualtPokePos;
		private int _rotY;
		private BtlvSound _btlvSound;
		private TaskVectorControl _iPtrTaskTransPos;
		private TaskVectorControl _iPtrTaskTransScl;
		private BattleDataTable _battleDataTable;
		private PokeEffWeight _pokeEffWeight;
		private string _effectFileName;
		private bool _isContest;
		
		// TODO
		public TaskPokeLandingMotion(ISequenceViewSystem pBtlvSystem, BtlvPos vPos, BattleViewCharacter pPoke, float introHeight, SEQ_DEF_DEFAULT_PLACEMENT placement = SEQ_DEF_DEFAULT_PLACEMENT.SEQ_DEF_DEFAULT_PLACEMENT_DEFAULT) { }
		
		protected override void OnDispose()
		{
			Mem.Del(ref _iPtrBtlvSystem);
			Mem.Del(ref _iPtrPoke);
			Mem.DelIDisposable(ref _iPtrTaskTransPos);
			Mem.DelIDisposable(ref _iPtrTaskTransScl);
			Mem.Del(ref _battleDataTable);
			Mem.Del(ref _btlvSound);
		}
		
		// TODO
		public override void Update(float deltaTime, float currentSeqeunceTime, int step) { }

		private enum Sequence : int
		{
			SEQ_SETUP = 0,
			SEQ_LAND_A = 1,
			SEQ_LAND_B = 2,
			SEQ_LAND_C = 3,
			SEQ_LAND = 4,
			SEQ_FINISH = 5,
		}
	}
}