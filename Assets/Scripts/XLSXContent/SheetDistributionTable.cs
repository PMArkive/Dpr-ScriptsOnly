using System;
using System.Collections.Generic;

namespace XLSXContent
{
    [Serializable]
    public class SheetDistributionTable
    {
        public int[] BeforeMorning;
        public int[] BeforeDaytime;
        public int[] BeforeNight;
        public int[] AfterMorning;
        public int[] AfterDaytime;
        public int[] AfterNight;
        public int[] Fishing;
        public int[] PokemonTraser;
        public int[] HoneyTree;

        // TODO
        public List<int> GetMapIds(TimeZoneType timeZone, bool isZukanZenkoku) { return null; }

        // TODO
        public List<int> GetSpecialMapIds(SpecialType type) { return null; }

        public enum HabitatType : int
        {
            Field = 0,
            Dungeon = 1,
            Num = 2,
        }

        public enum TimeZoneType : int
        {
            Morning = 0,
            Daytime = 1,
            Night = 2,
            Num = 3,
        }

        public enum SpecialType : int
        {
            Fishing = 0,
            PokemonTraser = 1,
            HoneyTree = 2,
            Num = 3,
        }
    }
}