using DG.Tweening;
using DPData;
using Dpr.Demo;
using Dpr.MsgWindow;
using Dpr.SubContents;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class UIPofinResult : UIWindow
	{
		[SerializeField]
		private CanvasGroup group;
		[SerializeField]
		private UIText timeText;
		[SerializeField]
		private UIText koboshiText;
		[SerializeField]
		private UIText kogashiText;
		[SerializeField]
		private Image pofinImage;
		[SerializeField]
		private UIText pofinInfo;
		[SerializeField]
		private Image Kekka;

		private bool isEnableInput;
		public Action OnExit;
		private PofinCookModel model;
		private PoffinData pofinData;
		private int poffinNum;
		private Demo_ModelViewer pofin3D_Demo;
		private int DebugModelNo;
		private int nowStateID;
		private MsgWindowParam msgParam;
		private DemoSceneManager demoMng;

		[Button("Exit", "Exit", new object[0])]
		public int Button02;
		
		// TODO
		private IEnumerator Start() { return default; }
		
		// TODO
		public void SetData(PofinCookModel model) { }
		
		// TODO
		public void UpdateInput(float deltaTime) { }
		
		// TODO
		private void NextState() { }
		
		// TODO
		private void GetPoffinMessage() { }
		
		// TODO
		private void ContinueConfirmation() { }
		
		// TODO
		private void EndCooking() { }
		
		// TODO
		private Tweener Enter() { return default; }
		
		// TODO
		public Tweener Exit() { return default; }
	}
}