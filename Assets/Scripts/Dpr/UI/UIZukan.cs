using DPData;
using Pml;
using Pml.PokePara;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class UIZukan : UIWindow
	{
		private const string ZukanMessageFileName = "ss_pokedex";
		private const string ShinouZukanNameMessageLabel = "SS_pokedex_183";
		private const string NationalZukanNameMessageLabel = "SS_pokedex_184";
		private const string NumberSortMessageLabel = "SS_pokedex_092";
		private const string NameSortMessageLabel = "SS_pokedex_093";
		private const string HeavierSortMessageLabel = "SS_pokedex_094";
		private const string LighterSortMessageLabel = "SS_pokedex_095";
		private const string HigherSortMessageLabel = "SS_pokedex_096";
		private const string LowerSortMessageLabel = "SS_pokedex_097";
		private const string CancelSortMessageLabel = "SS_pokedex_098";
		private const string NumberSortNameMessageLabel = "SS_pokedex_086";
		private const string NameSortNameMessageLabel = "SS_pokedex_087";
		private const string HeavierSortNameMessageLabel = "SS_pokedex_088";
		private const string LighterSortNameMessageLabel = "SS_pokedex_089";
		private const string HigherSortNameMessageLabel = "SS_pokedex_090";
		private const string LowerSortNameMessageLabel = "SS_pokedex_091";

		private const int ScrollListUpDownMoveValue = 1;
		private const int ScrollListLeftRightMoveValue = 9;
		private const float SliderIconRotateDuration = 0.3f;
		private const float SliderIconRotateValue = 15.0f;
		private const int StopLoadModelCount = -1;
		private const int StartLoadModelCount = 3;
		private const int SwitchZukanButton = 192;

		private readonly int _animStateIn = Animator.StringToHash("in");
		private readonly int _animStateOut = Animator.StringToHash("out");

        [SerializeField]
		private RectTransform header;
		[SerializeField]
		private Image headerImage;
		[SerializeField]
		private Sprite[] headerSprites;
		[SerializeField]
		private Image fadeImage;
		[SerializeField]
		private RectTransform sliderIconRectTransform;
		[SerializeField]
		private UIScrollView listScrolView;
		[SerializeField]
		private Image titleImage;
		[SerializeField]
		private UIText getCountText;
		[SerializeField]
		private UIText foundCountText;
		[SerializeField]
		private UIText sortNameText;
		[SerializeField]
		private ZukanDescriptionPanel descriptionPanel;
		[SerializeField]
		private RectTransform descriptionHideModelViewPosition;
		[SerializeField]
		private RectTransform descriptionHideInfoButtonPosition;
		[SerializeField]
		private RectTransform contextMenuPosition;

		private UIMsgWindowController msgWindowController;
		private List<ZukanInfo> zukanInfoList;
		private List<ZukanInfo> viewZukanInfoList;
		private List<ZukanInfo> getZukanInfoList;
		private Dictionary<int, int> nameSortOrderDic;
		private ZukanPokemonInfoButton.ViewType buttonViewType;
		private ZukanPokemonInfoButton selectedZukanPokemonInfoButton;
		private bool canSwitchZukan;
		private bool canShowDescription;
		private bool isWaitUpdate;
		private bool isShowZenkokuZukan;
		private int loadModelCount;
		private ShowZukanType showZukanType;
		
		// TODO
		public override void OnCreate() { }
		
		// TODO
		public void Open(UIWindowID prevWindowId, MonsNo showDescriptionMonsNo = MonsNo.NULL, ShowZukanType showZukanType = ShowZukanType.None) { }
		
		// TODO
		public IEnumerator OpOpen(UIWindowID prevWindowId, MonsNo showDescriptionMonsNo = MonsNo.NULL)
		{
			// TODO
            IEnumerator DelaySetDescription() { return default; }

            return default;
		}
		
		// TODO
		public void Close(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { }
		
		// TODO
		public IEnumerator OpClose(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { return default; }
		
		// TODO
		private void OnUpdate(float deltaTime) { }
		
		// TODO
		private void OnUpdateDefault() { }
		
		// TODO
		private void OnUpdateDescriptionPanel() { }
		
		// TODO
		private void UpdateLoadModelRequest(float deltaTime) { }
		
		// TODO
		private void Initialize() { }
		
		// TODO
		private void OnRequiredItemData(IUIButton button) { }
		
		// TODO
		private void OnSelectItemScrollViewItem(IUIButton button) { }
		
		// TODO
		private void OnUnSelectItemScrollViewItem(IUIButton button) { }
		
		// TODO
		private void SetupZukan() { }
		
		// TODO
		private void ReloadZukanList(MonsNo selectMonsNo = MonsNo.NULL) { }
		
		// TODO
		private void UpdateKeyGuide() { }
		
		// TODO
		private void HideKeyGuide() { }
		
		// TODO
		private void RotateSliderIcon(bool isNegative) { }
		
		// TODO
		private void RequestLoadModel() { }
		
		// TODO
		private void SwitchZukan() { }
		
		// TODO
		private void ShowHabitatWindow(PokemonParam pokemonParam) { }
		
		// TODO
		private void ShowMovingWindow(PokemonParam pokemonParam) { }
		
		// TODO
		private void ShowCompareWindow() { }
		
		// TODO
		private void Rating() { }
		
		// TODO
		private void ShowSortListContextMenu() { }
		
		// TODO
		private void SortList(ZUKAN_SORT_TYPE sortType) { }
		
		// TODO
		private void SetSortNameText(ZUKAN_SORT_TYPE sortType) { }
		
		// TODO
		private void CreateNameSortOrderData() { }
		
		// TODO
		private void SaveWorkCurrent() { }
		
		// TODO
		private void ShowDescriptionPanel() { }
		
		// TODO
		private void HideDescriptionPanel() { }

		public enum ShowZukanType : int
		{
			None = 0,
			Shinou = 1,
			Zenkoku = 2,
		}
	}
}