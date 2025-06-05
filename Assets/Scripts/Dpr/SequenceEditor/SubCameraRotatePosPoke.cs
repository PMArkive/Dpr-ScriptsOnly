namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SubCameraRotatePosPoke, "yellow", "", "")]
	public class SubCameraRotatePosPoke : Macro
	{
		public SEQ_DEF_POS posTrg;
		public SEQ_DEF_MOVETYPE move;
		
		public SubCameraRotatePosPoke(Macro macro) : base(macro)
        {
            posTrg = Parse_SEQ_DEF_POS(macro.GetValue("posTrg"));
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
        }
    }
}