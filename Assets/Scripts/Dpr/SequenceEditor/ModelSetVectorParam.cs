using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ModelSetVectorParam, "pink", "", "")]
	public class ModelSetVectorParam : Macro
	{
		public string materialName;
		public string paramName;
		public Vector3 value;
		
		public ModelSetVectorParam(Macro macro) : base(macro)
        {
            materialName = ParseString(macro.GetValue("materialName"));
            paramName = ParseString(macro.GetValue("paramName"));
            value = ParseVector3(macro.GetValue("value"));
        }
    }
}