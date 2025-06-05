using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Dpr.Demo
{
	public class Demo_ModelViewer : DemoBase
	{
		private string assetPath;
		public bool isEnd;
		private GameObject Model;
		private UnityEngine.Object Asset;
		public Vector3 ModelPosition = Vector3.zero;
		public Vector3 ModelEulerAngles = Vector3.zero;
		public Vector3 ModelScale = Vector3.one;
		public Vector3 ImageOffset = Vector2.zero;
		public Action<GameObject> OnCreateModel;
		private Dictionary<string, CacheParam> _cacheParams = new Dictionary<string, CacheParam>();
		private Coroutine cor;
		
		public Demo_ModelViewer(string AssetBundlePath, bool isDisableEndLight = true)
		{
			assetPath = AssetBundlePath;

			UseStartEnterFade = false;
			UseStartExitFade = false;
			UseEndEnterFade = false;
			UseEndExitFade = false;

			UseCamera = true;
			DisableEnvironmentController = true;
			isUseAlpha = true;
		}
		
		// TODO
		public override void Destroy() { }
		
		// TODO
		public override IEnumerator Enter() { return default; }
		
		// TODO
		public IEnumerator LoadAsset(bool useAssetUnloader = true) { return default; }
		
		// TODO
		private IEnumerator CreateModel([Optional] Action OnCreate, bool useAssetUnloader = true) { return default; }
		
		// TODO
		public void ChangeModel(string AssetBundlePath, bool useAssetUnloader = true) { }
		
		// TODO
		public override IEnumerator Main() { return default; }

		private class CacheParam
		{
			public UnityEngine.Object asset;
			public bool isLoading;
		}
	}
}