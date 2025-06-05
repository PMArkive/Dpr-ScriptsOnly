namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.DispEffectSpEnvironmentLightDir, "lightgreen", "", "")]
	public class DispEffectSpEnvironmentLightDir : Macro
	{
		public bool isReset;
		public float pitch;
		public float yaw;
		public SEQ_DEF_MOVETYPE move;
		
		public DispEffectSpEnvironmentLightDir(Macro macro) : base(macro)
        {
            isReset = ParseBool(macro.GetValue("isReset"), 0);
            pitch = ParseFloat(macro.GetValue("pitch"));
            yaw = ParseFloat(macro.GetValue("yaw"));
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
        }
    }
}