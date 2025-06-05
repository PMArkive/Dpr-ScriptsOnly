using SmartPoint.AssetAssistant;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SceneNavigator : MonoBehaviour
{
    [SceneGUID]
    public string sceneAsset;

    private void Start()
    {
        var button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnPointerClickDelegate);
            if (string.IsNullOrEmpty(sceneAsset) && !SceneBrowser.CanBack())
            {
                button.interactable = false;
                return;
            }
            return;
        }

        var eventTrigger = GetComponent<EventTrigger>();
        if (eventTrigger == null)
            eventTrigger = gameObject.AddComponent<EventTrigger>();

        var entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener((data) => OnPointerClickDelegate((PointerEventData)data));
        eventTrigger.triggers.Add(entry);
    }
    
    public void OnPointerClickDelegate(PointerEventData data)
    {
        OnPointerClickDelegate();
    }

    public void OnPointerClickDelegate()
    {
        if (string.IsNullOrEmpty(sceneAsset))
            SceneBrowser.GoBack();
        else
            SceneBrowser.Navigate(SceneDatabase.GUIDToPath(sceneAsset), false);
    }
}