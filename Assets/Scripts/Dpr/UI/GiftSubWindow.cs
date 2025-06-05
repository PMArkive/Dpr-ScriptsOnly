using UnityEngine.Events;

namespace Dpr.UI
{
	public abstract class GiftSubWindow : UIWindow
	{
		// TODO
		public void Initialize(UnityAction<UIWindow> onClosedCallback) { }

		protected abstract void OnInitialize();

		public abstract void OnUpdate(float deltaTime);
		
		// TODO
		public virtual void Show() { }
		
		// TODO
		public virtual void Hide() { }
		
		// TODO
		protected void SetupKeyguide(KeyguideID[] keyguideIDs) { }
	}
}