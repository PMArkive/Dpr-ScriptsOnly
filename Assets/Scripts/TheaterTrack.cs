using System;
using UnityEngine;

[Serializable]
public class TheaterTrack : ScriptableObject
{
	[SerializeField]
	public AnimationClip animationClip;
	[SerializeField]
	public string[] assetBundleNames;
	[SerializeField]
	public string cameraName;
	[SerializeField]
	public string targetName;
	[SerializeField]
	public ExtraData[] extraDatas;
	[SerializeField]
	public string[] eventNames;
	[SerializeField]
	public string[] bgTransfers;

	[Serializable]
	public class ExtraData
	{
		[SerializeField]
		public string assetBundleName;
		[SerializeField]
		public string[] instanceNames;
		
		public ExtraData(string assetBundleName, string[] instanceNames)
		{
			this.assetBundleName = assetBundleName;
			this.instanceNames = instanceNames;
		}
	}
}