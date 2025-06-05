using Pml.PokePara;
using System;
using UnityEngine;

namespace DPData
{
    [Serializable]
    public struct UgSaveData
    {
        public int ReturnZoneID;
        public int ReturnGridPosX;
        public int ReturnPosY;
        public int ReturnGridPosZ;
        public LOCATION_WORK ReturnZenmetsu_Ground;
        public DigPos[] DigPoints;
        [SerializeField]
        public SerializedPokemonFull[] EncountPokes;
        [SerializeField]
        public Vector3[] EncountPokePositions;
        public int ReturnUgZoneID;
        public UGRecord ugRecord;
        public UgPlayerInfo[] FriendPlayerList;
        public UgPlayerInfo[] OtherPlayerList;
        public byte[] TalkedNPCsID;

        public Vector2Int ReturnLocator { get; }
        public float ReturnHeight { get; }

        // TODO
        public void ClearEncountPokes() { }
    }
}