using UnityEngine;

public class UnionHostEmoticonController : MonoBehaviour
{
    [SerializeField]
    private int updateFrame = 2;

    public int GetUpdateFrame()
    {
        return updateFrame;
    }
}