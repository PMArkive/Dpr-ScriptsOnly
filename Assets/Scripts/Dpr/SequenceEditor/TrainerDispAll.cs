namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.TrainerDispAll, "lightyellow", "one_frame", "")]
	public class TrainerDispAll : Macro
	{
		public bool isDisp;
		
		public TrainerDispAll(Macro macro) : base(macro)
        {
            isDisp = ParseBool(macro.GetValue("isDisp"));
        }
    }
}