using AK;
using Audio;
using Dpr.Message;
using Dpr.SubContents;
using Dpr.UI;
using GameData;
using Pml;
using Pml.PokePara;
using System.Collections;
using UnityEngine;

namespace Dpr.Demo
{
	public class Demo_Hatch : DemoBase
	{
		private TimeLineBinder timeLine;
		private PokemonParam param;
		private float waitTime = 10.5f;
		private float pokeRoarAnimTime;
		private bool isCloseHatchMsg;
		private bool isManafy;
		private MarkerReceiver receiver;
		
		public Demo_Hatch(PokemonParam param)
		{
			this.param = param;

			StartEnterFadeDuration = 0.2f;
			StartExitFadeDuration = 0.2f;
			EndEnterFadeDuration = 0.5f;
			EndExitFadeDuration = 0.5f;

			UseCamera = true;
			DisableEnvironmentController = false;
			isDisablePostProcess = true;
			isDisableMainCamera = true;

			if (param.GetMonsNo() == MonsNo.MANAFI)
				isManafy = true;
		}
		
		public override void Destroy()
		{
			timeLine = null;
			param = null;
			receiver = null;
		}
		
		public override IEnumerator Enter()
        {
            AudioManager.Instance.SetBgmEvent(EVENTS.EV_SILENCE_EVO);
            PlayerWork.isPlayerInputActive = false;

			bgType = BGType.Evolve;
			cameraController.cam.transform.localPosition = new Vector3(0.0f, 0.4f, 1.3f);

			if (isManafy)
			{
				yield return Utils.LoadAsset("demo/timeline/hatch", asset =>
				{
					if (asset.name != "HatchMTimeLine")
						return;

					var go = Object.Instantiate(asset, parent) as GameObject;
					timeLine = go.GetComponent<TimeLineBinder>();
				});
			}
			else
			{
                yield return Utils.LoadAsset("demo/timeline/hatch", asset =>
                {
                    if (asset.name != "HatchTimeLine")
                        return;

                    var go = Object.Instantiate(asset, parent) as GameObject;
                    timeLine = go.GetComponent<TimeLineBinder>();
                });
            }

			timeLine.GetCamera().targetTexture = cameraController.cam.targetTexture;
			cameraController.cam.targetTexture = null;
			cameraController.cam.SetActive(false);

			var tamagoCatalog = DataManager.GetPokemonCatalog(param.GetMonsNo(), param.GetFormNo(), param.GetSex(), param.IsRare(), true);
			var pokeCatalog = Utils.GetPokemonCatalog(param);

			yield return LoadPokeAsset(param, false, true, true);

			yield return Utils.LoadAsset("objects/" + tamagoCatalog.AssetBundleName, asset =>
			{
				if (asset.name == tamagoCatalog.AssetBundleName)
					PokeAssets.Add(tamagoCatalog.UniqueID, asset);
			});

			var tamagoAsset = new TimeLineBinder.PokemonData(PokeAssets[tamagoCatalog.UniqueID], tamagoCatalog, param);
			var pokeAsset = new TimeLineBinder.PokemonData(PokeAssets[pokeCatalog.UniqueID], pokeCatalog, param);

			timeLine.ExternalAssets.Add("_Poke01", tamagoAsset);
			timeLine.ExternalAssets.Add("_Poke02", pokeAsset);

			receiver = timeLine.AddComponentIfNecessary<MarkerReceiver>();

			yield return timeLine.Setup();

			if (param.IsRare())
			{
				timeLine.MuteTrack("NormalEffect");
				timeLine.UnMuteTrack("RareEffect");
				timeLine.UnMuteTrack("RareEffect1");
				timeLine.UnMuteTrack("RareEffect2");
				timeLine.UnMuteTrack("SE RARE");
			}
			else
			{
                timeLine.MuteTrack("RareEffect");
                timeLine.UnMuteTrack("NormalEffect");
                timeLine.MuteTrack("RareEffect1");
                timeLine.MuteTrack("RareEffect2");
                timeLine.MuteTrack("SE RARE");
            }

			SetMessage();

			pokeRoarAnimTime = timeLine.battlePokeEntity.GetAnimationPlayer().clips[(int)BattlePokemonEntity.AnimationState.Roar01].length;
			timeLine.Play();
        }
		
		public override IEnumerator Main()
		{
			var isFinished = false;

			receiver.OnCheckEnd = (a, b) => isFinished = true;

			while (!isFinished)
				yield return null;

			DrawMessage(0);

			var isFinishBGM = false;

			AudioManager.Instance.PlaySe(EVENTS.M_FI011, ins => isFinishBGM = true);

			yield return WaitMessageWindow();

            while (!isFinishBGM)
                yield return null;

			yield return null;

			var bag = UIManager.Instance.GetCurrentUIWindow<UIBag>();
			var register = UIManager.Instance.CreateUIWindow<UIZukanRegister>(UIWindowID.ZUKAN_REGISTER);

			if (bag == null)
				manager.UICanvas.sortingOrder = 99;

			var isOpen = true;

			register.onClosed = __ => isOpen = false;
			register.Open(param, true);

			while (isOpen)
				yield return null;

			if (bag == null)
                manager.UICanvas.sortingOrder = 101;
        }
		
		public override IEnumerator Exit()
		{
			AudioManager.Instance.SetBgmEvent(EVENTS.EV_END_0SEC);
			PlayerWork.isPlayerInputActive = true;
			Object.Destroy(timeLine.gameObject);

			yield return null;
		}
		
		private void SetMessage()
		{
			var msg = CreateMsgWindowParam("ss_tamago_demo", "SS_tamago_demo_001");
			msg.inputCloseEnabled = false;
			msg.onFinishedCloseWindow = SetIsHauchMsg;
			Messages.Add(msg);

			MessageWordSetHelper.SetMonsNameWord(0, param);
		}
		
		private void SetIsHauchMsg()
		{
			isCloseHatchMsg = true;
		}
	}
}