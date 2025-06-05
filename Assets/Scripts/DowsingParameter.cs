public static class DowsingParameter
{
	public const int AreaSizeX = 17;
	public const int AreaSizeY = 13;
	public const int AreaOfsX = -8;
	public const int AreaOfsY = -6;

	public static readonly int[,] SonarLevel = new int[,]
	{
		{ 1, 2, 2, 3, 3, },
		{ 2, 2, 2, 3, 3, },
		{ 2, 2, 3, 3, 0, },
		{ 3, 3, 3, 0, 0, },
		{ 3, 3, 0, 0, 0, },
	};
}