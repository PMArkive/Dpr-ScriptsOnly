namespace Dpr.DigFossil
{
	public interface IDigAudioManager
	{
		void Initialize();

		void PlaySe(DigAudioManager.SeId id, float delay = 0.0f);

		void StopDelaySe(DigAudioManager.SeId id);

		void StopDelaySeAll();
	}
}