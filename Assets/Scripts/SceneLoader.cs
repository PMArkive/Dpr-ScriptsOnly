using SmartPoint.AssetAssistant;
using SmartPoint.Components;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
public class SceneLoader : MonoBehaviour
{
    public string scenePath;
    public string webViewURL;
    public string tapSE;

    private void Start()
    {
        var eventTrigger = GetComponent<EventTrigger>();
        var entry = new EventTrigger.Entry();

        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener(data => OnPointerClickDelegate(data as PointerEventData));
        eventTrigger.triggers.Add(entry);
    }

    public void OnPointerClickDelegate(PointerEventData data)
    {
        if (!string.IsNullOrEmpty(tapSE))
            AudioPlayer.PlayEffect(tapSE, 1.0f);

        SceneBrowser.Open(scenePath, true);
    }
}