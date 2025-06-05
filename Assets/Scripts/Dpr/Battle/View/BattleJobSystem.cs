using System.Collections.Generic;

namespace Dpr.Battle.View
{
	public static class BattleJobSystem
	{
		private static HashSet<ITranslationObject> _translationObjects = new HashSet<ITranslationObject>();
		
		// TODO
		public static bool Add(ITranslationObject item) { return default; }
		
		// TODO
		public static bool Remove(ITranslationObject item) { return default; }
		
		// TODO
		public static void Clear() { }
		
		// TODO
		public static void OnUpdatePreJob(float deltaTime) { }
		
		// TODO
		public static void OnUpdatePostJob(float deltaTime) { }
	}
}