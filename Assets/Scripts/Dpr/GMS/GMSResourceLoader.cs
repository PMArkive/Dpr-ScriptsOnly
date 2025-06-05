using System;
using UnityEngine;
using UnityEngine.U2D;

namespace Dpr.GMS
{
	public class GMSResourceLoader
	{
		private bool bIsLoading;
		
		public bool IsLoading { get => bIsLoading; }
		
		// TODO
		public void UnloadAssetBundle() { }
		
		// TODO
		public void AppendLoadAsset(string assetBundlePath, Action<UnityEngine.Object> onCompleteLoad) { }
		
		// TODO
		public void AppendLoadScenePrefabs(string assetBundlePath, Transform parent, Action<string, GameObject> onCompleteLoad) { }
		
		// TODO
		public void AppendLoadEarth(string path, Transform content, float earthRadius, Action<GameObject> onComplete) { }
		
		// TODO
		public void AppendLoadTexture2D(string path, Action<Texture2D> onComplete) { }
		
		// TODO
		public void LoadSpriteAtlas(string assetBundlePath, Action<SpriteAtlas> onCompleteLoad) { }
		
		// TODO
		public void RequestLoadAsset() { }
	}
}