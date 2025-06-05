namespace Dpr.DigFossil
{
	public interface IDigCursor
	{
		DigCursor.OnClicked onClicked { get; set; }

		void OnUpdate();

		void SetTool(bool bIsPickaxe);

		void SetDisplay(bool bIsDisplay);

		void Initialize();

		void SetTouchMode(bool bIsTouchMode);
	}
}