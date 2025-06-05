namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SubCameraReset, "yellow", "", "")]
	public class SubCameraReset : Macro
	{
		public SEQ_DEF_MOVETYPE move;
		
		public SubCameraReset(Macro macro) : base(macro)
        {
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
        }
    }
}