using Dpr.MsgWindow;
using Dpr.NetworkUtils;
using Dpr.SequenceEditor;
using INL1;
using SmartPoint.AssetAssistant;
using System.Collections;
using UnityEngine;

namespace Dpr.Contest
{
	public class ContestController : MonoBehaviour
	{
		private const float LIMIT_TIMEOUT = 10.0f;

		private ReceivedPlayerResultScore[] receivedScores;
		private ContestMatchingNetwork network = new ContestMatchingNetwork();
		private WaitTimer waitTimer;
		private bool bCanStartContest;
		private bool bIsRecieveWaitTime;
		private bool canSectionUpdate = true;
		private bool bIsStartMultiContest;
		[SerializeField]
		private Camera wazaCamera;
		private SceneObjectManager objectManagerPtr;
		private OpeningSection openingSection;
		private VisualSection visualSection;
		private DanceSection danceSection;
		private ResultSection resultSection;
		private ContestDataModel dataModel = new ContestDataModel();
		private SceneResourceLoader resourceLoader = new SceneResourceLoader();
		private ContestViewSystem contestViewSystem = new ContestViewSystem();
		private ContestViewSystem wazaViewSystem = new ContestViewSystem();
		private SectionID currentSectionID;
		private SectionID nextSectionID;
		private ResultDataModel resultDataModel;
		private bool hasRequestChangeSectionID;
		
		// TODO
		private void InitMultiMode() { }
		
		private void StartNetworkContest()
		{
			this.bIsStartMultiContest = true;
		}
		
		// TODO
		private void SetupNetwork() { }
		
		// TODO
		private IEnumerator IE_ActivateMultiMode() { return default; }
		
		// TODO
		private bool CanStartNetworkContest() { return default; }
		
		// TODO
		private void OnChangeSectionToVisual() { }
		
		// TODO
		private void UpdateWaitAsync() { }
		
		// TODO
		private void UpdateNetworkError() { }
		
		// TODO
		private void OnChangeSectionWaitAsync() { }
		
		// TODO
		private void ApplyReceivedPlayerResultScore() { }
		
		// TODO
		private void OnRecievePacket(byte dataID, PacketReader pr) { }
		
		// TODO
		private void OnReceiveNotice(NoticeNetData noticeData) { }
		
		private void OnSessionEvent(SessionEventData result)
		{
			switch((int)((ulong)result >> 0x20)) {
			case 3:
			  Contest_ContestController.OnChangeHostMine();
			default:
			case 6:
			  Contest_ContestController.OnLeaveOtherPlayer();
			case 7:
			case 8:
			  Contest_ContestController.OnSessionError();
			case 9:
			  Contest_ContestMatchingNetwork.ReleaseNetworkCallback(this[0]);
			  Contest_ContestController.OnSessionError();
			}
		}
		
		// TODO
		private void OnLeaveOtherPlayer(int stationIndex) { }
		
		private bool IsGaming()
		{
			return (int)this.currentSectionID < 3;
		}
		
		private void ChangeAllOtherPlayerToNPC()
		{
			Contest_DanceSection.OnLeaveOtherPlayer(this.danceSection,0);
			Contest_DanceSection.OnLeaveOtherPlayer(this.danceSection,1);
			Contest_DanceSection.OnLeaveOtherPlayer(this.danceSection,2);
			Contest_DanceSection.OnLeaveOtherPlayer(this.danceSection,3);
		}
		
		// TODO
		private void OnChangeHostMine() { }
		
		// TODO
		private void OnChangeHostOtherPlayer() { }
		
		// TODO
		private void OnSessionError() { }
		
		// TODO
		private void OnFinishedSession() { }
		
		// TODO
		[SceneBeforeActivateOperationMethod]
		public IEnumerator ActivateOperation(Transform cluster) { return default; }
		
		// TODO
		private void CloseUIWindow() { }
		
		// TODO
		private IEnumerator IE_LoadScenePrefabs(Transform cluster) { return default; }
		
		// TODO
		private void SceneInitialize() { }
		
		// TODO
		private IEnumerator IE_LoadMasterDatas() { return default; }
		
		// TODO
		private void SystemInitialize() { }
		
		// TODO
		private IEnumerator IE_PreLoadResource(Transform cluster) { return default; }
		
		// TODO
		private void AppendLoadNotesData() { }
		
		// TODO
		private void AppendOpeningResource() { }
		
		// TODO
		private void AppendLoadModel(Transform cluster) { }
		
		// TODO
		private void LoadMainSequence() { }
		
		// TODO
		private void LoadWazaSequence() { }
		
		// TODO
		private void SetupUITexture() { }
		
		// TODO
		private void Start() { }
		
		// TODO
		private void PrevSetup() { }
		
		// TODO
		private IEnumerator IE_Start() { return default; }
		
		// TODO
		private void AfterSetup() { }
		
		// TODO
		private void OnDestroy() { }
		
		private void StartContest()
		{
			this.bIsStartMultiContest = true;
			Contest_ContestController.ChangeSectionOpening();
		}
		
		// TODO
		private void OnUpdate(float deltaTime) { }
		
		private bool IsCompleteSection { get => currentSectionID == SectionID.End; }
		
		// TODO
		private void FinishedContest() { }
		
		private void UpdateSection(float deltaTime, float elapsedTime)
		{
			switch(this.currentSectionID) {
			case 0:
			  if (((((Contest_OpeningSection.UpdateSection(this.openingSection) & 1) == 0) &&
			       (Contest_OpeningSection.UpdateSection(this.openingSection) = Contest_DanceSection.IsReady(this.danceSection),
			       (Contest_OpeningSection.UpdateSection(this.openingSection) & 1) != 0)) && (this.wazaViewSystem.ready != 0)) &&
			     ((this.contestViewSystem.ready != 0 &&
			      (Contest_OpeningSection.UpdateSection(this.openingSection) = Contest_SceneObjectManager.get_IsReady(this.objectManagerPtr),
			      (Contest_OpeningSection.UpdateSection(this.openingSection) & 1) != 0)))) {
			    Contest_ContestController.RequestChangeSectionId(1);
			  }
			  break;
			case 1:
			  if ((Contest_VisualSection.UpdateSection(this.visualSection) & 1) == 0) {
			    Contest_ContestController.RequestChangeSectionId(2);
			  }
			  break;
			case 2:
			  Contest_ContestController.UpdateDanceSection();
			case 4:
			  Contest_ContestController.UpdateWaitAsync();
			case 5:
			  if ((Contest_ResultSection.UpdateSection(this.resultSection) & 1) == 0) {
			    if (this.resultSection.restartContest != 0) {
			      Contest_ContestController.RequestChangeSectionId(6);
			    }
			    Contest_ContestController.RequestChangeSectionId(8);
			  }
			  break;
			case 7:
			  Contest_ContestController.UpdateNetworkError();
			}
		}
		
		private void UpdateOpeningSection()
		{
			if (((((Contest_OpeningSection.UpdateSection(this.openingSection) & 1) == 0) &&
			     (Contest_OpeningSection.UpdateSection(this.openingSection) = Contest_DanceSection.IsReady(this.danceSection),
			     (Contest_OpeningSection.UpdateSection(this.openingSection) & 1) != 0)) && (this.wazaViewSystem.ready != 0)) &&
			   ((this.contestViewSystem.ready != 0 &&
			    (Contest_OpeningSection.UpdateSection(this.openingSection) = Contest_SceneObjectManager.get_IsReady(this.objectManagerPtr),
			    (Contest_OpeningSection.UpdateSection(this.openingSection) & 1) != 0)))) {
			  Contest_ContestController.RequestChangeSectionId(1);
			}
		}
		
		private void UpdateVisualSection()
		{
			if ((Contest_VisualSection.UpdateSection(this.visualSection) & 1) != 0) {
			}
			Contest_ContestController.RequestChangeSectionId(2);
		}
		
		// TODO
		private void UpdateDanceSection(float deltaTime, float elapsedTime) { }
		
		private void UpdateResultSection(float deltaTime)
		{
			if ((Contest_ResultSection.UpdateSection(this.resultSection) & 1) != 0) {
			}
			var uVar2 = 8;
			if (this.resultSection.restartContest != 0) {
			  uVar2 = 6;
			}
			Contest_ContestController.RequestChangeSectionId(uVar2);
		}
		
		// TODO
		private IEnumerator IE_LoadResultResource() { return default; }
		
		// TODO
		private void OnLateUpdate(float deltaTime) { }
		
		// TODO
		private void DoNextSection() { }
		
		private void LateUpdateSection()
		{
			if ((int)this.currentSectionID == 2) {
			  Contest_DanceSection.OnLateUpdate(this.danceSection);
			}
		}
		
		// TODO
		private void ChangeSectionOpening() { }
		
		// TODO
		private void RequestChangeSectionId(SectionID newSectionId) { }
		
		// TODO
		private void OnFindCommand(CommandNo commandNo, ContestViewSystem viewSystem) { }
		
		private void LoadMigawariModel()
		{
			Contest_SceneResourceLoader.LoadMigawariModel(this.resourceLoader,0);
		}
		
		// TODO
		private void OnPerformedCommand(CommandNo commandNo, ContestViewSystem viewSystem, Macro macro) { }
		
		// TODO
		private void ForceStopContest() { }
		
		// TODO
		private IEnumerator IE_RestartContest() { return default; }
		
		// TODO
		private IEnumerator IE_ReloadTutorialSeq() { return default; }
		
		// TODO
		private IEnumerator IE_LoadTutorialResource() { return default; }
		
		// TODO
		private void ResetParam() { }
	}
}