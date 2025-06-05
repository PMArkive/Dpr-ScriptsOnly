namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ModelCreateGBall, "pink", "", "PreloadModelGBall")]
	public class ModelCreateGBall : Macro
	{
		public SEQ_DEF_DRAWTYPE drawType;
		public bool subCamera;
		public SEQ_DEF_TRAINER trgChara;
		public BALL_ANIME animeType;
		
		public ModelCreateGBall(Macro macro) : base(macro)
        {
            drawType = Parse_SEQ_DEF_DRAWTYPE(macro.GetValue("drawType"));
            subCamera = ParseBool(macro.GetValue("subCamera"), 0);
            trgChara = Parse_SEQ_DEF_TRAINER(macro.GetValue("trgChara"));
            animeType = Parse_BALL_ANIME(macro.GetValue("animeType"));
        }
    }
}