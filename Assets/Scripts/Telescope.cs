using Pml;
using System.Collections.Generic;
using UnityEngine;

public class Telescope
{
	private static Vector2Int SafariPointOrigin = new Vector2Int(32, 32);
	private static Vector2Int[] SafariPoints = new Vector2Int[]
	{
        SafariPointOrigin + new Vector2Int(49, 5),
        SafariPointOrigin + new Vector2Int(53, 7),
        SafariPointOrigin + new Vector2Int(56, 7),
        SafariPointOrigin + new Vector2Int(26, 8),
        SafariPointOrigin + new Vector2Int(41, 8),
        SafariPointOrigin + new Vector2Int(11, 11),
        SafariPointOrigin + new Vector2Int(15, 11),
        SafariPointOrigin + new Vector2Int(18, 11),
        SafariPointOrigin + new Vector2Int(49, 12),
        SafariPointOrigin + new Vector2Int(15, 13),
        SafariPointOrigin + new Vector2Int(49, 16),
        SafariPointOrigin + new Vector2Int(9,  24),
        SafariPointOrigin + new Vector2Int(15, 36),
        SafariPointOrigin + new Vector2Int(51, 39),
        SafariPointOrigin + new Vector2Int(54, 39),
        SafariPointOrigin + new Vector2Int(15, 40),
        SafariPointOrigin + new Vector2Int(51, 41),
        SafariPointOrigin + new Vector2Int(55, 41),
        SafariPointOrigin + new Vector2Int(17, 45),
        SafariPointOrigin + new Vector2Int(13, 47),
        SafariPointOrigin + new Vector2Int(26, 50),
        SafariPointOrigin + new Vector2Int(41, 50),
        SafariPointOrigin + new Vector2Int(12, 59),
        SafariPointOrigin + new Vector2Int(60, 59),
        SafariPointOrigin + new Vector2Int(51, 67),
        SafariPointOrigin + new Vector2Int(55, 67),
        SafariPointOrigin + new Vector2Int(59, 70),
        SafariPointOrigin + new Vector2Int(8,  73),
        SafariPointOrigin + new Vector2Int(11, 75),
        SafariPointOrigin + new Vector2Int(14, 75),
        SafariPointOrigin + new Vector2Int(53, 70),
        SafariPointOrigin + new Vector2Int(26, 76),
        SafariPointOrigin + new Vector2Int(41, 76),
        SafariPointOrigin + new Vector2Int(11, 77),
        SafariPointOrigin + new Vector2Int(15, 77),
        SafariPointOrigin + new Vector2Int(52, 83),
    };

	private const int SafariPointLookCount = 5;

	private List<int> PointIndices = new List<int>(SafariPointLookCount);
	private int CurrentIndex;
	private int NextIndex;
	private Vector2Int EventPos;
	
	// TODO
	public void StartSafari(Vector2Int eventPos) { }
	
	// TODO
	public void GetCurrentMons(out MonsNo monsNo, out ushort formNo)
	{
		monsNo = MonsNo.NULL;
		formNo = 0;
	}
	
	// TODO
	public void JumpNext() { }
}