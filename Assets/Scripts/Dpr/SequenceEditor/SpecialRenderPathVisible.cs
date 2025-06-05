namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SpecialRenderPathVisible, "purple", "", "")]
	public class SpecialRenderPathVisible : Macro
	{
		public SEQ_DEF_RENDERER_TYPE trgRender;
		public bool shadowPath;
		public bool yedis;
		public bool zprePath;
		
		public SpecialRenderPathVisible(Macro macro) : base(macro)
        {
            trgRender = Parse_SEQ_DEF_RENDERER_TYPE(macro.GetValue("trgRender"));
            shadowPath = ParseBool(macro.GetValue("shadowPath"), 0);
            yedis = ParseBool(macro.GetValue("yedis"), 0);
            zprePath = ParseBool(macro.GetValue("zprePath"), 0);
        }
    }
}