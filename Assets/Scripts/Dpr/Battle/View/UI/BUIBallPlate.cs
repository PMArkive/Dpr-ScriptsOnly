using Dpr.Battle.Logic;
using Dpr.Battle.View.Systems;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.Battle.View.UI
{
	public class BUIBallPlate : BattleViewUICanvasBase
	{
		[SerializeField]
		private Image[] _pokeBallList;
		private float[] _baseXPositions;
		private bool _isPlayerside;
		private bool[] _isEnableSE;

        public bool IsInitialized { get; set; }

        private const float BALL_PLATE_WAIT = 2.2f;
		private const float BALL_DELAY = 0.1f;
		private const float BALL_OFFSET = 720.0f;
		
		// TODO
		public override void Startup() { }
		
		// TODO
		public void Initialize(BattleViewSystem.BattleViewSide side, Sprite[] ballTypeSprites) { }
		
		// TODO
		private int GetBallType(BTL_PARTY party, int num) { return default; }
		
		// TODO
		public void Play() { }
		
		// TODO
		protected override void OnShow() { }
		
		// TODO
		protected override void OnHide() { }
		
		// TODO
		public override void OnUpdate(float deltaTime) { }
	}
}