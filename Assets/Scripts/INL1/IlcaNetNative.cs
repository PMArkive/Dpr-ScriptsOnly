using nn.account;
using System;

namespace INL1
{
    public class IlcaNetNative
    {
        // TODO
        public static extern void CallSwitchNativeFunction(int i);

        // TODO
        public static extern void PrintLine(string line);

        // TODO
        public static extern void ErrorViewerDispCancelControl(bool on);

        // TODO
        public static extern void ShowApplicationError(uint code, string dialog, string screen, string lang);

        // TODO
        public static extern void InternetCurrentTimeGet(ref long getTime);

        // TODO
        public static extern void InitializeSoftwareKeyboardInline(uint textMaxLength, int textMinLength, int HeapSize = 0x1000000, bool miniaturize = false, uint invalidButtonFlag = 0, uint invalidCharFlag = 0, bool isCancelButtonDisabled = false, bool isPredictionEnabled = false, bool isUseNewLine = false, uint keyboardMode = 0, short leftOptionalSymbolKey = 0, short rightOptionalSymbolKey = 0);

        // TODO
        public static extern int UpdateSoftwareKeyboardInline(byte[] text, ref int size);

        // TODO
        public static extern void FinalizeSoftwareKeyboardInline();

        // TODO
        public static extern bool GetImageSoftwareKeyboardInline(out IntPtr buff, out int size);

        // TODO
        public static extern bool LICLoadNetworkServiceLicenseInfoAsync(UserHandle user);

        // TODO
        public static extern bool LICLoadNetworkServiceLicenseInfoAsyncWait();

        // TODO
        public static extern int LICGetNetworkServiceLicenseKind();

        // TODO
        public static extern bool VerifySignature(byte[] pPublicKey, int publicKeysize, byte[] pPokemonDataList, int pokemonListSize, byte[] pSignature);

        // TODO
        public static extern void BCATInitialize();

        // TODO
        public static extern void BCATMountDeliveryCacheStorage();

        // TODO
        public static extern bool BCATMountDeliveryCheck();

        // TODO
        public static extern int BCATMountDeliveryCheck2();

        // TODO
        public static extern int BCATMountDeliveryCheck3();

        // TODO
        public static extern int BCATWaitForDone();

        // TODO
        public static extern void BCATgetStart();

        // TODO
        public static extern void BCATgetStart2();

        // TODO
        public static extern bool BCATgetStart2x1();

        // TODO
        public static extern bool BCATgetStart2x2();

        // TODO
        public static extern int BCATgetStart3();

        // TODO
        public static extern void BCATEnumerateAll();

        // TODO
        public static extern void BCATUnmountDeliveryCacheStorage();

        // TODO
        public static extern int BCATFileCountGet(uint dirNum);

        // TODO
        public static extern int BCATFileCountListGet(uint dirNum, byte[] fileNameArray);

        // TODO
        public static extern long BCATFileSizeGet(uint dirNum, uint fileNum);

        // TODO
        public static extern int BCATFileRead(uint dirnum, uint filenum, byte[] data, int dataMaxSize);

        // TODO
        public static extern ushort FP32toFP16(float src);

        // TODO
        public static extern float FP16toFP32(ushort src);

        // TODO
        public static extern uint FP32toFP24(float src);

        // TODO
        public static extern float FP24toFP32(uint src);

        // TODO
        public static extern float BToFP32(uint src);

        // TODO
        public static extern uint FP32ToB(float src);

        // TODO
        public static extern double BToFP64(ulong src);

        // TODO
        public static extern ulong FP64ToB(double src);

        // TODO
        public static extern int INLpiaSessionGetStatus();

        // TODO
        public static extern int INLpiaSessionGetSessionId();

        // TODO
        public static extern int INLpiaSessionIsHost();

        // TODO
        public static extern int INLpiaSessionGetHostStationIndex();

        // TODO
        public static extern int INLpiaSessionGetThisStationIndex();

        // TODO
        public static extern ulong INLpiaSessionGetHostConstantId();

        // TODO
        public static extern ulong INLpiaSessionGetThisConstantId();

        // TODO
        public static extern int INLpiaSessionGetStationIndex(ulong id);

        // TODO
        public static extern ulong INLpiaSessionGetConstantId(uint id);

        // TODO
        public static extern int INLpiaSessionGetPlayerNum();

        // TODO
        public static extern int INLpiaSessionGetStationNum();

        // TODO
        public static extern int INLpiaSessionGetPlayerInfo(ulong id, byte[] name, ref byte lang, ref uint nameBytes);

        // TODO
        public static extern int INLpiaSessionGetConstantIdArray(ulong[] id_array);

        // TODO
        public static extern int INLpiaSessionGetRttArray(int[] rtt_array, int maxStation);

        // TODO
        public static extern int INLpiaStationTURNconnectIndex(uint id);

        // TODO
        public static extern int INLpiaStationTURNconnectConstantID(ulong constantid);

        // TODO
        public static extern uint INLnifmGetCurrentPrimaryIpAddress();

        // TODO
        public static extern bool NEXTradeObject(int target_point, byte[] core_binary, int core_binary_size, byte[] signature_binary, int signature_binary_size, IntPtr ptr);

        // TODO
        public static extern int NEXTradeObjectPolling();

        // TODO
        public static extern void NEXTradeObjectSuccessGet(byte[] core_binary, ref int core_binarysize, byte[] signature_binary, ref int signature_binarysize, ref ushort point);

        // TODO
        public static extern uint NEXTradeObjectResultGet();

        // TODO
        public static extern void hagegga(byte[] nanka, int size);
    }
}