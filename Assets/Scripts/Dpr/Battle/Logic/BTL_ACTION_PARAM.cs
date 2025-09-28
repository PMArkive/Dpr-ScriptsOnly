namespace Dpr.Battle.Logic
{
    public struct BTL_ACTION_PARAM
    {
        public long raw;

        private const int gen_sz0 = 4;
        private const int gen_loc0 = 0;
        private const int gen_sz1 = 5;
        private const int gen_loc1 = 4;
        private const int gen_sz2 = 55;
        private const int gen_loc2 = 9;
        private const long gen_mask0 =                                                                                            0b1111;
        private const long gen_mask1 =                                                                                  0b0001_1111_0000;
        private const long gen_mask2 = unchecked((long)0b1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1110_0000_0000);

        private const int fight_sz0 = 4;
        private const int fight_loc0 = 0;
        private const int fight_sz1 = 5;
        private const int fight_loc1 = 4;
        private const int fight_sz2 = 4;
        private const int fight_loc2 = 9;
        private const int fight_sz3 = 16;
        private const int fight_loc3 = 13;
        private const int fight_sz4 = 1;
        private const int fight_loc4 = 29;
        private const int fight_sz5 = 1;
        private const int fight_loc5 = 30;
        private const int fight_sz6 = 1;
        private const int fight_loc6 = 31;
        private const int fight_sz7 = 1;
        private const int fight_loc7 = 32;
        private const int fight_sz8 = 1;
        private const int fight_loc8 = 33;
        private const long fight_mask0 =                                         0b1111;
        private const long fight_mask1 =                               0b0001_1111_0000;
        private const long fight_mask2 =                          0b0001_1110_0000_0000;
        private const long fight_mask3 =      0b0001_1111_1111_1111_1110_0000_0000_0000;
        private const long fight_mask4 =      0b0010_0000_0000_0000_0000_0000_0000_0000;
        private const long fight_mask5 =      0b0100_0000_0000_0000_0000_0000_0000_0000;
        private const long fight_mask6 =      0b1000_0000_0000_0000_0000_0000_0000_0000;
        private const long fight_mask7 = 0b0001_0000_0000_0000_0000_0000_0000_0000_0000;
        private const long fight_mask8 = 0b0010_0000_0000_0000_0000_0000_0000_0000_0000;

        private const int item_sz0 = 4;
        private const int item_loc0 = 0;
        private const int item_sz1 = 5;
        private const int item_loc1 = 4;
        private const int item_sz2 = 8;
        private const int item_loc2 = 9;
        private const int item_sz3 = 16;
        private const int item_loc3 = 17;
        private const int item_sz4 = 8;
        private const int item_loc4 = 33;
        private const long item_mask0 =                                                   0b1111;
        private const long item_mask1 =                                         0b0001_1111_0000;
        private const long item_mask2 =                                    0b0001_1111_1111_0000;
        private const long item_mask3 =           0b0001_1111_1111_1111_1110_0000_0000_0000_0000;
        private const long item_mask4 = 0b0001_1111_1110_0000_0000_0000_0000_0000_0000_0000_0000;

        private const int change_sz0 = 4;
        private const int change_loc0 = 0;
        private const int change_sz1 = 5;
        private const int change_loc1 = 4;
        private const int change_sz2 = 3;
        private const int change_loc2 = 9;
        private const int change_sz3 = 3;
        private const int change_loc3 = 12;
        private const int change_sz4 = 1;
        private const int change_loc4 = 15;
        private const long change_mask0 =                0b1111;
        private const long change_mask1 =      0b0001_1111_0000;
        private const long change_mask2 =      0b1110_0000_0000;
        private const long change_mask3 = 0b0111_0000_0000_0000;
        private const long change_mask4 = 0b1000_0000_0000_0000;

        private const int escape_sz0 = 4;
        private const int escape_loc0 = 0;
        private const int escape_sz1 = 5;
        private const int escape_loc1 = 4;
        private const long escape_mask0 =           0b1111;
        private const long escape_mask1 = 0b0001_1111_0000;

        private const int g_start_sz0 = 4;
        private const int g_start_loc0 = 0;
        private const int g_start_sz1 = 5;
        private const int g_start_loc1 = 4;
        private const long g_start_mask0 =           0b1111;
        private const long g_start_mask1 = 0b0001_1111_0000;

        private const int cheer_sz0 = 4;
        private const int cheer_loc0 = 0;
        private const int cheer_sz1 = 5;
        private const int cheer_loc1 = 4;
        private const long cheer_mask0 =           0b1111;
        private const long cheer_mask1 = 0b0001_1111_0000;

        /// <summary>Location 0<br/>Size 4<br/>Mask 0x000F (0b1111)</summary>
        public byte gen_cmd { get => (byte)((raw & gen_mask0) >> gen_loc0); set => raw = raw & ~gen_mask0 | ((value & (gen_mask0 >> gen_loc0)) << gen_loc0); }
        /// <summary>Location 4<br/>Size 5<br/>Mask 0x01F0 (0b0001_1111_0000)</summary>
        public byte gen_pokeID { get => (byte)((raw & gen_mask1) >> gen_loc1); set => raw = raw & ~gen_mask1 | ((value & (gen_mask1 >> gen_loc1)) << gen_loc1); }
        /// <summary>Location 9<br/>Size 55<br/>Mask 0xFFFF_FFFF_FFFF_FE00 (0b1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1110_0000_0000)</summary>
        public ulong gen_param { get => (ulong)((raw & gen_mask2) >> gen_loc2); set => raw = raw & ~gen_mask2 | ((unchecked((long)value) & (gen_mask2 >> gen_loc2)) << gen_loc2); }

        /// <summary>Location 0<br/>Size 4<br/>Mask 0x000F (0b1111)</summary>
        public byte fight_cmd { get => (byte)((raw & fight_mask0) >> fight_loc0); set => raw = raw & ~fight_mask0 | ((value & (fight_mask0 >> fight_loc0)) << fight_loc0); }
        /// <summary>Location 4<br/>Size 5<br/>Mask 0x01F0 (0b0001_1111_0000)</summary>
        public byte fight_pokeID { get => (byte)((raw & fight_mask1) >> fight_loc1); set => raw = raw & ~fight_mask1 | ((value & (fight_mask1 >> fight_loc1)) << fight_loc1); }
        /// <summary>Location 9<br/>Size 4<br/>Mask 0x1E00 (0b0001_1110_0000_0000)</summary>
        public byte fight_targetPos { get => (byte)((raw & fight_mask2) >> fight_loc2); set => raw = raw & ~fight_mask2 | ((value & (fight_mask2 >> fight_loc2)) << fight_loc2); }
        /// <summary>Location 13<br/>Size 16<br/>Mask 0x1FFF_E000 (0b0001_1111_1111_1111_1110_0000_0000_0000)</summary>
        public ushort fight_waza { get => (ushort)((raw & fight_mask3) >> fight_loc3); set => raw = raw & ~fight_mask3 | ((value & (fight_mask3 >> fight_loc3)) << fight_loc3); }
        /// <summary>Location 29<br/>Size 1<br/>Mask 0x2000_0000 (0b0010_0000_0000_0000_0000_0000_0000_0000)</summary>
        public bool fight_wazaInfoFlag { get => ((raw & fight_mask4) >> fight_loc4) != 0; set => raw = raw & ~fight_mask4 | (((value ? 1 : 0) & (fight_mask4 >> fight_loc4)) << fight_loc4); }
        /// <summary>Location 30<br/>Size 1<br/>Mask 0x4000_0000 (0b0100_0000_0000_0000_0000_0000_0000_0000)</summary>
        public bool fight_ultraBurstFlag { get => ((raw & fight_mask5) >> fight_loc5) != 0; set => raw = raw & ~fight_mask5 | (((value ? 1 : 0) & (fight_mask5 >> fight_loc5)) << fight_loc5); }
        /// <summary>Location 31<br/>Size 1<br/>Mask 0x8000_0000 (0b1000_0000_0000_0000_0000_0000_0000_0000)</summary>
        public bool fight_gFlag { get => ((raw & fight_mask6) >> fight_loc6) != 0; set => raw = raw & ~fight_mask6 | (((value ? 1 : 0) & (fight_mask6 >> fight_loc6)) << fight_loc6); }
        /// <summary>Location 32<br/>Size 1<br/>Mask 0x0001_0000_0000 (0b0001_0000_0000_0000_0000_0000_0000_0000_0000)</summary>
        public bool fight_forbidGWaza { get => ((raw & fight_mask7) >> fight_loc7) != 0; set => raw = raw & ~fight_mask7 | (((value ? 1 : 0) & (fight_mask7 >> fight_loc7)) << fight_loc7); }
        /// <summary>Location 33<br/>Size 1<br/>Mask 0x0002_0000_0000 (0b0010_0000_0000_0000_0000_0000_0000_0000_0000)</summary>
        public bool fight_forceGWaza { get => ((raw & fight_mask8) >> fight_loc8) != 0; set => raw = raw & ~fight_mask8 | (((value ? 1 : 0) & (fight_mask8 >> fight_loc8)) << fight_loc8); }

        /// <summary>Location 0<br/>Size 4<br/>Mask 0x000F (0b1111)</summary>
        public byte item_cmd { get => (byte)((raw & item_mask0) >> item_loc0); set => raw = raw & ~item_mask0 | ((value & (item_mask0 >> item_loc0)) << item_loc0); }
        /// <summary>Location 4<br/>Size 5<br/>Mask 0x01F0 (0b0001_1111_0000)</summary>
        public byte item_pokeID { get => (byte)((raw & item_mask1) >> item_loc1); set => raw = raw & ~item_mask1 | ((value & (item_mask1 >> item_loc1)) << item_loc1); }
        /// <summary>Location 9<br/>Size 8<br/>Mask 0x0001_FE00 (0b0001_1111_1110_0000_0000)</summary>
        public byte item_targetID { get => (byte)((raw & item_mask2) >> item_loc2); set => raw = raw & ~item_mask2 | ((value & (item_mask2 >> item_loc2)) << item_loc2); }
        /// <summary>Location 17<br/>Size 16<br/>Mask 0x0001_FFFE_0000 (0b0001_1111_1111_1111_1110_0000_0000_0000_0000)</summary>
        public ushort item_number { get => (ushort)((raw & item_mask3) >> item_loc3); set => raw = raw & ~item_mask3 | ((value & (item_mask3 >> item_loc3)) << item_loc3); }
        /// <summary>Location 33<br/>Size 8<br/>Mask 0x01FE_0000_0000 (0b0001_1111_1110_0000_0000_0000_0000_0000_0000_0000_0000)</summary>
        public byte item_param { get => (byte)((raw & item_mask4) >> item_loc4); set => raw = raw & ~item_mask4 | ((value & (item_mask4 >> item_loc4)) << item_loc4); }

        /// <summary>Location 0<br/>Size 4<br/>Mask 0x000F (0b1111)</summary>
        public byte change_cmd { get => (byte)((raw & change_mask0) >> change_loc0); set => raw = raw & ~change_mask0 | ((value & (change_mask0 >> change_loc0)) << change_loc0); }
        /// <summary>Location 4<br/>Size 5<br/>Mask 0x01F0 (0b0001_1111_0000)</summary>
        public byte change_pokeID { get => (byte)((raw & change_mask1) >> change_loc1); set => raw = raw & ~change_mask1 | ((value & (change_mask1 >> change_loc1)) << change_loc1); }
        /// <summary>Location 9<br/>Size 3<br/>Mask 0x0E00 (0b1110_0000_0000)</summary>
        public byte change_posIdx { get => (byte)((raw & change_mask2) >> change_loc2); set => raw = raw & ~change_mask2 | ((value & (change_mask2 >> change_loc2)) << change_loc2); }
        /// <summary>Location 12<br/>Size 3<br/>Mask 0x7000 (0b0111_0000_0000_0000)</summary>
        public byte change_memberIdx { get => (byte)((raw & change_mask3) >> change_loc3); set => raw = raw & ~change_mask3 | ((value & (change_mask3 >> change_loc3)) << change_loc3); }
        /// <summary>Location 15<br/>Size 1<br/>Mask 0x8000 (0b1000_0000_0000_0000)</summary>
        public bool change_depleteFlag { get => ((raw & change_mask4) >> change_loc4) != 0; set => raw = raw & ~change_mask4 | (((value ? 1 : 0) & (change_mask4 >> change_loc4)) << change_loc4); }

        /// <summary>Location 0<br/>Size 4<br/>Mask 0x000F (0b1111)</summary>
        public byte escape_cmd { get => (byte)((raw & escape_mask0) >> escape_loc0); set => raw = raw & ~escape_mask0 | ((value & (escape_mask0 >> escape_loc0)) << escape_loc0); }
        /// <summary>Location 4<br/>Size 5<br/>Mask 0x01F0 (0b0001_1111_0000)</summary>
        public byte escape_pokeID { get => (byte)((raw & escape_mask1) >> escape_loc1); set => raw = raw & ~escape_mask1 | ((value & (escape_mask1 >> escape_loc1)) << escape_loc1); }

        /// <summary>Location 0<br/>Size 4<br/>Mask 0x000F (0b1111)</summary>
        public byte g_start_cmd { get => (byte)((raw & g_start_mask0) >> g_start_loc0); set => raw = raw & ~g_start_mask0 | ((value & (g_start_mask0 >> g_start_loc0)) << g_start_loc0); }
        /// <summary>Location 4<br/>Size 5<br/>Mask 0x01F0 (0b0001_1111_0000)</summary>
        public byte g_start_pokeID { get => (byte)((raw & g_start_mask1) >> g_start_loc1); set => raw = raw & ~g_start_mask1 | ((value & (g_start_mask1 >> g_start_loc1)) << g_start_loc1); }

        /// <summary>Location 0<br/>Size 4<br/>Mask 0x000F (0b1111)</summary>
        public byte cheer_cmd { get => (byte)((raw & cheer_mask0) >> cheer_loc0); set => raw = raw & ~cheer_mask0 | ((value & (cheer_mask0 >> cheer_loc0)) << cheer_loc0); }
        /// <summary>Location 4<br/>Size 5<br/>Mask 0x01F0 (0b0001_1111_0000)</summary>
        public byte cheer_pokeID { get => (byte)((raw & cheer_mask1) >> cheer_loc1); set => raw = raw & ~cheer_mask1 | ((value & (cheer_mask1 >> cheer_loc1)) << cheer_loc1); }
    }
}