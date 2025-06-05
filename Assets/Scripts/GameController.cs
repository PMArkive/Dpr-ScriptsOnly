using SmartPoint.AssetAssistant;
using System;
using System.Collections.Generic;
using nn.hid;
using UnityEngine;

public class GameController
{
    // TODO: cctor (for npadState)

    public static Vector2 analogStickL;
    public static Vector2 analogStickR;
    public static Vector2 digitalPad;
    public static int on = 0;
    public static int push = 0;
    public static int release = 0;
    public static int accel = 0;
    public static long[] times = new long[ButtonIndex.Count];
    public static int repeat = 0;
    private static long start = 5000000;
    private static long interval = 1250000;
    private static long limit_intarval = 250000;
    private static long required_time = 10000000;
    private static long prevTicks = 0;
    private static HashSet<LogicalInput> logicalInputs = new HashSet<LogicalInput>();
    private static readonly NpadId[] npadIds = new NpadId[2]
    {
        NpadId.No1, NpadId.Handheld
    };
    public static NpadState npadState; 
    public static NpadId npadId = NpadId.Invalid;
    public static NpadStyle npadStyle = NpadStyle.Invalid;
    private static int[] _analogStickLButtonMasks = new int[8]
    {
        ButtonMask.StickLUp,    ButtonMask.StickLUp | ButtonMask.StickLRight,   ButtonMask.StickLRight,  ButtonMask.StickLRight | ButtonMask.StickLDown,
        ButtonMask.StickLDown,  ButtonMask.StickLDown | ButtonMask.StickLLeft,  ButtonMask.StickLLeft,   ButtonMask.StickLLeft | ButtonMask.StickLUp,
    };
    private static int[] _analogStickRButtonMasks = new int[8]
    {
        ButtonMask.StickRUp,    ButtonMask.StickRUp | ButtonMask.StickRRight,   ButtonMask.StickRRight,  ButtonMask.StickRRight | ButtonMask.StickRDown,
        ButtonMask.StickRDown,  ButtonMask.StickRDown | ButtonMask.StickRLeft,  ButtonMask.StickRLeft,   ButtonMask.StickRLeft | ButtonMask.StickRUp,
    };

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void OnApplicationPlaying()
    {
        // TODO: These methods are external, so ignore for now
        //Npad.Initialize();
        Npad.SetSupportedIdType(npadIds);
        //Npad.SetSupportedStyleSet(NpadStyle.JoyDual | NpadStyle.Handheld | NpadStyle.FullKey);
        Sequencer.SubscribeUpdate(-10000, Update);
        Sequencer.onDestroy += Shutdown;
    }

    private static void Shutdown()
    {
        Sequencer.UnsubscribeUpdate(Update);
        logicalInputs.Clear();
    }

    private static void Update(float deltaTime)
    {
#if SWITCH
        // TODO
#else
        analogStickL.x = Input.GetAxisRaw("LStickH");
        analogStickL.y = Input.GetAxisRaw("LStickV");
        
        analogStickR.x = Input.GetAxisRaw("RStickH");
        analogStickR.y = Input.GetAxisRaw("RStickV");

        if (Input.GetAxisRaw("DPadH") > 0)
            digitalPad.x = 1.0f;
        else if (Input.GetAxisRaw("DPadH") < 0)
            digitalPad.x = -1.0f;
        else
            digitalPad.x = 0.0f;

        if (Input.GetAxisRaw("DPadV") > 0)
            digitalPad.y = 1.0f;
        else if (Input.GetAxisRaw("DPadV") < 0)
            digitalPad.y = -1.0f;
        else
            digitalPad.y = 0.0f;

        // Some of these I'm not sure on...
        int a =      Input.GetButton("Submit") ?   ButtonMask.A : 0;
        int b =      Input.GetButton("Cancel") ?   ButtonMask.B : 0;
        int x =      Input.GetButton("X") ?        ButtonMask.X : 0;
        int y =      Input.GetButton("Y") ?        ButtonMask.Y : 0;
        int stickL = Input.GetButton("Previous") ? ButtonMask.StickL : 0;
        int stickR = Input.GetButton("Next") ?     ButtonMask.StickR : 0;
        int l =      Input.GetButton("TriggerL") ? ButtonMask.L : 0;
        int r =      Input.GetButton("TriggerR") ? ButtonMask.R : 0;
        int zl =     Input.GetButton("Submit") ?   ButtonMask.ZL : 0;
        int zr =     Input.GetButton("Submit") ?   ButtonMask.ZR : 0;
        int plus =   Input.GetButton("Menu") ?     ButtonMask.Plus : 0;
        int minus =  Input.GetButton("Select") ?   ButtonMask.Minus : 0;
        int input = a | b | x | y | stickL | stickR | l | r | zl | zr | plus | minus;

        input |= (digitalPad.x > 0.01f) ?  ButtonMask.Right : 0;
        input |= (digitalPad.x < -0.01f) ? ButtonMask.Left : 0;
        input |= (digitalPad.y > 0.01f) ?  ButtonMask.Up : 0;
        input |= (digitalPad.y < -0.01f) ? ButtonMask.Down : 0;

        int stickLIndex = GetAnalogStickButtonIndex(analogStickL);
        input |= (stickLIndex >= 0) ? _analogStickLButtonMasks[stickLIndex] : 0;

        int stickRIndex = GetAnalogStickButtonIndex(analogStickR);
        input |= (stickRIndex >= 0) ? _analogStickRButtonMasks[stickRIndex] : 0;

        push = input & ~on;
        release = on & ~input;
        on = input;

        repeat = 0;
        accel = 0;

        long ticks = DateTime.Now.Ticks;

        for (int i=0; i<ButtonIndex.Count; i++)
        {
            int buttonMask = 1 << i;
            if ((on & buttonMask) == 0)
            {
                times[i] = 0;
                continue;
            }

            if (times[i] == 0)
            {
                times[i] = ticks;
                continue;
            }

            long deltaTicks = ticks - times[i] - start;
            if (deltaTicks > -1)
            {
                long deltaTicksNormalized = (interval != 0) ? deltaTicks / interval : 0;

                long previousTicks = prevTicks - times[i] - start;
                long prevTicksNormalized = (interval != 0) ? previousTicks / interval : 0;

                repeat |= (deltaTicksNormalized != prevTicksNormalized) ? buttonMask : 0;

                double deltaDouble = Math.Min((double)previousTicks / deltaTicksNormalized, 1.0);
                long deltaLong = (long)(deltaDouble * (limit_intarval - interval) + interval);

                long accelDeltaTicks = (deltaLong != 0) ? deltaTicks / deltaLong : 0;
                long accelPrevTicks = (deltaLong != 0) ? previousTicks / deltaLong : 0;

                accel |= (accelDeltaTicks != accelPrevTicks) ? buttonMask : 0;
            }
        }

        repeat |= push;
        accel |= push;
        prevTicks = ticks;

        foreach (var logInput in logicalInputs)
            logInput.Remap();
#endif
    }

    // TODO
    private static bool UpdateNpadState() { return false; }

    // TODO
    private static Vector2 CalcNpadAnalogValue(AnalogStickState analogState, float dead) { return default; }

    private static int GetAnalogStickButtonIndex(Vector2 analogStick)
    {
        if (analogStick.sqrMagnitude >= 0.25f)
        {
            float angle = Mathf.Atan2(-analogStick.x, -analogStick.y);
            angle = Mathf.Repeat((angle * 360.0f) / (Mathf.PI * 2) + 180.0f + 360.0f - 22.5f, 360.0f);
            return (int)(angle / 45.0f + 1.0f) % 8;
        }

        return -1;
    }

    public static void Subscribe(LogicalInput logicalInput)
    {
        logicalInputs.Add(logicalInput);
    }

    public static void Remove(LogicalInput logicalInput)
    {
        logicalInputs.Remove(logicalInput);
    }

    public class LogicalInput
    {
        public int on;
        public int push;
        public int release;
        public int repeat;
        public int accel;
        private ValueTuple<int, Condition>[] maps = new (int, Condition)[32];

        public LogicalInput()
        {
            Clear();
        }

        public void Assign(int index, int mask, Condition condition = Condition.Any)
        {
            maps[index] = (mask, condition);
        }

        public void Clear()
        {
            for (int i=0; i<maps.Length; i++)
                maps[i] = (0, Condition.Any);
        }

        internal void Remap()
        {
            on = 0;
            push = 0;
            accel = 0;
            release = 0;
            repeat = 0;

            for (int i=0; i<maps.Length; i++)
            {
                if (maps[i].Item1 == 0)
                    continue;

                int buttonMask = 1 << i;

                if (maps[i].Item2 == Condition.All)
                {
                    on |=      ((GameController.on & maps[i].Item1) == maps[i].Item1) ?      buttonMask : 0;
                    push |=    ((GameController.push & maps[i].Item1) == maps[i].Item1) ?    buttonMask : 0;
                    release |= ((GameController.release & maps[i].Item1) == maps[i].Item1) ? buttonMask : 0;
                    repeat |=  ((GameController.repeat & maps[i].Item1) == maps[i].Item1) ?  buttonMask : 0;
                    accel |=   ((GameController.accel & maps[i].Item1) == maps[i].Item1) ?   buttonMask : 0;
                }
                else
                {
                    on |=      ((GameController.on & maps[i].Item1) != 0) ?      buttonMask : 0;
                    push |=    ((GameController.push & maps[i].Item1) != 0) ?    buttonMask : 0;
                    release |= ((GameController.release & maps[i].Item1) != 0) ? buttonMask : 0;
                    repeat |=  ((GameController.repeat & maps[i].Item1) != 0) ?  buttonMask : 0;
                    accel |=   ((GameController.accel & maps[i].Item1) != 0) ?   buttonMask : 0;
                }
            }
        }

        public enum Condition : int
        {
            Any = 0,
            All = 1,
        }
    }

    public class ButtonIndex
    {
        public const int A = 0;
        public const int B = 1;
        public const int X = 2;
        public const int Y = 3;
        public const int StickL = 4;
        public const int StickR = 5;
        public const int L = 6;
        public const int R = 7;
        public const int ZL = 8;
        public const int ZR = 9;
        public const int Plus = 10;
        public const int Minus = 11;
        public const int Left = 12;
        public const int Up = 13;
        public const int Right = 14;
        public const int Down = 15;
        public const int StickLLeft = 16;
        public const int StickLUp = 17;
        public const int StickLRight = 18;
        public const int StickLDown = 19;
        public const int StickRLeft = 20;
        public const int StickRUp = 21;
        public const int StickRRight = 22;
        public const int StickRDown = 23;
        public const int LeftSL = 24;
        public const int LeftSR = 25;
        public const int RightSL = 26;
        public const int RightSR = 27;
        public const int Count = 28;
    }

    public class ButtonMask
    {
        public const int None = 0x0;
        public const int A = 0x1;                 // Bit 0
        public const int B = 0x2;                 // Bit 1
        public const int X = 0x4;                 // Bit 2
        public const int Y = 0x8;                 // Bit 3
        public const int StickL = 0x10;           // Bit 4
        public const int StickR = 0x20;           // Bit 5
        public const int L = 0x40;                // Bit 6
        public const int R = 0x80;                // Bit 7
        public const int ZL = 0x100;              // Bit 8
        public const int ZR = 0x200;              // Bit 9
        public const int Plus = 0x400;            // Bit 10
        public const int Minus = 0x800;           // Bit 11
        public const int Left = 0x1000;           // Bit 12
        public const int Up = 0x2000;             // Bit 13
        public const int Right = 0x4000;          // Bit 14
        public const int Down = 0x8000;           // Bit 15
        public const int StickLLeft = 0x10000;    // Bit 16
        public const int StickLUp = 0x20000;      // Bit 17
        public const int StickLRight = 0x40000;   // Bit 18
        public const int StickLDown = 0x80000;    // Bit 19
        public const int StickRLeft = 0x100000;   // Bit 20
        public const int StickRUp = 0x200000;     // Bit 21
        public const int StickRRight = 0x400000;  // Bit 22
        public const int StickRDown = 0x800000;   // Bit 23
        public const int LeftSL = 0x1000000;      // Bit 24
        public const int LeftSR = 0x2000000;      // Bit 25
        public const int RightSL = 0x4000000;     // Bit 26
        public const int RightSR = 0x8000000;     // Bit 27
    }
}