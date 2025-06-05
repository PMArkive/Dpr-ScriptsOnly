using Dpr.Message;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EffectPosData
{
    public int MstID;
    public string Name;
    public List<string> Path = new List<string>();
    public List<Vector3> Position = new List<Vector3>();
    public List<Vector3> Angles = new List<Vector3>();

    public EffectPosData(int mstID)
    {
        MstID = mstID;
        Name = MessageManager.Instance.GetNameMessage(MessageDataConstants.MONSNAME_FILE_NAME, MstID);
    }
}