namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SpecialObjectRenderVisible, "purple", "", "")]
	public class SpecialObjectRenderVisible : Macro
	{
		public SEQ_DEF_RENDERER_TYPE trgRender;
		public bool background;
		public bool fieldEff;
		public bool groundEff;
		
		public SpecialObjectRenderVisible(Macro macro) : base(macro)
        {
            trgRender = Parse_SEQ_DEF_RENDERER_TYPE(macro.GetValue("trgRender"));
            background = ParseBool(macro.GetValue("background"), 0);
            fieldEff = ParseBool(macro.GetValue("fieldEff"), 0);
            groundEff = ParseBool(macro.GetValue("groundEff"), 0);
        }
    }
}