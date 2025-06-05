namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.CameraRotatePos, "yellow", "", "")]
    public class CameraRotatePos : Macro
	{
		public int angle;
		public SEQ_DEF_MOVETYPE move;
		public bool isFlip;
		public SEQ_DEF_POS flipTrg;
		public SEQ_DEF_MOVETYPE moveOpt;
		public float targetDist;

		public CameraRotatePos(Macro macro) : base(macro)
        {
            angle = ParseInt(macro.GetValue("angle"));
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
            isFlip = ParseBool(macro.GetValue("isFlip"));
            flipTrg = Parse_SEQ_DEF_POS(macro.GetValue("flipTrg"));
            moveOpt = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("moveOpt"));
            targetDist = ParseFloat(macro.GetValue("targetDist"));
        }
    }
}