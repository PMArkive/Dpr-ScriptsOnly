using System;

namespace DPData
{
    [Serializable]
    public struct CON_PHOTO_LANG_DATA
    {
        public byte styleMonsLangID;
        public byte beautifulMonsLangID;
        public byte cuteMonsLangID;
        public byte cleverMonsLangID;
        public byte strongMonsLangID;
        public long reserved_long01;
        public long reserved_long02;
    }
}