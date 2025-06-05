using System;
using System.Collections.Generic;
using UnityEngine;

public class EvData : ScriptableObject
{
    public List<Script> Scripts = new List<Script>();
    public List<string> StrList = new List<string>();

    public string GetString(int index)
    {
        return index < StrList.Count ? StrList[index] : null;
    }

    public enum ArgType : int
    {
        Command = 0,
        Float = 1,
        Work = 2,
        Flag = 3,
        SysFlag = 4,
        String = 5,
    }

    [Serializable]
    public struct Aregment
    {
	    public ArgType argType;
        public int data;
    }

    [Serializable]
    public class Script
    {
        public string Label = "";
        public List<Command> Commands = new List<Command>();
    }

    [Serializable]
    public class Command
    {
        public List<Aregment> Arg = new List<Aregment>();
    }
}