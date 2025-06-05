﻿namespace Dpr.Battle.Logic
{
    public class ClientSendData
    {
        public static void Copy(ref RAID_BALL_SELECT pDest, in RAID_BALL_SELECT src)
        {
            pDest = src;
        }

        public struct ACTION_SELECT
        {
            public byte actionNum;
            public byte pad_0;
            public byte pad_1;
            public byte pad_2;
            public byte pad_3;
            public byte pad_4;
            public byte pad_5;
            public byte pad_6;
            public unsafe fixed ulong actionParam[ACTIONPARAM_NUM];
            public const int ACTIONPARAM_NUM = 10;
        }

        public struct CLIENT_LIMIT_TIME
        {
            public ushort limitTime;
        }

        public struct RAID_BALL_SELECT
        {
            public bool isThrow;
            public ushort itemID;

            public void CopyFrom(RAID_BALL_SELECT src)
            {
                isThrow = src.isThrow;
                itemID = src.itemID;
            }
        }
    }
}