namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ContestModelCreateBall, "orange", "", "PreloadModelBall")]
	public class ContestModelCreateBall : Macro
	{
		public int index;
		public SEQ_DEF_TRAINER trgChara;
		public BALL_ANIME animeType;
		public SEQ_DEF_DRAWTYPE drawType;
		public bool subCamera;
		
		public ContestModelCreateBall(Macro macro) : base(macro)
        {
            index = ParseInt(macro.GetValue("index"));
            trgChara = Parse_SEQ_DEF_TRAINER(macro.GetValue("trgChara"));
            animeType = Parse_BALL_ANIME(macro.GetValue("animeType"));
            drawType = Parse_SEQ_DEF_DRAWTYPE(macro.GetValue("drawType"));
            subCamera = ParseBool(macro.GetValue("subCamera"), 0);
        }
    }
}