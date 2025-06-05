namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.TrainerNameUI, "lightblue", "one_frame", "")]
	public class TrainerNameUI : Macro
	{
		public bool visible;
		public int value;
		
		public TrainerNameUI(Macro macro) : base(macro)
        {
            visible = ParseBool(macro.GetValue("visible"), 1);
            value = ParseInt(macro.GetValue("value"), 0);
        }
    }
}