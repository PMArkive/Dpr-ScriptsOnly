namespace Dpr.Contest
{
	public interface IContestUIWindow
	{
		ContestMenuEventID ResultEventID { get; }
		
		bool IsOpen { get; }

		void SetTimeCount(string minutStr, string secondStr);

		void CloseWindow();
	}
}