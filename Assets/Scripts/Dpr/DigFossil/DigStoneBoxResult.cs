using Dpr.Item;
using Dpr.SecretBase;
using Dpr.UnderGround.LightStone;
using Pml.Item;
using SmartPoint.AssetAssistant;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;
using XLSXContent;

namespace Dpr.DigFossil
{
	public class DigStoneBoxResult : IDigStoneBoxResult
	{
		private Context context;
		private Action onFinishDirection;
		private Step step;
		private StoneBoxDirection stoneBoxDirection;
		private GameObject statueModel;
		private StatueEffectData statueData;
		private GameObject bgModel;
		private int statueLoadWaitCount;
		private bool isMaxStatue;
		private StatueEffectRawData.Sheettable statue;

		private const string animatonClipAssetName = "objects/ob2000_00";
		private const string bgModelAssetName = "bg/arenas/ground/eventarea012";
		private const string bgModelPrefabName = "EVENTAREA012";
		
		public IEnumerator Initialize(Context context)
		{
			this.context = context;

			if (stoneBoxDirection != null)
				UnityEngine.Object.Destroy(stoneBoxDirection);

			if (statueModel != null)
			{
                UnityEngine.Object.Destroy(statueModel);
				statueModel = null;
            }

            if (bgModel != null)
            {
                UnityEngine.Object.Destroy(bgModel);
                bgModel = null;
            }

			if (context.boxData != null)
			{
				AnimationClip clip = null;
				GameObject model = null;

				AssetManager.AppendAssetBundleRequest(bgModelAssetName, true, null, null);
				AssetManager.AppendAssetBundleRequest(animatonClipAssetName, true, null, null);
				AssetManager.AppendAssetBundleRequest(context.boxData.BoxModelName, true, null, null);

				yield return AssetManager.DispatchRequests((eventType, assetName, asset) =>
				{
					switch (eventType)
					{
						case RequestEventType.Activated:
							{
								if (asset != null)
								{
									if (asset is GameObject)
									{
										if (context.boxData.BoxModelName.Contains(assetName))
										{
											model = UnityEngine.Object.Instantiate(asset, context.boxPos) as GameObject;
											model.SetActive(false);
										}
										else if (assetName == bgModelPrefabName)
										{
											bgModel = UnityEngine.Object.Instantiate(asset, context.boxPos) as GameObject;
                                            bgModel.SetActive(false);
                                        }
									}
									else if (asset is AnimationClip)
									{
										clip = asset as AnimationClip;
									}
								}
							}
							break;

						case RequestEventType.Cached:
							{
								AssetManager.UnloadAssetBundle(assetName);
							}
							break;

						case RequestEventType.Complete:
							{
								stoneBoxDirection = model.AddComponent<StoneBoxDirection>();
								stoneBoxDirection.Init(clip, context);
							}
							break;
					}
				});
			}
        }
		
		public void Start(Action onFinishDirection)
		{
			this.onFinishDirection = onFinishDirection;

			bgModel.SetActive(true);
			stoneBoxDirection?.SetActive(true);

			statueModel = null;

			LotteryAndLoadStatue();

            // Unsure on the duration, interfaces make this hard to parse
            context.fade.FadeStart(DigFade.Type.OverEffect, Color.black, Color.black, 0.1f, () => { /* Empty */ });

			step = Step.Init;
        }
		
		private void LotteryAndLoadStatue()
		{
			statue = LotteryStatue();
			isMaxStatue = !UgItemWork.IsAddItem(statue.UgItemID, 1);
			UgItemWork.AddUgItem(statue.UgItemID, 1);

			var uniqueStatuesOwned = UgItemWork.GetHaveStatueKindNum();
			if (uniqueStatuesOwned == UgItemManager.Instance.GetNumStatueKInd())
			{
				TvWork.SekizouHakkutunin(uniqueStatuesOwned);
			}
			else if (uniqueStatuesOwned > 0 && uniqueStatuesOwned % 50 == 0)
			{
				if (PlayerWork.UgCountRecord.NumStatueBroadcastOnTV < uniqueStatuesOwned)
				{
					TvWork.SekizouHakkutunin(uniqueStatuesOwned);
					PlayerWork.UgCountRecord.NumStatueBroadcastOnTV = (short)uniqueStatuesOwned;
				}
			}

			context.cameraSelector.SetCamera(statue);
			context.cameraSelector.SwitchBoxCamera(true);

			LoadStatue(statue);
		}
		
		private StatueEffectRawData.Sheettable LotteryStatue()
		{
			var lotteryInfos = context.masterDataManager.StatueEffectData
				.Where(data => data.type1Id == context.boxData.RawData.type && data.rarity == context.boxData.RawData.boxId)
				.Select(data => new LotteryInfo(data, context.digBoard.RatioId))
				.ToList();

			List<UgItemInfo> missingStatues = null;
			bool boostedRates = false;
			if (!LightStoneManager.Instance.IsBonusTime && context.digParam.NumOfOtherParticipants > 0)
			{
				missingStatues = UgItemWork.GetDoNotHaveStatue();
				boostedRates = true;
			}

			float totalRatio = 0.0f;
			foreach (var lotteryInfo in lotteryInfos)
			{
				if (boostedRates)
				{
					if (missingStatues.Exists(data => data.UgItemId == lotteryInfo.Info.UgItemID))
						lotteryInfo.Ratio *= context.digParam.Bonus;

					totalRatio += lotteryInfo.Ratio;
                }
				else
				{
                    totalRatio += lotteryInfo.Ratio;
                }
			}

			var result = lotteryInfos[0];

            var roll = UnityEngine.Random.Range(0.0f, totalRatio);
			for (int i=0; i<lotteryInfos.Count; i++)
			{
				roll -= lotteryInfos[i].Ratio;
				if (roll < 0.0f)
				{
                    result = lotteryInfos[i];
					break;
                }
            }

			return result.Info;
		}
		
		private void LoadStatue(StatueEffectRawData.Sheettable statue)
		{
			statueData = new StatueEffectData(statue);
			context.statueModelLoader.Load(statueData, context.boxPos, gameObject =>
			{
				statueModel = gameObject;
				statueModel.SetActive(false);
				ChangeStep(Step.IdleStatueLoding);
			});
		}
		
		public void OnUpdate()
		{
			switch (step)
			{
				case Step.IdleStatueLoding:
					{
						statueLoadWaitCount++;

						if (statueLoadWaitCount > 3 && statueModel != null && !statueModel.activeInHierarchy)
							ChangeStep(Step.FadeIn);
					}
					break;

				case Step.IdleBoxGetMessage:
                    {
						if (DigInput.Dig)
						{
                            context.audioManager.PlaySe(DigAudioManager.SeId.Decide);
                            context.message.Close();
                            ChangeStep(Step.ShowBoxOpenMessage);
                        }	
                    }
                    break;

				case Step.IdleBoxOpenMessage:
                    {
                        if (DigInput.Dig)
                        {
                            context.audioManager.PlaySe(DigAudioManager.SeId.Decide);
                            context.message.Close();
							ChangeStep(Step.BoxOpenDirection);
                        }
                    }
                    break;

				case Step.IdleStatueGetMessage:
                    {
                        if (DigInput.Dig)
                        {
                            context.audioManager.PlaySe(DigAudioManager.SeId.Decide);
                            context.message.Close();

							if (isMaxStatue)
								ChangeStep(Step.ShowStatueMaxMessage);
							else
							{
								onFinishDirection.Invoke();
                                ChangeStep(Step.End);
                            }
                        }
                    }
                    break;

				case Step.IdleStatueMaxMessage:
                    {
                        if (DigInput.Dig)
                        {
                            context.audioManager.PlaySe(DigAudioManager.SeId.Decide);
                            context.message.Close();

							onFinishDirection.Invoke();
                            ChangeStep(Step.End);
                        }
                    }
                    break;
            }
		}
		
		private void ChangeStep(Step step)
		{
			this.step = step;

			switch (step)
			{
				case Step.IdleStatueLoding:
					{
                        statueLoadWaitCount = 0;
                    }
					break;

				case Step.FadeIn:
					{
						// Unsure on the duration, interfaces make this hard to parse
						context.fade.FadeStart(DigFade.Type.OverEffect, Color.black, Color.black, 0.0f, () => ChangeStep(Step.ShowBoxGetMessage));
					}
					break;

				case Step.ShowBoxGetMessage:
					{
						context.message.ShowResultStoneBoxMessage(context.boxData.Reality, () => ChangeStep(Step.IdleBoxGetMessage), () => { /* Empty */ });
                    }
					break;

				case Step.ShowBoxOpenMessage:
					{
						context.message.ShowStoneBoxOpenMessage(() => ChangeStep(Step.IdleBoxOpenMessage), () => { /* Empty */ });
                    }
					break;

				case Step.BoxOpenDirection:
					{
						stoneBoxDirection.BoxOpen(context.boxPos.position, () =>
						{
                            stoneBoxDirection?.SetActive(false);
							statueModel.SetActive(true);
							context.cameraSelector.SwitchBoxCamera(false);

                            // Unsure on the duration, interfaces make this hard to parse
                            context.fade.FadeStart(DigFade.Type.OverEffect, Color.white, Color.white, 0.0f, () => ChangeStep(Step.ShowStatueGetMessage));

                            ChangeStep(Step.ShowStatueWhbiteIn);
                        });
                    }
					break;

                case Step.ShowStatueGetMessage:
                    {
                        context.message.ShowStatueGetMessage(statueData.MSLabelId, () => ChangeStep(Step.IdleStatueGetMessage), () => { /* Empty */ });
                    }
                    break;

                case Step.ShowStatueMaxMessage:
                    {
                        context.message.ShowUgItemMaxMessage(() => ChangeStep(Step.IdleStatueMaxMessage), () => { /* Empty */ });
                    }
                    break;
            }
		}

		public class Context
		{
			public DigMasterDataManager.StoneBoxData boxData;
			public Transform boxPos;
			public DigMasterDataManager masterDataManager;
			public IDigMessage message;
			public IDigFade fade;
			public IDigAudioManager audioManager;
			public IDigStatueCameraSelector cameraSelector;
			public IDigBoard digBoard;
			public DigFossilController.DigParam digParam;
			public StatueModelLoader statueModelLoader;
			public DigEffectManager effectManager;
			public DirectionParam directionParam;
			public DebugParam debugParam;
			
			public Context(DigMasterDataManager.StoneBoxData boxData, Transform boxPos, DigMasterDataManager masterDataManager, IDigMessage message, IDigFade fade, IDigAudioManager audioManager, IDigStatueCameraSelector cameraSelector, IDigBoard digBoard, DigFossilController.DigParam digParam, StatueModelLoader statueModelLoader, DigEffectManager effectManager)
			{
				this.boxData = boxData;
				this.boxPos = boxPos;
				this.masterDataManager = masterDataManager;
				this.message = message;
				this.fade = fade;
				this.audioManager = audioManager;
				this.cameraSelector = cameraSelector;
				this.digBoard = digBoard;
				this.digParam = digParam;
				this.statueModelLoader = statueModelLoader;
				this.effectManager = effectManager;
			}
		}

		public class DirectionParam
		{
			public float boxOpenAnimationSpeed;
			public float effectFireDelay;
			public Vector2 blackIn;
			public Vector2 whiteOut;
			public Vector2 whiteIn;
			
			public DirectionParam(float boxOpenAnimationSpeed, float effectFireDelay, Vector2 blackIn, Vector2 whiteOut, Vector2 whiteIn)
			{
				this.boxOpenAnimationSpeed = boxOpenAnimationSpeed;
				this.effectFireDelay = effectFireDelay;
				this.blackIn = blackIn;
				this.whiteOut = whiteOut;
				this.whiteIn = whiteIn;
			}
		}

		public class DebugParam
		{
			public int statueId;
			
			public DebugParam(int statueId)
			{
				this.statueId = statueId;
			}
		}

		public class LotteryInfo
		{
			public LotteryInfo(StatueEffectRawData.Sheettable info, DigMasterDataManager.RatioId ratioId)
			{
				Info = info;

				switch (ratioId)
				{
					case DigMasterDataManager.RatioId.Diamond:         Ratio = info.ratio1; break;
					case DigMasterDataManager.RatioId.Diamond_Dialga:  Ratio = info.ratio2; break;
					case DigMasterDataManager.RatioId.Diamond_Zenkoku: Ratio = info.ratio3; break;
					case DigMasterDataManager.RatioId.Pearl:           Ratio = info.ratio4; break;
					case DigMasterDataManager.RatioId.Pearl_Palkia:    Ratio = info.ratio5; break;
					case DigMasterDataManager.RatioId.Pearl_Zenkoku:   Ratio = info.ratio6; break;
				}
			}
			
			public StatueEffectRawData.Sheettable Info { get; private set; }
			public float Ratio { get; set; }
		}

		private enum Step : int
		{
			Init = 0,
			IdleStatueLoding = 1,
			FadeIn = 2,
			ShowBoxGetMessage = 3,
			IdleBoxGetMessage = 4,
			ShowBoxOpenMessage = 5,
			IdleBoxOpenMessage = 6,
			BoxOpenDirection = 7,
			ShowStatueWhbiteIn = 8,
			ShowStatueGetMessage = 9,
			IdleStatueGetMessage = 10,
			ShowStatueMaxMessage = 11,
			IdleStatueMaxMessage = 12,
			End = 13,
		}

		public class StoneBoxDirection : MonoBehaviour
		{
			private PlayableGraph graph;
			private AnimationClipPlayable clipPlayable;
			private Context context;
			
			public void Init(AnimationClip clip, Context context)
			{
				this.context = context;
				graph = PlayableGraph.Create();

				var animator = gameObject.GetComponent<Animator>();
				if (animator == null)
					animator = gameObject.AddComponent<Animator>();

				clipPlayable = AnimationClipPlayable.Create(graph, clip);
				clipPlayable.SetSpeed(context.directionParam.boxOpenAnimationSpeed);
				AnimationPlayableOutput.Create(graph, animator.name, animator).SetSourcePlayable(clipPlayable);
            }
			
			public void BoxOpen(Vector3 effectPos, Action onCompletedCallback)
			{
				StartCoroutine(BoxOpenDirection(effectPos, onCompletedCallback));
			}
			
			private void PlayBoxOpenAnimation()
			{
				graph.Play();
			}
			
			private IEnumerator BoxOpenDirection(Vector3 effectPos, Action onCompletedCallback)
			{
				graph.Play();

				yield return new WaitForSeconds(context.directionParam.effectFireDelay);

				context.audioManager.PlaySe(DigAudioManager.SeId.AppearStatue);
				var effHandle = context.effectManager.Play(DigEffectManager.EffectId.OpenBox, effectPos, false);

                yield return new WaitForSeconds(context.directionParam.whiteOut.x);

				bool whiteOutCompleted = false;

                // Unsure on the duration, interfaces make this hard to parse
                context.fade.FadeStart(DigFade.Type.OverEffect, Color.white, Color.white, 0.0f, () => {
					effHandle.Stop(0.0f, true);
					whiteOutCompleted = true;
				});

				while (!whiteOutCompleted)
					yield return null;

                yield return new WaitForSeconds(context.directionParam.whiteIn.x);

				onCompletedCallback.Invoke();
            }
		}
	}
}