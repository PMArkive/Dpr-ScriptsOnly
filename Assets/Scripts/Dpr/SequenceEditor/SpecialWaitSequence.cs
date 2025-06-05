namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SpecialWaitSequence, "purple", "one_frame", "")]
	public class SpecialWaitSequence : Macro
	{
		public SEQ_DEF_WAIT waitType;
		
		public SpecialWaitSequence(Macro macro) : base(macro)
        {
            waitType = Parse_SEQ_DEF_WAIT(macro.GetValue("waitType"));
        }
    }
}