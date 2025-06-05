namespace XLSXContent
{
	public static class ArenaInfoExtensionMethods
	{
		public static ArenaInfo.SheetArenaData GetArenaData(this ArenaInfo self, ArenaID arenaId)
		{
			return self.ArenaData[(int)arenaId];
		}
	}
}