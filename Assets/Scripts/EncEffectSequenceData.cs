using SmartPoint.Components;
using System;
using System.Collections.Generic;
using UnityEngine;

public class EncEffectSequenceData : ScriptableObject
{
    public EncEffectSeqDataTable table;
    public EffectFieldID EffectFieldID;
    public eSpecialType SpecialType;
    public List<KeyData> keyData = new List<KeyData>();

    public enum eSpecialType : int
    {
        Normal = 0,
        Gym = 1,
        Tower = 2,
        League = 3,
        AfterImage = 4,
    }

    public enum Command : int
    {
        PlayEffect = 0,
        SetColor = 1,
        FadeOut = 2,
        FadeIn = 3,
        MoveObject = 4,
        End = 5,
        SetFadeColor = 6,
        ChangeEffectLoop = 7,
        PlayGym = 8,
        PlaySE = 9,
        CameraPosition = 10,
        CameraRotation = 11,
        SetAfterImage = 12,
    }

    public enum DrawType : int
    {
        World = 0,
        UI = 1,
    }

    public enum State : int
    {
        Wait = 0,
        Run = 1,
        Finish = 2,
    }

    [Serializable]
    public class KeyData
    {
        public Command command = Command.End;
        public float startTime;
        public float endTime;
        public string path = "";
        public Color minColor = Color.white;
        public Color maxColor = Color.white;
        public float duration;
        public Fader.FadeMode fademode;
        public bool useSystemColor;
        public int fadeTexIndex;
        public string seEventName = "";
        public Vector3 cameraOffset = Vector3.zero;
        public bool saveCameraOffset;
        public float AfterImageAngle;
        public float AfterImageScale = 1.0f;
        [HideInInspector]
        public State state;
    }
}