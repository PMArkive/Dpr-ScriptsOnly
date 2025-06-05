namespace Dpr
{
    public class SaveDataLinkage
    {
        private const ulong APP_ID_E = 72084463414370304;
        private const ulong APP_ID_K = 72246641462509568;
        private const ulong APP_ID_P = 72061923425992704;
        private const ulong APP_ID_T = 72213381238669312;
        private const ulong APP_ID_H = 72092022778863616;
        private const uint H_CODE_TRUE = 1777065704;
        private const uint H_CODE_FALSE = 3290706629;
        private const string H_MOUNT_NAME = "HB";
        private const string H_SAVEDATA_PATH = "HB:/main2";
        private static bool _hLinkageEnable;

        // TODO
        public static bool IsEnable(LinkageApp app) { return false; }

        // TODO
        public static void CheckSaveData() { }

        // TODO
        private static bool CheckSaveDataCore(byte[] buf) { return false; }

        public enum LinkageApp : int
        {
            B = 0,
            O = 1,
            H = 2,
        }
    }
}