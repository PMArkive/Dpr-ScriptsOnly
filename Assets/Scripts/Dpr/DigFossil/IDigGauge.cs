namespace Dpr.DigFossil
{
	public interface IDigGauge
	{
		void Initialize(float gaugeMax);

		void SetGauge(float gaugeValue);
	}
}