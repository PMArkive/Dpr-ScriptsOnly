namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.EffDepthOfFieldSet, "lightgreen", "", "")]
	public class EffDepthOfFieldSet : Macro
	{
		public bool autoFocus;
		public float fNum;
		public float focusDistance;
		public SEQ_DEF_MOVETYPE move;
		public bool subCamera;
		
		public EffDepthOfFieldSet(Macro macro) : base(macro)
        {
            autoFocus = ParseBool(macro.GetValue("autoFocus"), 0);
            fNum = ParseFloat(macro.GetValue("fNum"), 2.0f);
            focusDistance = ParseFloat(macro.GetValue("focusDistance"), 100.0f);
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
            subCamera = ParseBool(macro.GetValue("subCamera"), 0);
        }
    }
}