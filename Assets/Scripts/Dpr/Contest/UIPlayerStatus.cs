using Dpr.SubContents;
using Effect;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dpr.Contest
{
	public class UIPlayerStatus : MonoBehaviour
	{
		[SerializeField]
		private Sprite[] tensionSprArray;
		[SerializeField]
		private GameObject[] statusIconObjArray;
		private Dictionary<int, Sprite> tensionSprTable = new Dictionary<int, Sprite>();
		private List<Coroutine> runningCoroutineList = new List<Coroutine>();
		private EffectInstance[] skillBgFxArray;
		private PlayerStatusIcon[] statusIconArray;
		private EffectEmitter fxEmitter = new EffectEmitter();
		private WaitForSeconds waitWazaStartFx;
		private float duration;
		private float jumpPower;
		
		// TODO
		public void Initialize(float waitWazaStartTime) { }
		
		// TODO
		private void SetTentionSprTable() { }
		
		// TODO
		public bool IsReady() { return default; }
		
		// TODO
		public void Setup(float duration, float jumpPower) { }
		
		// TODO
		private void LoadFx() { }
		
		// TODO
		public void SetPlayerDataUI(AContestPlayerData data, Sprite wazaTypeIconSpr, Sprite iconSpr) { }
		
		// TODO
		public void OnFinalize() { }
		
		// TODO
		public void ResetParam() { }
		
		// TODO
		public void Stop() { }
		
		// TODO
		public Vector3 GetIconPos(int index) { return default; }
		
		// TODO
		public void SetTensionID(int index, TensionID tensionID) { }
		
		// TODO
		public void SetTensionID(int index, TensionID tensionID, bool isUp) { }
		
		// TODO
		public void LaunchContestWaza(int playerIndex) { }
		
		// TODO
		private IEnumerator IE_LaunchContestWaza(int playerIndex, Action onComplete) { return default; }
		
		// TODO
		public void OnFinishedSkillEffect(int playerIndex) { }
		
		// TODO
		public void ShowWazaMaskByIndex(int playerIndex) { }
	}
}