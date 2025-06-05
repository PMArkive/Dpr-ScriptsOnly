using Pml;
using Pml.PokePara;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class UIWazaManage : UIWindow
	{
		private static readonly Vector2 MsgWindowAnchorPos = new Vector2(0.0f, 100.0f);

		private const string ConfirmRememberWazaMessageLabel = "SS_waza_remember_023";
		private const string ConfirmDontRememberWazaMessageLabel = "SS_waza_remember_026";
		private const string ConfirmUnlernWazaMessageLabel = "SS_waza_remember_037";
		private const string SwapWazaResultMessageLabel = "SS_waza_remember_040";
		private const string SelectSwapWazaMessageLabel = "SS_waza_remember_042";
		private const string ConfirmDontLearnWazaMessageLabel = "SS_waza_remember_043";
		private const string ConfirmSwapWazaMessageLabel = "SS_waza_remember_045";

		[SerializeField]
		private GameObject bgObject;
		[SerializeField]
		private GameObject withWazaBgObject;
		[SerializeField]
		private PokemonStatusTab[] categoryTabs;
		[SerializeField]
		private GameObject[] statusPanelObjects;
		[SerializeField]
		private Image[] categoryTabCornerImages;
		[SerializeField]
		private WazaManageWazaStatusPanel[] wazaStatusPanels;
		[SerializeField]
		private Image pokemonInfoMonsterBallImage;
		[SerializeField]
		private RectTransform pokemonInfoSelectArrowRoot;
		[SerializeField]
		private UIText pokemonInfoName;
		[SerializeField]
		private UIText pokemonInfoLevel;
		[SerializeField]
		private Image pokemonInfoSex;
		[SerializeField]
		private Image pokemonInfoLanguage;
		[SerializeField]
		private PokemonSick pokemonInfoSick;
		[SerializeField]
		private WazaManagePokemonStausPanel battlePokemonStatusPanel;
		[SerializeField]
		private WazaManagePokemonStausPanel contestPokemonStatusPanel;
		[SerializeField]
		private WazaManageCondition statusPanelCondition;

		private UIMsgWindowController msgWindowController;
		private List<PokemonStatusTab> activeTabs = new List<PokemonStatusTab>();

		private readonly int _animStateIn = Animator.StringToHash("in");
		private readonly int _animStateOut = Animator.StringToHash("out");

        private int selectTabIndex;
		private Param param;
		
		// TODO
		public override void OnCreate() { }
		
		// TODO
		public void Open(Param param) { }
		
		// TODO
		public IEnumerator OpOpen() { return default; }
		
		// TODO
		private void SetupPokemonInfo() { }
		
		// TODO
		private void SetupKeyGuide() { }
		
		// TODO
		public void Close(UnityAction<UIWindow> onClosed_) { }
		
		// TODO
		public IEnumerator OpClose(UnityAction<UIWindow> onClosed_) { return default; }
		
		// TODO
		private void OnUpdate(float deltaTime) { }
		
		// TODO
		private void UpdateSelectTab(float deltaTime) { }
		
		// TODO
		private void UpdateSelectWaza(float deltaTime) { }
		
		// TODO
		private bool SetSelectTabIndex(int selectTabIndex, bool isForce = false) { return default; }

		public enum BootType : int
		{
			Remember = 0,
			Unlearn = 1,
			Learn = 2,
		}

		public struct Param
		{
			public BootType BootType;
			public bool IsOpenFromFieldScript;
			public PokemonParam PokemonParam;
			public WazaNo LearnWazaNo;
			public Action<WazaNo, WazaNo> ResultCallback;
		}
	}
}