using Effect;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dpr.Contest
{
	public class ContestHeartEmitter
	{
		private const int GENERATE_DANCE_NORMAL_HEART_OBJ_NUM = 15;
		private const int GENERATE_DANCE_LARGE_HEART_OBJ_NUM = 7;

		private VisualHeartEffect[] visualNormalHeartArray;
		private VisualHeartEffect[] visualLargeHeartArray;
		private DanceHeartEffect[] danceNormalHeartArray;
		private DanceHeartEffect[] danceLargeHeartArray;
		private List<VisualHeartEffect> activeVisualHeartList = new List<VisualHeartEffect>();
		private HeartBeziePath[] bezieParams;
		private NPCHeartParam npcHeartParam;
		private EffectData normalHeartFxData;
		private EffectData largeHeartFxData;
		private EffectManager fxManagerPtr;
		private ContestSettings contestSettingPtr;
		private Vector2 screenHalfSize;
		private int visualNormalArrayIndex;
		private int visualLargeArrayIndex;
		private bool bLoadedVisualHeartFx;
		private bool bLoadedDanceHeartFx;
		
		public bool IsLoaded { get => bLoadedVisualHeartFx && bLoadedDanceHeartFx; }
		
		// TODO
		public void Setup(ContestPlayerEntity[] playerEntityArray, Transform visualHeartContent, Transform danceHeartContent, ContestSettings contestSetting) { }
		
		// TODO
		private void GenerateVisualHeartPool(Transform visualHeartContent, ContestPlayerEntity[] playerEntityArray) { }
		
		// TODO
		private int CalcGenerateVisualNormalHeartNum(ContestPlayerEntity[] playerEntityArray) { return default; }
		
		// TODO
		private int CalcGenerateVisualLargeHeartNum(ContestPlayerEntity[] playerEntityArray) { return default; }
		
		// TODO
		private void GenerateDanceHeartPool(Transform danceHeartContent) { }
		
		// TODO
		private void LoadFxData(EffectContestID fxID, int poolCount, Action<EffectData> onComplete) { }
		
		// TODO
		public void Reset() { }
		
		// TODO
		public void OnFinalize() { }
		
		// TODO
		public void CreateVisualHeartFx(int emitNum, Vector2 emitPos, bool isLarge) { }
		
		// TODO
		public DanceHeartEffect CreatePlayerHeart(Vector2 from, Vector2 to, EmitHeartPattern pattern, Action onComplete) { return default; }
		
		// TODO
		public DanceHeartEffect CreateNPCHeart(Vector2 from, Vector2 to, EmitHeartPattern pattern, Action onComplete) { return default; }
		
		// TODO
		private DanceHeartEffect FindDeactiveDanceNormalHeart() { return default; }
		
		// TODO
		private DanceHeartEffect FindDeactiveDanceLargeHeart() { return default; }
		
		// TODO
		public void UpdateVisualHeart(float deltaTime) { }
		
		// TODO
		public void StopVisualHeartFx() { }
		
		// TODO
		public void StopDanceHeartFx() { }
	}
}