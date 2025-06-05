namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.DprSetDOFSensorScale, "yellow", "", "")]
	public class DprSetDOFSensorScale : Macro
	{
		public float scale;
		public SEQ_DEF_MOVETYPE move;
		
		public DprSetDOFSensorScale(Macro macro) : base(macro)
        {
            scale = ParseFloat(macro.GetValue("scale"), 1.0f);
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
        }
    }
}