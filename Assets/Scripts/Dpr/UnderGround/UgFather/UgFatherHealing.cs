using Dpr.MsgWindow;
using Dpr.UI;
using SmartPoint.Components;
using UnityEngine;

namespace Dpr.UnderGround.UgFather
{
	public class UgFatherHealing : UgFatherBase
	{
		private float waitTime;

		private const float HealingWaitTime = 1.0f;

		private ContextMenuItem selectedItem;
		private State state;
		private ContextMenuID[] contextMenuIds = new ContextMenuID[] { ContextMenuID.UNDERGROUND_REST, ContextMenuID.UNDERGROUND_CANCEL };
		
		public override void OnTalkEvent()
		{
			base.OnTalkEvent();
			ChangeState(State.ChoicesMessage);
		}
		
		public override void OnUpdate(float deltaTime)
		{
			switch (state)
			{
				case State.BeginMessageWait:
				case State.EndMessageWait:
					if (UgFatherInput.Decide)
						MsgWindowManager.CloseMsg();
					break;

				case State.HealingFadOut:
					if (!Fader.isBusy)
                        ChangeState(State.HealingWait);
					break;

				case State.HealingWait:
					waitTime += deltaTime;
					if (waitTime >= HealingWaitTime)
                        ChangeState(State.HealingFadIn);
					break;

                case State.HealingFadIn:
                    if (!Fader.isBusy)
                        ChangeState(State.EndMessage);
                    break;
            }
		}
		
		private void ShowPcContextMenu()
		{
			var param = new ContextMenuWindow.Param();
			param.itemParams = new ContextMenuItem.Param[contextMenuIds.Length];

			for (int i = 0; i < contextMenuIds.Length; i++)
				param.itemParams[i] = new ContextMenuItem.Param { menuId = contextMenuIds[i] };

			param.position = new Vector2(1050.0f, 300.0f);
			param.pivot = new Vector2(1.0f, 1.0f);
			param.useLoopAndRepeat = false;

			var window = UIManager.Instance.CreateUIWindow<ContextMenuWindow>(UIWindowID.CONTEXTMENU);

			selectedItem = null;

			window.onClicked = item => selectedItem = item;
			window.onClosed = __ =>
			{
				if (selectedItem == null || selectedItem.param.menuId == ContextMenuID.UNDERGROUND_CANCEL)
				{
					MsgWindowManager.CloseMsg();
					EventEnd();
                }
				else if (selectedItem.param.menuId == ContextMenuID.UNDERGROUND_REST)
				{
					PlayerWork.playerParty.RecoverAll();
                    MsgWindowManager.CloseMsg();
                }

				selectedItem = null;
			};
        }
		
		private void ChangeState(State state)
		{
			this.state = state;

			switch (state)
			{
				case State.ChoicesMessage:
					UgFatherMessage.ShowHealingChoices(() => ShowPcContextMenu(), () =>
					{
						if (state == State.ChoicesMessage)
							ChangeState(State.BeginMessage);
					});
					break;

				case State.BeginMessage:
					UgFatherMessage.ShowHealingBegin(() => ChangeState(State.BeginMessageWait), () => ChangeState(State.HealingFadOut));
					break;

				case State.HealingFadOut:
                    Fader.FadeOut();
					break;

				case State.HealingWait:
					waitTime = 0.0f;
					break;

				case State.HealingFadIn:
					Fader.FadeIn();
					break;

				case State.EndMessage:
                    UgFatherMessage.ShowHealingEnd(() => ChangeState(State.EndMessageWait), () => EventEnd());
					break;
            }
		}
		
		private void EventEnd()
		{
			ChangeState(State.None);
			onEventEndCallback?.Invoke();
		}

		private enum State : int
		{
			None = 0,
			ChoicesMessage = 1,
			BeginMessage = 2,
			BeginMessageWait = 3,
			HealingFadOut = 4,
			HealingWait = 5,
			HealingFadIn = 6,
			EndMessage = 7,
			EndMessageWait = 8,
		}
	}
}