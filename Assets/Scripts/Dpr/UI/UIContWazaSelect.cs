using Dpr.Contest;
using Dpr.EvScript;
using Pml.PokePara;
using System.Collections;
using UnityEngine;

namespace Dpr.UI
{
	public class UIContWazaSelect : UIWindow, IContestUIWindow
	{
		[SerializeField]
		private MenuHeader _header;
		[SerializeField]
		private PokemonModelView _modelView;
		[SerializeField]
		private WazaManageWazaStatusPanel _wazaPanel;
		[SerializeField]
		private UIPokeStatusSelectPanel _uiPokeStatus;

		private KeyGuideCreater _keyGuide = new KeyGuideCreater();
		private EvWork.WORK_INDEX _resultWorkIndex;
		private ContestMenuEventID _resultEventID = ContestMenuEventID.None;
		private PokemonParam selectPokeParam;
		private byte _startSelectIndex;
		private bool _bInputed;
		private bool _bIsOpen;
		private bool _bIsOpening;
		private bool _bIsMultiMode;
		
		// TODO
		public override void OnCreate() { }
		
		// TODO
		public void Open(EvWork.WORK_INDEX resultWorkIndex, UIWindowID prevWindowID) { }
		
		// TODO
		public void OpenMultiMode(UIWindowID prevWindowID, string minutStr, string secondStr) { }
		
		// TODO
		private IEnumerator OpOpen(UIWindowID prevWindowID) { return default; }
		
		public bool IsOpen { get => _bIsOpen; }
		public ContestMenuEventID ResultEventID { get => _resultEventID; }
		
		// TODO
		private void OnUpdate(float deltaTime) { }
		
		// TODO
		private void UpdateInput() { }
		
		// TODO
		private bool CheckValidContestWaza() { return default; }
		
		// TODO
		public void CloseWindow() { }
		
		// TODO
		private IEnumerator OpClose() { return default; }
		
		// TODO
		public void SetTimeCount(string minutStr, string secondStr) { }
		
		// TODO
		private void ResetContestParam() { }
	}
}