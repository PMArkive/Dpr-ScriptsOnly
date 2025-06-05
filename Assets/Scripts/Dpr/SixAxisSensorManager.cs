using nn.hid;
using SmartPoint.AssetAssistant;
using System;
using UnityEngine;

namespace Dpr
{
    public static class SixAxisSensorManager
    {
        private const int HandleMax = 2;

        private static NpadId _currentNpadId = NpadId.Invalid;
        private static NpadStyle _currentNpadStyle = NpadStyle.Invalid;
        private static int _handlesCount = 0;
        private static SixAxisSensorHandle[] _handles = new SixAxisSensorHandle[2];
        private static SensorState[] _states = new SensorState[2];
        private static bool _isInitialized = false;
        private static bool _enableSensor = true;

        public static int handleCount { get => _handlesCount; }

        public static void Initialize()
        {
            if (_isInitialized)
                return;

            _isInitialized = true;

            ConfigWork.onValueChanged += OnSettingValueChanged;
            Sequencer.update += OnUpdate;
        }

        private static void OnSettingValueChanged(ConfigID configId, int value)
        {
            if (configId == ConfigID.GyroSensor)
                _enableSensor = value == 0;
        }

        public static void Terminate()
        {
            // Empty
        }

        public static SensorState GetSensorState(int index)
        {
            if (!_enableSensor)
                return null;

            if (index > _handlesCount)
                return null;

            return _states[index];
        }

        private static void OnUpdate(float deltaTime)
        {
            UpdateInternal(deltaTime);
        }

        // TODO
        private static void UpdateInternal(float deltaTime) { }

        // TODO
        private static bool UpdatePadState() { return false; }

        private static void GetSixAxisSensor(NpadId id, NpadStyle style)
        {
            for (int i = 0; i < _handlesCount; i++)
            {
                SixAxisSensor.Stop(_handles[i]);
            }

            SixAxisSensor.GetHandles(_handles, HandleMax, (nn.hid.NpadId)id, (nn.hid.NpadStyle)style);

            for (int i = 0; i < _handlesCount; i++)
            {
                SixAxisSensor.Start(_handles[i]);
                _states[i] = new SensorState();
            }
        }

        [Flags]
        public enum SixAxisSensorAttribute : int
        {
            IsConnected = 1,
            IsInterpolated = 2,
        }

        public enum NpadId : int
        {
            No1 = 0,
            No2 = 1,
            No3 = 2,
            No4 = 3,
            No5 = 4,
            No6 = 5,
            No7 = 6,
            No8 = 7,
            Handheld = 32,
            Invalid = 64,
        }

        [Flags]
        public enum NpadStyle : int
        {
            None = 0,
            FullKey = 1,
            Handheld = 2,
            JoyDual = 4,
            JoyLeft = 8,
            JoyRight = 16,
            Invalid = 32,
        }

        public class SensorState
        {
            public const float AccelerometerMax = 7;
            public const float AngularVelocityMax = 5;
            public long deltaTimeNanoSeconds;
            public long samplingNumber;
            public Vector3 acceleration;
            public Vector3 angularVelocity;
            public Vector3 angle;
            public SixAxisSensorAttribute attributes;
            public Quaternion quaternion;
            public Vector3 gravity;
            public Vector3 userAcceleration;
            public SixAxisSensorState native;

            // TODO
            public void Update() { }
        }
    }
}