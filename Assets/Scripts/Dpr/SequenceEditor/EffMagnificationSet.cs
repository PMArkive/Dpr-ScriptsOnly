namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.EffMagnificationSet, "lightgreen", "", "")]
	public class EffMagnificationSet : Macro
	{
		public float disperX;
		public float disperY;
		public SEQ_DEF_MOVETYPE move;
		public bool subCamera;
		
		public EffMagnificationSet(Macro macro) : base(macro)
        {
            disperX = ParseFloat(macro.GetValue("disperX"));
            disperY = ParseFloat(macro.GetValue("disperY"));
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
            subCamera = ParseBool(macro.GetValue("subCamera"), 0);
        }
    }
}