using System;

namespace DPData
{
    [Serializable]
    public struct POKETCH_DATA
    {
        public bool get_flag;
        public bool pedometer_flag;
        public bool dotart_modified_flag;
        public POKETCH_COLOR color_type;
        public sbyte app_count;
        public sbyte app_index;
        public bool[] app_flag;
        public uint pedometer;
        public byte[] dotart_data;
        public uint[] calendar_markbit;
        public MARK_MAP_POS[] mark_map_pos;
        public POKETCH_POKE_HISTORY[] poke_history;
        private static POKETCH_POKETORE_COUNT tempPoketore_count = default(POKETCH_POKETORE_COUNT);
        private static int tempPoketoreSaveDataIndex = -1;

        public POKETCH_DATA(int a)
        {
            get_flag = false;
            pedometer_flag = false;
            dotart_modified_flag = false;
            color_type = POKETCH_COLOR.POKETCH_COLOR_TYPE0;
            app_count = 0;
            app_index = 0;

            app_flag = new bool[20];
            for (int i=0; i<app_flag.Length; i++)
                app_flag[i] = false;

            pedometer = 0;

            dotart_data = new byte[192];
            for (int i=0; i<dotart_data.Length; i++)
                dotart_data[i] = 0;

            calendar_markbit = new uint[12];
            for (int i=0; i<calendar_markbit.Length; i++)
                calendar_markbit[i] = 0;

            mark_map_pos = new MARK_MAP_POS[6];
            for (int i=0; i<mark_map_pos.Length; i++)
            {
                mark_map_pos[i].x = 0;
                mark_map_pos[i].y = 0;
            }

            poke_history = new POKETCH_POKE_HISTORY[12];
            for (int i=0; i<poke_history.Length; i++)
            {
                poke_history[i].monsno = 0;
                poke_history[i].iconPattern = 0;
            }
        }

        // TODO
        public void PokeHistoryAdd(ushort monsno, ushort pattern) { }

        // TODO
        public int PokeHistoryGetRecordCount() { return 0; }

        // TODO
        public (int, int) PokeHistoryGetRecord(int index) { return (0, 0); }

        // TODO
        public void ResetTempPoketore() { }

        // TODO
        public void PoketoreSetCount(ushort monsNo, int count) { }
    }
}