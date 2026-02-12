using Dpr.Battle.Logic;
using Pml.PokePara;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Dpr.UI
{
	public class PokemonBattleWindow : PokemonWindowBase
	{
		[SerializeField]
		private PokemonPanelBattle _battle;
		private SelectType _selectType;
		private Param _param;
		private PokeSelParam _selParam;
		private Dictionary<PositionType, BTL_POKEPARAM> selectedPokemonDict;
		private List<PokemonParam> _pokemonParams = new List<PokemonParam>();
		private BTL_POKEPARAM _currentPokemon;
		public UnityAction<List<BTL_POKEPARAM>, PositionType> onPokemonSwap;
		public UnityAction OnSwapCancel;
		
		// TODO
		public override void OnCreate() { }
		
		// TODO
		public void Open(Param param, PokeSelParam selParam, UIWindowID prevWindowId) { }
		
		// TODO
		public IEnumerator OpOpen(Param param, PokeSelParam selParam, UIWindowID prevWindowId) { return default; }
		
		// TODO
		public void Close(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { }
		
		// TODO
		public IEnumerator OpClose(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { return default; }
		
		// TODO
		private int GetPlateType(int index) { return default; }
		
		private int GetMemberCount()
		{
			return this._pokemonParams.Length;
		}
		
		// TODO
		private void OnUpdate(float deltaTime) { }
		
		// TODO
		private void SetSelectType(SelectType selectType) { }
		
		// TODO
		private void UpdateKeyGuide() { }
		
		// TODO
		private void OnSelectChangedPartyItem(PokemonPartyItem partyItem, int selectIndex) { }
		
		private void OnClickPartyItem(PokemonPartyItem partyItem, int selectIndex)
		{
			this._party.SetActive(0,0);
			OpenContextMenu(partyItem,selectIndex);
		}
		
		// TODO
		private void OpenContextMenu(PokemonPartyItem partyItem, int selectIndex) { }
		
		// TODO
		private void OpenBagWindow(UIBag.ModeType modeType, PokemonParam selectPokemonParam) { }
		
		// TODO
		private void PokemonSwap(BTL_POKEPARAM pokeParam, PositionType posType = PositionType.None) { }
		
		private int GetSwapPokmeonNum()
		{
			if ((this._selParam != null) && (this._param.isPokeList == 0)) {
			  return this._selParam[0];
			}
			return 1;
		}
		
		// TODO
		private int GetSelectedPokemonNum() { return default; }
		
		// TODO
		private BTL_POKEPARAM GetSelectedPokeParam() { return default; }
		
		// TODO
		private void SetSelectPokemonParam(BTL_POKEPARAM pokeParam, PositionType posType) { }
		
		// TODO
		private PositionType GetEmptyPositionType() { return default; }
		
		// TODO
		private void ResetSelectPokemonParam() { }
		
		// TODO
		private List<ContextMenuItem.Param> GetContextMenuItems(BTL_POKEPARAM pokeParam, PokemonPartyItem partyItem) { return default; }
		
		private bool IsRecovery(BTL_POKEPARAM pokeParam)
		{
			if ((((this._param.isBattleTower == 0) && (this._param.isNet == 0)) &&
			    (this._param.isCancel != 0)) && (this._param.isSwapRuleSwap == 0)) {
			  var uVar2 = pokeParam.GetSrcData();
			  var uVar1 = uVar2.IsEgg(2);
			  return (uVar1 ^ 1) & 1;
			}
			return false;
		}
		
		private bool IsSwapWaitPokemon(BTL_POKEPARAM param)
		{
			if (param == null) {
			  return false;
			}
			if (this._param.isPokeList == 0) {
			  if ((this._selParam == null) || (this._selParam[0] != '\x02'))
			  {
			    return false;
			  }
			  var lVar3 = GetSelectedPokeParam();
			  if (lVar3 == null) {
			    return false;
			  }
			}
			else {
			  if (this._param.swapWaitPokemon == 0) {
			    return false;
			  }
			}
			var cVar1 = this._param.swapWaitPokemon.GetID();
			var cVar2 = param.GetID();
			return cVar1 == cVar2;
		}

		private enum SelectType : int
		{
			Party = 0,
			Waza = 1,
		}

		public enum PositionType : int
		{
            None = -1,
            Left = 0,
			Right = 1,
		}

		public enum SwapNumber : int
		{
			one = 1,
			two = 2,
		}

		public class Param : BaseParam
		{
			public BattleType battleType;
			public BTL_POKEPARAM leftPokeParam;
			public BTL_POKEPARAM rightPokeParam;
			public BTL_POKEPARAM swapWaitPokemon;
			public bool isCancel = true;
			public bool isSwap = true;
			public bool isSwapRuleSwap;
			public bool isPokeList;
			public bool isBattleTower;
			public bool isNet;

            public enum BattleType : int
            {
                Normal = 0,
                Double = 1,
                MultiPlayer = 2,
                Safari = 3,
            }
        }
	}
}