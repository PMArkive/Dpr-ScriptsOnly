namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ModelSetFloatParam, "pink", "", "")]
	public class ModelSetFloatParam : Macro
	{
		public string materialName;
		public string paramName;
		public float value;
		
		public ModelSetFloatParam(Macro macro) : base(macro)
        {
            materialName = ParseString(macro.GetValue("materialName"));
            paramName = ParseString(macro.GetValue("paramName"));
            value = ParseFloat(macro.GetValue("value"));
        }
    }
}