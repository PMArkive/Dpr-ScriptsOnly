using UnityEngine;

[CreateAssetMenu(fileName = "EncountFadeTextures", menuName = "ScriptableObjects/Fade/EncountFadeTextures")]
public class EncountFadeTextures : ScriptableObject
{
    [SerializeField]
    private Texture[] _textures;

    public Texture this[int index] => _textures[index];
}