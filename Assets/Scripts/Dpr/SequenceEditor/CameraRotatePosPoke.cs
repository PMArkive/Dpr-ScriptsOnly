namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.CameraRotatePosPoke, "yellow", "", "")]
    public class CameraRotatePosPoke : Macro
	{
		public SEQ_DEF_POS posTrg;
		public SEQ_DEF_MOVETYPE move;

		public CameraRotatePosPoke(Macro macro) : base(macro)
        {
            posTrg = Parse_SEQ_DEF_POS(macro.GetValue("posTrg"));
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
        }
    }
}