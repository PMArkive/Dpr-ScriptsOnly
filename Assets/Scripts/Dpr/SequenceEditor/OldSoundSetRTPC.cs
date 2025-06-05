namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.OldSoundSetRTPC, "blue", "one_frame", "")]
	public class OldSoundSetRTPC : Macro
	{
		public string rtpc;
		public float value;
		public int intr;
		
		public OldSoundSetRTPC(Macro macro) : base(macro)
        {
            rtpc = ParseString(macro.GetValue("rtpc"));
            value = ParseFloat(macro.GetValue("value"));
            intr = ParseInt(macro.GetValue("intr"), 0);
        }
    }
}