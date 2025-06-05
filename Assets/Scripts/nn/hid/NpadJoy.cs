namespace nn.hid
{
	public static class NpadJoy
	{
		public static extern NpadJoyAssignmentMode GetAssignment(NpadId npadId);
		public static extern void SetAssignmentModeSingle(NpadId npadId);
		public static extern void SetAssignmentModeSingle(NpadId npadId, NpadJoyDeviceType deviceType);
		public static extern void SetAssignmentModeSingle(ref NpadId pOutValue, NpadId npadId, NpadJoyDeviceType deviceType);
		public static extern void SetAssignmentModeDual(NpadId npadId);
		public static extern Result MergeSingleAsDual(NpadId npadId1, NpadId npadId2);
		public static extern void SwapAssignment(NpadId npadId1, NpadId npadId2);
		public static extern void SetHoldType(NpadJoyHoldType holdType);
		public static extern NpadJoyHoldType GetHoldType();
		public static extern void StartLrAssignmentMode();
		public static extern void StopLrAssignmentMode();
		public static extern void SetHandheldActivationMode(NpadHandheldActivationMode activationMode);
		public static extern NpadHandheldActivationMode GetHandheldActivationMode();
		public static extern void SetCommunicationMode(NpadCommunicationMode mode);
		public static extern NpadCommunicationMode GetCommunicationMode();
		
		// TODO
		public static ErrorRange ResultDualConnected { get; }
		
		// TODO
		public static ErrorRange ResultSameJoyTypeConnected { get; }
	}
}