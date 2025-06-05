using Dpr.Message;
using Pml;
using Pml.PokePara;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using XLSXContent;

namespace Dpr.SubContents
{
	public class TimeLineBinder : MonoBehaviour
	{
		private PlayableDirector director;

		[SerializeField]
		private Transform Camera;
		[SerializeField]
		private List<BindModel> BindAssets;
		[SerializeField]
		private List<BindModelEffect> BindEffects;
		[SerializeField]
		private List<BindModelSound> BindSounds;
		[SerializeField]
		private EnvironmentSettings EnvSettings;
		[SerializeField]
		private EnvironmentController MyEnvironmentController;

		private EnvironmentController PrevEnvController;
		private TimelineAsset timeLineAsset;
		public Dictionary<string, IBindData> ExternalAssets = new Dictionary<string, IBindData>();
		private Dictionary<int, UnityEngine.Object> PokeAssets = new Dictionary<int, UnityEngine.Object>();
		public Action OnTimeLineCallBack;
		public Action<PlayableDirector> OnComplete;
		public BattlePokemonEntity battlePokeEntity;

		[Button("Setup", "Setup", new object[0])]
		public int Button01;
        [Button("Play", "Play", new object[0])]
        public int Button02;

		private bool isActive;
		public int StartIndex;

        [Button("BindAssetToEffect", "BindAssetToEffect", new object[0])]
        public int Button10;

		private PatcheelPattern ppp;
		private uint ppval;

        [Button("DebugPattern", "DebugPattern", new object[0])]
        public int Button11;

		[SerializeField]
		private float DebugTime;

        [Button("DebugSetTime", "DebugSetTime", new object[0])]
        public int Button010;
		
		// TODO
		private void Awake() { }
		
		// TODO
		public Coroutine Setup() { return default; }
		
		// TODO
		public void Play() { }
		
		// TODO
		public void Pause() { }
		
		// TODO
		public void Resume() { }
		
		// TODO
		public void Stop() { }
		
		// TODO
		public void SetTime(float time) { }
		
		// TODO
		public void GotoTimelineEnd() { }
		
		// TODO
		private void Update() { }
		
		// TODO
		public void SetOnComplete(Action<PlayableDirector> onComplete) { }
		
		// TODO
		public void Bind() { }
		
		// TODO
		public void MuteTrack(string name) { }
		
		// TODO
		public void UnMuteTrack(string name) { }
		
		// TODO
		public void RemoveEffectsNum(int num) { }
		
		// TODO
		public void RemoveBindAsset() { }
		
		// TODO
		private IEnumerator OpLoadAssets() { return default; }
		
		// TODO
		private IEnumerator OpSetup() { return default; }
		
		// TODO
		private void MyUpdate(float deltaTime) { }
		
		// TODO
		private void OnPlayableDirectorPlayed(PlayableDirector aDirector) { }
		
		// TODO
		private void OnPlayableDirectorStoped(PlayableDirector aDirector) { }
		
		// TODO
		private void OnPlayableDirectorPaused(PlayableDirector aDirector) { }
		
		// TODO
		public IEnumerator LoadPokeAsset(MonsNo monsNo, ushort formNo, Sex sex, bool isRare, bool isEgg, Action<UnityEngine.Object> OnLoad) { return default; }
		
		// TODO
		public Camera GetCamera() { return default; }
		
		// TODO
		public void AddLightLayer(string layerName) { }
		
		// TODO
		public List<BindModel> GetBindModels() { return default; }
		
		// TODO
		private void OnDestroy() { }
		
		// TODO
		private void BindAssetToEffect() { }
		
		// TODO
		private void DebugPattern() { }
		
		// TODO
		public void DeleteBindPoke(int pokeNum) { }
		
		// TODO
		public void ChangePokeBattleScale() { }
		
		// TODO
		public void ChangePokeMenuScale() { }
		
		// TODO
		public void TimeLineCall() { }
		
		// TODO
		public BattlePokemonEntity GetPokeEntity() { return default; }
		
		// TODO
		private void DebugSetTime() { }

		public interface IBindData
		{
			void Destroy();
		}

		public class PokemonData : IBindData
		{
			public UnityEngine.Object asset;
			public PokemonInfo.SheetCatalog catalog;
			public PokemonParam param;
			public float scale;
			
			public PokemonData(UnityEngine.Object asset, PokemonInfo.SheetCatalog catalog, PokemonParam param)
			{
				this.asset = asset;
				this.catalog = catalog;
				this.param = param;
				scale = 1.0f;
			}
			
			public void Destroy()
			{
				asset = null;
				catalog = null;
				param = null;
			}
		}

		public class BallData : IBindData
		{
			public UnityEngine.Object asset;
			
			public BallData(UnityEngine.Object asset)
			{
				this.asset = asset;
			}
			
			public void Destroy()
			{
				asset = null;
			}
		}

		public class PokeNameData : IBindData
		{
			public string name;
			
			public PokeNameData(PokemonParam param)
			{
				name = param.GetNickName().GetInvalidRichText();
				name = MessageHelper.SurroundFontTag(name, param.GetLangId());
			}
			
			public void Destroy()
			{
				name = null;
			}
		}
	}
}