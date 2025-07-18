namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SubCameraTwist, "yellow", "", "")]
	public class SubCameraTwist : Macro
	{
		public float twist;
		public bool relative;
		public bool isFlip;
		public SEQ_DEF_POS flipTrg;
		public SEQ_DEF_MOVETYPE move;

		public SubCameraTwist(Macro macro) : base(macro)
        {
            twist = ParseFloat(macro.GetValue("twist"));
            relative = ParseBool(macro.GetValue("relative"));
            isFlip = ParseBool(macro.GetValue("isFlip"), 1);
            flipTrg = Parse_SEQ_DEF_POS(macro.GetValue("flipTrg"));
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
        }
    }
}