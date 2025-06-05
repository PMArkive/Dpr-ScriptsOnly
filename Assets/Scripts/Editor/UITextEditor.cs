using Dpr.UI;
using TMPro.EditorUtilities;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(UIText), true)]
public class UITextEditor : TMP_EditorPanelUI
{
    private bool shownUITextSettings;

    static readonly GUIContent k_sizeId = new GUIContent("Size ID", "Determines the size of the text. Usually overrides the font size.");
    static readonly GUIContent k_useMessage = new GUIContent("Use Message", "Whether the text is overriden by localized text.");
    static readonly GUIContent k_messageFile = new GUIContent("Message File", "Determines the message file to look for the localized text in.");
    static readonly GUIContent k_messageId = new GUIContent("Message Label", "Determines the specific label to look for in the given message file.");
    static readonly GUIContent k_useTag = new GUIContent("Use Tag", "???");
    static readonly GUIContent k_isManual = new GUIContent("Is Manual", "???");
    static readonly GUIContent k_fontMaterialDataIndex = new GUIContent("Font Material Data Index", "???");
    static readonly GUIContent k_uiTextEnable = new GUIContent("UI Text Enable", "???");

    private SerializedProperty m_sizeId;
    private SerializedProperty m_useMessage;
    private SerializedProperty m_messageFile;
    private SerializedProperty m_messageId;
    private SerializedProperty m_useTag;
    private SerializedProperty m_isManual;
    private SerializedProperty m_fontMaterialDataIndex;
    private SerializedProperty m_uiTextEnable;

    protected override void OnEnable()
    {
        base.OnEnable();

        m_sizeId = serializedObject.FindProperty("_sizeId");
        m_useMessage = serializedObject.FindProperty("_useMessage");
        m_messageFile = serializedObject.FindProperty("_messageFile");
        m_messageId = serializedObject.FindProperty("_messageId");
        m_useTag = serializedObject.FindProperty("_useTag");
        m_isManual = serializedObject.FindProperty("_isManual");
        m_fontMaterialDataIndex = serializedObject.FindProperty("_fontMaterialDataIndex");
        m_uiTextEnable = serializedObject.FindProperty("_uiTextEnable");
    }

    protected override void DrawExtraSettings()
    {
        base.DrawExtraSettings();

        Rect rect = EditorGUILayout.GetControlRect(false, 24);

        if (GUI.Button(rect, new GUIContent("<b>UIText Settings</b>"), TMP_UIStyleManager.sectionHeader))
            shownUITextSettings = !shownUITextSettings;

        GUI.Label(rect, (shownUITextSettings ? k_UiStateLabel[0] : k_UiStateLabel[1]), TMP_UIStyleManager.rightLabel);
        if (shownUITextSettings)
            DrawUITextSettings();
    }

    protected void DrawUITextSettings()
    {
        EditorGUI.BeginChangeCheck();
        EditorGUILayout.PropertyField(m_sizeId, k_sizeId);
        if (EditorGUI.EndChangeCheck())
            m_HavePropertiesChanged = true;

        EditorGUI.BeginChangeCheck();
        EditorGUILayout.PropertyField(m_useMessage, k_useMessage);
        if (EditorGUI.EndChangeCheck())
            m_HavePropertiesChanged = true;

        EditorGUI.BeginChangeCheck();
        EditorGUILayout.PropertyField(m_messageFile, k_messageFile);
        if (EditorGUI.EndChangeCheck())
            m_HavePropertiesChanged = true;

        EditorGUI.BeginChangeCheck();
        EditorGUILayout.PropertyField(m_messageId, k_messageId);
        if (EditorGUI.EndChangeCheck())
            m_HavePropertiesChanged = true;

        EditorGUI.BeginChangeCheck();
        EditorGUILayout.PropertyField(m_useTag, k_useTag);
        if (EditorGUI.EndChangeCheck())
            m_HavePropertiesChanged = true;

        EditorGUI.BeginChangeCheck();
        EditorGUILayout.PropertyField(m_isManual, k_isManual);
        if (EditorGUI.EndChangeCheck())
            m_HavePropertiesChanged = true;

        EditorGUI.BeginChangeCheck();
        EditorGUILayout.PropertyField(m_fontMaterialDataIndex, k_fontMaterialDataIndex);
        if (EditorGUI.EndChangeCheck())
            m_HavePropertiesChanged = true;

        EditorGUI.BeginChangeCheck();
        EditorGUILayout.PropertyField(m_uiTextEnable, k_uiTextEnable);
        if (EditorGUI.EndChangeCheck())
            m_HavePropertiesChanged = true;
    }
}