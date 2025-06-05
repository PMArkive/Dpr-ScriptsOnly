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
		
		// TODO
		private void StartNetworkContest() { }
		
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
		
		// TODO
		private void OnSessionEvent(SessionEventData result) { }
		
		// TODO
		private void OnLeaveOtherPlayer(int stationIndex) { }
		
		// TODO
		private bool IsGaming() { return default; }
		
		// TODO
		private void ChangeAllOtherPlayerToNPC() { }
		
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
		
		// TODO
		private void StartContest() { }
		
		// TODO
		private void OnUpdate(float deltaTime) { }
		
		private bool IsCompleteSection { get => currentSectionID == SectionID.End; }
		
		// TODO
		private void FinishedContest() { }
		
		// TODO
		private void UpdateSection(float deltaTime, float elapsedTime) { }
		
		// TODO
		private void UpdateOpeningSection() { }
		
		// TODO
		private void UpdateVisualSection() { }
		
		// TODO
		private void UpdateDanceSection(float deltaTime, float elapsedTime) { }
		
		// TODO
		private void UpdateResultSection(float deltaTime) { }
		
		// TODO
		private IEnumerator IE_LoadResultResource() { return default; }
		
		// TODO
		private void OnLateUpdate(float deltaTime) { }
		
		// TODO
		private void DoNextSection() { }
		
		// TODO
		private void LateUpdateSection() { }
		
		// TODO
		private void ChangeSectionOpening() { }
		
		// TODO
		private void RequestChangeSectionId(SectionID newSectionId) { }
		
		// TODO
		private void OnFindCommand(CommandNo commandNo, ContestViewSystem viewSystem) { }
		
		// TODO
		private void LoadMigawariModel() { }
		
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