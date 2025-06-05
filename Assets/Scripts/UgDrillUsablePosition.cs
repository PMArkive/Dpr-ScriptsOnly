using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UgDrillUsablePosition
{
	public ZoneID zoneID;
	public List<Vector2Int> AllGrids = new List<Vector2Int>();
	public List<Vector2Int> UseGrids = new List<Vector2Int>();
}