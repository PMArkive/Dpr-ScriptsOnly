namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.CameraReset, "yellow", "", "")]
    public class CameraReset : Macro
	{
		public SEQ_DEF_MOVETYPE move;
		
		public CameraReset(Macro macro) : base(macro)
        {
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
        }
	}
}