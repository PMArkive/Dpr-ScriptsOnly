namespace Dpr.DigFossil
{
	public interface IDigToolsSwitch
	{
		void Initialize(IDigCursor cursor);

		void OnUpdate();
	}
}