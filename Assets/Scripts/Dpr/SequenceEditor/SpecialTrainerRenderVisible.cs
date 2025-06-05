namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SpecialTrainerRenderVisible, "purple", "", "")]
	public class SpecialTrainerRenderVisible : Macro
	{
		public SEQ_DEF_RENDERER_TYPE trgRender;
		public SEQ_DEF_TRAINER_ADD trgTra;
		public bool model;
		public bool shadow;
		
		public SpecialTrainerRenderVisible(Macro macro) : base(macro)
        {
            trgRender = Parse_SEQ_DEF_RENDERER_TYPE(macro.GetValue("trgRender"));
            trgTra = Parse_SEQ_DEF_TRAINER_ADD(macro.GetValue("trgTra"));
            model = ParseBool(macro.GetValue("model"), 0);
            shadow = ParseBool(macro.GetValue("shadow"), 0);
        }
    }
}