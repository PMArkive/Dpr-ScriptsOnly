using System;

namespace DPData
{
    [Serializable]
    public struct FIELD_OBJ_SAVE_DATA
    {
        public byte cnt;
        public int name_hash;
        public int grid_x;
        public int grid_y;
        public int height;
        public int angle;
        public bool active;
        public int movecode;
        public int dir_head;
        public int mvParam0;
        public int mvParam1;
        public int mvParam2;
        public int limitX;
        public int limitZ;
        public int ev_type;
        public int mv_old_dir;
        public int mv_dir;
    }
}