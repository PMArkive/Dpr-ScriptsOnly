using TMPro;
using UnityEngine;

namespace Dpr.Battle.View.UI
{
	public class BUISafariBall : BattleViewUICanvasBase
	{
		private const string BallCountLabel = "msg_ui_btl_SafariNokoriMsg";

		[SerializeField]
		private TextMeshProUGUI _ballCount;
		
		// TODO
		public override void OnUpdate(float deltaTime) { }
		
		// TODO
		protected override void OnHide() { }
		
		// TODO
		public void SetBallCount(int count) { }
	}
}