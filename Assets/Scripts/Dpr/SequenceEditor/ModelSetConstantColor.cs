using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ModelSetConstantColor, "pink", "", "")]
	public class ModelSetConstantColor : Macro
	{
		public string matName;
		public int colNo;
		public Vector3 col;
		public float alpha;
		
		public ModelSetConstantColor(Macro macro) : base(macro)
        {
            matName = ParseString(macro.GetValue("matName"));
            colNo = ParseInt(macro.GetValue("colNo"));
            col = ParseVector3(macro.GetValue("col"));
            alpha = ParseFloat(macro.GetValue("alpha"), 1.0f);
        }
    }
}