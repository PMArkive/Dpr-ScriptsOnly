using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

namespace Dpr.DigFossil
{
	public class DigBuildupViewManager : MonoBehaviour, IDigBuildupViewManager
	{
		[SerializeField]
		private GameObject buildupPrefab;
		[SerializeField]
		private List<Sprite> sprites;
		[SerializeField]
		private SpriteAtlas atlas;
		private IDigBuildup[,] buildups;

		private const int BUILDUP_DURABILITY_BOUNDARY = 3;
		
		// TODO
		public void Initialize(in int[,] map) { }
		
		// TODO
		public Sprite GetSprite(int durability) { return default; }
		
		// TODO
		public void ApplyDurability(in int[,] inMap) { }
		
		// TODO
		public void GetTexture(in int[,] inMap, int x, int y, out Sprite outMain, out Sprite outTop, out Sprite outUnder, out Sprite outTopCorner, out Sprite outUnderCorner)
		{
			outMain = default;
			outTop = default;
			outUnder = default;
			outTopCorner = default;
			outUnderCorner = default;
		}
		
		// TODO
		private bool IsCheckUnderBuildup(int durability) { return default; }
		
		// TODO
		private bool IsCheckTopBuildup(int durability) { return default; }
		
		public DigBuildupViewManager()
		{
			// Empty, explicitely declared
		}
		
		void IDigBuildupViewManager.Initialize(in int[,] map) => Initialize(map);

		void IDigBuildupViewManager.ApplyDurability(in int[,] map) => ApplyDurability(map);

		private static class Bit
		{
			private const int BUILDUP_TOP_BIT = 0x1;
			private const int BUILDUP_UNDER_BIT = 0x10;
			private const int BUILDUP_TOP_CORNER_BIT = 0x100;
			private const int BUILDUP_UNDER_CORNER_BIT = 0x1000;

			private const int SHIFT_LEFT = 0;
			private const int SHIFT_RIGHT = 1;
			private const int SHIFT_UP = 2;
			private const int SHIFT_DOWN = 3;

			private const int SHIFT_LEFT_UP = 0;
			private const int SHIFT_LEFT_DOWN = 1;
			private const int SHIFT_RIGHT_UP = 2;
			private const int SHIFT_RIGHT_DOWN = 3;
			
			public static uint Top { get => TopLeft | TopRight | TopUp | TopDown; }
			public static uint TopLeft { get => BUILDUP_TOP_BIT << SHIFT_LEFT; }
			public static uint TopRight { get => BUILDUP_TOP_BIT << SHIFT_RIGHT; }
			public static uint TopUp { get => BUILDUP_TOP_BIT << SHIFT_UP; }
			public static uint TopDown { get => BUILDUP_TOP_BIT << SHIFT_DOWN; }
			
			public static uint Under { get => UnderLeft | UnderRight | UnderUp | UnderDown; }
            public static uint UnderLeft { get => BUILDUP_UNDER_BIT << SHIFT_LEFT; }
			public static uint UnderRight { get => BUILDUP_UNDER_BIT << SHIFT_RIGHT; }
            public static uint UnderUp { get => BUILDUP_UNDER_BIT << SHIFT_UP; }
            public static uint UnderDown { get => BUILDUP_UNDER_BIT << SHIFT_DOWN; }

            public static uint TopCorner { get => TopCornerLeftUp | TopCornerLeftDown | TopCornerRightUp | TopCornerRightDown; }
            public static uint TopCornerLeftUp { get => BUILDUP_TOP_CORNER_BIT << SHIFT_LEFT_UP; }
			public static uint TopCornerLeftDown { get => BUILDUP_TOP_CORNER_BIT << SHIFT_LEFT_DOWN; }
            public static uint TopCornerRightUp { get => BUILDUP_TOP_CORNER_BIT << SHIFT_RIGHT_UP; }
            public static uint TopCornerRightDown { get => BUILDUP_TOP_CORNER_BIT << SHIFT_RIGHT_DOWN; }

            public static uint UnderCorner { get => UnderCornerLeftUp | UnderCornerLeftDown | UnderCornerRightUp | UnderCornerRightDown; }
            public static uint UnderCornerLeftUp { get => BUILDUP_UNDER_CORNER_BIT << SHIFT_LEFT_UP; }
            public static uint UnderCornerLeftDown { get => BUILDUP_UNDER_CORNER_BIT << SHIFT_LEFT_DOWN; }
            public static uint UnderCornerRightUp { get => BUILDUP_UNDER_CORNER_BIT << SHIFT_RIGHT_UP; }
            public static uint UnderCornerRightDown { get => BUILDUP_UNDER_CORNER_BIT << SHIFT_RIGHT_DOWN; }

            public static uint TopLeftUp { get => TopLeft | TopUp; }
			public static uint TopLeftDown { get => TopLeft | TopDown; }
            public static uint TopRightUp { get => TopRight | TopUp; }
            public static uint TopRightDown { get => TopRight | TopDown; }

            public static uint UnderLeftUp { get => UnderLeft | UnderUp; }
            public static uint UnderLeftDown { get => UnderLeft | UnderDown; }
            public static uint UnderRightUp { get => UnderRight | UnderUp; }
            public static uint UnderRightDown { get => UnderRight | UnderDown; }
        }
	}
}