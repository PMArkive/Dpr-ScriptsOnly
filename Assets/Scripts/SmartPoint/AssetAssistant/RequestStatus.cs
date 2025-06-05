namespace SmartPoint.AssetAssistant
{
    public enum RequestStatus : int
    {
        None = 0,
        ResolveDependencies = 1,
        LoadAndInstall = 2,
        RequestInstallation = 3,
        InstallAssetBundles = 4,
        SaveManifest = 5,
        WaitForInstallation = 6,
        WaitForCacheLoading = 7,
        WaitForCacheWriting = 8,
        WaitForReloadShaders = 9,
        LoadAssetBundle = 10,
        LoadAsset = 11,
        LoadFinished = 12,
        Complete = 13,
        HttpError = 14,
        NetworkError = 15,
        FileNotFound = 16,
    }
}