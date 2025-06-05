namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ContestShowMsg, "orange", "one_frame", "")]
	public class ContestShowMsg : Macro
	{
		public string label;
		
		public ContestShowMsg(Macro macro) : base(macro)
        {
            label = ParseString(macro.GetValue("label"));
        }
    }
}