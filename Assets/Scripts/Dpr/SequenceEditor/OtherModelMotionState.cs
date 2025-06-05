namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.OtherModelMotionState, "violet", "one_frame", "")]
	public class OtherModelMotionState : Macro
	{
		public SEQ_DEF_POS trg;
		public string state;
		public bool reset;
		
		public OtherModelMotionState(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            state = ParseString(macro.GetValue("state"));
            reset = ParseBool(macro.GetValue("reset"), 0);
        }
    }
}