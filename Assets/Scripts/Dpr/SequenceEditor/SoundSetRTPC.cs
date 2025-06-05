namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SoundSetRTPC, "blue", "one_frame", "")]
	public class SoundSetRTPC : Macro
	{
		public string rtpc;
		public float value;
		public int intr;
		
		public SoundSetRTPC(Macro macro) : base(macro)
        {
            rtpc = ParseString(macro.GetValue("rtpc"));
            value = ParseFloat(macro.GetValue("value"));
            intr = ParseInt(macro.GetValue("intr"), 0);
        }
    }
}