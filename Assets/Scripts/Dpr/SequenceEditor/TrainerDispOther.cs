namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.TrainerDispOther, "lightyellow", "one_frame", "")]
	public class TrainerDispOther : Macro
	{
		public bool isDisp;
		
		public TrainerDispOther(Macro macro) : base(macro)
        {
            isDisp = ParseBool(macro.GetValue("isDisp"));
        }
    }
}