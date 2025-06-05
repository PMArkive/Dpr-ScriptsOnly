namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.CameraResetFieldAll, "yellow", "", "")]
    public class CameraResetFieldAll : Macro
	{
		public SEQ_DEF_MOVETYPE move;
		
		public CameraResetFieldAll(Macro macro): base(macro)
		{
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
        }
	}
}