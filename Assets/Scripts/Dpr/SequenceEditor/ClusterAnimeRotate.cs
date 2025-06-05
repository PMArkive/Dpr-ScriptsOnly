using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ClusterAnimeRotate, "orange", "one_frame", "")]
    public class ClusterAnimeRotate : Macro
	{
		public int frame1;
		public Vector3 rotate1;
		public int frame2;
		public Vector3 rotate2;
		public int frame3;
		public Vector3 rotate3;
		public int frame4;
		public Vector3 rotate4;
		public int frame5;
		public Vector3 rotate5;
		
		public ClusterAnimeRotate(Macro macro) : base(macro)
        {
            frame1 = ParseInt(macro.GetValue("frame1"));
            rotate1 = ParseVector3(macro.GetValue("rotate1"));
            frame2 = ParseInt(macro.GetValue("frame2"));
            rotate2 = ParseVector3(macro.GetValue("rotate2"));
            frame3 = ParseInt(macro.GetValue("frame3"));
            rotate3 = ParseVector3(macro.GetValue("rotate3"));
            frame4 = ParseInt(macro.GetValue("frame4"));
            rotate4 = ParseVector3(macro.GetValue("rotate4"));
            frame5 = ParseInt(macro.GetValue("frame5"));
            rotate5 = ParseVector3(macro.GetValue("rotate5"));
        }
    }
}