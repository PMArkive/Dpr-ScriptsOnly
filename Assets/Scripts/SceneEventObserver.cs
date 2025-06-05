using SmartPoint.AssetAssistant;
using SmartPoint.Components;
using System.Collections;
using UnityEngine;

public class SceneEventObserver
{
    private static readonly string BATTLE_SCENE_PATH = "Assets/SharedAssets/Games/Scenes/Battle.unity";
    private static readonly string FIELD_SCENE_PATH = "Assets/SharedAssets/Games/Scenes/Field.unity";

    [AssetAssistantInitializeMethod]
    private static void Initialize()
    {
        SceneBrowser.beforeSceneChanged += OnBeforeSceneChanged;
        SceneBrowser.sceneNavigated += OnSceneNavigated;
        SceneBrowser.prepareForSceneSwitching += PrepareForSceneSwitching;
    }

    private static IEnumerator PrepareForSceneSwitching(SceneEntity currentScene, SceneEntity targetScene)
    {
        var sw = new SimpleStopwatch("PrepareForSceneSwitching");
        
        while (Fader.isBusy)
            yield return null;

        if (currentScene != null && targetScene != null)
        {
            if (currentScene.path == FIELD_SCENE_PATH && targetScene.path == BATTLE_SCENE_PATH)
            {
                sw?.Dispose();
                yield break;
            }
            else if (currentScene.path == BATTLE_SCENE_PATH && targetScene.path == FIELD_SCENE_PATH)
            {
                PlayerWork.IsNeedUnloadOnFieldConnector = true;
                sw?.Dispose();
                yield break;
            }

            yield return Resources.UnloadUnusedAssets();
        }

        sw?.Dispose();
    }

    private static void OnBeforeSceneChanged(SceneEntity currentScene, SceneEntity targetScene)
    {
        if (currentScene != null)
            Fader.FadeIn();

        Fader.FadeOut(0.0f);
        Fader.FadeIn();
    }

    private static void OnSceneNavigated(SceneEntity currentScene, SceneEntity targetScene)
    {
        Fader.FadeOut();
    }
}