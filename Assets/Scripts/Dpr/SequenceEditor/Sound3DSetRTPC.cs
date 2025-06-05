namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.Sound3DSetRTPC, "blue", "one_frame", "")]
	public class Sound3DSetRTPC : Macro
	{
		public string rtpc;
		public float value;
		public int intr;
		
		public Sound3DSetRTPC(Macro macro) : base(macro)
        {
            rtpc = ParseString(macro.GetValue("rtpc"));
            value = ParseFloat(macro.GetValue("value"));
            intr = ParseInt(macro.GetValue("intr"), 0);
        }
    }
}