using Dpr.Battle.View.Objects;
using UnityEngine;

namespace Dpr.Battle.View
{
	public sealed class TaskPokeHitBack : Task
	{
		private BattleViewCharacter _iPtrPoke;
		private Sequence _current;
		private Vector3 _startPos;
		private Vector3 _hitbackPos;
		private float _elapsedTime;
		
		public TaskPokeHitBack(BattleViewCharacter target, int cnt = 0, int maxCnt = 3)
		{
			_iPtrPoke = target;
			_frame = cnt;
			_lifeTime = maxCnt;
			_current = 0;
			_startPos = target.GetTranslationVec();
			_hitbackPos = target.GetTranslationVec() + (-target.transform.forward * 0.6f);
		}
		
		protected override void OnDispose()
		{
			Mem.Del(ref _iPtrPoke);
		}
		
		// TODO
		public override void Update(float deltaTime, float currentSeqeunceTime, int step) { }

		private enum Sequence : int
		{
			BACK = 0,
			RETURN = 1,
			FINISH = 2,
		}

		public enum Mode : int
		{
			All = 0,
			BackOnly = 1,
		}
	}
}