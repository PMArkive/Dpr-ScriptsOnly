using UnityEngine;

namespace SmartPoint.AssetAssistant.Forms
{
    [CreateAssetMenu(menuName = "AssetAssistant/Forms/MessageBoxManifest")]
    public abstract class MessageBoxManifestBase : ScriptableObject
    {
        public GameObject windowPrefab;
        public GameObject buttonPrefab;
        public GameObject buttonSeparatorPrefab;
        public string captionTextObjectName;
        public string messageTextObjectName;
        public string buttonLayoutObjectName;
    }
}