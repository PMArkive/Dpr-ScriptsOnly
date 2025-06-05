using Dpr.Battle.Logic;
using Dpr.UI;
using Pml.WazaData;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.Battle.View.UI
{
	public class BUITargetSelect : BattleViewUICanvasBase
	{
		private static BtlvPos[] _searchOrder = new BtlvPos[]
		{
			BtlvPos.BTL_VPOS_FAR_2, BtlvPos.BTL_VPOS_FAR_1, BtlvPos.BTL_VPOS_NEAR_1, BtlvPos.BTL_VPOS_NEAR_2,
		};

		[SerializeField]
		[Header("IndexをPml.Btlvposに合わせる")]
		private BUITargetButton[] _targetButtons;
		[SerializeField]
		private TargetSelectCursor _targetCursor;
		[SerializeField]
		private Image[] _boardImage;

        public BtlPokePos Result { get; set; }

        private BTL_ACTION_PARAM_OBJ _destActionParam;
		private BtlvPos _actionVPos = BtlvPos.BTL_VPOS_NUM;
		private WazaTarget _targetType = WazaTarget.TARGET_MAX;
		[SerializeField]
		private WazaTarget _overrideTargetType = WazaTarget.TARGET_MAX;
        private Dictionary<int, BtlvPos> _prevTargetPos;
		private int _pokeIndex;
		private bool _isSingleTarget = true;
		private Dictionary<BtlvPos, BTL_POKEPARAM> currentFieldPokeParams = new Dictionary<BtlvPos, BTL_POKEPARAM>();
		
		// TODO
		public override void Startup() { }
		
		// TODO
		public void Initialize(byte pokeIndex, BTL_POKEPARAM bpp, BTL_ACTION_PARAM_OBJ dest) { }
		
		// TODO
		public override void OnUpdate(float deltaTime) { }
		
		// TODO
		protected override void OnShow() { }
		
		// TODO
		public void SetFocus(int index) { }
		
		// TODO
		private int GetTargetIndex() { return default; }
		
		// TODO
		private void SetBoardImageState(bool isEnable, int altIndex = -1) { }
		
		// TODO
		private void PreparaNextH(bool isForward) { }
		
		// TODO
		private void PreparaNextV(bool isForward) { }

		// TODO
		private void SetTargetButton(WazaTarget tagetType, BtlvPos actionVPos, BUITargetButton button, BtlvPos buttonVPos, [Optional] BTL_POKEPARAM btlParam, [Optional] Sprite effectiveSprite, string effectiveStr = "") { }
		
		// TODO
		private void OnSubmit() { }
		
		// TODO
		private void OnCancel() { }

		private enum BoardIndex : int
		{
			Up = 0,
			Down = 1,
			Left = 2,
			Right = 3,
		}
	}
}