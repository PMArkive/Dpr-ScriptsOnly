using INL1;
using System;
using UnityEngine;

namespace Dpr.NetworkUtils
{
    public static class NetworkHelper
    {
        // TODO
        public static void InitNetworkData() { }

        // TODO
        public static void CheckOnlineAccountAsync(Action<bool> onComplete) { }

        // TODO
        public static bool IsFirstConnectInternet() { return false; }

        // TODO
        public static ushort CheckPlayerNum(ushort playerNum) { return 0; }

        // TODO
        public static ushort CreateContestGameMode(MatchingType matchingType, IlcaNetSessionNetworkType connectType) { return default; }

        // TODO
        public static ushort CreateUnderGroundGameMode(MatchingType matchingType, IlcaNetSessionNetworkType connectType, ushort UgMapGroupID) { return default; }

        // TODO
        public static ushort CreateUnionGameMode(MatchingType matchingType, IlcaNetSessionNetworkType connectType) { return default; }

        // TODO
        public static ushort CreateBattleGameMode(MatchingType matchingType, BattleModeID battleModeID, IlcaNetSessionNetworkType connectType) { return default; }

        // TODO
        private static ushort GetMatchingBitByType(MatchingType matchingType) { return default; }

        // TODO
        private static ushort GetBattleModeBitByID(BattleModeID battleModeID) { return 0; }

        // TODO
        private static void EmitGameModeLog(ushort gamemode) { }

        // TODO
        public static SessionErrorType ConvertIlcaNetUtilInternetGoResultToSessionErrorType(IlcaNetUtilInternetGoResult internetGoResult) { return default; }

        // TODO
        public static SessionErrorType ConvertIIlcaNetTransportErrorEnumToSessionErrorType(IlcaNetTransportErrorEnum transportError) { return default; }

        // TODO
        public static void EmitValidateError(IlcaNetServerValidate.CheckResponse checkResponse) { }

        // TODO
        public static void EmitNetworkLog(string log, LogType logType = LogType.Log) { }
    }
}