namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ClusterSetRefrect, "orange", "one_frame", "")]
	public class ClusterSetRefrect : Macro
	{
		public float pos;
		public bool relative;
		public CLUSTER_POS_PLANE refDir;
		public CLUSTER_REFRECT refAct;
		public float brake;
		
		public ClusterSetRefrect(Macro macro) : base(macro)
        {
            pos = ParseFloat(macro.GetValue("pos"));
            relative = ParseBool(macro.GetValue("relative"));
            refDir = Parse_CLUSTER_POS_PLANE(macro.GetValue("refDir"));
            refAct = Parse_CLUSTER_REFRECT(macro.GetValue("refAct"));
            brake = ParseFloat(macro.GetValue("brake"), 1.0f);
        }
    }
}