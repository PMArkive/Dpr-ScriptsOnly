namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ContestEmitBalloutFx, "orange", "", "")]
	public class ContestEmitBalloutFx : Macro
	{
		public int index;
		
		public ContestEmitBalloutFx(Macro macro) : base(macro)
        {
            index = ParseInt(macro.GetValue("index"), 0);
        }
    }
}