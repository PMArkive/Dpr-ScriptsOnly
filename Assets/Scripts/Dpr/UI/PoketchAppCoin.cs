using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class PoketchAppCoin : PoketchAppBase
	{
		[SerializeField]
		private Image _coinImage;
		[SerializeField]
		private Sprite[] _coinSprites;

		private CoinState _state;
		public float CoinAnimationTime = 0.01f;
		private float _coinAnimationTimeCount;
		private int _coinSpriteIndex;

		private const string animationStateNameCointos = "Poketch_CoinMove01";
		private const string animationStateNameIdle = "Poketch_CoinMove02";

		private Animator _coinAnimator;
		
		// TODO
		protected override void OnInitialize() { }
		
		// TODO
		protected override void OnOpen() { }
		
		// TODO
		protected override void OnClose() { }
		
		// TODO
		protected override void OnUpdateDraw() { }
		
		// TODO
		protected override void OnUpdateControl([Optional] [DefaultParameterValue(false)] bool isAppControlEnable, [Optional] PoketchButton targetButton, PoketchWindow.TouchState state = PoketchWindow.TouchState.None) { }
		
		// TODO
		private void StartCointos() { }
		
		// TODO
		private void ItrCoinSprite() { }
		
		// TODO
		private void SetCoinSprite(int index) { }
		
		// TODO
		public void DisplayCoinResult() { }
		
		// TODO
		public void PlayCoinBoundSE() { }

		private enum CoinState : int
		{
			Idle = 0,
			Tos = 1,
			Result = 2,
			End = 3,
		}

		private enum CoinImageState : int
		{
			Heads00 = 0,
			Heads01 = 1,
			Heads02 = 2,
			Tails00 = 3,
			Tails01 = 4,
			End = 5,
		}
	}
}