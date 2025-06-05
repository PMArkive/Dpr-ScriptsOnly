using Dpr.UI;
using UnityEngine;
using UnityEngine.UI;

public class KeyguideItem : MonoBehaviour
{
    [SerializeField]
    private Image _button;
    [SerializeField]
    private UIText _text;

    public void Setup(Param param)
    {
        var keyguideData = UIManager.Instance.GetKeyguideData(param.keyguideId);
        _button.sprite = UIManager.Instance.GetSharedSprite(keyguideData.ButtonSpriteId);
        _text.SetupMessage(keyguideData.MessageFile, keyguideData.MessageLabel);
    }

    public class Param
    {
	    public KeyguideID keyguideId;
    }
}