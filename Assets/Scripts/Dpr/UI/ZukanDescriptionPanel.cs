using Audio;
using Dpr.Message;
using Pml.PokePara;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class ZukanDescriptionPanel : MonoBehaviour
	{
		private const float MoveDuration = 0.3f;
		private const float FadeDuration = 0.2f;

		[SerializeField]
		private UIButtonSelector languageButtonSelector;
		[SerializeField]
		private ZukanPokemonInfoButton pokemonInfoButton;
		[SerializeField]
		private Image pokemonMaleIconImage;
		[SerializeField]
		private Image pokemonFemaleIconImage;
		[SerializeField]
		private Image pokemonRareIconImage;
		[SerializeField]
		private GameObject arrowUpDownObject;
		[SerializeField]
		private GameObject arrowLeftRightObject;
		[SerializeField]
		private RectTransform arrowUpRectTransform;
		[SerializeField]
		private RectTransform arrowDownRectTransform;
		[SerializeField]
		private RectTransform arrowLeftRectTransform;
		[SerializeField]
		private RectTransform arrowRightRectTransform;
		[SerializeField]
		private UIText classText;
		[SerializeField]
		private TypePanel typePanel1;
		[SerializeField]
		private TypePanel typePanel2;
		[SerializeField]
		private UIText heightValueText;
		[SerializeField]
		private UIText weightValueText;
		[SerializeField]
		private UIText descriptionText;
		[SerializeField]
		private Image footprintImage;
		[SerializeField]
		private GameObject footprintObject;
		[SerializeField]
		private Image fadeImage;
		[SerializeField]
		private PokemonModelView modelView;
		[SerializeField]
		private Image unknownModelImage;
		[SerializeField]
		private RawImage modelViewRawImage;
		[SerializeField]
		private RectTransform modelViewRectTransform;
		[SerializeField]
		private RectTransform modelViewOnlyPositionRectTransform;
		[SerializeField]
		private GameObject pokemonInfoButtonObject;
		[SerializeField]
		private CanvasGroup pokemonInfoButtonCanvasGroup;
		[SerializeField]
		private CanvasGroup pokemonInfoButtonGenderIconCanvasGroup;
		[SerializeField]
		private GameObject hideObject;
		[SerializeField]
		private Image bgImage;
		[SerializeField]
		private Image bgHeadImage;
		[SerializeField]
		private Sprite[] bgHeadSprites;
		[SerializeField]
		private GameObject formObject;
		[SerializeField]
		private UIText formText;
		[SerializeField]
		private GameObject modelViewFrameObject;
		[SerializeField]
		private Image modelViewBgImage;
		[SerializeField]
		private UIText[] changeLanguageTexts;

		private Vector2 hideModelViewPosition;
		private Vector2 hideInfoButtonPosition;
		private ZukanInfo[] zukanInfos;
		private IndexSelector zukanInfoIndexSelector;
		private AudioInstance currentVoiceInstance;

		public ZukanInfo CurrentZukanInfo { get; set; }
		public bool IsTweening { get; set; }
		public bool IsShow { get; set; }
		public bool IsModelViewOnly { get; set; }
		public bool CanSwitchLanguage { get; set; }
		public bool CanShowMoving { get => CurrentZukanInfo.GetStatus == DPData.GET_STATUS.GET; }
		public bool CanShowCompare { get => CurrentZukanInfo.GetStatus == DPData.GET_STATUS.GET; }
		
		// TODO
		public void Initialize() { }
		
		// TODO
		public void Dispose() { }
		
		// TODO
		public void SetZukanInfos(ZukanInfo[] infos) { }
		
		// TODO
		public Vector3 GetModelViewPosition() { return default; }
		
		// TODO
		public Vector3 GetInfoButtonPosition() { return default; }
		
		// TODO
		public void SetArrowsActive(bool isUpDownActive, bool isLeftRightActive) { }
		
		// TODO
		public void SetBgHead(bool isZenkoku) { }
		
		// TODO
		public void OnUpdateModelView(float deltaTime, UIInputController input) { }
		
		// TODO
		public void SetHidePositions(Vector2 modelViewPos, Vector2 infoButtonPos) { }
		
		// TODO
		public void Set(ZukanPokemonInfoButton button) { }
		
		// TODO
		public void Set(ZukanInfo zukanInfo, bool isAllowSwitchLanguage = true) { }
		
		// TODO
		public void SetUnknownModelView() { }
		
		// TODO
		public void SetModelView(PokemonParam pokemonParam, bool isPlayVoice = false)
		{
            // TODO
            IEnumerator OnUpdate() { return default; }
        }
		
		// TODO
		public void ShowDescription([Optional] [DefaultParameterValue(false)] bool isImmidiate, [Optional] [DefaultParameterValue(true)] bool isMoveInfoButton, [Optional] Action onCompleteAction) { }
		
		// TODO
		public void HideDescription([Optional] [DefaultParameterValue(false)] bool isImmidiate, [Optional] [DefaultParameterValue(true)] bool isHideBg, [Optional] [DefaultParameterValue(true)] bool isMoveInfoButton, [Optional] Action onCompleteAction) { }
		
		// TODO
		public void ShowModelViewOnly([Optional] Action onCompleteAction) { }
		
		// TODO
		public void HideModelViewOnly([Optional] Action onCompleteAction) { }
		
		// TODO
		public void UpdateAshiatoIcon() { }
		
		// TODO
		public bool MoveLanguageButtonSelect(int value) { return default; }
		
		// TODO
		public void ResumeLanguageButtonSelect() { }
		
		// TODO
		public bool MoveZukanInfoSelect(int addValue) { return default; }
		
		// TODO
		public void ResumeZukanInfoSelect() { }
		
		// TODO
		public bool MoveCatalogSelect(int addValue) { return default; }
		
		// TODO
		private void SetupLanguageButtons() { }
		
		// TODO
		private void UpdateLanguageButtons() { }
		
		// TODO
		private void OnSelectLanguageButton(IUIButton button) { }
		
		// TODO
		private void OnUnSelectLanguageButton(IUIButton button) { }
		
		// TODO
		private void UpdateSexType() { }
		
		// TODO
		private void UpdateRareIcon() { }
		
		// TODO
		private void UpdateFormTextActive() { }
		
		// TODO
		private void UpdateTypes(MessageEnumData.MsgLangId langId = MessageEnumData.MsgLangId.Num) { }
		
		// TODO
		private void PlayVoice(PokemonParam pokemonParam) { }
	}
}