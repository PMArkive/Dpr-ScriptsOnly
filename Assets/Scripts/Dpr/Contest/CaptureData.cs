using UnityEngine;

namespace Dpr.Contest
{
	public sealed class CaptureData
	{
		public bool bAlreadyCapture;
		public ContestViewSystem viewSystemPtr;
		public Vector3 offsetPos;
		public int seqFrame;
		public uint userRank;
		public string monsNickName;
		public byte languageId;
		public int monsNo;
		public int wazaNo;
		public int formNo;
		public int sex;
		public bool rare;
		public int motionIndex;
		public float motionPlayTime;
		public Vector3 pokePosition;
		public Vector3 pokeEulerAngle;
		public Vector3 pokeScale;
		public Vector3 camPosition;
		public Vector3 camEulerAngle;
		public float dofDistance;
		public float dofFocalLength;
		public float dofFarDepth;
		public float dofTargetPosX;
		public float dofTargetPosY;
		public float dofTargetPosZ;
		public int monitorIndex;
		public float monitorPlayTime;
		public WazaEffectData[] wazaEffectDatas = new WazaEffectData[ContestDataConstants.MAX_PHOTO_FX_DATA_NUM];
	}
}