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
		
		public void SetScriptableObject(ResultSettings resultSettings)
		{
			this.Length = resultSettings;
		}
		
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
		
		public void LoadResource(ResultID resultID)
		{
			Contest_ResultAnnouncement.LoadResultFx(this[0]);
		}
		
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
		
		private void UpdatePersonalPerformance()
		{
			Contest_ResultPersonalPerformance.UpdatePokeMotion(this.personalPerformance);
			if ((int)this.personalPerformance.currentState == 1) {
			  Contest_ResultPersonalPerformance.UpdateKeywait(this.personalPerformance);
			  var cVar1 = this.personalPerformance.bRunning;
			}
			else {
			  cVar1 = this.personalPerformance.bRunning;
			}
			if (cVar1) {
			}
			this.currentState = (ResultState)5;
			this.bRunning = false;
		}
		
		// TODO
		private void UpdateTutorialMode(float deltaTime) { }
		
		private void ChangeState(ResultState stateID)
		{
			this.currentState = stateID;
			switch(stateID) {
			case 1:
			  Contest_ResultAnnouncement.StartAnimation(this[0]);
			case 2:
			  Contest_ResultTotalScores.StartAnimation(this.totalScores);
			case 3:
			  Contest_ResultPersonalPerformance.StartAnimation(this.personalPerformance);
			case 4:
			  Contest_ResultTutorialMode.StartAnimation(this.tutorialMode);
			case 5:
			  this.bRunning = false;
			}
		}
		
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