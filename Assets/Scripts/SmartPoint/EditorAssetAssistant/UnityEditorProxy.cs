using SmartPoint.AssetAssistant;
using SmartPoint.AssetAssistant.UnityExtensions;
using UnityEngine;
using UnityEngine.SceneManagement;

#if NON_DECOMP // [NON-DECOMP] From EditorAssetAssistant.dll, not included with the game.
namespace SmartPoint.EditorAssetAssistant
{
    public class UnityEditorProxy : IUnityEditorProxy
    {
        public string[] GetAllAssetBundleNames()
        {
            return ArrayHelper.Empty<string>();
        }

        public string GetAssetBundleNameAtPath(string path)
        {
            return "";
        }

        public bool HasAssetBundleNameAtPath(string path)
        {
            return false;
        }

        public string FindMatchAssetBundleNameWithVariants(string assetBundleName, string[] variants)
        {
            return "";
        }

        public string[] GetAssetBundleNamesWithVariant()
        {
            return ArrayHelper.Empty<string>();
        }

        public string[] GetAssetPathsFromAssetBundle(string assetBundleName)
        {
            return ArrayHelper.Empty<string>();
        }

        public AsyncOperation LoadLevelAdditiveAsyncInPlayMode(string path)
        {
            return null;
        }

        public UnityEngine.Object LoadMainAssetAtPath(string path)
        {
            return null;
        }

        public void ReloadEditorSkyboxShader()
        {

        }

        public void ReloadEditorShadersInScene(Scene scene)
        {

        }

        public void ReloadEditorShaders(UnityEngine.Object asset)
        {

        }

        public void ReloadVariantAssets(UnityEngine.Object asset, string[] variants)
        {

        }

        public bool IsSceneAssetAtPath(string path)
        {
            return false;
        }

        public CustomYieldInstruction ReloadEditorShadersOperation(UnityEngine.Object[] assets)
        {
            return null;
        }
    }
}
#endif