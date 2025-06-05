public struct CancelModel
{
	public CancelReason reason;
	public int fromStationIndex;

	public enum CancelReason : int
	{
		SelectCancel = 0,
		Down = 1,
	}
}