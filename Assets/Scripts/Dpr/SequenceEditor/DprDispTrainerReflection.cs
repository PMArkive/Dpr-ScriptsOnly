namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.DprDispTrainerReflection, "lightgreen", "one_frame", "")]
	public class DprDispTrainerReflection : Macro
	{
		public bool isDisp;
		
		public DprDispTrainerReflection(Macro macro) : base(macro)
        {
            isDisp = ParseBool(macro.GetValue("isDisp"), 0);
        }
    }
}