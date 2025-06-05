using Dpr.Contest;
using System;
using System.Collections;
using UnityEngine;

namespace Dpr.UI
{
	public class UIContestInfo : UIWindow
	{
		[SerializeField]
		private InfoItem[] infoItemArray;
		[SerializeField]
		private GameObject furRootObj;
		
		// TODO
		public override void OnCreate() { }
		
		// TODO
		public void Open(UIWindowID prevWindowId = WINDOWID_PARENT) { }
		
		// TODO
		private IEnumerator OpOpen(UIWindowID prevWindowId) { return default; }
		
		// TODO
		private void Setup() { }
		
		// TODO
		private RankID FindMaxClearRankNormalContest(CategoryID category) { return default; }
		
		// TODO
		private RankID FindMaxClearRankInSercretContest() { return default; }
		
		// TODO
		private void SetNameParam(int index, CategoryID category, RankID rankID) { }
		
		// TODO
		private void OnUpdate(float deltaTime) { }
		
		// TODO
		private void UpdateInput() { }
		
		// TODO
		private void CloseWindow() { }
		
		// TODO
		private IEnumerator OpClose() { return default; }

		[Serializable]
		public struct InfoItem
		{
			public UIText categoryNameText;
			public UIText rankNameText;
		}

		private class CategoryIndex
		{
			public const int Style = 0;
			public const int Beautiful = 1;
			public const int Cute = 2;
			public const int Clever = 3;
			public const int Strong = 4;
			public const int Fur = 5;
		}
	}
}