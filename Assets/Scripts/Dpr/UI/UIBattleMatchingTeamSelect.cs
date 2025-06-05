using Dpr.SubContents;
using Pml;
using Pml.PokePara;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Dpr.UI
{
	public class UIBattleMatchingTeamSelect : UIWindow
	{
		[SerializeField]
		private UIBattleMatchingTimer _timer;
		[SerializeField]
		private UIBattleMatchingTeamPlate[] _teamPlates;
		[SerializeField]
		private GameObject[] _objArrows;

		private const float CLOSING_INTERVAL = 0.5f;

		private BoxWindow _boxWindow;
		private Action _onDecide;
		private Action _onCancel;
		private UIState _currentState;
		private bool _cancelFade = true;
		private bool _closed;
		private bool _isServerError;
		private Dictionary<int, bool[]> _illegalList;
		private int _currentIndex = -1;
		private ShowMessageWindow _msgWindow = new ShowMessageWindow();
		private float _closingProgressTime;

		private readonly string[] YESNO_CONTEXTMENU_LABELS = new string[]
		{
            "SS_net_net_btl_036", "SS_net_net_btl_037",
        };
		private readonly Vector2 MSG_WINDOW_ANCHOR_POS = new Vector2(15.0f, 110.0f);
		
		public bool isActiveKeyGuide { get; set; }
		public bool IsServerError { get => _isServerError; }
		
		// TODO
		public override void OnCreate() { }
		
		// TODO
		public void Open(Action onDecide, Action onCancel, bool firstOpen = false, bool fadeIn = false, bool cancelFade = false, UIWindowID prevWindowId = WINDOWID_FIELD) { }
		
		// TODO
		public IEnumerator OpOpen(UIWindowID prevWindowId, bool firstOpen = false, bool fadeIn = false) { return default; }
		
		// TODO
		public void OpenTeam(Action onCancel, UIWindowID prevWindowId = WINDOWID_FIELD) { }
		
		// TODO
		public IEnumerator OpOpenTeam(UIWindowID prevWindowId) { return default; }
		
		// TODO
		public bool CanClose() { return default; }
		
		// TODO
		public void PreClose() { }
		
		// TODO
		public void Close(bool isCloseCB = false) { }
		
		// TODO
		public IEnumerator OpClose(bool isCloseCB = false) { return default; }
		
		// TODO
		private void OnUpdate(float deltaTime) { }
		
		// TODO
		private void OnUpdateMatchingMenu() { }
		
		// TODO
		private void OnUpdateClosingUIMenu(float deltaTime) { }
		
		// TODO
		private void SetKeyguide(bool backOnly = false) { }
		
		// TODO
		private void CloseKeyGuide() { }
		
		// TODO
		private void SetActiveArrow(bool active) { }
		
		// TODO
		public void RemainingWarningText(bool warning = true) { }
		
		// TODO
		public void UpdateUITimeText(string minutes, string seconds) { }
		
		// TODO
		private void OpenBox() { }
		
		// TODO
		private IEnumerator CloseBox() { return default; }
		
		// TODO
		private void MoveTeam(bool right) { }
		
		// TODO
		private void SelectTeam(int index) { }
		
		// TODO
		private int GetPrevIndex() { return default; }
		
		// TODO
		private int GetNextIndex() { return default; }
		
		// TODO
		private void SetTeam() { }
		
		// TODO
		private PokemonParam[] GetPokemonParams(int index) { return default; }
		
		// TODO
		private bool[] GetRegulations(int teamIndex, PokemonParam[] pokemonParams) { return default; }
		
		// TODO
		private RegulationType GetRegulation(int teamIndex, PokemonParam[] pokemonParams) { return default; }
		
		// TODO
		private void GetRegulation(PokemonParam[] pokemonParams, ref List<MonsNo> monsNoList, ref List<ItemNo> itemNoList) { }
		
		// TODO
		private bool IsRegulationEmpty(PokemonParam[] pokemonParams) { return default; }
		
		// TODO
		private bool IsRegulationNotEnoughNum(PokemonParam[] pokemonParams) { return default; }
		
		// TODO
		private bool IsRegulationLegend(MonsNo monsNo) { return default; }
		
		// TODO
		private bool IsRegulationSamePokemon(List<MonsNo> monsNoList, MonsNo monsNo) { return default; }
		
		// TODO
		private bool IsRegulationSameItem(List<ItemNo> itemNoList, ItemNo itemNo) { return default; }
		
		// TODO
		private bool IsRegulationIllegal(int teamIndex, int index) { return default; }
		
		// TODO
		private IEnumerator CheckIllegal(Action onFinish) { return default; }
		
		// TODO
		private void DecideTeam() { }
		
		// TODO
		private PokemonParam[] CreateModifyLevelParty(in PokemonParam[] pokemonParams) { return default; }
		
		// TODO
		private void Decide() { }
		
		// TODO
		private void Back() { }
		
		// TODO
		private void ShowDefaultMessageWindow(bool firstOpen = false) { }
		
		// TODO
		private void ShowInputCloseMessageWindow(string msbt, string label, [Optional] Action onCloseed) { }
		
		// TODO
		private void ShowConfirmYesNoMsg(string message, [Optional] Action onSelectYes, [Optional] Action onSelectNo) { }
		
		// TODO
		private void CloseMessageWindow() { }
		
		// TODO
		private void OpenContextMenu(string[] contextLabels, Action<int> onSelect) { }
		
		// TODO
		private void CloseContextMenu() { }

		private enum UIState : int
		{
			MatchingMenu = 0,
			OpenUIMenu = 1,
			ClosingUIMenu = 2,
			Closed = 3,
		}

		private enum RegulationType : int
		{
			None = 0,
			Empty = 1,
			NotEnoughNum = 2,
			Legend = 3,
			SamePokemon = 4,
			SameItem = 5,
			Illegal = 6,
		}
	}
}