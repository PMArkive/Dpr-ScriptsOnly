namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SpecialSetTimeZone, "purple", "", "")]
	public class SpecialSetTimeZone : Macro
	{
		public SEQ_DEF_TIME_ZONE timeZone;
		
		public SpecialSetTimeZone(Macro macro) : base(macro)
        {
            timeZone = Parse_SEQ_DEF_TIME_ZONE(macro.GetValue("timeZone"));
        }
    }
}