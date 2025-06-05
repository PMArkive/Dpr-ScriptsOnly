namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.EffStencilBufferEnable, "lightgreen", "one_frame", "")]
	public class EffStencilBufferEnable : Macro
	{
		public SEQ_STENCIL_TARGET trgNo1;
		public int grpNo1Start;
		public int grpNo1End;
		public SEQ_STENCIL_TARGET trgNo2;
		public int grpNo2Start;
		public int grpNo2End;
		public SEQ_STENCIL_TARGET trgNo3;
		public int grpNo3Start;
		public int grpNo3End;
		public SEQ_STENCIL_TARGET trgNo4;
		public int grpNo4Start;
		public int grpNo4End;
		
		public EffStencilBufferEnable(Macro macro) : base(macro)
        {
            trgNo1 = Parse_SEQ_STENCIL_TARGET(macro.GetValue("trgNo1"));
            grpNo1Start = ParseInt(macro.GetValue("grpNo1Start"), 0);
            grpNo1End = ParseInt(macro.GetValue("grpNo1End"), 0);
            trgNo2 = Parse_SEQ_STENCIL_TARGET(macro.GetValue("trgNo2"));
            grpNo2Start = ParseInt(macro.GetValue("grpNo2Start"), 0);
            grpNo2End = ParseInt(macro.GetValue("grpNo2End"), 0);
            trgNo3 = Parse_SEQ_STENCIL_TARGET(macro.GetValue("trgNo3"));
            grpNo3Start = ParseInt(macro.GetValue("grpNo3Start"), 0);
            grpNo3End = ParseInt(macro.GetValue("grpNo3End"), 0);
            trgNo4 = Parse_SEQ_STENCIL_TARGET(macro.GetValue("trgNo4"));
            grpNo4Start = ParseInt(macro.GetValue("grpNo4Start"), 0);
            grpNo4End = ParseInt(macro.GetValue("grpNo4End"), 0);
        }
    }
}