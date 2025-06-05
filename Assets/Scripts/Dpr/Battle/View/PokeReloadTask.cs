using Dpr.Battle.Logic;
using Dpr.SequenceEditor;
using System;

namespace Dpr.Battle.View
{
	public sealed class PokeReloadTask : Task
	{
		private ISequenceViewSystem _iPtrBtlvSystem;
		private Sequence _seq;
		private BtlvPos _vPos;
		private BtlvPos _vPosTarget;
		private bool _isMetamorphosus;
		private bool _isSimpleParam;
		private SimpleParam _simpleParam;
		private bool _isPlayPinchSound;
		private Action _onComplete;
		private bool _isFinishLoad;
		
		public PokeReloadTask(ISequenceViewSystem pBtlvSystem, BtlvPos vPos, Action onComplete)
		{
			_iPtrBtlvSystem = pBtlvSystem;
			_seq = Sequence.START_DELETE;
			_vPos = vPos;
			_vPosTarget = vPos;
			_isMetamorphosus = false;
			_isSimpleParam = false;
			_simpleParam = default;

			var boPokemon = _iPtrBtlvSystem.GetPokeModel(vPos);
			_onComplete = onComplete;
			_isPlayPinchSound = boPokemon.GetIsPlayPinchSound();
			_isFinishLoad = false;
        }
		
		public PokeReloadTask(ISequenceViewSystem pBtlvSystem, BtlvPos vPos, BtlvPos vPosTarget, Action onComplete)
		{
            _iPtrBtlvSystem = pBtlvSystem;
            _seq = Sequence.START_DELETE;
            _vPos = vPos;
            _vPosTarget = vPosTarget;
            _isMetamorphosus = true;
            _isSimpleParam = false;
            _simpleParam = default;

            var boPokemon = _iPtrBtlvSystem.GetPokeModel(vPos);
            _onComplete = onComplete;
            _isPlayPinchSound = boPokemon.GetIsPlayPinchSound();
            _isFinishLoad = false;
        }
		
		// TODO
		public override void Update(float deltaTime, float currentSeqeunceTime, int step) { }

		private enum Sequence : int
		{
			START_DELETE = 0,
			WAIT_DELETE = 1,
			START_LOAD = 2,
			WAIT_LOAD = 3,
			FINISH = 4,
		}
	}
}