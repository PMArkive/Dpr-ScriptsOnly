namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ContestShowIntroductionMsg, "orange", "one_frame", "")]
	public class ContestShowIntroductionMsg : Macro
	{
		public string label;
		public int index;
		
		public ContestShowIntroductionMsg(Macro macro) : base(macro)
        {
            label = ParseString(macro.GetValue("label"));
            index = ParseInt(macro.GetValue("index"), 0);
        }
    }
}