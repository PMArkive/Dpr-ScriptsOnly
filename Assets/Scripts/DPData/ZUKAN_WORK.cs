using System;

namespace DPData
{
    [Serializable]
    public struct ZUKAN_WORK
    {
        public GET_STATUS[] get_status;
        public bool[] male_color_flag;
        public bool[] female_color_flag;
        public bool[] male_flag;
        public bool[] female_flag;
        public bool[] UnknownTurn;
        public bool[] UnknownColor;
        public bool[] PowarunTurn;
        public bool[] PowarunColor;
        public bool[] DeokisisuTurn;
        public bool[] DeokisisuColor;
        public bool[] MinomuttiTurn;
        public bool[] MinomuttiColor;
        public bool[] MinomadamTurn;
        public bool[] MinomadamColor;
        public bool[] GaameiruTurn;
        public bool[] GaameiruColor;
        public bool[] TherimuTurn;
        public bool[] TherimuColor;
        public bool[] KaranakusiTurn;
        public bool[] KaranakusiColor;
        public bool[] ToritodonTurn;
        public bool[] ToritodonColor;
        public bool[] RotomTurn;
        public bool[] RotomColor;
        public bool[] GirathinaTurn;
        public bool[] GirathinaColor;
        public bool[] SheimiTurn;
        public bool[] SheimiColor;
        public bool[] AruseusuTurn;
        public bool[] AruseusuColor;
        public int[] TextVersionUp;
        public bool zukan_get;
        public bool zenkoku_flag;
    }
}
