namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ClusterSetSpawnTime, "orange", "one_frame", "")]
	public class ClusterSetSpawnTime : Macro
	{
		public int spawnTime;
		
		public ClusterSetSpawnTime(Macro macro) : base(macro)
        {
            spawnTime = ParseInt(macro.GetValue("spawnTime"));
        }
    }
}