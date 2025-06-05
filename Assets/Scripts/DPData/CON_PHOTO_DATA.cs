using System;

namespace DPData
{
    [Serializable]
    public struct CON_PHOTO_DATA
    {
        public CON_PHOTO_FX_DATA[] fxDatas;
        public string nickname;
        public float camPositionX;
        public float camPositionY;
        public float camPositionZ;
        public float camRotX; 
        public float camRotY;
        public float camRotZ;
        public float pokePositionX;
        public float pokePositionY;
        public float pokePositionZ;
        public float pokeRotX;
        public float pokeRotY;
        public float pokeRotZ;
        public float pokeScaleX;
        public float pokeScaleY;
        public float pokeScaleZ;
        public float monitorPlayTime;
        public float motionPlayTime;
        public float dofDistance;
        public float dofFocalLength;
        public float dofFarDepth;
        public float dofTargetPosX;
        public float dofTargetPosY;
        public float dofTargetPosZ;
        public int monsNo;
        public int wazaNo;
        public int seqFrame;
        public byte seqType;
        public byte userRank;
        public byte rankID;
        public byte formNo;
        public byte sex;
        public byte motionIndex;
        public byte monitorIndex;
        public bool hasData;
        public bool rare;
    }
}