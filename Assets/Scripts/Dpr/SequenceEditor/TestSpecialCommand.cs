using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.TestSpecialCommand, "Black", "", "")]
	public class TestSpecialCommand : Macro
	{
		public int valType;
		public int valInt;
		public Vector3 ValVec;

		public TestSpecialCommand(Macro macro) : base(macro)
        {
            valType = ParseInt(macro.GetValue("valType"));
            valInt = ParseInt(macro.GetValue("valInt"));
            ValVec = ParseVector3(macro.GetValue("ValVec"));
        }
    }
}