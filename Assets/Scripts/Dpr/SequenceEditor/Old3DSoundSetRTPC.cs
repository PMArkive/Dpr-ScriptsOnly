namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.Old3DSoundSetRTPC, "blue", "one_frame", "")]
	public class Old3DSoundSetRTPC : Macro
	{
		public string rtpc;
		public float value;
		public int intr;
		
		public Old3DSoundSetRTPC(Macro macro) : base(macro)
        {
            rtpc = ParseString(macro.GetValue("rtpc"));
            value = ParseFloat(macro.GetValue("value"));
            intr = ParseInt(macro.GetValue("intr"), 0);
        }
    }
}