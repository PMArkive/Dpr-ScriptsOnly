using UnityEngine;

namespace Dpr.UI
{
	public class UITouchInputController
	{
		private const int MaxTouchCount = 10;

		private float longTouchTime;
		
		public TouchInfo[] Touches { get; set; }
		public int TouchCount { get; set; }
		
		public UITouchInputController(float longTouchTime = 1.0f)
		{
			this.longTouchTime = longTouchTime;
			TouchCount = 0;
			Touches = new TouchInfo[MaxTouchCount];

			for (int i=0; i<Touches.Length; i++)
				Touches[i] = new TouchInfo();
		}
		
		// TODO
		public void OnUpdate(float deltaTime) { }
		
		// TODO
		public TouchInfo GetNearestOriginPointTouch() { return default; }
		
		// TODO
		private void SetBeganTouch(int index, Vector2 pos, float deltaTime) { }
		
		// TODO
		private void SetStationaryTouch(int index, Vector2 pos, float deltaTime) { }
		
		// TODO
		private void SetMovedTouch(int index, Vector2 pos, float deltaTime) { }
		
		// TODO
		private void SetEndTouch(int index, Vector2 pos, float deltaTime) { }

		public class TouchInfo
		{
			public float TouchTime;
			public Vector2 StartPoint;
			public Vector2 Point;
			public TouchState State;

            public enum TouchState : int
            {
                Began = 0,
                Stationary = 1,
                Moved = 2,
                Touched = 3,
                LongTouched = 4,
                End = 5,
            }
        }
	}
}