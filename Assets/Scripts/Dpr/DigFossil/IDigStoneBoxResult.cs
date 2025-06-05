using System;
using System.Collections;

namespace Dpr.DigFossil
{
	public interface IDigStoneBoxResult
	{
		IEnumerator Initialize(DigStoneBoxResult.Context context);

		void Start(Action onFinishDirection);

		void OnUpdate();
	}
}