using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ParticlCameraAutoRotate, "green", "", "")]
	public class ParticlCameraAutoRotate : Macro
	{
		public float length;
		public Vector3 ofs;
		public bool subCamera;
		
		public ParticlCameraAutoRotate(Macro macro) : base(macro)
        {
            length = ParseFloat(macro.GetValue("length"));
            ofs = ParseVector3(macro.GetValue("ofs"));
            subCamera = ParseBool(macro.GetValue("subCamera"), 0);
        }
    }
}