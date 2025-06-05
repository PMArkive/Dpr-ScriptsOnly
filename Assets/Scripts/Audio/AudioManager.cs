using SmartPoint.AssetAssistant;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;

namespace Audio
{
    // TODO: Any calls to the Wwise engine are commented out for now, while we prepare the Wwise project.
    public class AudioManager : SingletonMonoBehaviour<AudioManager>
    {
        [SerializeField]
        public GameObject _prefab;
        [SerializeField]
        public int[] _poolCounts = { 64, 8 };
        [SerializeField]
        public Transform _listenerRoot;
        [SerializeField]
        private string _commonBankName = "Delphis_Main";
        private List<ListenerParam> _listenerParams = new List<ListenerParam>();
        private List<AudioInstance> _audioInstances = new List<AudioInstance>();
        private ObjectPool<PoolType, AudioInstance> _objectPool = new ObjectPool<PoolType, AudioInstance>();
        private HashSet<AudioData> _audioDatas = new HashSet<AudioData>();
        private uint _eventId;
        private uint _bgmPlayId;
        private bool _isUpdateListenerCamera;
        private float _duration;
        public UnityAction<uint> onFinishBgm;
        private int _configVoice = -1;

        private const uint STOP_DEFAULT_SE = 0;
        private const uint STOP_DEFAULT_VOICE = 0;

        public float duration { get => _duration; }

        private void OnDestroy()
        {
            // Empty
        }

        private IEnumerator Start()
        {
            _configVoice = -1;
            ConfigWork.onValueChanged += OnSettingValueChanged;

            _prefab.SetActive(true);
            _objectPool.Instantiates(_poolCounts[0], PoolType.Se, _prefab, transform);
            _objectPool.Instantiates(_poolCounts[1], PoolType.Voice, _prefab, transform);
            _prefab.SetActive(false);

            uint systemSoundID = AkSoundEngine.GetIDFromString("System");
            AkSoundEngine.SetOutputVolume(systemSoundID, 1.0f);

            uint[] volumeParamIds = { 0x8D5E4BB2, 0xD2D1DC50, 0xD4FFB03E };
            for (int i = 0; i < _listenerRoot.childCount; i++)
            {
                ListenerParam listenerParam = new ListenerParam();

                listenerParam._listener = _listenerRoot.GetChild(i).GetComponent<AkAudioListener>();
                listenerParam._volumes = new float[Enum.GetNames(typeof(VolumeType)).Length];
                for (int j = 0; j < listenerParam._volumes.Length; j++)
                    listenerParam._volumes[j] = 1.0f;

                listenerParam._isMute = false;
                listenerParam._volumeParamId = volumeParamIds[i];

                _listenerParams.Add(listenerParam);
            }

            LoadParam loadParam = new LoadParam() { bankName = _commonBankName };
            Load(loadParam, _ => PlayBgm());

            yield return null;
        }

        private void OnSettingValueChanged(ConfigID configId, int value)
        {
            switch (configId)
            {
                case ConfigID.BgmVolume:
                    Instance._listenerParams[(int)ListenerType.Bgm]._volumes[0] = value / 10.0f;
                    Instance.SetVolumeInternal(ListenerType.Bgm);
                    break;
                case ConfigID.SeVolume:
                    Instance._listenerParams[(int)ListenerType.Se]._volumes[0] = value / 10.0f;
                    Instance.SetVolumeInternal(ListenerType.Se);
                    break;
                case ConfigID.VoiceVolume:
                    Instance._listenerParams[(int)ListenerType.Voice]._volumes[0] = value / 10.0f;
                    Instance.SetVolumeInternal(ListenerType.Voice);
                    _configVoice = value;
                    break;
            }
        }

        public float GetVolume(ListenerType type, VolumeType volumeType = VolumeType.Normal)
        {
            return _listenerParams[(int)type]._volumes[(int)volumeType];
        }

        public void SetVolume(ListenerType type, float volume, VolumeType volumeType = VolumeType.Normal)
        {
            _listenerParams[(int)type]._volumes[(int)volumeType] = volume;
            SetVolumeInternal(type);
        }

        private void SetVolumeInternal(ListenerType type)
        {
            if (type == ListenerType.Bgm)
            {
                AkSoundEngine.SetGameObjectOutputBusVolume(gameObject, _listenerParams[(int)type]._listener.gameObject, 1.0f);
            }
            else
            {
                foreach (var instance in _audioInstances)
                {
                    if (instance.listenerType == type)
                        _SetInstanceVolume(instance);
                }
            }

            float volume = 1.0f;
            for (int i=0; i<_listenerParams[(int)type]._volumes.Length; i++)
            {
                volume *= _listenerParams[(int)type]._volumes[i];
            }

            volume = Mathf.Lerp(-48.0f, 12.0f, volume);

            AkSoundEngine.SetRTPCValue(_listenerParams[(int)type]._volumeParamId, volume, null);
        }

        internal void _SetInstanceVolume(AudioInstance instance)
        {
            if (instance.listenerType == ListenerType.Voice)
            {
                if (_configVoice > -1)
                {
                    float rtpcValue = _configVoice == 0 ? -96.0f : 0.0f;
                    AkSoundEngine.SetRTPCValue(0xabdb81b, rtpcValue, null);
                }
            }

            AkSoundEngine.SetGameObjectOutputBusVolume(instance.akGameObj.gameObject, _listenerParams[(int)instance.listenerType]._listener.gameObject, instance.GetVolume());
        }

        public bool IsMute(ListenerType type)
        {
            return _listenerParams[(int)type]._isMute;
        }

        public void EnableMute(ListenerType type, bool isMute)
        {
            if (type == ListenerType.Bgm && isMute)
                PostEventInternal(0x4eaf83c9, 0x100009, false);
            else if (type == ListenerType.Bgm && !isMute)
                PostEventInternal(0x7999c78, 0x100009, false);
            else if (type != ListenerType.Bgm && isMute)
                PostEventInternal(0x7e2c5bad, 0x100009, false);
            else if (type != ListenerType.Bgm && !isMute)
                PostEventInternal(0xce42fd56, 0x100009, false);
        }

        public void Load(LoadParam loadParam, UnityAction<AudioData> onLoaded)
        {
            uint bankId = AkSoundEngine.GetIDFromString(loadParam.bankName);
            AudioData foundAudioData = FindAudioData(bankId);
            if (foundAudioData == null)
            {
                AudioData newAudioData = new AudioData();
                newAudioData._bankName = loadParam.bankName;
                newAudioData._loadState = AudioData.LoadState.Loading;
                _audioDatas.Add(newAudioData);

                AkSoundEngine.LoadBank(newAudioData._bankName,
                    (bankId_, bankPtr, result, data) =>
                    {
                        var audioData = data as AudioData;
                        audioData._bankId = bankId_;
                        audioData._loadState = AudioData.LoadState.Loaded;
                        if (onLoaded != null)
                            onLoaded(audioData);
                    },
                newAudioData, out _);
            }
            else
            {
                foundAudioData.AddRef();
                StartCoroutine(OpWaitLoad(foundAudioData, onLoaded));
            }
        }

        private IEnumerator OpWaitLoad(AudioData audioData, UnityAction<AudioData> onLoaded)
        {
            while (audioData._bankId == 0)
            {
                yield return null;
            }
            onLoaded(audioData);
        }

        internal static void _Unload(AudioData audioData)
        {
            if (_instance != null)
            {
                _instance._audioDatas.Remove(audioData);
            }
        }

        public AudioData FindAudioData(string bankName)
        {
            return FindAudioData(AkSoundEngine.GetIDFromString(bankName));
        }

        public AudioData FindAudioData(uint bankId)
        {
            return _audioDatas.FirstOrDefault(x => x._bankId == bankId);
        }

        public void PlayBgm()
        {
            // Not sure why this is done
            _listenerParams[(int)ListenerType.Bgm]._volumes[1] = _listenerParams[(int)ListenerType.Bgm]._volumes[1];
            
            SetVolumeInternal(ListenerType.Bgm);
            _bgmPlayId = PostEventInternal(0xba5ea5ec, 0x100009, false);
        }

        public void StopBgm()
        {
            PostEventInternal(0x3ffbcd36, 0x100009, false);
            _bgmPlayId = 0;
        }

        public void SetBgmEvent(string eventName, bool isThroughSameEvent = false)
        {
            SetBgmEvent(AkSoundEngine.GetIDFromString(eventName), isThroughSameEvent);
        }

        public void SetBgmEvent(uint eventId, bool isThroughSameEvent = false)
        {
            PostEventInternal(eventId, 0x100009, isThroughSameEvent);
        }

        public void SetBgmState(string stateName)
        {
            // Empty
        }

        public uint GetIdByName(string name)
        {
            return AkSoundEngine.GetIDFromString(name);
        }

        public AudioInstance PlaySe(uint playEventId, [Optional] UnityAction<AudioInstance> onFinished)
        {
            return PlaySe(playEventId, STOP_DEFAULT_SE, onFinished);
        }

        public AudioInstance PlaySe(uint playEventId, uint stopEventId, [Optional] UnityAction<AudioInstance> onFinished)
        {
            return CreateSe(playEventId, stopEventId).Play(onFinished, false);
        }

        public AudioInstance CreateSe(uint playEventId, uint stopEventId = STOP_DEFAULT_SE)
        {
            return CreateSe(playEventId, stopEventId, Vector3.zero, Quaternion.identity, null);
        }

        public AudioInstance CreateSe(uint playEventId, uint stopEventId, Vector3 position, Quaternion rotation, [Optional] Transform attachedTransform)
        {
            return CreateInstance(ListenerType.Se, playEventId, stopEventId, position, rotation, attachedTransform);
        }

        public AudioInstance PlayVoice(uint playEventId, [Optional] UnityAction<AudioInstance> onFinished)
        {
            return PlayVoice(playEventId, STOP_DEFAULT_VOICE, null, onFinished);
        }

        public AudioInstance PlayVoice(uint playEventId, uint stopEventId, [Optional] UnityAction<AudioInstance> onFinished)
        {
            return PlayVoice(playEventId, stopEventId, null, onFinished);
        }

        public AudioInstance PlayVoice(uint playEventId, uint stopEventId, Transform t, [Optional] UnityAction<AudioInstance> onFinished)
        {
            return CreateVoice(playEventId, stopEventId, Vector3.zero, Quaternion.identity, t).Play(onFinished, false);
        }

        public AudioInstance CreateVoice(uint playEventId, uint stopEventId = STOP_DEFAULT_VOICE)
        {
            return CreateVoice(playEventId, stopEventId, Vector3.zero, Quaternion.identity, null);
        }

        public AudioInstance CreateVoice(uint playEventId, uint stopEventId, Vector3 position, Quaternion rotation, [Optional] Transform attachedTransform)
        {
            return CreateInstance(ListenerType.Voice, playEventId, stopEventId, position, rotation, attachedTransform);
        }

        private AudioInstance CreateInstance(ListenerType listenerType, uint playEventId, uint stopEventId, Vector3 position, Quaternion rotation, [Optional] Transform attachedTransform)
        {
            AudioInstance audioInstance = _objectPool.Create((PoolType)listenerType, false);
            _audioInstances.Add(audioInstance);
            audioInstance._Setup(ListenerType.Voice, playEventId, stopEventId, position, rotation, attachedTransform);
            return audioInstance;
        }

        public uint GetCurrentStateId(uint groupId)
        {
            AkSoundEngine.GetState(groupId, out uint rState);
            return rState;
        }

        public Vector3 GetListenerPosition()
        {
            return _listenerRoot.transform.position;
        }

        public void SetListenerPosition(Vector3 pos)
        {
            _listenerRoot.transform.position = pos;
        }

        public Quaternion GetListenerRotation()
        {
            return _listenerRoot.transform.rotation;
        }

        public void SetListenerRotation(Quaternion rotation)
        {
            _listenerRoot.transform.rotation = rotation;
        }

        public float GetBgmPlayPosition()
        {
            if (_bgmPlayId != 0)
            {
                AkSoundEngine.GetSourcePlayPosition(_bgmPlayId, out int puPosition);
                return puPosition / 1000.0f;
            }

            return 0.0f;
        }

        internal void _RemoveInstance(AudioInstance instance)
        {
            if (_audioInstances.Remove(instance))
            {
                _objectPool.Release((PoolType)instance.listenerType, instance, false);
            }
        }

        public uint PostEvent(uint eventId, uint callbackFlags = 0x100009, bool isThroughSameEvent = false)
        {
            return PostEventInternal(eventId, callbackFlags, isThroughSameEvent);
        }

        private uint PostEventInternal(uint eventId, uint callbackFlags, bool isThroughSameEvent)
        {
            if (!isThroughSameEvent || _eventId != eventId)
            {
                _eventId = eventId;
                //return AkSoundEngine.PostEvent(eventId, gameObject, callbackFlags, OnPostEvent, eventId);
                return 0;
            }
            else
            {
                return 0;
            }
        }

        private static void OnPostEvent(object in_cookie, AkCallbackType in_type, AkCallbackInfo in_info)
        {
            if (in_type == AkCallbackType.AK_EndOfEvent)
            {
                if (Instance != null && Instance.onFinishBgm != null)
                    Instance.onFinishBgm((in_info as AkEventCallbackInfo).eventID);
            }
            else if (in_type == AkCallbackType.AK_Duration)
            {
                Instance._duration = (in_info as AkDurationCallbackInfo).fEstimatedDuration / 1000.0f;
            }
        }

        public uint RePostEvent(uint eventId, uint callbackFlags = 0x100009)
        {
            return RePostEventInternal(eventId, callbackFlags);
        }

        private uint RePostEventInternal(uint eventId, uint callbackFlags)
        {
            _eventId = eventId;
            //return AkSoundEngine.PostEvent(eventId, gameObject, callbackFlags, OnPostEvent, eventId);
            return 0;
        }

        private void LateUpdate()
        {
            UpdateListenerByMainCamera();
            foreach (var instance in _audioInstances)
                instance._Update();
        }

        public void EnableUpdateListenerByMainCamera(bool enabled)
        {
            _isUpdateListenerCamera = enabled;
        }

        public bool IsEnableUpdateListenerByMainCamera()
        {
            return _isUpdateListenerCamera;
        }

        private void UpdateListenerByMainCamera()
        {
            if (_isUpdateListenerCamera)
            {
                if (Camera.main != null)
                {
                    _listenerRoot.gameObject.transform.position = Camera.main.transform.position;
                    _listenerRoot.gameObject.transform.rotation = Camera.main.transform.rotation;
                }
            }
        }

        public float GetRTPCValue(uint gameParamId)
        {
            int rValueType = 1;
            AkSoundEngine.GetRTPCValue(gameParamId, null, 0, out float rValue, ref rValueType);
            return rValue;
        }

        public void SetRTPCValue(uint gameParamId, float value)
        {
            AkSoundEngine.SetRTPCValue(gameParamId, value, null);
        }

        public void CreateVoiceRTPCDatas()
        {
            // Empty
        }

        public enum ListenerType : int
        {
            Bgm = 0,
            Se = 1,
            Voice = 2,
        }

        public enum VolumeType : int
        {
            Config = 0,
            Normal = 1,
        }

        private class ListenerParam
        {
            public AkAudioListener _listener;
            public float[] _volumes;
            public bool _isMute;
            public uint _volumeParamId;

            public float GetVolume()
            {
                if (_volumes.Length < 1)
                    return 1.0f;

                float result = 1.0f;
                foreach (float volume in _volumes)
                    result += volume;

                return result;
            }
        }

        private enum PoolType : int
        {
            Se = 1,
            Voice = 2,
        }

        public struct LoadParam
        {
	        public string bankName;
        }
    }
}