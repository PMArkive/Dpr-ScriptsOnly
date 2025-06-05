using System;
using UnityEngine;

public class PokemonPrefabInfo : MonoBehaviour
{
    [SerializeField]
    private Vector3 mStartPoint;
    [SerializeField]
    private Vector3 mEndPoint;
    [SerializeField]
    private float mModelHeight;
    public AABBData[] mAABBArray;

    public Vector3 StartPoint { get => mStartPoint; }
    public Vector3 EndPoint { get => mEndPoint; }
    public float ModelHeight { get => mModelHeight; }

    private void Start()
    {
        // Empty
    }

    public AABBData GetAABB(string motionName)
    {
        for (int i=0; i<mAABBArray.Length; i++)
        {
            if (motionName == mAABBArray[i].motionName)
                return mAABBArray[i];
        }

        return null;
    }

    public AABBData GetCurrentAABB()
    {
        var clipInfo = GetComponentInChildren<Animator>().GetCurrentAnimatorClipInfo(0);
        if (clipInfo == null || clipInfo.Length == 0)
            return null;

        return GetAABB(clipInfo[0].clip.name);
    }

    private void Update()
    {
        // Empty
    }

    [Serializable]
    public class AABBData
    {
	    public Vector3 size;
        public Vector3 center;
        public string motionName;
    }
}