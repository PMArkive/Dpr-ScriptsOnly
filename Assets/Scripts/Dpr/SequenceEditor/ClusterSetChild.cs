namespace Dpr.SequenceEditor
{
	[Macro(CommandNo.ClusterSetChild, "orange", "one_frame", "")]
	public class ClusterSetChild : Macro
	{
		public int parent;
		public CLUSTER_CHILD type;
		public bool follow;

		public ClusterSetChild(Macro macro) : base(macro)
		{
            parent = ParseInt(macro.GetValue("parent"));
            type = Parse_CLUSTER_CHILD(macro.GetValue("type"));
            follow = ParseBool(macro.GetValue("follow"));
		}
	}
}