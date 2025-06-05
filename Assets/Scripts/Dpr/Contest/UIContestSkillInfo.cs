using DG.Tweening;
using Dpr.SubContents;
using UnityEngine;
using UnityEngine.UI;
using XLSXContent;

namespace Dpr.Contest
{
	public class UIContestSkillInfo : MonoBehaviour
	{
		[SerializeField]
		private GameObject template;
		private UILaunchSkillLog[] skillLogArray;
		private Sprite[] chainCountSprArray;
		private RectTransform commandIconTransform;
		private RectTransform chainCountContentRect;
		private GameObject acceptChainGaugeObj;
		private Image acceptChainGaugeImage;
		private DOTweenAnimation[] chainCountTweenArray;
		private DOTweenAnimation[] commandAppealTween;
		private EffectEmitter fxEmitter = new EffectEmitter();
		private GameObject chainCountObj;
		private Image chainCountImage;
		private CanvasGroup appealCanvasGroup;
		private float showSkillLogDuration;
		private float showChainCountDuration;
		private float showChainCountTimer;
		private int showLogCount;
		private bool bIsShowCommand;
		private bool bIsShowChainCount;
		private bool bPlayingCommandAppealTween;
		
		// TODO
		public void Initialize() { }
		
		// TODO
		private void InitChainCount() { }
		
		// TODO
		private void SetChainCountSprArray() { }
		
		// TODO
		public bool IsReady() { return default; }
		
		// TODO
		public void OnFinalize() { }
		
		// TODO
		public void ResetParam() { }
		
		// TODO
		public void Setup(ContestConfigDatas configDatas, ContestPlayerEntity[] entities, bool isTutorial) { }
		
		// TODO
		private void SetSkillUser(int logIndex, ContestPlayerEntity entity, Transform parent) { }
		
		// TODO
		public void UseContestSkill(int playerIndex, int chainCount, bool isShowChainCount, bool canChain, bool isShowChainCountFx, bool isSameUserWazaType) { }
		
		// TODO
		private void ShowChainCount(int chainCount, bool isShowFx) { }
		
		// TODO
		private void PlayChainCountFx() { }
		
		// TODO
		private void StopChainCountFx() { }
		
		// TODO
		public void HideUserContestSkill() { }
		
		// TODO
		public void PlayCommandAppealTween() { }
		
		// TODO
		private void StopCommandAppealTween() { }
		
		// TODO
		private void SetCommandActive(bool active) { }
		
		// TODO
		private void ShowAcceptChainGauge() { }
		
		public bool IsShowLog { get => showLogCount > 0; }
		
		// TODO
		private void ShowLaunchSkillLog(int playerIndex, bool isSameUserWazaType) { }
		
		// TODO
		public void OnUpdate(float deltaTime) { }
		
		// TODO
		private void UpdateUIChainCount(float deltaTime) { }
		
		// TODO
		public void OnCompleteBackWards() { }
		
		private bool IsUpdateChainGauge { get => acceptChainGaugeObj.activeSelf; }
		
		// TODO
		public void UpdateChainGauge(float gaugeRatio) { }
		
		// TODO
		public void UpdateChainGaugeHideTime(float deltaTime) { }
		
		// TODO
		public void HideChainGauge() { }
		
		// TODO
		private void SetAcceptChainGaugeActive(bool active) { }
	}
}