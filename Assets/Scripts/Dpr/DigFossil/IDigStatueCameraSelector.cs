using XLSXContent;

namespace Dpr.DigFossil
{
	public interface IDigStatueCameraSelector
	{
		void SetCamera(StatueEffectRawData.Sheettable data);

		void SetActive(bool isActive);

		void SwitchBoxCamera(bool isBox);
	}
}