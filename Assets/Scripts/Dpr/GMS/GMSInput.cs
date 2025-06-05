using UnityEngine;

namespace Dpr.GMS
{
	public class GMSInput
	{
		public static GMSInput input;
		private GameController.LogicalInput localInput = new GameController.LogicalInput();
		
		// TODO
		public static void CreateInstance() { }
		
		// TODO
		public static void DestroyInstance() { }
		
		// TODO
		public void Subscribe() { }
		
		// TODO
		public void Remove() { }
		
		// TODO
		private void AssignKeyLeft() { }
		
		// TODO
		private void AssignKeyRight() { }
		
		// TODO
		private void AssignKeyUp() { }
		
		// TODO
		private void AssignKeyDown() { }
		
		// TODO
		private void AssignKeyDecide() { }
		
		// TODO
		private void AssignKeyCancel() { }
		
		// TODO
		private void AssignKeyFarCamera() { }
		
		// TODO
		private void AssignKeyNearCamera() { }
		
		// TODO
		private void AssignKeySpeed() { }
		
		// TODO
		private void AssignKeyPlayCry() { }
		
		// TODO
		public static bool RepeatLeft() { return default; }
		
		// TODO
		public static bool ReleaseLeft() { return default; }
		
		// TODO
		public static bool RepeatRight() { return default; }
		
		// TODO
		public static bool ReleaseRight() { return default; }
		
		// TODO
		public static bool RepeatUp() { return default; }
		
		// TODO
		public static bool ReleaseUp() { return default; }
		
		// TODO
		public static bool RepeatDown() { return default; }
		
		// TODO
		public static bool ReleaseDown() { return default; }
		
		// TODO
		public static bool PushDecide() { return default; }
		
		// TODO
		public static bool PushCancel() { return default; }
		
		// TODO
		public static bool PushFarCamera() { return default; }
		
		// TODO
		public static bool PushNearCamera() { return default; }
		
		// TODO
		public static bool OnSpeedUp() { return default; }
		
		// TODO
		public static bool IsPushPlayCry() { return default; }
		
		// TODO
		public static Vector2 Analog { get; }
		
		// TODO
		private bool IsPush(int assignValue) { return default; }
		
		// TODO
		private bool IsRepeat(int assignValue) { return default; }
		
		// TODO
		private bool IsRelease(int assignValue) { return default; }
		
		// TODO
		private bool IsOn(int assignValue) { return default; }

		private enum KeyAssignId : int
		{
			Left = 0,
			Right = 1,
			Up = 2,
			Down = 3,
			Decide = 4,
			Cancel = 5,
			FarCamera = 6,
			NearCamera = 7,
			SpeedUp = 8,
			PlayCry = 9,
		}

		private class KeyAssignIdValue
		{
			public const int Left = 1;
			public const int Right = 2;
			public const int Up = 4;
			public const int Down = 8;
			public const int Decide = 16;
			public const int Cancel = 32;
			public const int FarCamera = 64;
			public const int NearCamera = 128;
			public const int SpeedUp = 256;
			public const int PlayCry = 512;
		}
	}
}