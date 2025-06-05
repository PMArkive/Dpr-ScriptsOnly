using SmartPoint.AssetAssistant;
using System;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;

namespace Audio
{
    public class AudioInstance : IObjectPoolInstance
    {
        private AkGameObj _akGameObj;
        private AudioManager.ListenerType _listenerType = AudioManager.ListenerType.Se;
        private uint _playEventId;
        private uint _stopEventId;
        private Transform _attachedTransform;
        private Vector3 _localPosition = Vector3.zero;
        private Quaternion _localRotation = Quaternion.identity;
        private UnityAction<AudioInstance> _onFinished;
        private float _volume = 1.0f;
        private uint _playId;
        private float _duration;
        private bool _isDurtyRtpc;
        private bool _isManualRemoved;
        private StateBits _stateBits;

        public AkGameObj akGameObj { get => _akGameObj; }
        public AudioManager.ListenerType listenerType { get => _listenerType; }
        public uint playEventId { get => _playEventId; }
        public uint stopEventId { get => _stopEventId; }
        public uint postEventNumber { get => _playId; }
        public float duration { get => _duration; }
        internal bool _isCleanup { get => _stateBits == StateBits.Cleanedup; }

        void IObjectPoolInstance.SetGameObject(GameObject obj)
        {
            _akGameObj = obj.GetComponent<AkGameObj>();
        }

        GameObject IObjectPoolInstance.GetGameObject()
        {
            return _akGameObj.gameObject;
        }

        void IObjectPoolInstance.OnCreate()
        {
            // Empty
        }

        void IObjectPoolInstance.OnRelease()
        {
            // Empty
        }

        internal void _Setup(AudioManager.ListenerType listenerType, uint playEventId, uint stopEventId, Vector3 position, Quaternion rotation, [Optional] Transform attachedTransform)
        {
            _attachedTransform = attachedTransform;
            _stateBits = StateBits.Created;
            _isDurtyRtpc = false;
            _isManualRemoved = false;
            _listenerType = listenerType;
            _playEventId = playEventId;
            _stopEventId = stopEventId;
            _volume = 1.0f;
            _playId = 0;

            if (attachedTransform != null)
            {
                _localRotation = rotation;
                _localPosition = position;
                UpdateTransform();
            }
            else
            {
                _akGameObj.gameObject.transform.localRotation = rotation;
                _akGameObj.gameObject.transform.localPosition = position;

                _akGameObj.SetPosition();
            }
        }

        public AudioInstance Play([Optional] UnityAction<AudioInstance> onFinished, bool isManualRemoved = false)
        {
            _onFinished = onFinished;
            _stateBits |= StateBits.Played;
            _isManualRemoved = isManualRemoved;
            _akGameObj.gameObject.SetActive(true);
            
            // Not sure why this is done
            _volume = _volume;

            AudioManager.Instance._SetInstanceVolume(this);
            UpdateTransform();

            _playId = AkSoundEngine.PostEvent(_playEventId, _akGameObj.gameObject, 0x100009, OnPostEvent, this);

            if (_playId == 0)
                Sequencer.Start(OpDelayPlayComplete());

            return this;
        }

        private IEnumerator OpDelayPlayComplete()
        {
            yield return null;
            OnPostEvent(this, AkCallbackType.AK_EndOfEvent, null);
        }

        private static void OnPostEvent(object in_cookie, AkCallbackType in_type, AkCallbackInfo in_info)
        {
            if (in_cookie == null)
                return;

            var audioInstance = in_cookie as AudioInstance;

            if (in_type == AkCallbackType.AK_EndOfEvent)
            {
                if (audioInstance._onFinished != null)
                {
                    audioInstance._onFinished(audioInstance);
                    audioInstance._onFinished = null;
                }
                audioInstance._stateBits |= StateBits.PlayEnded;
                audioInstance.PostCleanupEvent(false);
            }
            else if (in_type == AkCallbackType.AK_Duration)
            {
                if (in_info != null)
                    audioInstance._duration = (in_info as AkDurationCallbackInfo).fEstimatedDuration / 1000.0f;
            }
        }

        public void PostCleanupEvent(bool isForce = false)
        {
            if (_isDurtyRtpc && !isForce)
            {
                AkSoundEngine.PostEvent(0xef75803a, _akGameObj.gameObject, 1, (in_cookie, in_type, in_info) => (in_cookie as AudioInstance).Cleanup(), this);
            }
            else
            {
                Cleanup();
            }
        }

        private void Cleanup()
        {
            _stateBits |= StateBits.Cleanup;
            if (!_isManualRemoved)
            {
                _stateBits |= (StateBits.Cleanup | StateBits.Cleanedup);
                AudioManager.Instance._RemoveInstance(this);
            }
        }

        public void Stop()
        {
            _isManualRemoved = false;
            _stateBits |= StateBits.Stopped;
            if ((int)(_stateBits & StateBits.Played) != 0)
            {
                if ((int)(_stateBits & StateBits.PlayEnded) == 0)
                {
                    if (_stopEventId != 0)
                    {
                        AkSoundEngine.PostEvent(_stopEventId, _akGameObj.gameObject, 1, OnStopComplete, this);
                    }
                }
                else if ((int)(_stateBits & StateBits.Cleanup) != 0 && _isManualRemoved)
                {
                    _stateBits |= StateBits.Cleanup;

                    if (!_isManualRemoved)
                    {
                        _stateBits |= StateBits.Cleanedup;
                        AudioManager.Instance._RemoveInstance(this);
                    }
                }
            }
            else
            {
                PostCleanupEvent(true);
            }
        }

        private static void OnStopComplete(object in_cookie, AkCallbackType in_type, AkCallbackInfo in_info)
        {
            // Empty
        }

        public void SetLocalPosition(Vector3 localPos)
        {
            _localPosition = localPos;
        }

        internal void _Update()
        {
            UpdateTransform();
        }

        private void UpdateTransform()
        {
            if (_attachedTransform != null && _attachedTransform.gameObject != null)
            {
                Matrix4x4 currentMatrix = _akGameObj.transform.localToWorldMatrix;
                Matrix4x4 newMatrix = Matrix4x4.TRS(_localPosition, _localRotation, Vector3.one);

                Matrix4x4 result = currentMatrix * newMatrix;

                Vector4 col1 = result.GetColumn(1);
                Vector4 col2 = result.GetColumn(2);
                Vector4 col3 = result.GetColumn(3);

                _akGameObj.transform.localPosition = col3;
                _akGameObj.transform.localRotation = Quaternion.LookRotation(col2, col1);

                _akGameObj.SetPosition();
            }
        }

        public float GetPlayPosition(bool isExtrapolate = true)
        {
            AkSoundEngine.GetSourcePlayPosition(_playId, out int puPosition, isExtrapolate);
            return puPosition / 1000.0f;
        }

        public float GetVolume()
        {
            return _volume;
        }

        public void SetVolume(float volume)
        {
            _volume = volume;
            AudioManager.Instance._SetInstanceVolume(this);
        }

        public float GetRTPCValue(uint gameParamId)
        {
            int rValueType = 2;
            AkSoundEngine.GetRTPCValue(gameParamId, _akGameObj.gameObject, 0, out float rValue, ref rValueType);
            return rValue;
        }

        public void SetRTPCValue(uint gameParamId, float value)
        {
            _isDurtyRtpc = true;
            AkSoundEngine.SetRTPCValue(gameParamId, value, _akGameObj.gameObject);
        }

        public uint GetSwitch(uint groupId)
        {
            AkSoundEngine.GetSwitch(groupId, _akGameObj.gameObject, out uint rSwitchState);
            return rSwitchState;
        }

        public void SetSwitch(uint groupId, uint state)
        {
            AkSoundEngine.SetSwitch(groupId, state, _akGameObj.gameObject);
        }

        [Flags]
        private enum StateBits : int
        {
            None = 0,
            Created = 1,
            Played = 2,
            Stopped = 4,
            PlayEnded = 8,
            Cleanup = 16,
            Cleanedup = 32,
        }
    }
}
