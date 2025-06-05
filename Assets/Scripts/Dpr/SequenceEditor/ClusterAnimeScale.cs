using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ClusterAnimeScale, "orange", "one_frame", "")]
    public class ClusterAnimeScale : Macro
	{
		public int frame1;
		public Vector3 scale1;
		public int frame2;
		public Vector3 scale2;
		public int frame3;
		public Vector3 scale3;
		public int frame4;
		public Vector3 scale4;
		public int frame5;
		public Vector3 scale5;
		
		public ClusterAnimeScale(Macro macro) : base(macro)
        {
            frame1 = ParseInt(macro.GetValue("frame1"));
            scale1 = ParseVector3(macro.GetValue("scale1"), 1.0f, 1.0f, 1.0f);
            frame2 = ParseInt(macro.GetValue("frame2"));
            scale2 = ParseVector3(macro.GetValue("scale2"), 1.0f, 1.0f, 1.0f);
            frame3 = ParseInt(macro.GetValue("frame3"));
            scale3 = ParseVector3(macro.GetValue("scale3"), 1.0f, 1.0f, 1.0f);
            frame4 = ParseInt(macro.GetValue("frame4"));
            scale4 = ParseVector3(macro.GetValue("scale4"), 1.0f, 1.0f, 1.0f);
            frame5 = ParseInt(macro.GetValue("frame5"));
            scale5 = ParseVector3(macro.GetValue("scale5"), 1.0f, 1.0f, 1.0f);
        }
    }
}