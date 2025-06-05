using Dpr.Battle.Logic;
using Pml;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Dpr.Battle.View.UI
{
	public class BUITokuseiPlate : BattleViewUICanvasBase
	{
		private const string TokuseiNameMessageLabel = "msg_ui_btl_wazainfo_tokuseiname";
		private const float TOKUSEI_PLATE_WAIT = 0.1f;

		[SerializeField]
		private TextMeshProUGUI _tokuseiText;
		[SerializeField]
		private TextMeshProUGUI _nameText;

        public TokuseiNo _currentNo { get; set; }

        private TokuseiNo _changeNo;

        public bool IsDisplay { get; set; }

        public bool isSkillSwapOpenAnimation;
		
		public bool IsStable { get => IsDisplay && IsShow; }
		
		// TODO
		public void Initialize(BTL_POKEPARAM btlParam, bool isEnablePokeName = true) { }
		
		// TODO
		public override void OnUpdate(float deltaTime) { }
		
		// TODO
		protected override void OnShow() { }
		
		// TODO
		protected override void OnHide() { }
		
		// TODO
		public void PlayShow() { }
		
		// TODO
		public void PlayHide() { }
		
		// TODO
		protected override void OnPlayAnimation() { }
		
		// TODO
		public void SetChange(TokuseiNo no) { }
		
		// TODO
		public void SetTokuseiName(TokuseiNo no) { }
		
		// TODO
		public void SetName(uint pokeID) { }
		
		// TODO
		private IEnumerator OutCoroutine() { return default; }
	}
}