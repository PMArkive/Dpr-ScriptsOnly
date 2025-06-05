using UnityEngine;

namespace Dpr.DigFossil
{
	public interface IDigBuildupViewManager
	{
		void Initialize(in int[,] map);

		Sprite GetSprite(int durability);

		void ApplyDurability(in int[,] map);
	}
}