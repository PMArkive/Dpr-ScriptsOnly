using Dpr.Battle.View.Objects;
using UnityEngine;

namespace Dpr.Battle.View
{
	public sealed class TaskPokemonLookAt : Task
	{
		private BattleViewCharacter _iPtrPoke;
		private bool _isWaitFinish;
		
		protected override bool IsFinishCondition { get => _lifeTime <= _frame; }
		
		public TaskPokemonLookAt(BattleViewCharacter pPoke, Vector3 pos, int lifeTime)
		{
			_iPtrPoke = pPoke;
			_frame = 0;
			_lifeTime = lifeTime;
			_isWaitFinish = false;

			_iPtrPoke.StartLookAt(pos);
		}
		
		protected override void OnDispose()
		{
			Mem.Del(ref _iPtrPoke);
		}
		
		// TODO
		public override void Update(float deltaTime, float currentSeqeunceTime, int step) { }
	}
}