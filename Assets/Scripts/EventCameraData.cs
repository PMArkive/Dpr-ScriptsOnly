using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EvCamData_", menuName = "ScriptableObjects/EventCameraData")]
public class EventCameraData : ScriptableObject
{
    public float baseTime;
    public float timeScale = 1.0f;
    public int length;
    public List<EventType> type = new List<EventType>();
    public List<bool> isEnd = new List<bool>();
    public List<float> startTime = new List<float>();
    public List<FadeData> fadeData = new List<FadeData>();
    public List<PathData> pathData = new List<PathData>();
    public List<DofData> dofData = new List<DofData>();
    public List<PathData2> pathData2 = new List<PathData2>();
    public List<RotationData> rotationData = new List<RotationData>();
    public List<ReturnDefault> returnDefault = new List<ReturnDefault>();
    public List<ReturnDefault> returnDefaultRotate = new List<ReturnDefault>();
    public List<FovData> fovData = new List<FovData>();

    public enum EventType : int
    {
        Path = 0,
        Fade = 1,
        EventEnd = 2,
        StopEnd = 3,
        DofLength = 4,
        NewPath = 5,
        Rotation = 6,
        ReturnDefaultCamera = 7,
        ReturnDefaultRotate = 8,
        FieldOfView = 9,
    }

    public enum FadeType : int
    {
        In = 0,
        Out = 1,
    }

    public enum VectorType : int
    {
        Local = 0,
        World = 1,
        Default = 2,
        Before = 3,
    }

    public enum DofValType : int
    {
        Input = 0,
        Defaul = 1,
        Work = 2,
    }

    [Serializable]
    public class ReturnDefault
    {
        public int curveIndex;
        public float workTime;
        public float workTimeScale = 1.0f;
    }

    [Serializable]
    public class RotationData
    {
        public int curveIndex;
        public float workTime;
        public float workTimeScale = 1.0f;
        public bool isDefaultRotate;
        public Vector3 Angle1;
        public Vector3 Angle2;
    }

    [Serializable]
    public class PathData2
    {
        public int curveIndex;
        public float workTime;
        public float workTimeScale = 1.0f;
        public VectorType vTypeStart;
        public VectorType vTypeEnd;
        public Vector3 Pos1;
        public Vector3 Pos2;
        public Vector3 Pos3;
    }

    [Serializable]
    public class PathData
    {
        public float workTime;
        public float workTimeScale = 1.0f;
        public VectorType vTypeStart;
        public VectorType vTypeEnd;
        public Vector3 startPosition;
        public Vector3 Vectol;
        public Vector3 endPosition;
        public bool isDefaultRotate;
        public Vector3 startRotation;
        public Vector3 endRotation;
    }

    [Serializable]
    public class FadeData
    {
        public FadeType type;
        public Color color;
        public float duration;
    }

    [Serializable]
    public class DofData
    {
        public float workTime;
        public float workTimeScale;
        public bool[] use = new bool[3];
        public DofValType[] typeStart = new DofValType[3];
        public DofValType[] typeEnd = new DofValType[3];
        public float[] valStart = new float[3];
        public float[] valEnd = new float[3];
        public Vector3 targetOffset;
    }

    [Serializable]
    public class FovData
    {
        public int curveIndex;
        public float workTime;
        public float workTimeScale;
        public float field_of_view_start;
        public float field_of_view;
        public bool is_default_start;
        public bool is_default_end;
    }
}