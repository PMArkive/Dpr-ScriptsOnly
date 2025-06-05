using Dpr.Message;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class DisplayMessage : MonoBehaviour
{
    [SerializeField]
    private int materialIndex;
    private readonly string DEFAULT_USE_MSBT_NAME = "dp_scenario1";
    private TextMeshProUGUI messageText;
    private MessageMsgFile useMsgFile;
    private RectTransform messageRect;
    private GameObject noiseImage;
    private int useLabelHash;
    private bool isRedGyarados;
    private float blinkCycle;
    private float blinkWidth;
    private Color fromColor;
    private Color toColor;

    public void Initialize()
    {
        messageText = this.FindDeep("Message").GetComponent<TextMeshProUGUI>();
        messageRect = messageText.GetComponent<RectTransform>();
        noiseImage = this.FindDeep("Noise");

        if (noiseImage != null)
            noiseImage.SetActive(false);

        InitTextSetting();
        messageRect.localScale = new Vector3(MessageDataConstants.ASPECT_SCALE.x, MessageDataConstants.ASPECT_SCALE.y, 0.0f);
        ChangeUseMsgFile(DEFAULT_USE_MSBT_NAME);
        SetMessageEnabled(false);
    }

    private void InitTextSetting()
    {
        messageText.text = string.Empty;
        messageText.font = FontManager.Instance.GetFontAsset();
        FontManager.Instance.ChangeFontMaterial(messageText, materialIndex);
    }

    private void OnDestroy()
    {
        useMsgFile = null;
    }

    private void SetMessageEnabled(bool enabled)
    {
        if (messageText.enabled != enabled)
        {
            gameObject.SetActive(enabled);
            messageText.enabled = enabled;
        }
    }

    private void ChangeUseMsgFile(string newMsbtName)
    {
        if (!IsUseSameMsbt(newMsbtName))
        {
            useMsgFile = MessageManager.Instance.GetMsgFile(newMsbtName);
            useLabelHash = newMsbtName.GetHashCode();
        }
    }

    private bool IsUseSameMsbt(string newMsbtName)
    {
        return useLabelHash != 0 && useLabelHash == newMsbtName.GetHashCode();
    }

    public void ShowMessage(string labelName, string msbtName = "", bool bIsUseTag = false)
    {
        if (!string.IsNullOrEmpty(msbtName))
            ChangeUseMsgFile(msbtName);

        if (useMsgFile != null)
        {
            var model = useMsgFile.GetTextDataModel(labelName);
            if (model != null)
            {
                InitializeFont(model);

                if (bIsUseTag)
                {
                    model.ApplyFormat();
                    messageText.text = model.GetAllText();
                }
                else
                {
                    messageText.text = useMsgFile.GetNameStr(labelName);
                }

                SetMessageEnabled(true);
            }
        }
    }

    public void ChangeMessage(string message)
    {
        transform.SetActive(true);
        messageText.paragraphSpacing = -50.0f;
        messageText.enabled = true;
        messageText.text = message;
    }

    public void HideMessage()
    {
        isRedGyarados = false;

        if (noiseImage != null)
            noiseImage.SetActive(false);

        InitializeFont(null);
        SetMessageEnabled(false);
    }

    private void InitializeFont([Optional] MessageTextParseDataModel textDataModel)
    {
        if (isRedGyarados)
            SetFontColor(toColor);
        else
            SetFontColor(Color.white);
    }

    private void SetMessageWidth(float width)
    {
        var sizeDelta = messageRect.sizeDelta;
        sizeDelta.x = width;
        messageRect.sizeDelta = sizeDelta;
    }

    private void SetFontSize(float fontSize)
    {
        messageText.fontSize = fontSize;
    }

    private void SetFontAutoSize(bool auto)
    {
        messageText.enableAutoSizing = auto;
    }

    private void SetFontColor(Color color)
    {
        messageText.color = color;
    }

    private void SetFontBold(bool bold)
    {
        if (bold)
            messageText.fontStyle = FontStyles.Bold;
        else
            messageText.fontStyle &= ~FontStyles.Bold;
    }

    private void SetFontLineSpace(float space)
    {
        messageText.lineSpacing = space;
    }

    private void SetFontSoftness(float softness)
    {
        if (messageText.fontSharedMaterial.HasProperty("_OutlineSoftness"))
            messageText.fontSharedMaterial.SetFloat("_OutlineSoftness", softness);
    }

    private void SetFontDilate(float dilate)
    {
        if (messageText.fontSharedMaterial.HasProperty("_FaceDilate"))
            messageText.fontSharedMaterial.SetFloat("_FaceDilate", dilate);
    }

    public void RedGyaradosMessage(bool flag)
    {
        isRedGyarados = flag;

        if (noiseImage != null)
            noiseImage.SetActive(isRedGyarados);

        if (flag)
        {
            fromColor = Color.black;
            toColor = messageText.color;

            var redGyara = FieldTvRedGyaradosEntity.GetTvRedGyarados();
            if (redGyara != null)
            {
                var material = redGyara.gameObject.GetComponent<MeshRenderer>().material;
                if (material != null)
                {
                    if (messageText.fontSharedMaterial.HasProperty("_BlinkCycle"))
                        blinkCycle = messageText.fontSharedMaterial.GetFloat("_BlinkCycle");

                    if (messageText.fontSharedMaterial.HasProperty("_BlinkWidth"))
                        blinkWidth = messageText.fontSharedMaterial.GetFloat("_BlinkWidth");
                }
            }
        }
    }

    private void Update()
    {
        if (isRedGyarados)
        {
            float blink = Time.time / blinkCycle;
            float angle = (blink - Mathf.FloorToInt(blink)) * Mathf.PI;
            float t = Mathf.Cos(angle + angle) * blinkWidth + 0.9f;

            SetFontColor(new Color(Mathf.Lerp(fromColor.r, toColor.r, t),
                Mathf.Lerp(fromColor.g, toColor.g, t),
                Mathf.Lerp(fromColor.b, toColor.b, t)));
        }
    }
}