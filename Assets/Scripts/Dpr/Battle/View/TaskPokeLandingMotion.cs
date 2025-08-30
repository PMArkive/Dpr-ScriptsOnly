using DG.Tweening;
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
		
		public TaskPokeLandingMotion(ISequenceViewSystem pBtlvSystem, BtlvPos vPos, BattleViewCharacter pPoke, float introHeight, SEQ_DEF_DEFAULT_PLACEMENT placement = SEQ_DEF_DEFAULT_PLACEMENT.SEQ_DEF_DEFAULT_PLACEMENT_DEFAULT) :
			base()
		{
			_vPos = vPos;
			_iPtrPoke = pPoke as BOPokemon;
			_introHeight = introHeight;
			_effectFileName = string.Empty;
			_isContest = PlayerWork.isContest;
			_iPtrBtlvSystem.GetDefaultPokePos(vPos, ref _defualtPokePos, ref _rotY, placement);
			_battleDataTable = BattleDataTableManager.Instance.BattleDataTable;

			if (!_isContest)
			{
				_btlvSound = new BtlvSound(_battleDataTable.GetBattleConstantString(BattleConstantKey.LANDING_SOUND_REGISTER));
				_btlvSound.CreateSound(_battleDataTable.GetBattleConstantString(BattleConstantKey.LANDING_SOUND_REGISTER));
                _pokeEffWeight = _iPtrPoke.CheckPokemonEffectWeight();
			}

			var lifeTime = _battleDataTable.GetBattleConstantInt(BattleConstantKey.POKE_LANDING_POLE_SCALE_FRAME);
			var basePos = Vector3.zero;
			_iPtrPoke.GetNodeBasePositionSequence(SEQ_DEF_NODE.SEQ_DEF_NODE_CENTER, ref basePos);
			basePos.x = 0.0f;
			basePos.z = 0.0f;
			basePos.y *= _iPtrPoke.GetScaleOffset().y;
			_centerOfsY = basePos.y;

			_iPtrPoke.SetScaleVec(Vector4.one * 0.01f);

			pBtlvSystem.GetTaskManagerLate().RegisterTask(new TaskVector4Control(basePos, Vector4.zero, Ease.Linear, lifeTime, x => _iPtrPoke.SetTranslationOffset(x)));
			pBtlvSystem.GetTaskManagerLate().RegisterTask(new TaskVector4Control(Vector4.one * 0.01f, Vector4.one, Ease.Linear, lifeTime, x => _iPtrPoke.SetScaleVec(x)));
        }
		
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