using UnityEngine.EventSystems;
using UnityEngine;
using SmartPoint.AssetAssistant;
using System.Runtime.InteropServices;

[RequireComponent(typeof(EventTrigger))]
public class SceneCloser : MonoBehaviour
{
    [SerializeField]
    private RectTransform _rectTransform;

    private void Start()
    {
        var eventTrigger = GetComponent<EventTrigger>();
        var entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener((data) => OnPointerClickDelegate((PointerEventData)data));
        eventTrigger.triggers.Add(entry);
    }

    public void OnPointerClickDelegate([Optional] PointerEventData data)
    {
        if (_rectTransform == null)
            SceneBrowser.Close(this);
    }
}