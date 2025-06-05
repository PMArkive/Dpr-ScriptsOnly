namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SubCameraResetFieldAll, "yellow", "", "")]
	public class SubCameraResetFieldAll : Macro
	{
		public SEQ_DEF_MOVETYPE move;
		
		public SubCameraResetFieldAll(Macro macro) : base(macro)
        {
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
        }
    }
}