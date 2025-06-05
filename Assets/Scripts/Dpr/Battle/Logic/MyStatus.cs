﻿using DPData;
using Dpr.Message;
using Pml;
using Pml.PokePara;

namespace Dpr.Battle.Logic
{
    public class MyStatus
    {
        public string name;
        public bool sex;
        public MessageEnumData.MsgLangId lang;
        public uint id;
        public byte fashion;
        public byte body_type;
        public byte hat;
        public byte shoes;

        // TODO
        public void Deserialize(in MYSTATUS status) { }

        // TODO
        public void Deserialize(in MYSTATUS_COMM status) { }

        // TODO
        public void CopyFrom(MyStatus src) { }

        // TODO
        public string GetNameString() { return string.Empty; }

        // TODO
        public Sex GetSex() { return Sex.MALE; }

        // TODO
        public int GetHatVariation() { return 0; }

        // TODO
        public int GetShoesVariation() { return 0; }

        // TODO
        public MessageEnumData.MsgLangId GetPokeLanguageId() { return MessageEnumData.MsgLangId.JPN; }

        // TODO
        public bool IsMyPokemon(CoreParam poke) { return false; }

        // TODO
        public string GetModelID() { return string.Empty; }

        // TODO
        public int GetColorID() { return 0; }

        private Sex _sex { get => sex ? Sex.MALE : Sex.FEMALE; }

        // TODO
        public bool HasGBand() { return false; }

        // TODO
        public void SetCyclingRoad() { }

        // TODO
        public static void GetParamFromSysFlag(out byte hat, out byte shoes)
        {
            hat = 0;
            shoes = 0;
        }
    }
}
