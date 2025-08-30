using Dpr.Contest;
using Dpr.Message;
using GameData;
using Pml;
using Pml.PokePara;
using SmartPoint.AssetAssistant;
using SmartPoint.Components;
using SmartPoint.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;

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
		
		private void Awake()
		{
			director = GetComponent<PlayableDirector>();

			director.played += OnPlayableDirectorPlayed;
			director.stopped += OnPlayableDirectorStoped;
			director.paused += OnPlayableDirectorPaused;

			timeLineAsset = (TimelineAsset)director.playableAsset;

			AddLightLayer("Character");
			AddLightLayer("Field");

			var canvas = GetComponent<Canvas>();
			canvas.sortingOrder = 200;

			var canvasScaler = canvas.GetComponent<CanvasScaler>();
			canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
			canvasScaler.referenceResolution = new Vector2(1280.0f, 720.0f);

			if (EnvironmentController.global != null)
			{
                EnvironmentController.global.gameObject.SetActive(false);
                PrevEnvController = EnvironmentController.global;
            }

			if (Camera != null)
			{
				var cam = Camera.GetComponent<Camera>();
				cam.cullingMask = 1;
				cam.cullingMask |= Layer.Character;
				cam.cullingMask |= Layer.Field;
				cam.cullingMask |= Layer.Effect;
				cam.farClipPlane = 100.0f;

				var postProcess = cam.GetComponent<PostProcessFilter>();
				postProcess.Reset();
				postProcess.AddComponentIfNecessary<RenderPriorityController>();
            }

			BindAssets.ForEach(x =>
			{
				if (x.assetBundlePath == "_MyPoke")
					x.assetBundlePath = "_Poke01";

                if (x.assetBundlePath == "_FriendPoke")
                    x.assetBundlePath = "_Poke02";

                if (x.assetBundlePath == "_MyBall")
                    x.assetBundlePath = "_Ball01";

                if (x.assetBundlePath == "_FriendBall")
                    x.assetBundlePath = "_Ball02";
            });
        }
		
		public Coroutine Setup()
		{
			return StartCoroutine(OpSetup());
		}
		
		public void Play()
		{
			director.Play();
		}
		
		public void Pause()
		{
			director.Pause();
		}
		
		public void Resume()
		{
			director.Resume();
		}
		
		public void Stop()
		{
			director.Stop();
		}
		
		public void SetTime(float time)
		{
			director.time = time;
		}
		
		public void GotoTimelineEnd()
		{
			SetTime((float)director.duration * 0.99f);
		}
		
		private void Update()
		{
			if (director.time / director.duration > 0.9900000095367432)
			{
				Pause();
				OnComplete?.Invoke(director);
				OnComplete = null;
			}
		}
		
		public void SetOnComplete(Action<PlayableDirector> onComplete)
		{
			OnComplete = onComplete;
		}
		
		public void Bind()
		{
			director = GetComponent<PlayableDirector>();

			BindAssets.ForEach(x =>
			{
                GameObject go = null;

				if (x.LoadedAsset != null)
				{
					go = Instantiate(x.LoadedAsset, x.parent) as GameObject;

					var bpe = go.GetComponent<BattlePlayerEntity>();
					if (bpe != null)
						bpe.Initialize(ContestUtils.CreateTrainerSimpleParam(PlayerWork.playerSex ? Trainer.TrainerType.BOY : Trainer.TrainerType.GIRL, PlayerWork.colorID));

					BaseEntity pokemonEntity = go.GetComponent<FieldPokemonEntity>();
					if (pokemonEntity == null)
                        pokemonEntity = go.GetComponent<BattlePokemonEntity>();

					if (pokemonEntity != null)
					{
                        battlePokeEntity = (BattlePokemonEntity)pokemonEntity; // This cast is weird considering you can possibly have a FieldPokemonEntity here
						if (x.catalog != null)
							go.transform.localScale *= x.isBattleScale ? x.catalog.BattleScale : x.catalog.MenuScale;
                    }

					if (x.scale != -1.0f)
						go.transform.localScale *= x.scale;
                }

				if (go != null)
				{
					go.SetActive(true);
					go.transform.localPosition = Vector3.zero;

					if (x.Rename != "")
						go.name = x.Rename;

					if (x.pokeParam != null)
					{
						var motion = x.parent.GetComponent<TimeLineMotion>();
						if (motion != null)
						{
							motion.Pattern = x.pokeParam.GetPersonalRnd();
							motion.updatePattern = true;
						}
					}
				}
            });

            BindEffects.ForEach(x =>
            {
				if (x.EffectName == "")
					return;

				x.parent.AddComponentIfNecessary<TimeLineEffect>();
				var eff = x.parent.GetComponent<TimeLineEffect>();
				eff.SetEffect(x.EffData, x);
            });

            BindSounds.ForEach(x =>
            {
				var audio = x.parent.gameObject.AddComponent<TimeLineAudio>();
				audio.soundType = x.soundType;

				switch (x.soundType)
				{
					case BindModelSound.SoundType.BGM:
					case BindModelSound.SoundType.SE:
						audio.SoundID = x.GetID();
						break;

					case BindModelSound.SoundType.VOICE:
						if (x.catalog == null)
						{
							if (x.Debug_Voice != MonsNo.NULL)
								audio.monsNo = x.Debug_Voice;
						}
						else
						{
							if (x.catalog.MonsNo != MonsNo.TAMAGO && x.catalog.MonsNo != MonsNo.DAMETAMAGO)
                            {
                                audio.monsNo = x.catalog.MonsNo;
                                audio.formNo = x.catalog.FormNo;
                            }
						}
						break;
				}

				if (!x.WaitFinish)
					return;

				audio.SetCallBack(() => Pause(), () => Resume());
            });
        }
		
		// TODO
		public void MuteTrack(string name) { }
		
		// TODO
		public void UnMuteTrack(string name) { }
		
		public void RemoveEffectsNum(int num)
		{
			while (num != 0)
			{
				BindEffects.RemoveAt(BindEffects.Count - 1);
				num--;
			}
		}
		
		public void RemoveBindAsset()
		{
			BindAssets.Clear();
		}
		
		private IEnumerator OpLoadAssets()
		{
			var assetName = "";

			for (int i=0; i<BindAssets.Count; i++)
			{
				if (BindAssets[i].assetBundlePath.Contains("_Ball"))
					BindAssets[i].Rename = "ball";
				else if (BindAssets[i].assetBundlePath.Contains("_Poke"))
                    BindAssets[i].Rename = "Poke";

				if (ExternalAssets.ContainsKey(BindAssets[i].assetBundlePath))
				{
					if (ExternalAssets[BindAssets[i].assetBundlePath].GetType() == typeof(PokemonData))
					{
						var pokeData = ExternalAssets[BindAssets[i].assetBundlePath] as PokemonData;
						BindAssets[i].LoadedAsset = pokeData.asset;
						BindAssets[i].catalog = pokeData.catalog;
						BindAssets[i].monsNo = MonsNo.NULL;
                        BindAssets[i].scale = pokeData.scale;
						BindAssets[i].pokeParam = pokeData.param;
                    }
					else if (ExternalAssets[BindAssets[i].assetBundlePath].GetType() == typeof(BallData))
                    {
                        var ballData = ExternalAssets[BindAssets[i].assetBundlePath] as BallData;
                        BindAssets[i].LoadedAsset = ballData.asset;
                    }
				}
				else
				{
                    if (BindAssets[i].assetBundlePath.Contains("_Player"))
					{
						BindAssets[i].assetBundlePath = "persons/battle/" + DataManager.GetCharacterDressData(PlayerWork.playerFashion).BattleGraphic;
						assetName = BindAssets[i].GetAssetName();

						yield return Utils.LoadAsset(BindAssets[i].assetBundlePath, asset =>
						{
							if (asset.name.ToLower() == assetName)
								BindAssets[i].LoadedAsset = asset;
                        });
                    }

					var monsNo = BindAssets[i].monsNo;
					var sex = new PokemonParam(monsNo, 1, 0).GetSex();
					var isEgg = BindAssets[i].isEgg;
                    var catalog = DataManager.GetPokemonCatalog(monsNo, 0, sex, false, BindAssets[i].isEgg);

					if (monsNo != MonsNo.NULL)
					{
                        yield return LoadPokeAsset(monsNo, 0, sex, false, isEgg, asset =>
                        {
                            BindAssets[i].LoadedAsset = asset;
                            BindAssets[i].catalog = catalog;
                        });
                    }
					else
					{
						if (BindAssets[i].assetBundlePath != "")
						{
							if (BindAssets[i].assetBundlePath.Contains("_Ball"))
								BindAssets[i].assetBundlePath = "objects/ob0203_00";

                            assetName = BindAssets[i].GetAssetName();

							yield return Utils.LoadAsset(BindAssets[i].assetBundlePath, asset =>
                            {
                                if (asset.name.ToLower() == assetName)
                                    BindAssets[i].LoadedAsset = asset;
                            }, BindAssets[i].isVariants);
                        }
                    }
                }
            }

			for (int i=0; i<BindEffects.Count; i++)
			{
				yield return Utils.LoadEffect(BindEffects[i].GetEffectID(), eff => BindEffects[i].EffData = eff);
			}

			for (int i=0; i<BindSounds.Count; i++)
			{
				if (ExternalAssets.ContainsKey(BindSounds[i].SoundName))
				{
					var soundData = ExternalAssets[BindSounds[i].SoundName] as PokemonData;
					BindSounds[i].catalog = soundData.catalog;
					BindSounds[i].Debug_Voice = MonsNo.NULL;
                }
			}
		}
		
		private IEnumerator OpSetup()
		{
			yield return OpLoadAssets();

			Bind();

			yield return null;

			GameManager.connector.ResetLight();
			MyEnvironmentController.SetActive(true);
			GameManager.connector.IsEnableUpdate = false;

			Sequencer.update += MyUpdate;
		}
		
		private void MyUpdate(float deltaTime)
		{
			MyEnvironmentController.SetLight(EnvSettings, PeriodOfDay.Daytime, 0.0f);
		}
		
		private void OnPlayableDirectorPlayed(PlayableDirector aDirector)
		{
			// Empty
		}
		
		private void OnPlayableDirectorStoped(PlayableDirector aDirector)
        {
            // Empty
        }

        private void OnPlayableDirectorPaused(PlayableDirector aDirector)
        {
            // Empty
        }

        public IEnumerator LoadPokeAsset(MonsNo monsNo, ushort formNo, Sex sex, bool isRare, bool isEgg, Action<UnityEngine.Object> OnLoad)
		{
			var catalogBundleName = DataManager.GetPokemonCatalog(monsNo, formNo, sex, isRare, isEgg).AssetBundleName;
			var baseBundleName = isEgg ? "objects/" : "pokemons/battle/";
			var pokeBundleName = baseBundleName + catalogBundleName;
			var assetName = Utils.GetAssetNamebyPath(pokeBundleName);

			AssetManager.AppendAssetBundleRequest(pokeBundleName, true, null, null);
			yield return AssetManager.DispatchRequests((eventType, name, asset) =>
			{
				if (eventType == RequestEventType.Activated)
				{
					if (asset.name == assetName)
						OnLoad.Invoke(asset);
				}
				else if (eventType == RequestEventType.Complete)
				{
					FieldManager.abUnloader.AddPath(pokeBundleName);
				}
			});
		}
		
		public Camera GetCamera()
		{
			return Camera.GetComponent<Camera>();
		}
		
		public void AddLightLayer(string layerName)
		{
            MyEnvironmentController.GetComponent<Light>().cullingMask |= (1 << LayerMask.NameToLayer(layerName));
        }
		
		public List<BindModel> GetBindModels()
		{
			return BindAssets;
		}
		
		// TODO
		private void OnDestroy() { }
		
		private void BindAssetToEffect()
		{
			for (int i=StartIndex; i<BindAssets.Count; i++)
			{
				var eff = new BindModelEffect();
				eff.parent = BindAssets[i].parent;
				eff.EffectName = BindAssets[i].GetAssetName().ToUpper();
				eff.StartActive = BindAssets[i].StartActive;
				BindEffects.Add(eff);
			}
		}
		
		private void DebugPattern()
		{
			ppp.SetPattern(ppval);
		}
		
		public void DeleteBindPoke(int pokeNum)
		{
			BindAssets.ForEach(x =>
			{
				if (x.assetBundlePath.Contains("_Poke"))
				{
					if (int.Parse(x.assetBundlePath.Substring(5, 2)) > pokeNum)
						x.assetBundlePath = "";

					x.monsNo = MonsNo.NULL;
				}
			});

            BindSounds.ForEach(x =>
            {
                if (x.SoundName.Contains("_Poke"))
                {
                    if (int.Parse(x.SoundName.Substring(5, 2)) > pokeNum)
					{
                        x.SoundName = "";
						x.Debug_Voice = MonsNo.NULL;
                    }
                }
            });
        }
		
		public void ChangePokeBattleScale()
		{
			BindAssets.ForEach(x =>
			{
				if (x.assetBundlePath.Contains("_Poke"))
					x.parent.GetComponentInChildren<BaseEntity>().transform.localScale = Vector3.one * x.catalog.BattleScale;
			});
        }
		
		public void ChangePokeMenuScale()
		{
            BindAssets.ForEach(x =>
            {
                if (x.assetBundlePath.Contains("_Poke"))
                    x.parent.GetComponentInChildren<BaseEntity>().transform.localScale = Vector3.one * x.catalog.MenuScale;
            });
        }
		
		public void TimeLineCall()
		{
			OnTimeLineCallBack?.Invoke();
		}
		
		public BattlePokemonEntity GetPokeEntity()
		{
			return battlePokeEntity;
		}
		
		private void DebugSetTime()
		{
			director.time = DebugTime;
		}

		public interface IBindData
		{
			void Destroy();
		}

		public class PokemonData : IBindData
		{
			public UnityEngine.Object asset;
			public XLSXContent.PokemonInfo.SheetCatalog catalog;
			public PokemonParam param;
			public float scale;
			
			public PokemonData(UnityEngine.Object asset, XLSXContent.PokemonInfo.SheetCatalog catalog, PokemonParam param)
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