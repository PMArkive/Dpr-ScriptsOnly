using DPData;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;

namespace Dpr.UI
{
	public abstract class PoketchAppBase : MonoBehaviour
	{
		[SerializeField]
		public PoketchButton[] Buttons;

		public POKETCH_APPID AppID { get; set; } = POKETCH_APPID.NONE;

        protected PoketchWindow _poketchInstance;
		protected bool isInitialized;

		public PoketchButton PreButton { get; set; }
		public PoketchWindow.TouchState PreState { get; set; }
		
		// TODO
		public void Initialize() { }

		protected abstract void OnInitialize();
		
		// TODO
		public void Uninitialize() { }
		
		// TODO
		protected virtual void OnUninitialize() { }
		
		// TODO
		public void Open(PoketchWindow poketch) { }

		protected abstract void OnOpen();
		
		// TODO
		public void Close() { }

		protected abstract void OnClose();
		
		// TODO
		public void OnUpdate(bool isAppControlEnable, [Optional] PoketchButton currentButton, PoketchWindow.TouchState currentState = PoketchWindow.TouchState.None) { }

		protected abstract void OnUpdateDraw();

		protected abstract void OnUpdateControl([Optional] [DefaultParameterValue(false)] bool isAppControlEnable, [Optional] PoketchButton targetButton, PoketchWindow.TouchState state = PoketchWindow.TouchState.None);
		
		// TODO
		public virtual void OnSizeChanged(bool isLarge) { }
		
		// TODO
		public virtual void OnAppChanged() { }
		
		// TODO
		public void ChangeSize([Optional] [DefaultParameterValue(false)] bool notReleaseUncontrol, [Optional] UnityAction callback) { }
		
		// TODO
		protected bool CloseWithPoketchBody() { return default; }
		
		// TODO
		protected void ResetButtons() { }
	}
}