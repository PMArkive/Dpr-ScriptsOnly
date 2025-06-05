namespace Dpr.Battle.Logic
{
	public sealed class Section_MamoruSuccess : Section
	{
		public Section_MamoruSuccess(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }

		public class Description
		{
			public BTL_POKEPARAM attacker;
			public BTL_POKEPARAM target;
			public WazaParam wazaParam;
			
			public Description()
			{
				attacker = null;
				target = null;
				wazaParam = null;
			}
		}

		public class Result { }
	}
}