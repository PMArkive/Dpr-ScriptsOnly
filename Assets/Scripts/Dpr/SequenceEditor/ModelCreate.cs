namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ModelCreate, "pink", "", "PreloadModel")]
	public class ModelCreate : Macro
	{
		public string file;
		public bool isMulti;
		public SEQ_DEF_DRAWTYPE drawType;
		public SEQ_DEF_ROTATE_ORDER rotOrder;
		public bool castShadow;
		public bool subCamera;
		
		public ModelCreate(Macro macro) : base(macro)
        {
            file = ParseString(macro.GetValue("file"));
            isMulti = ParseBool(macro.GetValue("isMulti"), 0);
            drawType = Parse_SEQ_DEF_DRAWTYPE(macro.GetValue("drawType"));
            rotOrder = Parse_SEQ_DEF_ROTATE_ORDER(macro.GetValue("rotOrder"));
            castShadow = ParseBool(macro.GetValue("castShadow"), 0);
            subCamera = ParseBool(macro.GetValue("subCamera"), 0);
        }
    }
}