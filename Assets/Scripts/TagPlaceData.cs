using System;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/field/TagPlaceData", fileName = "TagPlaceData")]
public class TagPlaceData : ScriptableObject
{
	public TagData[] data;

	[Serializable]
	public class TagData
	{
		public string ID;
		public string ParentID;
		public int TagType;
	}
}