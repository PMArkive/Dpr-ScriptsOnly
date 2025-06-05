namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SpecialChainAttakDefine, "purple", "one_frame", "CheckSpecialChainAttakDefine")]
	public class SpecialChainAttakDefine : Macro
	{
		public int start1;
		public int end1;
		public int start2;
		public int end2;
		public int start3;
		public int end3;
		public int start4;
		public int end4;
		public int start5;
		public int end5;
		public int start6;
		public int end6;
		
		public SpecialChainAttakDefine(Macro macro) : base(macro)
        {
            start1 = ParseInt(macro.GetValue("start1"));
            end1 = ParseInt(macro.GetValue("end1"));
            start2 = ParseInt(macro.GetValue("start2"));
            end2 = ParseInt(macro.GetValue("end2"));
            start3 = ParseInt(macro.GetValue("start3"));
            end3 = ParseInt(macro.GetValue("end3"));
            start4 = ParseInt(macro.GetValue("start4"));
            end4 = ParseInt(macro.GetValue("end4"));
            start5 = ParseInt(macro.GetValue("start5"));
            end5 = ParseInt(macro.GetValue("end5"));
            start6 = ParseInt(macro.GetValue("start6"));
            end6 = ParseInt(macro.GetValue("end6"));
        }
    }
}