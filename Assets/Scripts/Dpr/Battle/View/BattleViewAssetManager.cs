using Dpr.Battle.View.Playables;
using Dpr.SequenceEditor;
using Effect;
using Pml;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dpr.Battle.View
{
	public static class BattleViewAssetManager
	{
		private static Dictionary<string, UnityEngine.Object> CachedAssetBundle { get; set; } = new Dictionary<string, UnityEngine.Object>();
		public static List<Tuple<string, EffectData>> CachedEffectData { get; set; } = new List<Tuple<string, EffectData>>();
		public static List<Tuple<string, ObjectEntity>> CachedModelData { get; set; } = new List<Tuple<string, ObjectEntity>>();
		public static Dictionary<string, CameraFilePlayable> CachedCameraFilePlayables { get; set; } = new Dictionary<string, CameraFilePlayable>();

        public static List<UnityEngine.Object> NeedDestroyObjects = new List<UnityEngine.Object>();

        // TODO
        public static void Initialize() { }
		
		// TODO
		public static void UnInitialize(bool isNeedDestroyObjects = false) { }
		
		// TODO
		public static bool HasCameraFilePlayable(string key) { return default; }
		
		// TODO
		public static void AddCameraFilePlayable(string key, CameraFilePlayable playable) { }
		
		// TODO
		public static bool TryGetCameraFilePlayable(string key, out CameraFilePlayable playable)
		{
			playable = default;
			return default;
		}
		
		// TOD
		public static IEnumerator LoadBattleViewUISystem(string path, Action<GameObject> onComplete) { return default; }
		
		// TODO
		public static IEnumerator LoadModel(string path, Action<GameObject> onComplete) { return default; }
		
		// TODO
		public static IEnumerator LoadTrainer(TrainerSimpleParam param, Action<GameObject> onComplete) { return default; }
		
		// TODO
		public static IEnumerator LoadPoke(MonsNo monsNo, int formNo, Sex sex, bool isRare, Action<GameObject> onComplete) { return default; }
		
		// TODO
		public static IEnumerator LoadExceptionPoke(MonsNo monsNo, int formNo, Sex sex, bool isRare, string AssetBundleName, Action<GameObject> onComplete) { return default; }
		
		// TODO
		public static IEnumerator LoadSequenceFile(string path, Action<SequenceFile> onComplete) { return default; }
		
		// TODO
		public static IEnumerator LoadWaitCameraFile(string fileName, Action<GameObject> onComplete) { return default; }
		
		// TODO
		private static IEnumerator LoadAssetBundle<T>(string path, Action<UnityEngine.Object> onComplete) { return default; }
		
		// TODO
		private static void AddNeedDestroyObject(GameObject go, bool isCheckDead = false) { }
	}
}