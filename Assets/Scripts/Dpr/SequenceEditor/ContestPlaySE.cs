namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ContestPlaySE, "orange", "", "")]
	public class ContestPlaySE : Macro
	{
		public int seID;
		
		public ContestPlaySE(Macro macro) : base(macro)
        {
            seID = ParseInt(macro.GetValue("seID"), 0);
        }
    }
}