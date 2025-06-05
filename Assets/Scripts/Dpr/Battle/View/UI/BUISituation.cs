using Dpr.Battle.Logic;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.Battle.View.UI
{
	public class BUISituation : BattleViewUICanvasBase
	{
		[SerializeField]
		private BUISituationButton[] _situationButtons;
		private Dictionary<int, BTL_POKEPARAM> _monsParams = new Dictionary<int, BTL_POKEPARAM>();
		private Dictionary<int, string> _trainerNames = new Dictionary<int, string>();
		private Dictionary<int, Image> _icons = new Dictionary<int, Image>();
		
		// TODO
		public void Initialize() { }
		
		// TODO
		public override void OnUpdate(float deltaTime) { }
		
		// TODO
		protected override void OnShow() { }
		
		// TODO
		public void SetFocus(int index) { }
		
		// TODO
		private void PreparaNextH(bool isForward) { }
		
		// TODO
		private void PreparaNextV(bool isForward) { }
		
		// TODO
		private void OnSubmit() { }
		
		// TODO
		private void OnCancel() { }
	}
}