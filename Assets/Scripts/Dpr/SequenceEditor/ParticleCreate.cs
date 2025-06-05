namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ParticleCreate, "green", "", "PreloadParticle")]
	public class ParticleCreate : Macro
	{
		public string file;
		public bool isBallEffect;
		public bool isCapture;
		public bool isStreamLineEffect;
		public bool isAttrEffect;
		public int index;
		public bool isMulti;
		public SEQ_DEF_EFF_DRAWTYPE drawType;
		public SEQ_DEF_ROTATE_ORDER rotOrder;
		public int forceCalc;
		public bool subCamera;
		public SEQ_DEF_PARTICLE_DELETE deleteType;
		
		public ParticleCreate(Macro macro) : base(macro)
        {
            file = ParseString(macro.GetValue("file"));
            isBallEffect = ParseBool(macro.GetValue("isBallEffect"), 0);
            isCapture = ParseBool(macro.GetValue("isCapture"), 0);
            isStreamLineEffect = ParseBool(macro.GetValue("isStreamLineEffect"), 0);
            isAttrEffect = ParseBool(macro.GetValue("isAttrEffect"), 0);
            index = ParseInt(macro.GetValue("index"));
            isMulti = ParseBool(macro.GetValue("isMulti"), 0);
            drawType = Parse_SEQ_DEF_EFF_DRAWTYPE(macro.GetValue("drawType"));
            rotOrder = Parse_SEQ_DEF_ROTATE_ORDER(macro.GetValue("rotOrder"));
            forceCalc = ParseInt(macro.GetValue("forceCalc"));
            subCamera = ParseBool(macro.GetValue("subCamera"), 0);
            deleteType = (SEQ_DEF_PARTICLE_DELETE)ParseInt(macro.GetValue("deleteType"), 0);
        }
    }
}