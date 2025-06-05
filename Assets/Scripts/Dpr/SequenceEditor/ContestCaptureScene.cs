namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ContestCaptureScene, "orange", "", "")]
	public class ContestCaptureScene : Macro
	{
		public int capturePersent;
		
		public ContestCaptureScene(Macro macro) : base(macro)
        {
            capturePersent = ParseInt(macro.GetValue("capturePersent"), 0);
        }
    }
}