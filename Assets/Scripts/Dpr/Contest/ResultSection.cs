using System.Collections;
using UnityEngine;

namespace Dpr.Contest
{
	public class ResultSection : MonoBehaviour
	{
		private ResultSettings resultSettings;
		private ResultAnnouncement resultAnnounce;
		private ResultTotalScores totalScores;
		private ResultPersonalPerformance personalPerformance;
		private ResultTutorialMode tutorialMode;
		private ResultDataModel resultDataModel;
		private ResultState currentState;
		private bool bRunning;
		private bool restartContest;
		private bool isTutorial;
		private WaitForSeconds waitStartResult;
		
		// TODO
		public void SetScriptableObject(ResultSettings resultSettings) { }
		
		// TODO
		public void Initialize() { }
		
		// TODO
		public void ResetParam() { }
		
		// TODO
		public void OnFinalize() { }
		
		public bool IsRestart { get => restartContest; }
		public bool IsReady { get => resultAnnounce.IsReady; }
		
		// TODO
		public void Setup(bool isTutorial) { }
		
		// TODO
		public void LoadResource(ResultID resultID) { }
		
		// TODO
		public void StartSection(ResultDataModel resultDataModel) { }
		
		// TODO
		private IEnumerator IE_StartSection(ResultState firstState) { return default; }
		
		// TODO
		public bool UpdateSection(float deltaTime) { return default; }
		
		// TODO
		private void UpdateAnnouncement(float deltaTime) { }
		
		// TODO
		private void UpdateTotalScores(float deltaTime) { }
		
		// TODO
		private void UpdatePersonalPerformance() { }
		
		// TODO
		private void UpdateTutorialMode(float deltaTime) { }
		
		// TODO
		private void ChangeState(ResultState stateID) { }
		
		// TODO
		private RankGaugeData CreateRankGaugeData() { return default; }

		private enum ResultState : int
		{
			WaitStart = 0,
			Announcement = 1,
			TotalScores = 2,
			PersonalPerformance = 3,
			Tutorial = 4,
			Finish = 5,
		}
	}
}