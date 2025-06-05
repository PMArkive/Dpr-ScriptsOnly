namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SpecialFesTrainerSetup, "purple", "one_frame", "")]
	public class SpecialFesTrainerSetup : Macro
	{
		public bool isDisp;
		
		public SpecialFesTrainerSetup(Macro macro) : base(macro)
        {
            isDisp = ParseBool(macro.GetValue("isDisp"), 1);
        }
    }
}