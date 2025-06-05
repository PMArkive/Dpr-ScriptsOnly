using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SoundBelugaAutoCameraRotate, "blue", "", "")]
	public class SoundBelugaAutoCameraRotate : Macro
	{
		public float length;
		public Vector3 ofs;
		
		public SoundBelugaAutoCameraRotate(Macro macro) : base(macro)
        {
            length = ParseFloat(macro.GetValue("length"));
            ofs = ParseVector3(macro.GetValue("ofs"));
        }
    }
}