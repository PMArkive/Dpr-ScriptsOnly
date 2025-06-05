namespace Dpr.DigFossil
{
	public interface IDigCameraShaker
	{
		void DoShake(float strength, float period);
		
		bool IsEnable { get; set; }
	}
}