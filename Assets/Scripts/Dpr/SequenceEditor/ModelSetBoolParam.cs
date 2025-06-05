namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ModelSetBoolParam, "pink", "one_frame", "")]
	public class ModelSetBoolParam : Macro
	{
		public string materialName;
		public string paramName;
		public bool value;
		
		public ModelSetBoolParam(Macro macro) : base(macro)
        {
            materialName = ParseString(macro.GetValue("materialName"));
            paramName = ParseString(macro.GetValue("paramName"));
            value = ParseBool(macro.GetValue("vertical"), 0);
        }
    }
}